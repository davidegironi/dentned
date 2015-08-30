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
        public void Invoices_Test1()
        {
            DateTime today = DateTime.Now;

            string[] errors = new string[] { };
            invoices t_invoices = null;
            doctors t_doctors = null;
            patients t_patients = null;

            _dentnedModel.Invoices.Remove(_dentnedModel.Invoices.List(r => r.invoices_number == "XX1" && r.invoices_date == today.Date).ToArray());
            _dentnedModel.Invoices.Remove(_dentnedModel.Invoices.List(r => r.invoices_number == "XX2" && r.invoices_date == today.Date).ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

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

            t_invoices = new invoices()
            {
                invoices_date = today,
                //invoices_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsFalse(_dentnedModel.Invoices.CanAdd(t_invoices));

            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX1",
                doctors_id = -999,
                patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsFalse(_dentnedModel.Invoices.CanAdd(t_invoices));

            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = -999,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsFalse(_dentnedModel.Invoices.CanAdd(t_invoices));

            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX1",
                //doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsFalse(_dentnedModel.Invoices.CanAdd(t_invoices));

            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                //patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsFalse(_dentnedModel.Invoices.CanAdd(t_invoices));

            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                //invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsFalse(_dentnedModel.Invoices.CanAdd(t_invoices));

            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                //invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsFalse(_dentnedModel.Invoices.CanAdd(t_invoices));

            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                //invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsFalse(_dentnedModel.Invoices.CanAdd(t_invoices));

            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = -10,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsFalse(_dentnedModel.Invoices.CanAdd(t_invoices));

            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 10,
                invoices_totalgross = 8,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsFalse(_dentnedModel.Invoices.CanAdd(t_invoices));
            
            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsTrue(_dentnedModel.Invoices.CanAdd(t_invoices));
            _dentnedModel.Invoices.Add(t_invoices);

            t_invoices = new invoices()
            {
                invoices_date = today.AddYears(1),
                invoices_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsTrue(_dentnedModel.Invoices.CanAdd(t_invoices));

            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX2",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 0
            };
            Assert.IsTrue(_dentnedModel.Invoices.CanAdd(t_invoices));
            _dentnedModel.Invoices.Add(t_invoices);

            t_invoices = _dentnedModel.Invoices.List(r => r.invoices_number == "XX1" && r.invoices_date == today.Date).FirstOrDefault();
            t_invoices.invoices_number = "XX2";
            Assert.IsFalse(_dentnedModel.Invoices.CanUpdate(t_invoices));
            t_invoices.invoices_number = "XX3";
            Assert.IsTrue(_dentnedModel.Invoices.CanUpdate(t_invoices));

            t_invoices = _dentnedModel.Invoices.List(r => r.invoices_number == "XX1" && r.invoices_date == today.Date).FirstOrDefault();
            t_invoices.doctors_id = -999;
            Assert.IsTrue(_dentnedModel.Invoices.CanUpdate(t_invoices));

            _dentnedModel.Invoices.Remove(_dentnedModel.Invoices.List(r => r.invoices_number == "XX1" && r.invoices_date == today.Date).ToArray());
            _dentnedModel.Invoices.Remove(_dentnedModel.Invoices.List(r => r.invoices_number == "XX2" && r.invoices_date == today.Date).ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
        }


        [Test]
        public void Invoices_Test2()
        {
            DateTime today = DateTime.Now;

            string[] errors = new string[] { };
            invoices t_invoices = null;
            doctors t_doctors = null;
            patients t_patients = null;
            invoiceslines t_invoiceslines = null;
            treatments t_treatments = null;
            treatmentstypes t_treatmentstypes = null;
            patientstreatments t_patientstreatments = null;

            _dentnedModel.Invoices.Remove(_dentnedModel.Invoices.List(r => r.invoices_number == "XX1" && r.invoices_date == today.Date).ToArray());
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

            t_invoices = new invoices()
            {
                invoices_date = today,
                invoices_number = "XX1",
                doctors_id = t_doctors.doctors_id,
                patients_id = t_patients.patients_id,
                invoices_doctor = "test",
                invoices_patient = "patient",
                invoices_footer = "footer",
                invoices_payment = "payment",
                invoices_totalnet = 0,
                invoices_totalgross = 0,
                invoices_totaldue = 0,
                invoices_deductiontaxrate = 20
            };
            _dentnedModel.Invoices.Add(t_invoices);

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXX",
                invoiceslines_description = "test",
                invoiceslines_quantity = 1,
                invoiceslines_unitprice = 10,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            _dentnedModel.InvoicesLines.Add(t_invoiceslines);

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXY",
                invoiceslines_description = "test",
                invoiceslines_quantity = 2,
                invoiceslines_unitprice = 12,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            _dentnedModel.InvoicesLines.Add(t_invoiceslines);

            t_invoices = _dentnedModel.Invoices.List(r => r.invoices_number == "XX1" && r.invoices_date == today.Date).FirstOrDefault();
            Assert.That(t_invoices.invoices_totalnet, Is.EqualTo(34));
            Assert.That(t_invoices.invoices_totalgross, Is.EqualTo(41.48));
            Assert.That(t_invoices.invoices_totaldue, Is.EqualTo(34.68));

            t_invoiceslines = new invoiceslines()
            {
                invoices_id = t_invoices.invoices_id,
                invoiceslines_code = "XXY",
                invoiceslines_description = "test",
                invoiceslines_quantity = 1,
                invoiceslines_unitprice = -10,
                invoiceslines_taxrate = 22,
                invoiceslines_istaxesdeductionsable = true,
                patientstreatments_id = t_patientstreatments.patientstreatments_id
            };
            _dentnedModel.InvoicesLines.Add(t_invoiceslines);

            t_invoices = _dentnedModel.Invoices.List(r => r.invoices_number == "XX1" && r.invoices_date == today.Date).FirstOrDefault();
            Assert.That(t_invoices.invoices_totalnet, Is.EqualTo(24));

            _dentnedModel.Invoices.Remove(_dentnedModel.Invoices.List(r => r.invoices_number == "XX1" && r.invoices_date == today.Date).ToArray());
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
        }
    }
}
