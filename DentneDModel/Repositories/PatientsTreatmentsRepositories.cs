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
    public class PatientsTreatmentsRepository : GenericDataRepository<patientstreatments, DentneDModel>
    {
        public PatientsTreatmentsRepository() : base() { }

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params patientstreatments[] items)
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
        public override bool CanUpdate(ref string[] errors, params patientstreatments[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params patientstreatments[] items)
        {
            bool ret = true;

            foreach (patientstreatments item in items)
            {
                if (item.patientstreatments_price < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invalid price. Can not be less than zero." }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Doctors.Find(item.doctors_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Doctors is mandatory." }).ToArray();
                }
                if (BaseModel.Patients.Find(item.patients_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Patient is mandatory." }).ToArray();
                }
                if (BaseModel.Treatments.Find(item.treatments_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Treatments type is mandatory." }).ToArray();
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
        public override void Remove(params patientstreatments[] items)
        {
            //remove or unset all related items
            foreach (patientstreatments item in items)
            {
                foreach (invoiceslines invoiceline in BaseModel.InvoicesLines.List(r => r.patientstreatments_id == item.patientstreatments_id))
                {
                    invoiceline.patientstreatments_id = null;
                    BaseModel.InvoicesLines.Update(invoiceline);
                }
            }

            base.Remove(items);
        }

        /// <summary>
        /// Get the tooth string for a treatment
        /// </summary>
        /// <returns></returns>
        public string GetTreatmentsToothsString(patientstreatments item)
        {
            string ret = (item.patientstreatments_t11 && item.patientstreatments_t12 && item.patientstreatments_t13 && item.patientstreatments_t14 && item.patientstreatments_t15 && item.patientstreatments_t16 && item.patientstreatments_t17 && item.patientstreatments_t18 &&
                    item.patientstreatments_t21 && item.patientstreatments_t22 && item.patientstreatments_t23 && item.patientstreatments_t24 && item.patientstreatments_t25 && item.patientstreatments_t26 && item.patientstreatments_t27 && item.patientstreatments_t28 &&
                    item.patientstreatments_t31 && item.patientstreatments_t32 && item.patientstreatments_t33 && item.patientstreatments_t34 && item.patientstreatments_t35 && item.patientstreatments_t36 && item.patientstreatments_t37 && item.patientstreatments_t38 &&
                    item.patientstreatments_t41 && item.patientstreatments_t42 && item.patientstreatments_t43 && item.patientstreatments_t44 && item.patientstreatments_t45 && item.patientstreatments_t46 && item.patientstreatments_t47 && item.patientstreatments_t48 ? "All" : 
                        (item.patientstreatments_t11 && item.patientstreatments_t12 && item.patientstreatments_t13 && item.patientstreatments_t14 && item.patientstreatments_t15 && item.patientstreatments_t16 && item.patientstreatments_t17 && item.patientstreatments_t18 &&
                        item.patientstreatments_t21 && item.patientstreatments_t22 && item.patientstreatments_t23 && item.patientstreatments_t24 && item.patientstreatments_t25 && item.patientstreatments_t26 && item.patientstreatments_t27 && item.patientstreatments_t28 &&
                        !item.patientstreatments_t31 && !item.patientstreatments_t32 && !item.patientstreatments_t33 && !item.patientstreatments_t34 && !item.patientstreatments_t35 && !item.patientstreatments_t36 && !item.patientstreatments_t37 && !item.patientstreatments_t38 &&
                        !item.patientstreatments_t41 && !item.patientstreatments_t42 && !item.patientstreatments_t43 && !item.patientstreatments_t44 && !item.patientstreatments_t45 && !item.patientstreatments_t46 && !item.patientstreatments_t47 && !item.patientstreatments_t48 ? "Up" : 
                            (!item.patientstreatments_t11 && !item.patientstreatments_t12 && !item.patientstreatments_t13 && !item.patientstreatments_t14 && !item.patientstreatments_t15 && !item.patientstreatments_t16 && !item.patientstreatments_t17 && !item.patientstreatments_t18 &&
                            !item.patientstreatments_t21 && !item.patientstreatments_t22 && !item.patientstreatments_t23 && !item.patientstreatments_t24 && !item.patientstreatments_t25 && !item.patientstreatments_t26 && !item.patientstreatments_t27 && !item.patientstreatments_t28 &&
                            item.patientstreatments_t31 && item.patientstreatments_t32 && item.patientstreatments_t33 && item.patientstreatments_t34 && item.patientstreatments_t35 && item.patientstreatments_t36 && item.patientstreatments_t37 && item.patientstreatments_t38 &&
                            item.patientstreatments_t41 && item.patientstreatments_t42 && item.patientstreatments_t43 && item.patientstreatments_t44 && item.patientstreatments_t45 && item.patientstreatments_t46 && item.patientstreatments_t47 && item.patientstreatments_t48 ? "Down" :
                                (!item.patientstreatments_t11 && !item.patientstreatments_t12 && !item.patientstreatments_t13 && !item.patientstreatments_t14 && !item.patientstreatments_t15 && !item.patientstreatments_t16 && !item.patientstreatments_t17 && !item.patientstreatments_t18 &&
                                !item.patientstreatments_t21 && !item.patientstreatments_t22 && !item.patientstreatments_t23 && !item.patientstreatments_t24 && !item.patientstreatments_t25 && !item.patientstreatments_t26 && !item.patientstreatments_t27 && !item.patientstreatments_t28 &&
                                !item.patientstreatments_t31 && !item.patientstreatments_t32 && !item.patientstreatments_t33 && !item.patientstreatments_t34 && !item.patientstreatments_t35 && !item.patientstreatments_t36 && !item.patientstreatments_t37 && !item.patientstreatments_t28 &&
                                !item.patientstreatments_t41 && !item.patientstreatments_t42 && !item.patientstreatments_t43 && !item.patientstreatments_t44 && !item.patientstreatments_t45 && !item.patientstreatments_t46 && !item.patientstreatments_t47 && !item.patientstreatments_t48 ? "None" :
                                    (item.patientstreatments_t11 ? "11," : "") +
                                    (item.patientstreatments_t12 ? "12," : "") +
                                    (item.patientstreatments_t13 ? "13," : "") +
                                    (item.patientstreatments_t14 ? "14," : "") +
                                    (item.patientstreatments_t15 ? "15," : "") +
                                    (item.patientstreatments_t16 ? "16," : "") +
                                    (item.patientstreatments_t17 ? "17," : "") +
                                    (item.patientstreatments_t18 ? "18," : "") +
                                    (item.patientstreatments_t21 ? "21," : "") +
                                    (item.patientstreatments_t22 ? "22," : "") +
                                    (item.patientstreatments_t23 ? "23," : "") +
                                    (item.patientstreatments_t24 ? "24," : "") +
                                    (item.patientstreatments_t25 ? "25," : "") +
                                    (item.patientstreatments_t26 ? "26," : "") +
                                    (item.patientstreatments_t27 ? "27," : "") +
                                    (item.patientstreatments_t28 ? "28," : "") +
                                    (item.patientstreatments_t31 ? "31," : "") +
                                    (item.patientstreatments_t32 ? "32," : "") +
                                    (item.patientstreatments_t33 ? "33," : "") +
                                    (item.patientstreatments_t34 ? "34," : "") +
                                    (item.patientstreatments_t35 ? "35," : "") +
                                    (item.patientstreatments_t36 ? "36," : "") +
                                    (item.patientstreatments_t37 ? "37," : "") +
                                    (item.patientstreatments_t38 ? "38," : "") +
                                    (item.patientstreatments_t41 ? "41," : "") +
                                    (item.patientstreatments_t42 ? "42," : "") +
                                    (item.patientstreatments_t43 ? "43," : "") +
                                    (item.patientstreatments_t44 ? "44," : "") +
                                    (item.patientstreatments_t45 ? "45," : "") +
                                    (item.patientstreatments_t46 ? "46," : "") +
                                    (item.patientstreatments_t47 ? "47," : "") +
                                    (item.patientstreatments_t48 ? "48," : "")
                                )
                            )
                        )
                    );
            ret = (ret.EndsWith(",") ? ret.Substring(0, ret.Length-1) : ret);
            return ret;
        }
    }

}

