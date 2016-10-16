#region License
// Copyright (c) 2016 Davide Gironi
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
        public void PatientsAttributesTypes_Test1()
        {
            string[] errors = new string[] { };
            patientsattributestypes t_patientsattributestypes = null;

            _dentnedModel.PatientsAttributesTypes.Remove(_dentnedModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray());
            _dentnedModel.PatientsAttributesTypes.Remove(_dentnedModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX2").ToArray());

            t_patientsattributestypes = new patientsattributestypes()
            {
                //patientsattributestypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.PatientsAttributesTypes.CanAdd(t_patientsattributestypes));

            t_patientsattributestypes = new patientsattributestypes()
            {
                patientsattributestypes_name = "XX1"
            };
            Assert.IsTrue(_dentnedModel.PatientsAttributesTypes.CanAdd(t_patientsattributestypes));
            _dentnedModel.PatientsAttributesTypes.Add(t_patientsattributestypes);

            t_patientsattributestypes = new patientsattributestypes()
            {
                patientsattributestypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.PatientsAttributesTypes.CanAdd(t_patientsattributestypes));

            t_patientsattributestypes = new patientsattributestypes()
            {
                patientsattributestypes_name = "XX2"
            };
            _dentnedModel.PatientsAttributesTypes.Add(t_patientsattributestypes);

            t_patientsattributestypes = _dentnedModel.PatientsAttributesTypes.FirstOrDefault(r => r.patientsattributestypes_name == "XX1");
            t_patientsattributestypes.patientsattributestypes_name = "XX2";
            Assert.IsFalse(_dentnedModel.PatientsAttributesTypes.CanUpdate(t_patientsattributestypes));
            t_patientsattributestypes.patientsattributestypes_name = "XX3";
            Assert.IsTrue(_dentnedModel.PatientsAttributesTypes.CanUpdate(t_patientsattributestypes));

            _dentnedModel.PatientsAttributesTypes.Remove(_dentnedModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray());
            _dentnedModel.PatientsAttributesTypes.Remove(_dentnedModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX2").ToArray());
        }
        
        [Test]
        public void PatientsAttributesTypes_Test2()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            patientsattributestypes t_patientsattributestypes = null;
            patientsattributes t_patientsattributes = null;

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.PatientsAttributesTypes.Remove(_dentnedModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray());

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

            t_patientsattributestypes = new patientsattributestypes()
            {
                patientsattributestypes_name = "XX1"
            };
            _dentnedModel.PatientsAttributesTypes.Add(t_patientsattributestypes);

            t_patientsattributes = new patientsattributes()
            {
                patients_id = t_patients.patients_id,
                patientsattributestypes_id = t_patientsattributestypes.patientsattributestypes_id,
                patientsattributes_value = "XX"
            };
            _dentnedModel.PatientsAttributes.Add(t_patientsattributes);

            Assert.IsFalse(_dentnedModel.PatientsAttributesTypes.CanRemove(_dentnedModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray()));

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            Assert.IsTrue(_dentnedModel.PatientsAttributesTypes.CanRemove(_dentnedModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray()));

            _dentnedModel.PatientsAttributesTypes.Remove(_dentnedModel.PatientsAttributesTypes.List(r => r.patientsattributestypes_name == "XX1").ToArray());
        }
        
        [Test]
        public void PatientsAttributesTypes_Test3()
        {
            string[] errors = new string[] { };
            patientsattributestypes patientsattributestypesSendAppointmentsReminder = null;

            patientsattributestypesSendAppointmentsReminder = _dentnedModel.PatientsAttributesTypes.FirstOrDefault(r => r.patientsattributestypes_name == PatientsAttributesTypesRepository.SystemAttributes.SendAppointmentsReminder.ToString());
            if (patientsattributestypesSendAppointmentsReminder == null)
            {
                patientsattributestypesSendAppointmentsReminder = new patientsattributestypes()
                {
                    patientsattributestypes_name = PatientsAttributesTypesRepository.SystemAttributes.SendAppointmentsReminder.ToString(),
                };
                _dentnedModel.PatientsAttributesTypes.Add(patientsattributestypesSendAppointmentsReminder);
            }

            patientsattributestypesSendAppointmentsReminder.patientsattributestypes_name = "test";
            Assert.IsFalse(_dentnedModel.PatientsAttributesTypes.CanUpdate(patientsattributestypesSendAppointmentsReminder));

            patientsattributestypesSendAppointmentsReminder = _dentnedModel.PatientsAttributesTypes.FirstOrDefault(r => r.patientsattributestypes_name == PatientsAttributesTypesRepository.SystemAttributes.SendAppointmentsReminder.ToString());
            Assert.IsFalse(_dentnedModel.PatientsAttributesTypes.CanRemove(patientsattributestypesSendAppointmentsReminder));
        }
    }
}
