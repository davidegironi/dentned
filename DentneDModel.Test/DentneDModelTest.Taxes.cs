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
        public void Taxes_Test1()
        {
            string[] errors = new string[] { };
            taxes t_taxes = null;

            _dentnedModel.Taxes.Remove(_dentnedModel.Taxes.List(r => r.taxes_name == "XX1").ToArray());
            _dentnedModel.Taxes.Remove(_dentnedModel.Taxes.List(r => r.taxes_name == "XX2").ToArray());
            
            t_taxes = new taxes()
            {
                //taxes_name = "XX1",
                taxes_rate = 20
            };
            Assert.IsFalse(_dentnedModel.Taxes.CanAdd(t_taxes));

            t_taxes = new taxes()
            {
                taxes_name = "XX1",
                taxes_rate = -20
            };
            Assert.IsFalse(_dentnedModel.Taxes.CanAdd(t_taxes));

            t_taxes = new taxes()
            {
                taxes_name = "XX1",
                taxes_rate = 20
            };
            Assert.IsTrue(_dentnedModel.Taxes.CanAdd(t_taxes));
            _dentnedModel.Taxes.Add(t_taxes);

            t_taxes = new taxes()
            {
                taxes_name = "XX1",
                taxes_rate = 20
            };
            Assert.IsFalse(_dentnedModel.Taxes.CanAdd(t_taxes));

            t_taxes = new taxes()
            {
                taxes_name = "XX2",
                taxes_rate = 20
            };
            _dentnedModel.Taxes.Add(t_taxes);

            t_taxes = _dentnedModel.Taxes.List(r => r.taxes_name == "XX1").FirstOrDefault();
            t_taxes.taxes_name = "XX2";
            Assert.IsFalse(_dentnedModel.Taxes.CanUpdate(t_taxes));
            t_taxes.taxes_name = "XX3";
            Assert.IsTrue(_dentnedModel.Taxes.CanUpdate(t_taxes));

            _dentnedModel.Taxes.Remove(_dentnedModel.Taxes.List(r => r.taxes_name == "XX1").ToArray());
            _dentnedModel.Taxes.Remove(_dentnedModel.Taxes.List(r => r.taxes_name == "XX2").ToArray());
        }
    }
}
