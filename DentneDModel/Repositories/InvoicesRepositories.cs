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
    public class InvoicesRepository : GenericDataRepository<invoices, DentneDModel>
    {
        public InvoicesRepository() : base() { }

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params invoices[] items)
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
        public override bool CanUpdate(ref string[] errors, params invoices[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params invoices[] items)
        {
            bool ret = true;

            foreach (invoices item in items)
            {
                if (String.IsNullOrEmpty(item.invoices_number))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Number can not be empty." }).ToArray();
                }
                if (String.IsNullOrEmpty(item.invoices_doctor))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Doctor can not be empty." }).ToArray();
                }
                if (String.IsNullOrEmpty(item.invoices_patient))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Patient can not be empty." }).ToArray();
                }
                if (String.IsNullOrEmpty(item.invoices_payment))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Payment can not be empty." }).ToArray();
                }

                if (!ret)
                    break;
                
                if (item.invoices_total < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invalid price. Can not be less than zero." }).ToArray();
                }
                
                if (!ret)
                    break;
                
                if (!isUpdate)
                {
                    //needed at the add stage, but can be omitted in the update stage, cause those link can be deleted
                    if (BaseModel.Doctors.Find(item.doctors_id) == null)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { "Doctor is mandatory." }).ToArray();
                    }
                    if (BaseModel.Patients.Find(item.patients_id) == null)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { "Patient is mandatory." }).ToArray();
                    }
                }
                else
                { }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (List(r => r.invoices_date.Year == item.invoices_date.Year && r.invoices_number == item.invoices_number).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { "Invoice footer already inserted within this year." }).ToArray();
                    }
                }
                else
                {
                    if (List(r => r.invoices_id != item.invoices_id && r.invoices_date.Year == item.invoices_date.Year && r.invoices_number == item.invoices_number).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { "Invoice footer already inserted within this year." }).ToArray();
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
        public override void Remove(params invoices[] items)
        {
            //remove all related items
            foreach (invoices item in items)
            {
                BaseModel.InvoicesLines.Remove(BaseModel.InvoicesLines.List(r => r.invoices_id == item.invoices_id).ToArray());
                foreach (estimates estimate in BaseModel.Estimates.List(r => r.invoices_id == item.invoices_id))
                {
                    estimate.invoices_id = null;
                    BaseModel.Estimates.Update(estimate);
                }
            }

            base.Remove(items);
        }

        /// <summary>
        /// Update an invoice total
        /// </summary>
        /// <param name="invoice"></param>
        public void UpdateTotal(invoices invoice)
        {
            decimal totaltax = 0;
            decimal totaldeductiontax = 0;
            decimal totalnotax = 0;
            decimal total = 0;

            //get total
            CalculateTotal(invoice, ref totaltax, ref totaldeductiontax, ref totalnotax, ref total);

            //update total
            invoice.invoices_total = total;

            base.Update(invoice);
        }

        /// <summary>
        /// Calculate the total for an invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="totaltax"></param>
        /// <param name="totaldeductiontax"></param>
        /// <param name="totalnotax"></param>
        /// <param name="total"></param>
        public void CalculateTotal(invoices invoice, ref decimal totaltax, ref decimal totaldeductiontax, ref decimal totalnotax, ref decimal total)
        {
            totaltax = 0;
            totaldeductiontax = 0;
            totalnotax = 0;
            total = 0;

            foreach (invoiceslines invoicesline in BaseModel.InvoicesLines.List(r => r.invoices_id == invoice.invoices_id))
            {
                decimal invoiceslineTotal = invoicesline.invoiceslines_quantity * invoicesline.invoiceslines_unitprice;
                decimal invoiceslineTotaltax = (invoicesline.invoiceslines_quantity * invoicesline.invoiceslines_unitprice) * (invoicesline.invoiceslines_taxrate / 100);
                decimal invoiceslineTotaldeduction = (invoicesline.invoiceslines_quantity * invoicesline.invoiceslines_unitprice) * (invoice.invoices_deductiontaxrate / 100);

                totaltax += Math.Round(invoiceslineTotaltax, 2);
                totaldeductiontax += Math.Round(invoiceslineTotaldeduction, 2);
                totalnotax += Math.Round(invoiceslineTotal, 2);
                total += Math.Round(invoiceslineTotal + invoiceslineTotaltax - invoiceslineTotaldeduction, 2);
            }
        }
    }

}

