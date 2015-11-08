#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Model.Entity;
using NUnit.Framework;
using System;
using System.Linq;

namespace DG.DentneD.Model.Test
{
    [TestFixture]
    public partial class DentneDModelTest
    {
        [Test]
        public void TreatmentsPricesLists_Test1()
        {
            string[] errors = new string[] { };
            treatmentspriceslists t_treatmentspriceslists = null;

            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX1").ToArray());
            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX2").ToArray());

            t_treatmentspriceslists = new treatmentspriceslists()
            {
                //treatmentspriceslists_name = "XX1",
                treatmentspriceslists_multiplier = 1
            };
            Assert.IsFalse(_dentnedModel.TreatmentsPricesLists.CanAdd(t_treatmentspriceslists));

            t_treatmentspriceslists = new treatmentspriceslists()
            {
                treatmentspriceslists_name = "XX1",
                treatmentspriceslists_multiplier = 1
            };
            Assert.IsTrue(_dentnedModel.TreatmentsPricesLists.CanAdd(t_treatmentspriceslists));
            _dentnedModel.TreatmentsPricesLists.Add(t_treatmentspriceslists);

            t_treatmentspriceslists = new treatmentspriceslists()
            {
                treatmentspriceslists_name = "XX1",
                treatmentspriceslists_multiplier = 1
            };
            Assert.IsFalse(_dentnedModel.TreatmentsPricesLists.CanAdd(t_treatmentspriceslists));

            t_treatmentspriceslists = new treatmentspriceslists()
            {
                treatmentspriceslists_name = "XX2",
                treatmentspriceslists_multiplier = 1
            };
            _dentnedModel.TreatmentsPricesLists.Add(t_treatmentspriceslists);

            t_treatmentspriceslists = _dentnedModel.TreatmentsPricesLists.FirstOrDefault(r => r.treatmentspriceslists_name == "XX1");
            t_treatmentspriceslists.treatmentspriceslists_name = "XX2";
            Assert.IsFalse(_dentnedModel.TreatmentsPricesLists.CanUpdate(t_treatmentspriceslists));
            t_treatmentspriceslists.treatmentspriceslists_name = "XX3";
            Assert.IsTrue(_dentnedModel.TreatmentsPricesLists.CanUpdate(t_treatmentspriceslists));

            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX1").ToArray());
            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX2").ToArray());
        }

        [Test]
        public void TreatmentsPricesLists_Test2()
        {
            treatmentsprices t_treatmentsprices = null;
            treatments t_treatments = null;
            treatmentstypes t_treatmentstypes = null;
            treatmentspriceslists t_treatmentspriceslists = null;
            patients t_patients = null;

            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX1").ToArray());
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            t_treatmentspriceslists = new treatmentspriceslists()
            {
                treatmentspriceslists_name = "XX1"
            };
            _dentnedModel.TreatmentsPricesLists.Add(t_treatmentspriceslists);

            t_treatmentstypes = new treatmentstypes()
            {
                treatmentstypes_name = "XX1"
            };
            _dentnedModel.TreatmentsTypes.Add(t_treatmentstypes);

            t_treatments = new treatments()
            {
                treatmentstypes_id = t_treatmentstypes.treatmentstypes_id,
                treatments_code = "XX1",
                treatments_name = "XX1",
                treatments_price = 10
            };
            _dentnedModel.Treatments.Add(t_treatments);

            t_treatmentsprices = new treatmentsprices()
            {
                treatments_id = t_treatments.treatments_id,
                treatmentspriceslists_id = t_treatmentspriceslists.treatmentspriceslists_id,
                treatmentsprices_price = 10
            };
            _dentnedModel.TreatmentsPrices.Add(t_treatmentsprices);

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                patients_password = "123456",
                treatmentspriceslists_id = t_treatmentspriceslists.treatmentspriceslists_id
            };
            _dentnedModel.Patients.Add(t_patients);

            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX1").ToArray());

            t_patients = _dentnedModel.Patients.FirstOrDefault(r => r.patients_name == "XX1" && r.patients_surname == "XX1");
            Assert.That(t_patients.treatmentspriceslists_id, Is.EqualTo(null));

            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX1").ToArray());
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

        }
    }
}
