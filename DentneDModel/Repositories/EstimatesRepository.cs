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
    public class EstimatesRepository : GenericDataRepository<estimates, DentneDModel>
    {
        public EstimatesRepository() : base() { }

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
            public string text008 = "Estimate footer already inserted within this year.";
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
        public override bool CanAdd(ref string[] errors, params estimates[] items)
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
        public override bool CanUpdate(ref string[] errors, params estimates[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params estimates[] items)
        {
            bool ret = true;

            foreach (estimates item in items)
            {
                if (String.IsNullOrEmpty(item.estimates_number))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.estimates_doctor))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.estimates_patient))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.estimates_payment))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text004 }).ToArray();
                }

                if (!ret)
                    break;

                if (item.estimates_deductiontaxrate < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text012 }).ToArray();
                }

                if (!ret)
                    break;
                
                if (item.estimates_totalnet < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text005 }).ToArray();
                }
                else if (item.estimates_totalgross < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text009 }).ToArray();
                }
                else if (item.estimates_totaldue < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text010 }).ToArray();
                }
                else
                {
                    if (item.estimates_totalnet > item.estimates_totalgross)
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
                    if (List(r => r.doctors_id == item.doctors_id && r.estimates_date.Year == item.estimates_date.Year && r.estimates_number == item.estimates_number).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text008 }).ToArray();
                    }
                }
                else
                {
                    if (List(r => r.estimates_id != item.estimates_id && r.doctors_id == item.doctors_id && r.estimates_date.Year == item.estimates_date.Year && r.estimates_number == item.estimates_number).Count() > 0)
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
        public override void Remove(params estimates[] items)
        {
            //remove all related items
            foreach (estimates item in items)
            {
                BaseModel.EstimatesLines.Remove(BaseModel.EstimatesLines.List(r => r.estimates_id == item.estimates_id).ToArray());
            }

            base.Remove(items);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="items"></param>
        public override void Update(params estimates[] items)
        {
            base.Update(items);

            //update totals
            foreach (estimates item in items)
            {
                UpdateTotal(item);
            }
        }

        /// <summary>
        /// Update an invoice total
        /// </summary>
        /// <param name="item"></param>
        public void UpdateTotal(estimates item)
        {
            decimal totaltax = 0;
            decimal totaldeductiontax = 0;
            decimal totalnotax = 0;

            //get total
            CalculateTotal(item, ref totaltax, ref totaldeductiontax, ref totalnotax);

            //update total
            item.estimates_totalnet = totalnotax;
            item.estimates_totalgross = totalnotax + totaltax;
            item.estimates_totaldue = totalnotax + totaltax - totaldeductiontax;

            base.Update(item);
        }

        /// <summary>
        /// Calculate the total for an invoice
        /// </summary>
        /// <param name="item"></param>
        /// <param name="totaltax"></param>
        /// <param name="totaldeductiontax"></param>
        /// <param name="totalnotax"></param>
        public void CalculateTotal(estimates item, ref decimal totaltax, ref decimal totaldeductiontax, ref decimal totalnotax)
        {
            totaltax = 0;
            totaldeductiontax = 0;
            totalnotax = 0;

            foreach (estimateslines estimatesline in BaseModel.EstimatesLines.List(r => r.estimates_id == item.estimates_id))
            {
                decimal estimateslineTotal = estimatesline.estimateslines_quantity * estimatesline.estimateslines_unitprice;
                decimal estimateslineTotaltax = (estimatesline.estimateslines_quantity * estimatesline.estimateslines_unitprice) * (estimatesline.estimateslines_taxrate / 100);
                decimal estimateslineTotaldeduction = (estimatesline.estimateslines_istaxesdeductionsable ? (estimatesline.estimateslines_quantity * estimatesline.estimateslines_unitprice) * (item.estimates_deductiontaxrate / 100) : 0);

                totaltax += Math.Round(estimateslineTotaltax, 2);
                totaldeductiontax += Math.Round(estimateslineTotaldeduction, 2);
                totalnotax += Math.Round(estimateslineTotal, 2);
            }
        }
    }

}

