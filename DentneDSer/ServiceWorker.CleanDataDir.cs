#region License
// Copyright (c) 2016 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Helpers;
using System;
using System.Configuration;

namespace DG.DentneD.Service
{
    public partial class ServiceWorker
    {
        private bool cleanDataDirEnabled = false;
        private string cleanDataDirCronTab = "* * * * *";
        private DateTime cleanDataDirNextOccurrence = DateTime.Now;

        /// <summary>
        /// Load parameters
        /// </summary>
        private void CleanDataDirLoad()
        {
            cleanDataDirEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["cleanDataDirEnabled"]);
            cleanDataDirCronTab = ConfigurationManager.AppSettings["cleanDataDirCronTab"];
            cleanDataDirNextOccurrence = DateTime.Now;
        }

        /// <summary>
        /// Runner check
        /// </summary>
        private void CleanDataDirDo()
        {
            DoCrontabRunner(CleanDataDir, cleanDataDirEnabled, cleanDataDirCronTab, ref cleanDataDirNextOccurrence);
        }

        /// <summary>
        /// Clean data dirs
        /// </summary>
        private void CleanDataDir()
        {
            try
            {
                string[] messages = new string[] { };
                string[] errors = new string[] { };

                //clean the patient datadir
                log.Info("Cleaning Patient Data folder \"" + patientsDatadir + "\"...");
                CleanDir.CleanPatientDir(patientsDatadir, doSecureDelete, ref messages, ref errors);
                foreach (string message in messages)
                    log.Info("  " + message);
                foreach (string error in errors)
                    log.Error("  " + error);

                //clean the patient attachment dir
                log.Info("Cleaning Patient Attachments folder \"" + patientsAttachmentsdir + "\"...");
                CleanDir.CleanPatientAttachmentsDir(patientsAttachmentsdir, doSecureDelete, ref messages, ref errors);
                foreach (string message in messages)
                    Console.WriteLine("  " + message);
                foreach (string error in errors)
                    Console.WriteLine("  " + error);
            }
            catch
            {
                log.Error("Exception happened running CleanDataDir");
            }
        }
    }
}
