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
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Code can not be empty.";
            public string text002 = "Description can not be empty.";
            public string text003 = "Invalid quantity. Can not be less or equal than zero.";
            public string text004 = "Invoice is mandatory.";
            public string text005 = "Invalid code format. 3 character, uppercase letters [A-Z] or numbers [0-9], or minus '-'.";
            public string text006 = "Invalid price. Invoice total can not be less than zero.";
            public string text007 = "Treatment is mandatory if not empty.";
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
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }
                if (String.IsNullOrEmpty(item.estimateslines_description))
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }

                if (!ret)
                    break;

                if (item.estimateslines_quantity <= 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text003 }).ToArray();
                }

                if (!ret)
                    break;

                if (BaseModel.Estimates.Find(item.estimates_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text004 }).ToArray();
                }
                if (item.patientstreatments_id != null && BaseModel.PatientsTreatments.Find(item.patientstreatments_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text007 }).ToArray();
                }

                if (!ret)
                    break;

                if (!Regex.Match(item.estimateslines_code, @"^[A-Z0-9\-]{3}$").Success)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text005 }).ToArray();
                }

                if (!ret)
                    break;

                if(BaseModel.Estimates.Find(item.estimates_id).estimates_totalnet + Math.Round(item.estimateslines_quantity * item.estimateslines_unitprice, 2) < 0)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text006 }).ToArray();
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

