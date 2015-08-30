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
        public void PatientsContacts_Test1()
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
                //patients_id = t_patients.patients_id,
                contactstypes_id = t_contactstypes.contactstypes_id,
                patientscontacts_value = "XX"
            };
            Assert.IsFalse(_dentnedModel.PatientsContacts.CanAdd(t_patientscontacts));

            t_patientscontacts = new patientscontacts()
            {
                patients_id = t_patients.patients_id,
                //contactstypes_id = t_contactstypes.contactstypes_id,
                patientscontacts_value = "XX"
            };
            Assert.IsFalse(_dentnedModel.PatientsContacts.CanAdd(t_patientscontacts));

            t_patientscontacts = new patientscontacts()
            {
                patients_id = t_patients.patients_id,
                contactstypes_id = t_contactstypes.contactstypes_id,
                //patientscontacts_value = "XX"
            };
            Assert.IsFalse(_dentnedModel.PatientsContacts.CanAdd(t_patientscontacts));

            t_patientscontacts = new patientscontacts()
            {
                patients_id = t_patients.patients_id,
                contactstypes_id = t_contactstypes.contactstypes_id,
                patientscontacts_value = "XX"
            };
            Assert.IsTrue(_dentnedModel.PatientsContacts.CanAdd(t_patientscontacts));
            _dentnedModel.PatientsContacts.Add(t_patientscontacts);

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.ContactsTypes.Remove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray());
        }
    }
}
