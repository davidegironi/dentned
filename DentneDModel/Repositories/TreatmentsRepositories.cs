#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System.Linq;
using DG.Data.Model;
using DG.DentneD.Model.Entity;
using System.Text.RegularExpressions;
using System;

namespace DG.DentneD.Model.Repositories
{
    public class TreatmentsRepository : GenericDataRepository<treatments, DentneDModel>
    {
        public TreatmentsRepository() : base() { }

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params treatments[] items)
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
        public override bool CanUpdate(ref string[] errors, params treatments[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params treatments[] items)
        {
            bool ret = true;

            foreach (treatments item in items)
            {
                if (String.IsNullOrEmpty(item.treatments_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Name can not be empty." }).ToArray();
                }
                if (String.IsNullOrEmpty(item.treatments_code))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Code can not be empty." }).ToArray();
                }

                if (!ret)
                    break;

                if (item.treatments_code != null && !Regex.Match(item.treatments_code, @"^[A-Z0-9\-]{3}$").Success)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invalid code format. 3 character, uppercase letters [A-Z] or numbers [0-9], or minus '-'." }).ToArray();
                }
                if (item.treatments_mexpiration != null && (item.treatments_mexpiration <= 0 || item.treatments_mexpiration > 48))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invalid expiration period. Insert from 1 to 48 month, or leave empty." }).ToArray();
                }
                if (item.treatments_price < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invalid price. Can not be less than zero." }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.TreatmentsTypes.Find(item.treatmentstypes_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Treatment type is mandatory." }).ToArray();
                }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (List(r => r.treatments_code == item.treatments_code).Count() > 0 ||
                        List(r => r.treatments_name == item.treatments_name).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { "Treatment already inserted." }).ToArray();
                    }
                }
                else
                {
                    if (List(r => r.treatments_id != item.treatments_id && r.treatments_code == item.treatments_code).Count() > 0 ||
                        List(r => r.treatments_id != item.treatments_id && r.treatments_name == item.treatments_name).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { "Treatment already inserted." }).ToArray();
                    }
                }

                if (!ret)
                    break;
            }

            return ret;
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="items"></param>
        public override void Remove(params treatments[] items)
        {
            //remove all related items
            foreach (treatments item in items)
            {
                BaseModel.TreatmentsPrices.Remove(BaseModel.TreatmentsPrices.List(r => r.treatments_id == item.treatments_id).ToArray());
            }

            base.Remove(items);
        }
    }

}

