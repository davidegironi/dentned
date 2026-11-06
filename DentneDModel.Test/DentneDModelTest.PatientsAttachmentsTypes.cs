#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Model.Entity;
using DG.DentneD.Model.Repositories;
using NUnit.Framework;
using System;
using System.Linq;

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
                //patientsattachmentstypes_name = "XX1",
                patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
            };
            Assert.That(_dentnedModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes), Is.EqualTo(false));

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX1",
                //patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
            };
            Assert.That(_dentnedModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes), Is.EqualTo(false));

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX1",
                patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
            };
            Assert.That(_dentnedModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes), Is.EqualTo(true));
            _dentnedModel.PatientsAttachmentsTypes.Add(t_patientsattachmentstypes);

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX1",
                patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
            };
            Assert.That(_dentnedModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes), Is.EqualTo(false));

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX2",
                patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
            };
            _dentnedModel.PatientsAttachmentsTypes.Add(t_patientsattachmentstypes);

            t_patientsattachmentstypes = _dentnedModel.PatientsAttachmentsTypes.FirstOrDefault(r => r.patientsattachmentstypes_name == "XX1");
            t_patientsattachmentstypes.patientsattachmentstypes_name = "XX2";
            Assert.That(_dentnedModel.PatientsAttachmentsTypes.CanUpdate(t_patientsattachmentstypes), Is.EqualTo(false));
            t_patientsattachmentstypes.patientsattachmentstypes_name = "XX3";
            Assert.That(_dentnedModel.PatientsAttachmentsTypes.CanUpdate(t_patientsattachmentstypes), Is.EqualTo(true));

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
                patientsattachmentstypes_name = "XX1",
                patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString()
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

            Assert.That(_dentnedModel.PatientsAttachmentsTypes.CanRemove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray()), Is.EqualTo(false));

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            Assert.That(_dentnedModel.PatientsAttachmentsTypes.CanRemove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray()), Is.EqualTo(true));

            _dentnedModel.PatientsAttachmentsTypes.Remove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray());
        }
    }
}
