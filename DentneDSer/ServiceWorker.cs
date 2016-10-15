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

namespace DG.DentneD.Service
{
    public partial class ServiceWorker
    {
        private log4net.ILog log = null;

        private bool runactions = false;

        private Mailer _mailer = null;
        private const string MailerSubjectPrefix = "[DentnetDSer] ";

        private DentneDModel _dentnedModel = null;

        private string language = "en";
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

        public ServiceWorker()
        {
            //load main configuration file
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
#if DEBUG
            configMap.ExeConfigFilename = @"..\..\..\DentneD\bin\Debug\DentneD.exe.config";
#else
            configMap.ExeConfigFilename = @"DentneD.exe.config";
#endif
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            //set current working directory and load logger files
            Directory.SetCurrentDirectory(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            log4net.Config.XmlConfigurator.Configure(new FileInfo("Config.log4net"));
            log = log4net.LogManager.GetLogger("MainLogger");

            //set if run at startup enabled
#if DEBUG
            runactions = true;
#endif

            //load language
            language = config.AppSettings.Settings["language"].Value;

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
            _mailer = new Mailer(mailerSMTPhost, mailerSMTPport, mailerSMTPfrom, mailerSMTPusername, mailerSMTPpassword, mailerSMTPenablessl, MailerSubjectPrefix);

            //load connection string
            Configuration actualConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            actualConfig.ConnectionStrings.ConnectionStrings["dentnedEntities"].ConnectionString = config.ConnectionStrings.ConnectionStrings["dentnedEntities"].ConnectionString;
            actualConfig.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");

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
