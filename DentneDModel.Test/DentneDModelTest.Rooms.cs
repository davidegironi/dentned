#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System.Linq;
using DG.DentneD.Model.Entity;
using NUnit.Framework;

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
    }
}
