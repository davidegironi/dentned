#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System.Linq;
using DG.Data.Model;
using DG.DentneD.Model.Entity;

namespace DG.DentneD.Model.Repositories
{
    public class TreatmentsPricesRepository : GenericDataRepository<treatmentsprices, DentneDModel>
    {
        public TreatmentsPricesRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Invalid price. Can not be less than zero.";
            public string text002 = "Treatment type is mandatory.";
            public string text003 = "Treatment price list is mandatory.";
            public string text004 = "Treatments price already inserted.";
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
        public override bool CanAdd(ref string[] errors, params treatmentsprices[] items)
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
        public override bool CanUpdate(ref string[] errors, params treatmentsprices[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params treatmentsprices[] items)
        {
            bool ret = true;

            foreach (treatmentsprices item in items)
            {
                if (item.treatmentsprices_price < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }
                
                if (!ret)
                    break;
                
                if (BaseModel.Treatments.Find(item.treatments_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }
                if (BaseModel.TreatmentsPricesLists.Find(item.treatmentspriceslists_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }

                if (!ret)
                    break;

                if (!isUpdate)
                {
                    if (List(r => r.treatments_id == item.treatments_id && r.treatmentspriceslists_id == item.treatmentspriceslists_id).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text004 }).ToArray();
                    }
                }
                else
                {
                    if (List(r => r.treatmentsprices_id != item.treatmentsprices_id && r.treatments_id == item.treatments_id && r.treatmentspriceslists_id == item.treatmentspriceslists_id).Count() > 0)
                    {
                        ret = false;
                        errors = errors.Concat(new string[] { language.text004 }).ToArray();
                    }
                }

                if (!ret)
                    break;
            }

            return ret;
        }
    }

}

