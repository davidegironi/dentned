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
        public void AddressesTypes_Test1()
        {
            string[] errors = new string[] { };
            addressestypes t_addressestypes = null;

            _dentnedModel.AddressesTypes.Remove(_dentnedModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").ToArray());
            _dentnedModel.AddressesTypes.Remove(_dentnedModel.AddressesTypes.List(r => r.addressestypes_name == "XX2").ToArray());
            
            t_addressestypes = new addressestypes()
            {
                //addressestypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.AddressesTypes.CanAdd(t_addressestypes));
            
            t_addressestypes = new addressestypes()
            {
                addressestypes_name = "XX1"
            };
            Assert.IsTrue(_dentnedModel.AddressesTypes.CanAdd(t_addressestypes));
            _dentnedModel.AddressesTypes.Add(t_addressestypes);

            t_addressestypes = new addressestypes()
            {
                addressestypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.AddressesTypes.CanAdd(t_addressestypes));

            t_addressestypes = new addressestypes()
            {
                addressestypes_name = "XX2"
            };
            _dentnedModel.AddressesTypes.Add(t_addressestypes);

            t_addressestypes = _dentnedModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").FirstOrDefault();
            t_addressestypes.addressestypes_name = "XX2";
            Assert.IsFalse(_dentnedModel.AddressesTypes.CanUpdate(t_addressestypes));
            t_addressestypes.addressestypes_name = "XX3";
            Assert.IsTrue(_dentnedModel.AddressesTypes.CanUpdate(t_addressestypes));

            _dentnedModel.AddressesTypes.Remove(_dentnedModel.AddressesTypes.List(r => r.addressestypes_name == "XX1").ToArray());
            _dentnedModel.AddressesTypes.Remove(_dentnedModel.AddressesTypes.List(r => r.addressestypes_name == "XX2").ToArray());
        }
    }
}
