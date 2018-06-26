#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model;
using DG.DentneD.Model.Entity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;

namespace DG.DentneD.Model.Repositories
{
    public class AppointmentsRepository : GenericDataRepository<appointments, DentneDModel>
    {
        public AppointmentsRepository() : base() { }

        /// <summary>
        /// Check for time override
        /// </summary>
        private bool _checkAppointmentsTimeOverride = false;

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Title can not be empty.";
            public string text002 = "End date can not be greater than start date.";
            public string text003 = "Patient is mandatory.";
            public string text004 = "Doctors is mandatory.";
            public string text005 = "Room is mandatory.";
            public string text006 = "Appointment already inserted.";
            public string text007 = "Invalid color.";
        }

        /// <summary>
        /// Repository language
        /// </summary>
        public RepositoryLanguage language = new RepositoryLanguage();

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params appointments[] items)
        {
            errors = new string[] { };

            bool ret = Validate(false, ref errors, items);
            if (!ret)
                return ret;

            ret = base.CanAdd(ref errors, items);

            return ret;
        }

        /// <summary>
        /// Check if an item can be updated
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanUpdate(ref string[] errors, params appointments[] items)
        {
            errors = new string[] { };

            bool ret = Validate(true, ref errors, items);
            if (!ret)
                return ret;

            ret = base.CanUpdate(ref errors, items);

            return ret;
        }

        /// <summary>
        /// Validate an item
        /// </summary>
        /// <param name="isUpdate"></param>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        private bool Validate(bool isUpdate, ref string[] errors, params appointments[] items)
        {
            bool ret = true;

            foreach (appointments item in items)
            {
                if (String.IsNullOrEmpty(item.appointments_title))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }

                if (!ret)
                    break;

                if (item.appointments_from >= item.appointments_to)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }

                if (!ret)
                    break;

                if (!String.IsNullOrEmpty(item.appointments_color) && !Regex.Match(item.appointments_color, @"^#(?:[0-9a-fA-F]{3}){2}$").Success)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text007 }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Patients.Find(item.patients_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }
                if (BaseModel.Doctors.Find(item.doctors_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text004 }).ToArray();
                }
                if (BaseModel.Rooms.Find(item.rooms_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text005 }).ToArray();
                }
                if (!ret)
                    break;

                if (_checkAppointmentsTimeOverride)
                {
                    if (!isUpdate)
                    {
                        if (Any(r => r.rooms_id == item.rooms_id &&
                                ((r.appointments_from <= item.appointments_to && r.appointments_from >= item.appointments_from) ||
                                (r.appointments_from <= item.appointments_from && r.appointments_to >= item.appointments_to) ||
                                (r.appointments_to >= item.appointments_from && r.appointments_to <= item.appointments_to) ||
                                (r.appointments_from >= item.appointments_from && r.appointments_to <= item.appointments_to))) ||
                            Any(r => r.doctors_id == item.doctors_id &&
                                ((r.appointments_from <= item.appointments_to && r.appointments_from >= item.appointments_from) ||
                                (r.appointments_from <= item.appointments_from && r.appointments_to >= item.appointments_to) ||
                                (r.appointments_to >= item.appointments_from && r.appointments_to <= item.appointments_to) ||
                                (r.appointments_from >= item.appointments_from && r.appointments_to <= item.appointments_to))) ||
                            Any(r => r.patients_id == item.patients_id &&
                                ((r.appointments_from <= item.appointments_to && r.appointments_from >= item.appointments_from) ||
                                (r.appointments_from <= item.appointments_from && r.appointments_to >= item.appointments_to) ||
                                (r.appointments_to >= item.appointments_from && r.appointments_to <= item.appointments_to) ||
                                (r.appointments_from >= item.appointments_from && r.appointments_to <= item.appointments_to))))
                        {
                            ret = false;
                            errors = errors.Concat(new string[] { language.text006 }).ToArray();
                        }
                    }
                    else
                    {
                        if (Any(r => r.appointments_id != item.appointments_id && r.rooms_id == item.rooms_id &&
                                ((r.appointments_from <= item.appointments_to && r.appointments_from >= item.appointments_from) ||
                                (r.appointments_from <= item.appointments_from && r.appointments_to >= item.appointments_to) ||
                                (r.appointments_to >= item.appointments_from && r.appointments_to <= item.appointments_to) ||
                                (r.appointments_from >= item.appointments_from && r.appointments_to <= item.appointments_to))) ||
                            Any(r => r.appointments_id != item.appointments_id && r.doctors_id == item.doctors_id &&
                                ((r.appointments_from <= item.appointments_to && r.appointments_from >= item.appointments_from) ||
                                (r.appointments_from <= item.appointments_from && r.appointments_to >= item.appointments_to) ||
                                (r.appointments_to >= item.appointments_from && r.appointments_to <= item.appointments_to) ||
                                (r.appointments_from >= item.appointments_from && r.appointments_to <= item.appointments_to))) ||
                            Any(r => r.appointments_id != item.appointments_id && r.patients_id == item.patients_id &&
                                ((r.appointments_from <= item.appointments_to && r.appointments_from >= item.appointments_from) ||
                                (r.appointments_from <= item.appointments_from && r.appointments_to >= item.appointments_to) ||
                                (r.appointments_to >= item.appointments_from && r.appointments_to <= item.appointments_to) ||
                                (r.appointments_from >= item.appointments_from && r.appointments_to <= item.appointments_to))))
                        {
                            ret = false;
                            errors = errors.Concat(new string[] { language.text006 }).ToArray();
                        }
                    }

                    if (!ret)
                        break;
                }
            }

            return ret;
        }


        /// <summary>
        /// Purge appointments older than days
        /// </summary>
        /// <param name="days"></param>
        /// <param name="purgedAppintments"></param>
        public void Purge(int days, ref int purgedAppintments)
        {
            purgedAppintments = 0;

            if (days >= 0)
                return;

            DateTime dayback = DateTime.Now.AddDays(days);
            appointments[] appointmentsToDeletes = List(r => DbFunctions.TruncateTime(r.appointments_from) <= DbFunctions.TruncateTime(dayback)).ToArray();

            purgedAppintments = appointmentsToDeletes.Count();

            Remove(appointmentsToDeletes);
        }
    }

}

