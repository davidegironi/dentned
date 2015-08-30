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
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Number can not be empty.";
            public string text002 = "Doctor can not be empty.";
            public string text003 = "Patient can not be empty.";
            public string text004 = "Payment can not be empty.";
            public string text005 = "Invalid net total. Can not be less than zero.";
            public string text006 = "Doctor is mandatory.";
            public string text007 = "Patient is mandatory.";
            public string text008 = "Invoice footer already inserted within this year.";
            public string text009 = "Invalid gross total. Can not be less than zero.";
            public string text010 = "Invalid due total. Can not be less than zero.";
            public string text011 = "Gross total can not be less than net total.";
            public string text012 = "Invalid deduction tax rate. Can not be less than zero.";
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
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.invoices_doctor))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.invoices_patient))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.invoices_payment))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text004 }).ToArray();
                }
                
                if (!ret)
                    break;

                if (item.invoices_deductiontaxrate < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text012 }).ToArray();
                }

                if (!ret)
                    break;

                if (item.invoices_totalnet < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text005 }).ToArray();
                }
                else if (item.invoices_totalgross < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text009 }).ToArray();
                }
                else if (item.invoices_totaldue < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text010 }).ToArray();
                }
                else
                {
                    if (item.invoices_totalnet > item.invoices_totalgross)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text011 }).ToArray();
                    }
                }
                
                if (!ret)
                    break;
                
                if (!isUpdate)
                {
                    //needed at the add stage, but can be omitted in the update stage, cause those link can be deleted
                    if (BaseModel.Doctors.Find(item.doctors_id) == null)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text006 }).ToArray();
                    }
                    if (BaseModel.Patients.Find(item.patients_id) == null)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text007 }).ToArray();
                    }
                }
                else
                { }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (List(r => r.doctors_id == item.doctors_id && r.invoices_date.Year == item.invoices_date.Year && r.invoices_number == item.invoices_number).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text008 }).ToArray();
                    }
                }
                else
                {
                    if (List(r => r.invoices_id != item.invoices_id && r.doctors_id == item.doctors_id && r.invoices_date.Year == item.invoices_date.Year && r.invoices_number == item.invoices_number).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text008 }).ToArray();
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
        /// Update an item
        /// </summary>
        /// <param name="items"></param>
        public override void Update(params invoices[] items)
        {
            base.Update(items);

            //update totals
            foreach (invoices item in items)
            {
                UpdateTotal(item);
            }
        }

        /// <summary>
        /// Update an invoice total
        /// </summary>
        /// <param name="item"></param>
        public void UpdateTotal(invoices item)
        {
            decimal totaltax = 0;
            decimal totaldeductiontax = 0;
            decimal totalnotax = 0;

            //get total
            CalculateTotal(item, ref totaltax, ref totaldeductiontax, ref totalnotax);

            //update totals
            item.invoices_totalnet = totalnotax;
            item.invoices_totalgross = totalnotax + totaltax;
            item.invoices_totaldue = totalnotax + totaltax - totaldeductiontax;

            base.Update(item);
        }

        /// <summary>
        /// Calculate the total for an invoice
        /// </summary>
        /// <param name="item"></param>
        /// <param name="totaltax"></param>
        /// <param name="totaldeductiontax"></param>
        /// <param name="totalnotax"></param>
        public void CalculateTotal(invoices item, ref decimal totaltax, ref decimal totaldeductiontax, ref decimal totalnotax)
        {
            totaltax = 0;
            totaldeductiontax = 0;
            totalnotax = 0;

            foreach (invoiceslines invoicesline in BaseModel.InvoicesLines.List(r => r.invoices_id == item.invoices_id))
            {
                decimal invoiceslineTotal = invoicesline.invoiceslines_quantity * invoicesline.invoiceslines_unitprice;
                decimal invoiceslineTotaltax = (invoicesline.invoiceslines_quantity * invoicesline.invoiceslines_unitprice) * (invoicesline.invoiceslines_taxrate / 100);
                decimal invoiceslineTotaldeduction = (invoicesline.invoiceslines_istaxesdeductionsable ? (invoicesline.invoiceslines_quantity * invoicesline.invoiceslines_unitprice) * (item.invoices_deductiontaxrate / 100) : 0);

                totaltax += Math.Round(invoiceslineTotaltax, 2);
                totaldeductiontax += Math.Round(invoiceslineTotaldeduction, 2);
                totalnotax += Math.Round(invoiceslineTotal, 2);
            }
        }
    }

}

