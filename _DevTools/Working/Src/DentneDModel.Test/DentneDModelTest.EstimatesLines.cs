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
        public void EstimatesLines_Test1()
        {
            DateTime today = DateTime.Now;

            string[] errors = new string[] { };
            estimates t_estimates = null;
            doctors t_doctors = null;
            patients t_patients = null;
            estimateslines t_estimateslines = null;
            treatments t_treatments = null;
            treatmentstypes t_treatmentstypes = null;
            patientstreatments t_patientstreatments = null;

            _dentnedModel.Estimates.Remove(_dentnedModel.Estimates.List(r => r.estimates_number == "XX1" && r.estimates_date == today.Date).ToArray());
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1236",
                doctors_password = "123456"
            };
            _dentnedModel.Doctors.Add(t_doctors);

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
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                treatments_id = t_treatments.treatments_id,
                patientstreatments_creationdate = DateTime.Now,
                patientstreatments_price = 10
            };
            _dentnedModel.PatientsTreatments.Add(t_patientstreatments);

            t_estimates = new estimates()
            {
                estimates_date = today,
                estimates_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                estimates_doctor = "test",
                estimates_patient = "patient",
                estimates_footer = "footer",
                estimates_payment = "payment",
                estimates_totalnet = 0,
                estimates_totalgross = 0,
                estimates_totaldue = 0,
                estimates_deductiontaxrate = 20
            };
            _dentnedModel.Estimates.Add(t_estimates);

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_dentnedModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                //estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_dentnedModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                //estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_dentnedModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                //estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_dentnedModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = -1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_dentnedModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = -999
            };
            Assert.IsFalse(_dentnedModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                //patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_dentnedModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXX",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = 10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_dentnedModel.EstimatesLines.CanAdd(t_estimateslines));
            _dentnedModel.EstimatesLines.Add(t_estimateslines);

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXY",
                estimateslines_description = "test",
                estimateslines_quantity = 2,
                estimateslines_unitprice = 12,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_dentnedModel.EstimatesLines.CanAdd(t_estimateslines));
            _dentnedModel.EstimatesLines.Add(t_estimateslines);

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXY",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = -10,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsTrue(_dentnedModel.EstimatesLines.CanAdd(t_estimateslines));
            _dentnedModel.EstimatesLines.Add(t_estimateslines);

            t_estimateslines = new estimateslines()
            {
                estimates_id = t_estimates.estimates_id,
                estimateslines_code = "XXY",
                estimateslines_description = "test",
                estimateslines_quantity = 1,
                estimateslines_unitprice = -25,
                estimateslines_taxrate = 22,
                estimateslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            Assert.IsFalse(_dentnedModel.EstimatesLines.CanAdd(t_estimateslines));

            t_estimateslines = _dentnedModel.EstimatesLines.FirstOrDefault(r => r.estimateslines_code == "XXX");
            t_estimateslines.patientstreatments_id = -999;
            Assert.IsFalse(_dentnedModel.EstimatesLines.CanUpdate(t_estimateslines));
            t_estimateslines.patientstreatments_id = null;
            Assert.IsTrue(_dentnedModel.EstimatesLines.CanUpdate(t_estimateslines));

            _dentnedModel.Estimates.Remove(_dentnedModel.Estimates.List(r => r.estimates_number == "XX1" && r.estimates_date == today.Date).ToArray());
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
        }

    }
}
