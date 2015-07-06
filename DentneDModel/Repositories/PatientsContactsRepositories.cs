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
    public class PatientsContactsRepository : GenericDataRepository<patientscontacts, DentneDModel>
    {
        public PatientsContactsRepository() : base() { }

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params patientscontacts[] items)
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
        public override bool CanUpdate(ref string[] errors, params patientscontacts[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params patientscontacts[] items)
        {
            bool ret = true;

            foreach (patientscontacts item in items)
            {
                if (String.IsNullOrEmpty(item.patientscontacts_value))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Contact can not be empty." }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Patients.Find(item.patients_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Patient is mandatory." }).ToArray();
                }
                if (BaseModel.ContactsTypes.Find(item.contactstypes_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Contact type is mandatory." }).ToArray();
                }

                if (!ret)
                    break;
            }

            return ret;
        }
    }

}

