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
        public void ContactsTypes_Test1()
        {
            string[] errors = new string[] { };
            contactstypes t_contactstypes = null;

            _dentnedModel.ContactsTypes.Remove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray());
            _dentnedModel.ContactsTypes.Remove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX2").ToArray());
            
            t_contactstypes = new contactstypes()
            {
                //contactstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.ContactsTypes.CanAdd(t_contactstypes));
            
            t_contactstypes = new contactstypes()
            {
                contactstypes_name = "XX1"
            };
            Assert.IsTrue(_dentnedModel.ContactsTypes.CanAdd(t_contactstypes));
            _dentnedModel.ContactsTypes.Add(t_contactstypes);

            t_contactstypes = new contactstypes()
            {
                contactstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.ContactsTypes.CanAdd(t_contactstypes));

            t_contactstypes = new contactstypes()
            {
                contactstypes_name = "XX2"
            };
            _dentnedModel.ContactsTypes.Add(t_contactstypes);

            t_contactstypes = _dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").FirstOrDefault();
            t_contactstypes.contactstypes_name = "XX2";
            Assert.IsFalse(_dentnedModel.ContactsTypes.CanUpdate(t_contactstypes));
            t_contactstypes.contactstypes_name = "XX3";
            Assert.IsTrue(_dentnedModel.ContactsTypes.CanUpdate(t_contactstypes));

            _dentnedModel.ContactsTypes.Remove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX1").ToArray());
            _dentnedModel.ContactsTypes.Remove(_dentnedModel.ContactsTypes.List(r => r.contactstypes_name == "XX2").ToArray());
        }
    }
}
