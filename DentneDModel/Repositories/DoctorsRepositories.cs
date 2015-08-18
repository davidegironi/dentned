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
    public class DoctorsRepository : GenericDataRepository<doctors, DentneDModel>
    {
        public DoctorsRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Invoice text can not be empty.";
            public string text002 = "Remove doctor's appointments before deleting this item.";
            public string text003 = "Name can not be empty.";
            public string text004 = "Surnname can not be empty.";
            public string text005 = "Doctor already inserted.";
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
                if (String.IsNullOrEmpty(item.doctors_doctext))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Appointments.List(r => r.doctors_id == item.doctors_id).Count() > 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
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

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (List(r => r.doctors_name == item.doctors_name && r.doctors_surname == item.doctors_surname).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text005 }).ToArray();
                    }
                }
                else
                {
                    if (List(r => r.doctors_id != item.doctors_id && r.doctors_name == item.doctors_name && r.doctors_surname == item.doctors_surname).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text005 }).ToArray();
                    }
                }

                if (!ret)
                    break;
            }

            return ret;
        }
    }

}

