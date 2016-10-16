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
        private bool cleanTmpdirEnabled = false;
        private string cleanTmpdirCronTab = "* * * * *";
        private DateTime cleanTmpdirNextOccurrence = DateTime.Now;

        /// <summary>
        /// Load parameters
        /// </summary>
        private void CleanTmpdirLoad()
        {
            cleanTmpdirEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["cleanTmpdirEnabled"]);
            cleanTmpdirCronTab = ConfigurationManager.AppSettings["cleanTmpdirCronTab"];
            cleanTmpdirNextOccurrence = DateTime.Now;
        }

        /// <summary>
        /// Runner check
        /// </summary>
        private void CleanTmpdirDo()
        {
            DoCrontabRunner(CleanTmpdir, cleanTmpdirEnabled, cleanTmpdirCronTab, ref cleanTmpdirNextOccurrence);
        }

        /// <summary>
        /// Clean temporary folder
        /// </summary>
        private void CleanTmpdir()
        {
            try
            {
                string[] messages = new string[] { };
                string[] errors = new string[] { };

                //clean the tmpdir
                log.Info("Cleaning Temporary folder \"" + tmpdir + "\"...");
                CleanDir.CleanTmpdir(tmpdir, doSecureDelete, -1, ref messages, ref errors);
                foreach (string message in messages)
                    log.Info(message);
                foreach (string error in errors)
                    log.Error(error);
            }
            catch
            {
                log.Error("Exception happened running CleanTmpdir");
            }
        }
    }
}
