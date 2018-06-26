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
        public void Payments_Test1()
        {
            string[] errors = new string[] { };
            payments t_payments = null;
            patients t_patients = null;

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

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

            t_payments = new payments()
            {
                payments_amount = (decimal)-20,
                payments_date = DateTime.Now,
                patients_id = t_patients.patients_id
            };
            Assert.IsFalse(_dentnedModel.Payments.CanAdd(t_payments));

            t_payments = new payments()
            {
                payments_amount = (decimal)10.10,
                payments_date = DateTime.Now,
                //patients_id = t_patients.patients_id
            };
            Assert.IsFalse(_dentnedModel.Payments.CanAdd(t_payments));

            t_payments = new payments()
            {
                payments_amount = (decimal)10.10,
                payments_date = DateTime.Now,
                patients_id = t_patients.patients_id
            };
            Assert.IsTrue(_dentnedModel.Payments.CanAdd(t_payments));
            _dentnedModel.Payments.Add(t_payments);

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
        }
    }
}
