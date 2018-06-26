#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model;
using DG.DentneD.Model.Entity;
using System;
using System.Linq;

namespace DG.DentneD.Model.Repositories
{
    public class PatientsAttributesRepository : GenericDataRepository<patientsattributes, DentneDModel>
    {
        public PatientsAttributesRepository() : base() { }

        /// <summary>
        /// Repository language dictionary
        /// </summary>
        public class RepositoryLanguage : IGenericDataRepositoryLanguage
        {
            public string text001 = "Patient is mandatory.";
            public string text002 = "Attribute type is mandatory.";
            public string text003 = "System attribute type already inserted.";
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
        public override bool CanAdd(ref string[] errors, params patientsattributes[] items)
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
        public override bool CanUpdate(ref string[] errors, params patientsattributes[] items)
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
        private bool Validate(bool isUpdate, ref string[] errors, params patientsattributes[] items)
        {
            bool ret = true;

            foreach (patientsattributes item in items)
            {
                if (BaseModel.Patients.Find(item.patients_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text001 }).ToArray();
                }
                if (BaseModel.PatientsAttributesTypes.Find(item.patientsattributestypes_id) == null)
                {
                    ret = false;
                    errors = errors.Concat(new string[] { language.text002 }).ToArray();
                }

                if (!ret)
                    break;

                //check one system type per patient
                patientsattributestypes patientsattributestype = BaseModel.PatientsAttributesTypes.Find(item.patientsattributestypes_id);
                if (patientsattributestype != null)
                {
                    if (Enum.GetNames(typeof(PatientsAttributesTypesRepository.SystemAttributes)).ToArray().Contains(patientsattributestype.patientsattributestypes_name))
                    {
                        if (!isUpdate)
                        {
                            if (Any(r => r.patients_id == item.patients_id && r.patientsattributestypes_id == item.patientsattributestypes_id))
                            {
                                ret = false;
                                errors = errors.Concat(new string[] { language.text003 }).ToArray();
                            }
                        }
                        else
                        {
                            if (Any(r => r.patientsattributestypes_id != item.patientsattributestypes_id && r.patients_id == item.patients_id && r.patientsattributestypes_id == item.patientsattributestypes_id))
                            {
                                ret = false;
                                errors = errors.Concat(new string[] { language.text003 }).ToArray();
                            }
                        }
                    }
                }
            }

            return ret;
        }
    }

}

