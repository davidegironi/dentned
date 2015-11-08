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
        public void MedicalrecordsTypes_Test1()
        {
            string[] errors = new string[] { };
            medicalrecordstypes t_medicalrecordstypes = null;

            _dentnedModel.MedicalrecordsTypes.Remove(_dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX1").ToArray());
            _dentnedModel.MedicalrecordsTypes.Remove(_dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX2").ToArray());

            t_medicalrecordstypes = new medicalrecordstypes()
            {
                //medicalrecordstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.MedicalrecordsTypes.CanAdd(t_medicalrecordstypes));

            t_medicalrecordstypes = new medicalrecordstypes()
            {
                medicalrecordstypes_name = "XX1"
            };
            Assert.IsTrue(_dentnedModel.MedicalrecordsTypes.CanAdd(t_medicalrecordstypes));
            _dentnedModel.MedicalrecordsTypes.Add(t_medicalrecordstypes);

            t_medicalrecordstypes = new medicalrecordstypes()
            {
                medicalrecordstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.MedicalrecordsTypes.CanAdd(t_medicalrecordstypes));

            t_medicalrecordstypes = new medicalrecordstypes()
            {
                medicalrecordstypes_name = "XX2"
            };
            _dentnedModel.MedicalrecordsTypes.Add(t_medicalrecordstypes);

            t_medicalrecordstypes = _dentnedModel.MedicalrecordsTypes.FirstOrDefault(r => r.medicalrecordstypes_name == "XX1");
            t_medicalrecordstypes.medicalrecordstypes_name = "XX2";
            Assert.IsFalse(_dentnedModel.MedicalrecordsTypes.CanUpdate(t_medicalrecordstypes));
            t_medicalrecordstypes.medicalrecordstypes_name = "XX3";
            Assert.IsTrue(_dentnedModel.MedicalrecordsTypes.CanUpdate(t_medicalrecordstypes));

            _dentnedModel.MedicalrecordsTypes.Remove(_dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX1").ToArray());
            _dentnedModel.MedicalrecordsTypes.Remove(_dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX2").ToArray());
        }

        [Test]
        public void MedicalrecordsTypes_Test2()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            medicalrecordstypes t_medicalrecordstypes = null;
            patientsmedicalrecords t_patientsmedicalrecords = null;

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.MedicalrecordsTypes.Remove(_dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX1").ToArray());

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

            t_medicalrecordstypes = new medicalrecordstypes()
            {
                medicalrecordstypes_name = "XX1"
            };
            _dentnedModel.MedicalrecordsTypes.Add(t_medicalrecordstypes);

            t_patientsmedicalrecords = new patientsmedicalrecords()
            {
                patients_id = t_patients.patients_id,
                medicalrecordstypes_id = t_medicalrecordstypes.medicalrecordstypes_id,
                patientsmedicalrecords_value = "ttt"
            };
            _dentnedModel.PatientsMedicalrecords.Add(t_patientsmedicalrecords);

            Assert.IsFalse(_dentnedModel.MedicalrecordsTypes.CanRemove(_dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX1").ToArray()));

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            Assert.IsTrue(_dentnedModel.MedicalrecordsTypes.CanRemove(_dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX1").ToArray()));

            _dentnedModel.MedicalrecordsTypes.Remove(_dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX1").ToArray());
        }
    }
}
