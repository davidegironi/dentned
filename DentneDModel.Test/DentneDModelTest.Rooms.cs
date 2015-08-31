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
        public void Rooms_Test1()
        {
            string[] errors = new string[] { };
            rooms t_rooms = null;

            _dentnedModel.Rooms.Remove(_dentnedModel.Rooms.List(r => r.rooms_name == "XX1").ToArray());
            _dentnedModel.Rooms.Remove(_dentnedModel.Rooms.List(r => r.rooms_name == "XX2").ToArray());
            
            t_rooms = new rooms()
            {
                //rooms_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.Rooms.CanAdd(t_rooms));
            
            t_rooms = new rooms()
            {
                rooms_name = "XX1"
            };
            Assert.IsTrue(_dentnedModel.Rooms.CanAdd(t_rooms));
            _dentnedModel.Rooms.Add(t_rooms);

            t_rooms = new rooms()
            {
                rooms_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.Rooms.CanAdd(t_rooms));

            t_rooms = new rooms()
            {
                rooms_name = "XX2"
            };
            _dentnedModel.Rooms.Add(t_rooms);

            t_rooms = _dentnedModel.Rooms.List(r => r.rooms_name == "XX1").FirstOrDefault();
            t_rooms.rooms_name = "XX2";
            Assert.IsFalse(_dentnedModel.Rooms.CanUpdate(t_rooms));
            t_rooms.rooms_name = "XX3";
            Assert.IsTrue(_dentnedModel.Rooms.CanUpdate(t_rooms));

            _dentnedModel.Rooms.Remove(_dentnedModel.Rooms.List(r => r.rooms_name == "XX1").ToArray());
            _dentnedModel.Rooms.Remove(_dentnedModel.Rooms.List(r => r.rooms_name == "XX2").ToArray());
        }

        [Test]
        public void Rooms_Test2()
        {
            string[] errors = new string[] { };
            patients t_patients = null;
            doctors t_doctors = null;
            rooms t_rooms = null;
            appointments t_appointments = null;

            t_patients = _dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").FirstOrDefault();
            if (t_patients != null)
                _dentnedModel.Appointments.Remove(_dentnedModel.Appointments.List(r => r.patients_id == t_patients.patients_id).ToArray());
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Rooms.Remove(_dentnedModel.Rooms.List(r => r.rooms_name == "XX1").ToArray());

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

            t_doctors = new doctors()
            {
                doctors_name = "XX1",
                doctors_surname = "XX1",
                doctors_doctext = "XXXXX",
                doctors_username = "xxxx1236",
                doctors_password = "123456"
            };
            _dentnedModel.Doctors.Add(t_doctors);

            t_rooms = new rooms()
            {
                rooms_name = "XX1"
            };
            _dentnedModel.Rooms.Add(t_rooms);

            t_appointments = new appointments()
            {
                patients_id = t_patients.patients_id,
                doctors_id = t_doctors.doctors_id,
                rooms_id = t_rooms.rooms_id,
                appointments_title = "xxx",
                appointments_from = DateTime.Now,
                appointments_to = DateTime.Now.AddMinutes(40)
            };
            _dentnedModel.Appointments.Add(t_appointments);

            Assert.IsFalse(_dentnedModel.Rooms.CanRemove(_dentnedModel.Rooms.List(r => r.rooms_name == "XX1").ToArray()));

            t_patients = _dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").FirstOrDefault();
            if (t_patients != null)
                _dentnedModel.Appointments.Remove(_dentnedModel.Appointments.List(r => r.patients_id == t_patients.patients_id).ToArray());

            Assert.IsTrue(_dentnedModel.Rooms.CanRemove(_dentnedModel.Rooms.List(r => r.rooms_name == "XX1").ToArray()));
            
            _dentnedModel.Patients.Remove(_dentnedModel.Patients.List(r => r.patients_name == "XX1" && r.patients_surname == "XX1").ToArray());
            _dentnedModel.Doctors.Remove(_dentnedModel.Doctors.List(r => r.doctors_name == "XX1" && r.doctors_surname == "XX1").ToArray());
            _dentnedModel.Rooms.Remove(_dentnedModel.Rooms.List(r => r.rooms_name == "XX1").ToArray());
        }
    }
}
