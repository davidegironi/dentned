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
    public class PatientsRepository : GenericDataRepository<patients, DentneDModel>
    {
        public PatientsRepository() : base() { }

        /// <summary>
        /// Check if an item can be added
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public override bool CanAdd(ref string[] errors, params patients[] items)
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
        public override bool CanUpdate(ref string[] errors, params patients[] items)
        {
            errors = new string[] { };

            bool ret = Validate(true, ref errors, items);
            if (!ret)
                return ret;

            ret = base.CanUpdate(ref errors, items);

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
        public override bool CanRemove(bool checkForeingKeys, string[] excludedForeingKeys, ref string[] errors, params patients[] items)
        {
            bool ret = true;

            foreach (patients item in items)
            {
                if (BaseModel.Appointments.List(r => r.patients_id == item.patients_id).Count() > 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Remove appointments before deleting this item." }).ToArray();
                }

                if (!ret)
                    break;
            }

            return base.CanRemove(checkForeingKeys, excludedForeingKeys, ref errors, items);
        }

        /// <summary>
        /// Validate an item
        /// </summary>
        /// <param name="isUpdate"></param>
        /// <param name="errors"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        private bool Validate(bool isUpdate, ref string[] errors, params patients[] items)
        {
            bool ret = true;

            foreach (patients item in items)
            {
                if (String.IsNullOrEmpty(item.patients_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Name can not be empty." }).ToArray();
                }
                if (String.IsNullOrEmpty(item.patients_surname))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Surname can not be empty." }).ToArray();
                }
                if (String.IsNullOrEmpty(item.patients_birthcity))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Birth city can not be empty." }).ToArray();
                }
                if (String.IsNullOrEmpty(item.patients_doctext))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invoices text can not be empty." }).ToArray();
                }

                if (!ret)
                    break;

                if (item.patients_sex != "M" && item.patients_sex != "F")
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invalid sex. Can be 'M' or 'F'." }).ToArray();
                }

                if (!ret)
                    break;

                if (item.treatmentspriceslists_id != null && BaseModel.TreatmentsPricesLists.Find(item.treatmentspriceslists_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { "Invalid treatment price list." }).ToArray();
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
        public override void Remove(params patients[] items)
        {
            //remove or unset all related items
            foreach (patients item in items)
            {
                BaseModel.PatientsAddresses.Remove(BaseModel.PatientsAddresses.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.PatientsContacts.Remove(BaseModel.PatientsContacts.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.PatientsMedicalrecords.Remove(BaseModel.PatientsMedicalrecords.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.PatientsAttachments.Remove(BaseModel.PatientsAttachments.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.PatientsNotes.Remove(BaseModel.PatientsNotes.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.PatientsTreatments.Remove(BaseModel.PatientsTreatments.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.Payments.Remove(BaseModel.Payments.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.Appointments.Remove(BaseModel.Appointments.List(r => r.patients_id == item.patients_id).ToArray());
                BaseModel.Estimates.Remove(BaseModel.Estimates.List(r => r.patients_id == item.patients_id).ToArray());
                foreach (invoices invoice in BaseModel.Invoices.List(r => r.patients_id == item.patients_id))
                {
                    invoice.patients_id = null;
                    BaseModel.Invoices.Update(invoice);
                }
            }

            base.Remove(items);
        }
    }

}

