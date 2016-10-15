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
        private bool sendAppointmentsReminderEnabled = false;
        private string sendAppointmentsReminderCronTab = "* * * * *";
        private DateTime sendAppointmentsReminderNextOccurrence = DateTime.Now;

        /// <summary>
        /// Load parameters
        /// </summary>
        private void SendAppointmentsReminderLoad()
        {
            sendAppointmentsReminderEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["sendAppointmentsReminderEnabled"]);
            sendAppointmentsReminderCronTab = ConfigurationManager.AppSettings["sendAppointmentsReminderCronTab"];
            sendAppointmentsReminderNextOccurrence = DateTime.Now;
        }

        /// <summary>
        /// Runner check
        /// </summary>
        private void SendAppointmentsReminderDo()
        {
            DoCrontabRunner(SendAppointmentsReminder, sendAppointmentsReminderEnabled, sendAppointmentsReminderCronTab, ref sendAppointmentsReminderNextOccurrence);
        }

        /// <summary>
        /// Send appointments reminder
        /// </summary>
        private void SendAppointmentsReminder()
        {

        }
    }
}
