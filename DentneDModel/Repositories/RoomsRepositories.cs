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
    public class RoomsRepository : GenericDataRepository<rooms, DentneDModel>
    {
        public RoomsRepository() : base() { }

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params rooms[] items)
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
        public override bool CanUpdate(ref string[] errors, params rooms[] items)
        {
            errors = new string[] { };

            bool ret = Validate(true, ref errors, items);
            if (!ret)
                return ret;

            ret = base.CanUpdate(ref errors, items);

            return ret;
        }

        /// <summary>
        /// Check if an item can be removed
        /// </summary>
        /// <param name="checkForeingKeys"></param>
        /// <param name="excludedForeingKeys"></param>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanRemove(bool checkForeingKeys, string[] excludedForeingKeys, ref string[] errors, params rooms[] items)
        {
            bool ret = true;

            foreach (rooms item in items)
            {
                if (String.IsNullOrEmpty(item.rooms_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Name can not be empty." }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Appointments.List(r => r.rooms_id == item.rooms_id).Count() > 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Remove appointments before deleting this item." }).ToArray();
                }

                if (!ret)
                    break;
            }

            return base.CanRemove(checkForeingKeys, excludedForeingKeys, ref errors, items);
        }

        /// <summary>
        /// Validate an item
        /// </summary>
        /// <param name="isUpdate"></param>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        private bool Validate(bool isUpdate, ref string[] errors, params rooms[] items)
        {
            bool ret = true;

            foreach (rooms item in items)
            {               
                if (!isUpdate)
                {
                    if (List(r => r.rooms_name == item.rooms_name).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { "Room already inserted." }).ToArray();
                    }
                }
                else
                {
                    if (List(r => r.rooms_id != item.rooms_id && r.rooms_name == item.rooms_name).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { "Room already inserted." }).ToArray();
                    }
                }

                if (!ret)
                    break;
            }

            return ret;
        }
    }

}

