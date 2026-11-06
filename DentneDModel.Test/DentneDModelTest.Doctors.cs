#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Model.Entity;
using NUnit.Framework;
using System.Linq;

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

            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX2" && r.doctors_surname == "XX2").ToArray());

            t_doctors = new doctors()
            {
                //doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.That(_dentnedModel.Doctors.CanAdd(t_doctors), Is.EqualTo(false));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                //doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.That(_dentnedModel.Doctors.CanAdd(t_doctors), Is.EqualTo(false));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                //doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.That(_dentnedModel.Doctors.CanAdd(t_doctors), Is.EqualTo(false));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                //doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.That(_dentnedModel.Doctors.CanAdd(t_doctors), Is.EqualTo(false));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                //doctors_password = "123456"
            };
            Assert.That(_dentnedModel.Doctors.CanAdd(t_doctors), Is.EqualTo(false));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xXxx1234",
                doctors_password = "123456"
            };
            Assert.That(_dentnedModel.Doctors.CanAdd(t_doctors), Is.EqualTo(false));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "X23456"
            };
            Assert.That(_dentnedModel.Doctors.CanAdd(t_doctors), Is.EqualTo(false));

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.That(_dentnedModel.Doctors.CanAdd(t_doctors), Is.EqualTo(true));
            _dentnedModel.Doctors.Add(t_doctors);

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.That(_dentnedModel.Doctors.CanAdd(t_doctors), Is.EqualTo(false));

            t_doctors = new doctors()
            {
                doctors_name = "XX2",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1234",
                doctors_password = "123456"
            };
            Assert.That(_dentnedModel.Doctors.CanAdd(t_doctors), Is.EqualTo(false));

            t_doctors = new doctors()
            {
                doctors_name = "XX2",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1235",
                doctors_password = "123456"
            };
            Assert.That(_dentnedModel.Doctors.CanAdd(t_doctors), Is.EqualTo(true));

            t_doctors = new doctors()
            {
                doctors_name = "XX2",
                doctors_surname = "XX2",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1235",
                doctors_password = "123456"
            };
            _dentnedModel.Doctors.Add(t_doctors);

            t_doctors = _dentnedModel.Doctors.FirstOrDefault(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1");
            t_doctors.doctors_name = "XX2";
            t_doctors.doctors_surname = "XX2";
            Assert.That(_dentnedModel.Doctors.CanUpdate(t_doctors), Is.EqualTo(false));
            t_doctors.doctors_name = "XX3";
            t_doctors.doctors_surname = "XX3";
            Assert.That(_dentnedModel.Doctors.CanUpdate(t_doctors), Is.EqualTo(true));

            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX2" && r.doctors_surname == "XX2").ToArray());
        }
    }
}
