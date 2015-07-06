#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System.Linq;
using DG.DentneD.Model.Entity;
using NUnit.Framework;
using System;

namespace DG.DentneD.Model.Test
{
    [TestFixture]
    public partial class DentneDModelTest
    {
        [Test]
        public void PatientsNotes_Test1()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            patientsnotes t_patientsnotes = null;
            
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M"
            };
            _dentnedModel.Patients.Add(t_patients);
            
            t_patientsnotes = new patientsnotes()
            {
                //patients_id = t_patients.patients_id
                patientsnotes_text = "XX",
                patientsnotes_date = DateTime.Now
            };
            Assert.IsFalse(_dentnedModel.PatientsNotes.CanAdd(t_patientsnotes));

            t_patientsnotes = new patientsnotes()
            {
                patients_id = t_patients.patients_id,
                //contactstypes_id = t_contactstypes.contactstypes_id,
                patientsnotes_date = DateTime.Now
            };
            Assert.IsFalse(_dentnedModel.PatientsNotes.CanAdd(t_patientsnotes));
            
            t_patientsnotes = new patientsnotes()
            {
                patients_id = t_patients.patients_id,
                patientsnotes_text = "XX",
                patientsnotes_date = DateTime.Now
            };
            Assert.IsTrue(_dentnedModel.PatientsNotes.CanAdd(t_patientsnotes));
            _dentnedModel.PatientsNotes.Add(t_patientsnotes);

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
        }
    }
}
