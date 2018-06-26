#region License
// Copyright (c) 2016 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.Configuration;

namespace DG.DentneD.Service
{
    public partial class ServiceWorker
    {
        private bool purgeAppointmentsEnabled = false;
        private string purgeAppointmentsCronTab = "* * * * *";
        private DateTime purgeAppointmentsNextOccurrence = DateTime.Now;
        private int purgeAppointmentsDays = -365;

        /// <summary>
        /// Load parameters
        /// </summary>
        private void PurgeAppointmentsLoad()
        {
            purgeAppointmentsEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["purgeAppointmentsEnabled"]);
            purgeAppointmentsCronTab = ConfigurationManager.AppSettings["purgeAppointmentsCronTab"];
            purgeAppointmentsNextOccurrence = DateTime.Now;
            purgeAppointmentsDays = Convert.ToInt16(ConfigurationManager.AppSettings["purgeAppointmentsDays"]);
        }

        /// <summary>
        /// Runner check
        /// </summary>
        private void PurgeAppointmentsDo()
        {
            DoCrontabRunner(PurgeAppointments, purgeAppointmentsEnabled, purgeAppointmentsCronTab, ref purgeAppointmentsNextOccurrence);
        }

        /// <summary>
        /// Purge old appointments
        /// </summary>
        private void PurgeAppointments()
        {
            try
            {
                int purgedAppointments = 0;

                //purge appointments
                log.Info("Purging appointments older than " + DateTime.Now.AddDays(purgeAppointmentsDays).ToShortDateString() + "...");
                _dentnedModel.Appointments.Purge(purgeAppointmentsDays, ref purgedAppointments);
                log.Info(purgedAppointments + " appointments were purged.");
            }
            catch
            {
                log.Error("Exception happened running PurgeAppointments");
            }
        }
    }
}
