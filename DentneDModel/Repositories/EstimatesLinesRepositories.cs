#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System.Linq;
using DG.Data.Model;
using DG.DentneD.Model.Entity;
using System;
using System.Text.RegularExpressions;

namespace DG.DentneD.Model.Repositories
{
    public class EstimatesLinesRepository : GenericDataRepository<estimateslines, DentneDModel>
    {
        public EstimatesLinesRepository() : base() { }

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params estimateslines[] items)
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
        public override bool CanUpdate(ref string[] errors, params estimateslines[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params estimateslines[] items)
        {
            bool ret = true;

            foreach (estimateslines item in items)
            {
                if (String.IsNullOrEmpty(item.estimateslines_code))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Code can not be empty." }).ToArray();
                }
                if (String.IsNullOrEmpty(item.estimateslines_description))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Description can not be empty." }).ToArray();
                }

                if (!ret)
                    break;

                if (item.estimateslines_quantity < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invalid quantity. Can not be less than zero." }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Estimates.Find(item.estimates_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invoice is mandatory." }).ToArray();
                }

                if (!ret)
                    break;

                if (item.estimateslines_code != null && !Regex.Match(item.estimateslines_code, @"^[A-Z0-9\-]{3}$").Success)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invalid code format. 3 character, uppercase letters [A-Z] or numbers [0-9], or minus '-'." }).ToArray();
                }

                if (!ret)
                    break;

                if(BaseModel.Estimates.Find(item.estimates_id).estimates_total +
                    (Math.Round((item.estimateslines_quantity * item.estimateslines_unitprice)*item.estimateslines_taxrate / 100, 2) + Math.Round(item.estimateslines_quantity * item.estimateslines_unitprice, 2)) < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invalid price. Invoice total can not be less than zero." }).ToArray();
                }
            }

            return ret;
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="items"></param>
        public override void Add(params estimateslines[] items)
        {
            base.Add(items);

            //update estimates total
            foreach (estimateslines item in items)
            {
                BaseModel.Estimates.UpdateTotal(BaseModel.Estimates.Find(item.estimates_id));
            }
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="items"></param>
        public override void Update(params estimateslines[] items)
        {
            base.Update(items);

            //update estimates total
            foreach (estimateslines item in items)
            {
                BaseModel.Estimates.UpdateTotal(BaseModel.Estimates.Find(item.estimates_id));
            }
        }
    }

}

