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
        public void Doctors_Test1()
        {
            string[] errors = new string[] { };
            doctors t_doctors = null;
            patients t_patients = null;

            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX2" && r.doctors_surname == "XX2").ToArray());
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            t_doctors = new doctors()
            {
                //doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_dentnedModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                //doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_dentnedModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                //doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_dentnedModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                //doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_dentnedModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                //doctors_password = "123456"
            };
            Assert.IsFalse(_dentnedModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xXxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_dentnedModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "X23456"
            };
            Assert.IsFalse(_dentnedModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsTrue(_dentnedModel.Doctors.CanAdd(t_doctors));
            _dentnedModel.Doctors.Add(t_doctors);

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_dentnedModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX2",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.IsFalse(_dentnedModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX2",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1235",
                doctors_password = "123456"
            };
            Assert.IsTrue(_dentnedModel.Doctors.CanAdd(t_doctors));

            t_doctors = new doctors()
            {
                doctors_name = "XX2",
                doctors_surname = "XX2",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1235",
                doctors_password = "123456"
            };
            _dentnedModel.Doctors.Add(t_doctors);

            t_doctors = _dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").FirstOrDefault();
            t_doctors.doctors_name = "XX2";
            t_doctors.doctors_surname = "XX2";
            Assert.IsFalse(_dentnedModel.Doctors.CanUpdate(t_doctors));
            t_doctors.doctors_name = "XX3";
            t_doctors.doctors_surname = "XX3";
            Assert.IsTrue(_dentnedModel.Doctors.CanUpdate(t_doctors));

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
            Assert.IsFalse(_dentnedModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1236",
                patients_password = "123456"
            };
            Assert.IsTrue(_dentnedModel.Patients.CanAdd(t_patients));

            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX2" && r.doctors_surname == "XX2").ToArray());
        }
    }
}
