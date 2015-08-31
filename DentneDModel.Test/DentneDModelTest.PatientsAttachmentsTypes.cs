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
        public void PatientsAttachmentsTypes_Test1()
        {
            string[] errors = new string[] { };
            patientsattachmentstypes t_patientsattachmentstypes = null;

            _dentnedModel.PatientsAttachmentsTypes.Remove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray());
            _dentnedModel.PatientsAttachmentsTypes.Remove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX2").ToArray());
            
            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                //patientsattachmentstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes));
            
            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX1"
            };
            Assert.IsTrue(_dentnedModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes));
            _dentnedModel.PatientsAttachmentsTypes.Add(t_patientsattachmentstypes);

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes));

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX2"
            };
            _dentnedModel.PatientsAttachmentsTypes.Add(t_patientsattachmentstypes);

            t_patientsattachmentstypes = _dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").FirstOrDefault();
            t_patientsattachmentstypes.patientsattachmentstypes_name = "XX2";
            Assert.IsFalse(_dentnedModel.PatientsAttachmentsTypes.CanUpdate(t_patientsattachmentstypes));
            t_patientsattachmentstypes.patientsattachmentstypes_name = "XX3";
            Assert.IsTrue(_dentnedModel.PatientsAttachmentsTypes.CanUpdate(t_patientsattachmentstypes));

            _dentnedModel.PatientsAttachmentsTypes.Remove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray());
            _dentnedModel.PatientsAttachmentsTypes.Remove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX2").ToArray());
        }

        [Test]
        public void PatientsAttachmentsTypes_Test2()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            patientsattachmentstypes t_patientsattachmentstypes = null;
            patientsattachments t_patientsattachments = null;

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.PatientsAttachmentsTypes.Remove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray());

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

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX1"
            };
            _dentnedModel.PatientsAttachmentsTypes.Add(t_patientsattachmentstypes);

            t_patientsattachments = new patientsattachments()
            {
                patients_id = t_patients.patients_id,
                patientsattachmentstypes_id = t_patientsattachmentstypes.patientsattachmentstypes_id,
                patientsattachments_value = "XX",
                patientsattachments_date = DateTime.Now
            };
            _dentnedModel.PatientsAttachments.Add(t_patientsattachments);

            Assert.IsFalse(_dentnedModel.PatientsAttachmentsTypes.CanRemove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray()));

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            Assert.IsTrue(_dentnedModel.PatientsAttachmentsTypes.CanRemove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray()));

            _dentnedModel.PatientsAttachmentsTypes.Remove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray());
        }
    }
}
