#region License
// Copyright (c) 2016 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Model.Entity;
using DG.DentneD.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace DG.DentneD.Service
{
    public partial class ServiceWorker
    {
        private bool sendAppointmentsReminderEnabled = false;
        private string sendAppointmentsReminderCronTab = "* * * * *";
        private DateTime sendAppointmentsReminderNextOccurrence = DateTime.Now;
        private int sendAppointmentsDays = 2;

        private class SendAppointmentsReminderElement
        {
            public string name { get; set; }
            public string email { get; set; }
            public DateTime appointmentDate { get; set; }
        }

        /// <summary>
        /// Load parameters
        /// </summary>
        private void SendAppointmentsReminderLoad()
        {
            sendAppointmentsReminderEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["sendAppointmentsReminderEnabled"]);
            sendAppointmentsReminderCronTab = ConfigurationManager.AppSettings["sendAppointmentsReminderCronTab"];
            sendAppointmentsReminderNextOccurrence = DateTime.Now;
            sendAppointmentsDays = Convert.ToInt16(ConfigurationManager.AppSettings["sendAppointmentsDays"]);
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
            try
            {
                DateTime appointmentDate = DateTime.Now.AddDays(sendAppointmentsDays);
                DateTime appointmentDatefrom = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, 0, 0, 0);
                DateTime appointmentDateto = appointmentDatefrom.AddDays(1).AddMilliseconds(-1);

                log.Info("Sending appintments reminder for appointments of day " + appointmentDate.ToShortDateString() + "...");

                List<SendAppointmentsReminderElement> appointmentElements = new List<SendAppointmentsReminderElement>();

                //select patients with an email and with send appointments reminder enabled
                using (var context = (dentnedEntities)Activator.CreateInstance(_dentnedModel.ContextType, _dentnedModel.ContextParameters))
                {
                    appointmentElements =
                            (from patient in context.patients
                             join patientscontact in context.patientscontacts on patient.patients_id equals patientscontact.patients_id
                             join patientsattribute in context.patientsattributes on patient.patients_id equals patientsattribute.patients_id
                             join contactstype in context.contactstypes on patientscontact.contactstypes_id equals contactstype.contactstypes_id
                             join patientsattributestype in context.patientsattributestypes on patientsattribute.patientsattributestypes_id equals patientsattributestype.patientsattributestypes_id
                             join appointment in context.appointments on patient.patients_id equals appointment.patients_id
                             where
                                contactstype.contactstypes_name == ContactsTypesRepository.SystemAttributes.EMail.ToString() &&
                                patientsattributestype.patientsattributestypes_name == PatientsAttributesTypesRepository.SystemAttributes.SendAppointmentsReminder.ToString() &&
                                DbFunctions.TruncateTime(appointment.appointments_from) == DbFunctions.TruncateTime(appointmentDate)
                             select new SendAppointmentsReminderElement()
                             {
                                 name = patient.patients_name,
                                 email = patientscontact.patientscontacts_value,
                                 appointmentDate = appointment.appointments_from
                             }).Distinct().ToList();
                }

                //send emails
                foreach (SendAppointmentsReminderElement appointmentElement in appointmentElements)
                {
                    string subject = language.sendAppointmentsReminderSubject;
                    string body = language.sendAppointmentsReminderBody;
                    string email = appointmentElement.email;
                    string name = appointmentElement.name;
                    string date = String.Format("{0:" + language.dateFormat + "}", appointmentElement.appointmentDate);
                    string time = String.Format("{0:" + language.timeFormat + "}", appointmentElement.appointmentDate);
                    body = body.Replace("%NAME%", appointmentElement.name);
                    body = body.Replace("%DATE%", date);
                    body = body.Replace("%TIME%", time);

                    try
                    {
                        _mailer.SendMail(subject, body, new string[] { email }, new string[] { });
                        log.Info("Appointment reminder successfully sent to \"" + email + "\".");
                    }
                    catch
                    {
                        log.Error("Can not send the appointment reminder to \"" + email + "\".");
                    }
                }
            }
            catch
            {
                log.Error("Exception happened running SendAppointmentsReminder");
            }

        }
    }
}
