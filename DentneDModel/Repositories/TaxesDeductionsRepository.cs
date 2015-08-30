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
    public class TaxesDeductionsRepository : GenericDataRepository<taxesdeductions, DentneDModel>
    {
        public TaxesDeductionsRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Name can not be empty.";
            public string text002 = "Tax deduction already inserted.";
            public string text003 = "Invalid rate. Can not be less than zero.";
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
        public override bool CanAdd(ref string[] errors, params taxesdeductions[] items)
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
        public override bool CanUpdate(ref string[] errors, params taxesdeductions[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params taxesdeductions[] items)
        {
            bool ret = true;

            foreach (taxesdeductions item in items)
            {
                if (String.IsNullOrEmpty(item.taxesdeductions_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }

                if (!ret)
                    break;

                if(item.taxesdeductions_rate < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }
                
                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (List(r => r.taxesdeductions_name == item.taxesdeductions_name).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text002 }).ToArray();
                    }
                }
                else
                {
                    if (List(r => r.taxesdeductions_id != item.taxesdeductions_id && r.taxesdeductions_name == item.taxesdeductions_name).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text002 }).ToArray();
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
        public override void Add(params taxesdeductions[] items)
        {
            SetIsDefault(items);

            base.Add(items);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="items"></param>
        public override void Update(params taxesdeductions[] items)
        {
            SetIsDefault(items);

            base.Update(items);
        }

        /// <summary>
        /// Set IsDefault
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private void SetIsDefault(params taxesdeductions[] items)
        {
            foreach (taxesdeductions item in items)
            {
                if (item.taxesdeductions_isdefault)
                {
                    //unset all db items default
                    taxesdeductions[] itemsupd = List().ToArray();
                    foreach (taxesdeductions itemupd in itemsupd)
                    {
                        itemupd.taxesdeductions_isdefault = false;
                        base.Update(itemupd);
                    }
                    //unset all current items default
                    foreach (taxesdeductions item2 in items)
                    {
                        if (item2 != item)
                            item2.taxesdeductions_isdefault = false;
                    }
                    break;
                }
            }
        }
    }

}

