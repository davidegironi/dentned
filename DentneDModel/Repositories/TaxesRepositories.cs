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
    public class TaxesRepository : GenericDataRepository<taxes, DentneDModel>
    {
        public TaxesRepository() : base() { }

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params taxes[] items)
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
        public override bool CanUpdate(ref string[] errors, params taxes[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params taxes[] items)
        {
            bool ret = true;

            foreach (taxes item in items)
            {
                if (String.IsNullOrEmpty(item.taxes_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Name can not be empty." }).ToArray();
                }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (List(r => r.taxes_name == item.taxes_name).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { "Tax already inserted." }).ToArray();
                    }
                }
                else
                {
                    if (List(r => r.taxes_id != item.taxes_id && r.taxes_name == item.taxes_name).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { "Tax already inserted." }).ToArray();
                    }
                }

                if (!ret)
                    break;
            }

            return ret;
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="items"></param>
        public override void Add(params taxes[] items)
        {
            SetIsDefault(items);

            base.Add(items);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="items"></param>
        public override void Update(params taxes[] items)
        {
            SetIsDefault(items);

            base.Update(items);
        }

        /// <summary>
        /// Set IsDefault
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private void SetIsDefault(params taxes[] items)
        {
            foreach (taxes item in items)
            {
                if (item.taxes_isdefault)
                {
                    //unset all db items default
                    taxes[] itemsupd = List().ToArray();
                    foreach (taxes itemupd in itemsupd)
                    {
                        itemupd.taxes_isdefault = false;
                        base.Update(itemupd);
                    }
                    //unset all current items default
                    foreach (taxes item2 in items)
                    {
                        if (item2 != item)
                            item2.taxes_isdefault = false;
                    }
                    break;
                }
            }
        }
    }

}

