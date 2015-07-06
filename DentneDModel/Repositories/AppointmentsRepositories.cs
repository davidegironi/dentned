#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System.Linq;
using DG.Data.Model;
using DG.DentneD.Model.Entity;
using System;

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
                    errors = errors.Concat(new string[] { "Title can not be empty." }).ToArray();
                }

                if (!ret)
                    break;

                if (item.appointments_from >= item.appointments_to)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "End date can not be greater than start date." }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Patients.Find(item.patients_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Patient is mandatory." }).ToArray();
                }
                if (BaseModel.Doctors.Find(item.doctors_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Doctors is mandatory." }).ToArray();
                }
                if (BaseModel.Rooms.Find(item.rooms_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Room is mandatory." }).ToArray();
                }
                if (!ret)
                    break;

                if (_checkAppointmentsTimeOverride)
                {
                    if (!isUpdate)
                    {
                        if (List(r => r.rooms_id == item.rooms_id &&
                                ((r.appointments_from <= item.appointments_to && r.appointments_from >= item.appointments_from) ||
                                (r.appointments_from <= item.appointments_from && r.appointments_to >= item.appointments_to) ||
                                (r.appointments_to >= item.appointments_from && r.appointments_to <= item.appointments_to) ||
                                (r.appointments_from >= item.appointments_from && r.appointments_to <= item.appointments_to))).Count() > 0 ||
                            List(r => r.doctors_id == item.doctors_id &&
                                ((r.appointments_from <= item.appointments_to && r.appointments_from >= item.appointments_from) ||
                                (r.appointments_from <= item.appointments_from && r.appointments_to >= item.appointments_to) ||
                                (r.appointments_to >= item.appointments_from && r.appointments_to <= item.appointments_to) ||
                                (r.appointments_from >= item.appointments_from && r.appointments_to <= item.appointments_to))).Count() > 0 ||
                            List(r => r.patients_id == item.patients_id &&
                                ((r.appointments_from <= item.appointments_to && r.appointments_from >= item.appointments_from) ||
                                (r.appointments_from <= item.appointments_from && r.appointments_to >= item.appointments_to) ||
                                (r.appointments_to >= item.appointments_from && r.appointments_to <= item.appointments_to) ||
                                (r.appointments_from >= item.appointments_from && r.appointments_to <= item.appointments_to))).Count() > 0)
                        {
                            ret = false;
                            errors = errors.Concat(new string[] { "Appointment already inserted." }).ToArray();
                        }
                    }
                    else
                    {
                        if (List(r => r.appointments_id != item.appointments_id && r.rooms_id == item.rooms_id &&
                                ((r.appointments_from <= item.appointments_to && r.appointments_from >= item.appointments_from) ||
                                (r.appointments_from <= item.appointments_from && r.appointments_to >= item.appointments_to) ||
                                (r.appointments_to >= item.appointments_from && r.appointments_to <= item.appointments_to) ||
                                (r.appointments_from >= item.appointments_from && r.appointments_to <= item.appointments_to))).Count() > 0 ||
                            List(r => r.appointments_id != item.appointments_id && r.doctors_id == item.doctors_id &&
                                ((r.appointments_from <= item.appointments_to && r.appointments_from >= item.appointments_from) ||
                                (r.appointments_from <= item.appointments_from && r.appointments_to >= item.appointments_to) ||
                                (r.appointments_to >= item.appointments_from && r.appointments_to <= item.appointments_to) ||
                                (r.appointments_from >= item.appointments_from && r.appointments_to <= item.appointments_to))).Count() > 0 ||
                            List(r => r.appointments_id != item.appointments_id && r.patients_id == item.patients_id &&
                                ((r.appointments_from <= item.appointments_to && r.appointments_from >= item.appointments_from) ||
                                (r.appointments_from <= item.appointments_from && r.appointments_to >= item.appointments_to) ||
                                (r.appointments_to >= item.appointments_from && r.appointments_to <= item.appointments_to) ||
                                (r.appointments_from >= item.appointments_from && r.appointments_to <= item.appointments_to))).Count() > 0)
                        {
                            ret = false;
                            errors = errors.Concat(new string[] { "Appointment already inserted." }).ToArray();
                        }
                    }

                    if (!ret)
                        break;
                }
            }

            return ret;
        }
    }

}

