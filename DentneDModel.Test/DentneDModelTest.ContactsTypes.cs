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
        public void ContactsTypes_Test1()
        {
            string[] errors = new string[] { };
            contactstypes t_contactstypes = null;

            _dentnedModel.ContactsTypes.Remove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray());
            _dentnedModel.ContactsTypes.Remove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX2").ToArray());

            t_contactstypes = new contactstypes()
            {
                //contactstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.ContactsTypes.CanAdd(t_contactstypes));

            t_contactstypes = new contactstypes()
            {
                contactstypes_name = "XX1"
            };
            Assert.IsTrue(_dentnedModel.ContactsTypes.CanAdd(t_contactstypes));
            _dentnedModel.ContactsTypes.Add(t_contactstypes);

            t_contactstypes = new contactstypes()
            {
                contactstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.ContactsTypes.CanAdd(t_contactstypes));

            t_contactstypes = new contactstypes()
            {
                contactstypes_name = "XX2"
            };
            _dentnedModel.ContactsTypes.Add(t_contactstypes);

            t_contactstypes = _dentnedModel.ContactsTypes.FirstOrDefault(r => r.contactstypes_name == "XX1");
            t_contactstypes.contactstypes_name = "XX2";
            Assert.IsFalse(_dentnedModel.ContactsTypes.CanUpdate(t_contactstypes));
            t_contactstypes.contactstypes_name = "XX3";
            Assert.IsTrue(_dentnedModel.ContactsTypes.CanUpdate(t_contactstypes));

            _dentnedModel.ContactsTypes.Remove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray());
            _dentnedModel.ContactsTypes.Remove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX2").ToArray());
        }

        [Test]
        public void ContactsTypes_Test2()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            contactstypes t_contactstypes = null;
            patientscontacts t_patientscontacts = null;

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.ContactsTypes.Remove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray());

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

            t_contactstypes = new contactstypes()
            {
                contactstypes_name = "XX1"
            };
            _dentnedModel.ContactsTypes.Add(t_contactstypes);

            t_patientscontacts = new patientscontacts()
            {
                patients_id = t_patients.patients_id,
                contactstypes_id = t_contactstypes.contactstypes_id,
                patientscontacts_value = "XX"
            };
            _dentnedModel.PatientsContacts.Add(t_patientscontacts);

            Assert.IsFalse(_dentnedModel.ContactsTypes.CanRemove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray()));

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            Assert.IsTrue(_dentnedModel.ContactsTypes.CanRemove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray()));

            _dentnedModel.ContactsTypes.Remove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray());
        }
    }
}
