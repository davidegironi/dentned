#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System.Linq;
using DG.DentneD.Model.Entity;
using NUnit.Framework;
using System;
using DG.DentneD.Model.Repositories;

namespace DG.DentneD.Model.Test
{
    [TestFixture]
    public partial class DentneDModelTest
    {
        [Test]
        public void PatientsTreatments_Test1()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            doctors t_doctors = null;
            treatments t_treatments = null;
            treatmentstypes t_treatmentstypes = null;
            patientstreatments t_patientstreatments = null;
            
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                patients_password = "123456"
            };
            _dentnedModel.Patients.Add(t_patients);
            
            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1236",
                doctors_password = "123456"
            };
            _dentnedModel.Doctors.Add(t_doctors);

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

            t_patientstreatments = new patientstreatments()
            {
                //doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                treatments_id = t_treatments.treatments_id,
                patientstreatments_creationdate = DateTime.Now,
                patientstreatments_price = 10,
                patientstreatments_taxrate = 0,
            };
            Assert.IsFalse(_dentnedModel.PatientsTreatments.CanAdd(t_patientstreatments));

            t_patientstreatments = new patientstreatments()
            {
                doctors_id = t_doctors.doctors_id,
                //patients_id = t_patients.patients_id,
                treatments_id = t_treatments.treatments_id,
                patientstreatments_creationdate = DateTime.Now,
                patientstreatments_price = 10,
                patientstreatments_taxrate = 0,
            };
            Assert.IsFalse(_dentnedModel.PatientsTreatments.CanAdd(t_patientstreatments));

            t_patientstreatments = new patientstreatments()
            {
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                //treatments_id = t_treatments.treatments_id,
                patientstreatments_creationdate = DateTime.Now,
                patientstreatments_price = 10,
                patientstreatments_taxrate = 0,
            };
            Assert.IsFalse(_dentnedModel.PatientsTreatments.CanAdd(t_patientstreatments));
            
            t_patientstreatments = new patientstreatments()
            {
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                treatments_id = t_treatments.treatments_id,
                //patientstreatments_creationdate = DateTime.Now,
                patientstreatments_price = -10,
                patientstreatments_taxrate = 0,
            };
            Assert.IsFalse(_dentnedModel.PatientsTreatments.CanAdd(t_patientstreatments));

            t_patientstreatments = new patientstreatments()
            {
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                treatments_id = t_treatments.treatments_id,
                patientstreatments_creationdate = DateTime.Now,
                patientstreatments_price = 10,
                patientstreatments_taxrate = -10,
            };
            Assert.IsFalse(_dentnedModel.PatientsTreatments.CanAdd(t_patientstreatments));

            t_patientstreatments = new patientstreatments()
            {
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                treatments_id = t_treatments.treatments_id,
                patientstreatments_creationdate = DateTime.Now,
                patientstreatments_price = 10,
                patientstreatments_taxrate = 0,
            };
            Assert.IsTrue(_dentnedModel.PatientsTreatments.CanAdd(t_patientstreatments));
            _dentnedModel.PatientsTreatments.Add(t_patientstreatments);

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
        }
    }
}
