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
    public class InvoicesLinesRepository : GenericDataRepository<invoiceslines, DentneDModel>
    {
        public InvoicesLinesRepository() : base() { }

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params invoiceslines[] items)
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
        public override bool CanUpdate(ref string[] errors, params invoiceslines[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params invoiceslines[] items)
        {
            bool ret = true;

            foreach (invoiceslines item in items)
            {
                if (String.IsNullOrEmpty(item.invoiceslines_code))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Code can not be empty." }).ToArray();
                }
                if (String.IsNullOrEmpty(item.invoiceslines_description))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Description can not be empty." }).ToArray();
                }

                if (!ret)
                    break;

                if (item.invoiceslines_quantity < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invalid quantity. Can not be less than zero." }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Invoices.Find(item.invoices_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invoice is mandatory." }).ToArray();
                }
                if (item.patientstreatments_id != null && BaseModel.PatientsTreatments.Find(item.patientstreatments_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Treatments is mandatory if not empty." }).ToArray();
                }

                if (!ret)
                    break;

                if (item.invoiceslines_code != null && !Regex.Match(item.invoiceslines_code, @"^[A-Z0-9\-]{3}$").Success)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invalid code format. 3 character, uppercase letters [A-Z] or numbers [0-9], or minus '-'." }).ToArray();
                }

                if (!ret)
                    break;

                if(BaseModel.Invoices.Find(item.invoices_id).invoices_total +
                    (Math.Round((item.invoiceslines_quantity * item.invoiceslines_unitprice)*item.invoiceslines_taxrate / 100, 2) + Math.Round(item.invoiceslines_quantity * item.invoiceslines_unitprice, 2)) < 0)
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
        public override void Add(params invoiceslines[] items)
        {
            base.Add(items);

            //update invoices total
            foreach (invoiceslines item in items)
            {
                BaseModel.Invoices.UpdateTotal(BaseModel.Invoices.Find(item.invoices_id));
            }
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="items"></param>
        public override void Update(params invoiceslines[] items)
        {
            base.Update(items);

            //update invoices total
            foreach (invoiceslines item in items)
            {
                BaseModel.Invoices.UpdateTotal(BaseModel.Invoices.Find(item.invoices_id));
            }
        }
    }

}

