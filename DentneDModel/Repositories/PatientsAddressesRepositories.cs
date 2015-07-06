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
    public class PatientsAddressesRepository : GenericDataRepository<patientsaddresses, DentneDModel>
    {
        public PatientsAddressesRepository() : base() { }

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params patientsaddresses[] items)
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
        public override bool CanUpdate(ref string[] errors, params patientsaddresses[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params patientsaddresses[] items)
        {
            bool ret = true;

            foreach (patientsaddresses item in items)
            {
                if (String.IsNullOrEmpty(item.patientsaddresses_state))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "State can not be empty." }).ToArray();
                }
                if (String.IsNullOrEmpty(item.patientsaddresses_city))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "City can not be empty." }).ToArray();
                }
                if (String.IsNullOrEmpty(item.patientsaddresses_zipcode))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Zip Code can not be empty." }).ToArray();
                }
                if (String.IsNullOrEmpty(item.patientsaddresses_street))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Street can not be empty." }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Patients.Find(item.patients_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Patient is mandatory." }).ToArray();
                }
                if (BaseModel.AddressesTypes.Find(item.addressestypes_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Address type is mandatory." }).ToArray();
                }

                if (!ret)
                    break;
            }

            return ret;
        }
    }

}

