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
    public class InvoicesFootersRepository : GenericDataRepository<invoicesfooters, DentneDModel>
    {
        public InvoicesFootersRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Name can not be empty.";
            public string text002 = "Text can not be empty.";
            public string text003 = "Invoice footer already inserted.";
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
        public override bool CanAdd(ref string[] errors, params invoicesfooters[] items)
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
        public override bool CanUpdate(ref string[] errors, params invoicesfooters[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params invoicesfooters[] items)
        {
            bool ret = true;

            foreach (invoicesfooters item in items)
            {
                if (String.IsNullOrEmpty(item.invoicesfooters_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.invoicesfooters_doctext))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (List(r => r.invoicesfooters_name == item.invoicesfooters_name).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text003 }).ToArray();
                    }
                }
                else
                {
                    if (List(r => r.invoicesfooters_id != item.invoicesfooters_id && r.invoicesfooters_name == item.invoicesfooters_name).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text003 }).ToArray();
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
        public override void Add(params invoicesfooters[] items)
        {
            SetIsDefault(items);

            base.Add(items);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="items"></param>
        public override void Update(params invoicesfooters[] items)
        {
            SetIsDefault(items);

            base.Update(items);
        }

        /// <summary>
        /// Set IsDefault
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private void SetIsDefault(params invoicesfooters[] items)
        {
            foreach (invoicesfooters item in items)
            {
                if (item.invoicesfooters_isdefault)
                {
                    //unset all db items default
                    invoicesfooters[] itemsupd = List().ToArray();
                    foreach (invoicesfooters itemupd in itemsupd)
                    {
                        itemupd.invoicesfooters_isdefault = false;
                        base.Update(itemupd);
                    }
                    //unset all current items default
                    foreach (invoicesfooters item2 in items)
                    {
                        if (item2 != item)
                            item2.invoicesfooters_isdefault = false;
                    }
                    break;
                }
            }
        }
    }

}

