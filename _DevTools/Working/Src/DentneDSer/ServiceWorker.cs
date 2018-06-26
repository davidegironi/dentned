#region License
// Copyright (c) 2016 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Helpers;
using DG.DentneD.Model;
using NCrontab;
using System;
using System.Configuration;
using System.IO;
using System.Web.Script.Serialization;

namespace DG.DentneD.Service
{
    public partial class ServiceWorker
    {
        private log4net.ILog log = null;

        private bool runactions = false;

        private Mailer _mailer = null;

        private DentneDModel _dentnedModel = null;

        private DentneDSerLanguage language = new DentneDSerLanguage();
        private const string LanguageFilenamePrefix = "DentneDSer-";
        private string languageFolder = "lang";

        private readonly string tmpdir = "";
        private readonly string patientsDatadir = "";
        private readonly string patientsAttachmentsdir = "";
        private readonly bool doSecureDelete = false;

        private readonly string mailerSMTPhost = "";
        private readonly int mailerSMTPport = 587;
        private readonly string mailerSMTPfrom = "";
        private readonly string mailerSMTPusername = "";
        private readonly string mailerSMTPpassword = "";
        private readonly bool mailerSMTPenablessl = false;

        /// <summary>
        /// Language definitions
        /// </summary>
        private class DentneDSerLanguage
        {
            public string dateFormat = "yyyy/MM/dd";
            public string timeFormat = "HH:mm";
            public string sendAppointmentsReminderSubject = "Appointment reminder from Dental Clinic";
            public string sendAppointmentsReminderBody = "Dear <b>%NAME%</b><br/><br/>This is a reminder that you have an appoinment with us on <b>%DATE%</b> at <b>%TIME%</b>.<br/><br/>Thank you,<br/><b>Dental Clinic</b><br/><br/><br/><small>This message is a PRIVATE communication. This message and all attachments are a private communication and may be confidential or protected by privilege. If you are not the intended recipient, you are hereby notified that any disclosure, copying, distribution or use of the information contained in or attached to this message is strictly prohibited. Please notify the sender of the delivery error by replying to this message, and then delete it from your system. Thank you.</small>";
        }

        /// <summary>
        /// main service worker
        /// </summary>
        public ServiceWorker()
        {
            //set current working directory and load logger files
            Directory.SetCurrentDirectory(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (File.Exists("Config.log4net"))
                log4net.Config.XmlConfigurator.Configure(new FileInfo("Config.log4net"));
            else
                throw new Exception("Can not load log4net configuration file.");
            log = log4net.LogManager.GetLogger("MainLogger");

            //start message
            log.Info("Service is starting...");

            //load main configuration file
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
#if DEBUG
            if (File.Exists("DentneD.exe.config"))
                configMap.ExeConfigFilename = "DentneD.exe.config";
            else
            {
                if (File.Exists("..\\..\\..\\DentneD\\bin\\Debug\\DentneD.exe.config"))
                    configMap.ExeConfigFilename = "..\\..\\..\\DentneD\\bin\\Debug\\DentneD.exe.config";
                else
                    throw new Exception("Can not load configuration file.");
            }
#else
            if (File.Exists("DentneD.exe.config"))
                configMap.ExeConfigFilename = "DentneD.exe.config";
            else
                throw new Exception("Can not load configuration file.");
#endif
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            //set if run at startup enabled
#if DEBUG
            runactions = true;
#endif

            //load folder preferences
            tmpdir = config.AppSettings.Settings["tmpdir"].Value;
            patientsDatadir = config.AppSettings.Settings["patientsDatadir"].Value;
            patientsAttachmentsdir = config.AppSettings.Settings["patientsAttachmentsdir"].Value;
            doSecureDelete = Convert.ToBoolean(config.AppSettings.Settings["doSecureDelete"].Value);

            //load mailer preferences
            mailerSMTPhost = config.AppSettings.Settings["mailerSMTPhost"].Value;
            mailerSMTPport = Convert.ToInt16(config.AppSettings.Settings["mailerSMTPport"].Value);
            mailerSMTPfrom = config.AppSettings.Settings["mailerSMTPfrom"].Value;
            mailerSMTPusername = config.AppSettings.Settings["mailerSMTPusername"].Value;
            mailerSMTPpassword = config.AppSettings.Settings["mailerSMTPpassword"].Value;
            mailerSMTPenablessl = Convert.ToBoolean(config.AppSettings.Settings["mailerSMTPenablessl"].Value);

            //set mailer
            _mailer = new Mailer(mailerSMTPhost, mailerSMTPport, mailerSMTPfrom, mailerSMTPusername, mailerSMTPpassword, mailerSMTPenablessl);

            //load language
            if (!String.IsNullOrEmpty(languageFolder + "\\" + LanguageFilenamePrefix + config.AppSettings.Settings["language"].Value + ".json"))
            {
                try
                {
                    string jsontext = null;
#if DEBUG
                    if (File.Exists(languageFolder + "\\" + LanguageFilenamePrefix + config.AppSettings.Settings["language"].Value + ".json"))
                        jsontext = File.ReadAllText(languageFolder + "\\" + LanguageFilenamePrefix + config.AppSettings.Settings["language"].Value + ".json");
                    else
                    {
                        if (File.Exists("..\\..\\..\\DentneD\\bin\\Debug\\" + languageFolder + "\\" + LanguageFilenamePrefix + config.AppSettings.Settings["language"].Value + ".json"))
                            jsontext = File.ReadAllText("..\\..\\..\\DentneD\\bin\\Debug\\" + languageFolder + "\\" + LanguageFilenamePrefix + config.AppSettings.Settings["language"].Value + ".json");
                    }
#else
                    if (File.Exists(languageFolder + "\\" + LanguageFilenamePrefix + config.AppSettings.Settings["language"].Value + ".json"))
                        jsontext = File.ReadAllText(languageFolder + "\\" + LanguageFilenamePrefix + config.AppSettings.Settings["language"].Value + ".json");
#endif
                    language = new JavaScriptSerializer().Deserialize<DentneDSerLanguage>(jsontext);
                }
                catch { }
            }

            //load data model
            _dentnedModel = new DentneDModel();
            _dentnedModel.LanguageHelper.LoadFromFile(languageFolder + "\\" + language + ".json");

            //load services runner paramenters
            SendAppointmentsReminderLoad();
            PurgeAppointmentsLoad();
            CleanTmpdirLoad();
            CleanDataDirLoad();
        }

        /// <summary>
        /// Main worker method
        /// </summary>
        public void Do()
        {
            //run services runner paramenters
            SendAppointmentsReminderDo();
            PurgeAppointmentsDo();
            CleanTmpdirDo();
            CleanDataDirDo();

            //run actions after first startup
            if (!runactions)
                runactions = true;
        }

        /// <summary>
        /// Generic crontab runner
        /// </summary>
        /// <param name="wrokerAction"></param>
        /// <param name="workerEnabled"></param>
        /// <param name="workerCronTab"></param>
        /// <param name="workerNextOccurence"></param>
        private void DoCrontabRunner(Action wrokerAction, bool workerEnabled, string workerCronTab, ref DateTime workerNextOccurence)
        {
            if (workerEnabled)
            {
                if (workerNextOccurence < DateTime.Now || workerNextOccurence == null)
                {
                    CrontabSchedule c = CrontabSchedule.Parse(workerCronTab);
                    workerNextOccurence = c.GetNextOccurrence(DateTime.Now, DateTime.Now.AddYears(1));
                    if (runactions)
                        wrokerAction();
                }
            }
        }
    }
}
