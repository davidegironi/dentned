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
        public void PatientsAddresses_Test1()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            addressestypes t_addressestypes = null;
            patientsaddresses t_patientsaddresses = null;
            
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.AddressesTypes.Remove(_dentnedModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").ToArray());

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

            t_addressestypes = new addressestypes()
            {
                addressestypes_name = "XX1"
            };
            _dentnedModel.AddressesTypes.Add(t_addressestypes);

            t_patientsaddresses = new patientsaddresses()
            {
                //patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            Assert.IsFalse(_dentnedModel.PatientsAddresses.CanAdd(t_patientsaddresses));

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                //addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            Assert.IsFalse(_dentnedModel.PatientsAddresses.CanAdd(t_patientsaddresses));

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                //patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            Assert.IsFalse(_dentnedModel.PatientsAddresses.CanAdd(t_patientsaddresses));

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                //patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            Assert.IsFalse(_dentnedModel.PatientsAddresses.CanAdd(t_patientsaddresses));

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                //patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            Assert.IsFalse(_dentnedModel.PatientsAddresses.CanAdd(t_patientsaddresses));

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                //patientsaddresses_zipcode = "XX"
            };
            Assert.IsFalse(_dentnedModel.PatientsAddresses.CanAdd(t_patientsaddresses));

            t_patientsaddresses = new patientsaddresses()
            {
                patients_id = t_patients.patients_id,
                addressestypes_id = t_addressestypes.addressestypes_id,
                patientsaddresses_state = "XX",
                patientsaddresses_city = "XX",
                patientsaddresses_street = "XX",
                patientsaddresses_zipcode = "XX"
            };
            Assert.IsTrue(_dentnedModel.PatientsAddresses.CanAdd(t_patientsaddresses));
            _dentnedModel.PatientsAddresses.Add(t_patientsaddresses);

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.AddressesTypes.Remove(_dentnedModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").ToArray());
        }
    }
}
