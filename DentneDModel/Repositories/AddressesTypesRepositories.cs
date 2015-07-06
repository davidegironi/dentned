﻿#region License
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
    public class AddressesTypesRepository : GenericDataRepository<addressestypes, DentneDModel>
    {
        public AddressesTypesRepository() : base() { }

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params addressestypes[] items)
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
        public override bool CanUpdate(ref string[] errors, params addressestypes[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params addressestypes[] items)
        {
            bool ret = true;

            foreach (addressestypes item in items)
            {
                if (String.IsNullOrEmpty(item.addressestypes_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Name can not be empty." }).ToArray();
                }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (List(r => r.addressestypes_name == item.addressestypes_name).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { "Address type already inserted." }).ToArray();
                    }
                }
                else
                {
                    if (List(r => r.addressestypes_id != item.addressestypes_id && r.addressestypes_name == item.addressestypes_name).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { "Address type already inserted." }).ToArray();
                    }
                }

                if (!ret)
                    break;
            }

            return ret;
        }
    }

}
