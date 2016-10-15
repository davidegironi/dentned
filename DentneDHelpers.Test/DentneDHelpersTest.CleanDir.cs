#region License
// Copyright (c) 2016 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Model.Entity;
using DG.DentneD.Model.Repositories;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace DG.DentneD.Helpers.Test
{
    [TestFixture]
    public partial class DentneDHelpersTest
    {
        [Test]
        public void CleanDir_CleanTmpdir()
        {
            if (Directory.Exists("test"))
                Directory.Delete("test", true);
            Directory.CreateDirectory("test");

            string[] messages = new string[] { };
            string[] errors = new string[] { };

            File.Create("test\\test1.txt").Dispose();
            File.SetLastWriteTime("test\\test1.txt", DateTime.Now.AddDays(-5));
            File.Create("test\\test2.txt").Dispose();
            File.SetLastWriteTime("test\\test2.txt", DateTime.Now.AddDays(-5));
            File.Create("test\\test3.txt").Dispose();
            Assert.IsTrue(File.Exists("test\\test1.txt"));
            Assert.IsTrue(File.Exists("test\\test2.txt"));
            Assert.IsTrue(File.Exists("test\\test3.txt"));
            CleanDir.CleanTmpdir("test", false, null, ref messages, ref errors);
            Assert.That(messages.Length, Is.Not.EqualTo(0));
            Assert.That(errors.Length, Is.EqualTo(0));
            Assert.IsFalse(File.Exists("test\\test1.txt"));
            Assert.IsFalse(File.Exists("test\\test2.txt"));
            Assert.IsFalse(File.Exists("test\\test3.txt"));
            File.Delete("test\\test3.txt");

            //for other methods call test, look at FileHelper.PurgeFolder         

            Directory.Delete("test");
        }

        [Test]
        public void CleanDir_CleanPatientDir()
        {
            if (Directory.Exists("test"))
                Directory.Delete("test", true);
            Directory.CreateDirectory("test");

            string[] messages = new string[] { };
            string[] errors = new string[] { };

            patients t_patients1 = null;
            patients t_patients2 = null;

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX2" && r.patients_surname == "XX2").ToArray());

            t_patients1 = new patients()
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
            _dentnedModel.Patients.Add(t_patients1);

            Directory.CreateDirectory("test\\" + t_patients1.patients_id);
            Directory.CreateDirectory("test\\" + t_patients1.patients_id + "\\test");
            File.Create("test\\" + t_patients1.patients_id + "\\test1.txt").Dispose();
            File.Create("test\\" + t_patients1.patients_id + "\\test\\test1.txt").Dispose();

            t_patients2 = new patients()
            {
                patients_name = "XX2",
                patients_surname = "XX2",
                patients_birthdate = DateTime.Now,
                patients_birthcity = "xxx",
                patients_doctext = "xxx",
                patients_sex = "M",
                patients_username = "xxxx1234",
                patients_password = "123456"
            };
            _dentnedModel.Patients.Add(t_patients2);

            Directory.CreateDirectory("test\\" + t_patients2.patients_id);
            Directory.CreateDirectory("test\\" + t_patients2.patients_id + "\\test");
            File.Create("test\\" + t_patients2.patients_id + "\\test1.txt").Dispose();
            File.Create("test\\" + t_patients2.patients_id + "\\test\\test1.txt").Dispose();

            Assert.IsTrue(Directory.Exists("test\\" + t_patients1.patients_id));
            Assert.IsTrue(File.Exists("test\\" + t_patients1.patients_id + "\\test1.txt"));
            Assert.IsTrue(File.Exists("test\\" + t_patients1.patients_id + "\\test\\test1.txt"));
            Assert.IsTrue(Directory.Exists("test\\" + t_patients2.patients_id));
            Assert.IsTrue(File.Exists("test\\" + t_patients2.patients_id + "\\test1.txt"));
            Assert.IsTrue(File.Exists("test\\" + t_patients2.patients_id + "\\test\\test1.txt"));

            CleanDir.CleanPatientDir("test", false, ref messages, ref errors);
            Assert.That(messages.Length, Is.EqualTo(0));
            Assert.That(errors.Length, Is.EqualTo(0));

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX2" && r.patients_surname == "XX2").ToArray());

            CleanDir.CleanPatientDir("test", false, ref messages, ref errors);
            Assert.That(messages.Length, Is.Not.EqualTo(0));
            Assert.That(errors.Length, Is.EqualTo(0));

            Assert.IsTrue(Directory.Exists("test\\" + t_patients1.patients_id));
            Assert.IsTrue(File.Exists("test\\" + t_patients1.patients_id + "\\test1.txt"));
            Assert.IsTrue(File.Exists("test\\" + t_patients1.patients_id + "\\test\\test1.txt"));
            Assert.IsFalse(Directory.Exists("test\\" + t_patients2.patients_id));
            Assert.IsFalse(File.Exists("test\\" + t_patients2.patients_id + "\\test1.txt"));
            Assert.IsFalse(File.Exists("test\\" + t_patients2.patients_id + "\\test\\test1.txt"));

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX2" && r.patients_surname == "XX2").ToArray());

            CleanDir.CleanPatientDir("test", true, ref messages, ref errors);
            Assert.That(messages.Length, Is.Not.EqualTo(0));
            Assert.That(errors.Length, Is.EqualTo(0));

            Assert.IsFalse(Directory.Exists("test\\" + t_patients1.patients_id));
            Assert.IsFalse(File.Exists("test\\" + t_patients1.patients_id + "\\test1.txt"));
            Assert.IsFalse(File.Exists("test\\" + t_patients1.patients_id + "\\test\\test1.txt"));
            Assert.IsFalse(Directory.Exists("test\\" + t_patients2.patients_id));
            Assert.IsFalse(File.Exists("test\\" + t_patients2.patients_id + "\\test1.txt"));
            Assert.IsFalse(File.Exists("test\\" + t_patients2.patients_id + "\\test\\test1.txt"));

            Directory.Delete("test", true);
        }

        [Test]
        public void CleanDir_CleanPatientAttachmentsDir()
        {
            if (Directory.Exists("test"))
                Directory.Delete("test", true);
            Directory.CreateDirectory("test");

            string[] messages = new string[] { };
            string[] errors = new string[] { };

            patients t_patients = null;
            patientsattachmentstypes t_patientsattachmentstypes = null;
            patientsattachments t_patientsattachments1 = null;
            patientsattachments t_patientsattachments2 = null;

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

            t_patientsattachments1 = new patientsattachments()
            {
                patients_id = t_patients.patients_id,
                patientsattachmentstypes_id = t_patientsattachmentstypes.patientsattachmentstypes_id,
                patientsattachments_value = "XX",
                patientsattachments_date = DateTime.Now,
                patientsattachments_filename = "test1.txt"
            };
            _dentnedModel.PatientsAttachments.Add(t_patientsattachments1);

            t_patientsattachments2 = new patientsattachments()
            {
                patients_id = t_patients.patients_id,
                patientsattachmentstypes_id = t_patientsattachmentstypes.patientsattachmentstypes_id,
                patientsattachments_value = "XX",
                patientsattachments_date = DateTime.Now,
                patientsattachments_filename = "test2.txt"
            };
            _dentnedModel.PatientsAttachments.Add(t_patientsattachments2);

            Directory.CreateDirectory("test\\" + t_patients.patients_id);
            File.Create("test\\" + t_patients.patients_id + "\\test1.txt").Dispose();
            File.Create("test\\" + t_patients.patients_id + "\\test2.txt").Dispose();

            Assert.IsTrue(Directory.Exists("test\\" + t_patients.patients_id));
            Assert.IsTrue(File.Exists("test\\" + t_patients.patients_id + "\\test1.txt"));
            Assert.IsTrue(File.Exists("test\\" + t_patients.patients_id + "\\test2.txt"));
            CleanDir.CleanPatientAttachmentsDir("test", false, ref messages, ref errors);
            Assert.That(messages.Length, Is.EqualTo(0));
            Assert.That(errors.Length, Is.EqualTo(0));
            Assert.IsTrue(Directory.Exists("test\\" + t_patients.patients_id));
            Assert.IsTrue(File.Exists("test\\" + t_patients.patients_id + "\\test1.txt"));
            Assert.IsTrue(File.Exists("test\\" + t_patients.patients_id + "\\test2.txt"));

            Directory.CreateDirectory("test\\" + t_patients.patients_id + "\\test");
            Assert.IsTrue(Directory.Exists("test\\" + t_patients.patients_id + "\\test"));
            CleanDir.CleanPatientAttachmentsDir("test", false, ref messages, ref errors);
            Assert.That(messages.Length, Is.Not.EqualTo(0));
            Assert.That(errors.Length, Is.EqualTo(0));
            Assert.IsFalse(Directory.Exists("test\\" + t_patients.patients_id + "\\test"));

            t_patientsattachments2.patientsattachments_filename = null;
            _dentnedModel.PatientsAttachments.Update(t_patientsattachments2);

            CleanDir.CleanPatientAttachmentsDir("test", false, ref messages, ref errors);
            Assert.That(messages.Length, Is.Not.EqualTo(0));
            Assert.That(errors.Length, Is.EqualTo(0));
            Assert.IsTrue(Directory.Exists("test\\" + t_patients.patients_id));
            Assert.IsTrue(File.Exists("test\\" + t_patients.patients_id + "\\test1.txt"));
            Assert.IsFalse(File.Exists("test\\" + t_patients.patients_id + "\\test2.txt"));

            t_patientsattachments1.patientsattachments_filename = null;
            _dentnedModel.PatientsAttachments.Update(t_patientsattachments1);

            CleanDir.CleanPatientAttachmentsDir("test", true, ref messages, ref errors);
            Assert.That(messages.Length, Is.Not.EqualTo(0));
            Assert.That(errors.Length, Is.EqualTo(0));
            Assert.IsFalse(Directory.Exists("test\\" + t_patients.patients_id));
            Assert.IsFalse(File.Exists("test\\" + t_patients.patients_id + "\\test1.txt"));
            Assert.IsFalse(File.Exists("test\\" + t_patients.patients_id + "\\test2.txt"));

            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());

            Directory.Delete("test", true);
        }

    }
}
