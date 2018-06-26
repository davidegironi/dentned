#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model;
using DG.DentneD.Model.Entity;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DG.DentneD.Model.Repositories
{
    public class DoctorsRepository : GenericDataRepository<doctors, DentneDModel>
    {
        public DoctorsRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Invoice text can not be empty.";
            public string text002 = "This item can not be removed. Appointments depends on it.";
            public string text003 = "Name can not be empty.";
            public string text004 = "Surname can not be empty.";
            public string text005 = "Doctor already inserted.";
            public string text006 = "Username can not be empty.";
            public string text007 = "Password can not be empty.";
            public string text008 = "Invalid username format. 8 character, lower letters [a-z] or numbers [0-9].";
            public string text009 = "Invalid password format. 6 numbers [0-9].";
            public string text010 = "A patient already exists with this username.";
            public string text011 = "This item can not be removed. Patient treatments depends on it.";
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
        public override bool CanAdd(ref string[] errors, params doctors[] items)
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
        public override bool CanUpdate(ref string[] errors, params doctors[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params doctors[] items)
        {
            bool ret = true;

            foreach (doctors item in items)
            {
                if (String.IsNullOrEmpty(item.doctors_name))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.doctors_surname))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text004 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.doctors_doctext))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.doctors_username))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text006 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.doctors_password))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text007 }).ToArray();
                }

                if (!ret)
                    break;

                if (!Regex.Match(item.doctors_username, @"^[a-z0-9]{8}$").Success)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text008 }).ToArray();
                }

                if (!Regex.Match(item.doctors_password, @"^[0-9]{6}$").Success)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text009 }).ToArray();
                }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (Any(r => r.doctors_name == item.doctors_name && r.doctors_surname == item.doctors_surname) ||
                        Any(r => r.doctors_username == item.doctors_username))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text005 }).ToArray();
                    }
                }
                else
                {
                    if (Any(r => r.doctors_id != item.doctors_id && r.doctors_name == item.doctors_name && r.doctors_surname == item.doctors_surname) ||
                        Any(r => r.doctors_id != item.doctors_id && r.doctors_username == item.doctors_username))
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text005 }).ToArray();
                    }
                }

                if (BaseModel.Patients.Any(r => r.patients_username == item.doctors_username))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text010 }).ToArray();
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
        public override bool CanRemove(bool checkForeingKeys, string[] excludedForeingKeys, ref string[] errors, params doctors[] items)
        {
            bool ret = true;

            foreach (doctors item in items)
            {
                if (BaseModel.Appointments.Any(r => r.doctors_id == item.doctors_id))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }
                if (BaseModel.PatientsTreatments.Any(r => r.doctors_id == item.doctors_id))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text011 }).ToArray();
                }

                if (!ret)
                    break;
            }

            if (!ret)
                return ret;

            if (excludedForeingKeys == null)
                excludedForeingKeys = new string[] { };
            if (!excludedForeingKeys.Contains("FK_estimates_doctors"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_estimates_doctors" }).ToArray();
            if (!excludedForeingKeys.Contains("FK_invoices_doctors"))
                excludedForeingKeys = excludedForeingKeys.Concat(new string[] { "FK_invoices_doctors" }).ToArray();

            return base.CanRemove(checkForeingKeys, excludedForeingKeys, ref errors, items);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="items"></param>
        public override void Remove(params doctors[] items)
        {
            //remove all related items
            foreach (doctors item in items)
            {
                foreach (invoices invoice in BaseModel.Invoices.List(r => r.doctors_id == item.doctors_id))
                {
                    invoice.doctors_id = null;
                    BaseModel.Invoices.Update(invoice);
                }
                foreach (estimates estimate in BaseModel.Estimates.List(r => r.doctors_id == item.doctors_id))
                {
                    estimate.doctors_id = null;
                    BaseModel.Estimates.Update(estimate);
                }
            }

            base.Remove(items);
        }
    }

}

