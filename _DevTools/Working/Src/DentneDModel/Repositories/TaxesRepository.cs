#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model;
using DG.DentneD.Model.Entity;
using System;
using System.Linq;

namespace DG.DentneD.Model.Repositories
{
    public class TaxesRepository : GenericDataRepository<taxes, DentneDModel>
    {
        public TaxesRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Name can not be empty.";
            public string text002 = "Tax already inserted.";
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
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }

                if (!ret)
                    break;


                if (item.taxes_rate < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (Any(r => r.taxes_name == item.taxes_name))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text002 }).ToArray();
                    }
                }
                else
                {
                    if (Any(r => r.taxes_id != item.taxes_id && r.taxes_name == item.taxes_name))
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
        /// Check if an item can be removed
        /// </summary>
        /// <param name="checkForeingKeys"></param>
        /// <param name="excludedForeingKeys"></param>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanRemove(bool checkForeingKeys, string[] excludedForeingKeys, ref string[] errors, params taxes[] items)
        {
            bool ret = true;

            errors = new string[] { };

            if (excludedForeingKeys == null)
                excludedForeingKeys = new string[] { };
            if (!excludedForeingKeys.Contains("FK_computedlines_taxes"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_computedlines_taxes" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_treatments_taxes"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_treatments_taxes" }).ToArray();

            ret = base.CanRemove(checkForeingKeys, excludedForeingKeys, ref errors, items);

            return ret;
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="items"></param>
        public override void Remove(params taxes[] items)
        {
            //remove or unset all related items
            foreach (taxes item in items)
            {
                foreach (computedlines computedline in BaseModel.ComputedLines.List(r => r.taxes_id == item.taxes_id))
                {
                    computedline.taxes_id = null;
                    BaseModel.ComputedLines.Update(computedline);
                }
                foreach (treatments treatment in BaseModel.Treatments.List(r => r.taxes_id == item.taxes_id))
                {
                    treatment.taxes_id = null;
                    BaseModel.Treatments.Update(treatment);
                }
            }

            base.Remove(items);
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

