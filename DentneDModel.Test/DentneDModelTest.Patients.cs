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
        public void Patients_Test1()
        {
            string[] errors = new string[] { };
            patients t_patients = null;

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            
            t_patients = new patients()
            {
                //patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M"
            };
            Assert.IsFalse(_dentnedModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                //patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M"
            };
            Assert.IsFalse(_dentnedModel.Patients.CanAdd(t_patients));
            
            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                //patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M"
            };
            Assert.IsFalse(_dentnedModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                //patients_doctext = "xxx",
                patients_sex = "M"
            };
            Assert.IsFalse(_dentnedModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "X"
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
                treatmentspriceslists_id = -1
            };
            Assert.IsFalse(_dentnedModel.Patients.CanAdd(t_patients));

            t_patients = new patients()
            {
                patients_name = "XX1",
                patients_surname = "XX1",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M"
            };
            Assert.IsTrue(_dentnedModel.Patients.CanAdd(t_patients));
            _dentnedModel.Patients.Add(t_patients);
            
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
        }
    }
}
