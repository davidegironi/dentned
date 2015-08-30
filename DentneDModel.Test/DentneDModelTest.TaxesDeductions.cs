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
        public void TaxesDeductions_Test1()
        {
            string[] errors = new string[] { };
            taxesdeductions t_taxesdeductions = null;

            _dentnedModel.TaxesDeductions.Remove(_dentnedModel.TaxesDeductions.List(r => r.taxesdeductions_name == "XX1").ToArray());
            _dentnedModel.TaxesDeductions.Remove(_dentnedModel.TaxesDeductions.List(r => r.taxesdeductions_name == "XX2").ToArray());
            
            t_taxesdeductions = new taxesdeductions()
            {
                //taxesdeductions_name = "XX1",
                taxesdeductions_rate = 20
            };
            Assert.IsFalse(_dentnedModel.TaxesDeductions.CanAdd(t_taxesdeductions));

            t_taxesdeductions = new taxesdeductions()
            {
                taxesdeductions_name = "XX1",
                taxesdeductions_rate = -20
            };
            Assert.IsFalse(_dentnedModel.TaxesDeductions.CanAdd(t_taxesdeductions));

            t_taxesdeductions = new taxesdeductions()
            {
                taxesdeductions_name = "XX1",
                taxesdeductions_rate = 20
            };
            Assert.IsTrue(_dentnedModel.TaxesDeductions.CanAdd(t_taxesdeductions));
            _dentnedModel.TaxesDeductions.Add(t_taxesdeductions);

            t_taxesdeductions = new taxesdeductions()
            {
                taxesdeductions_name = "XX1",
                taxesdeductions_rate = 20
            };
            Assert.IsFalse(_dentnedModel.TaxesDeductions.CanAdd(t_taxesdeductions));

            t_taxesdeductions = new taxesdeductions()
            {
                taxesdeductions_name = "XX2",
                taxesdeductions_rate = 20
            };
            _dentnedModel.TaxesDeductions.Add(t_taxesdeductions);

            t_taxesdeductions = _dentnedModel.TaxesDeductions.List(r => r.taxesdeductions_name == "XX1").FirstOrDefault();
            t_taxesdeductions.taxesdeductions_name = "XX2";
            Assert.IsFalse(_dentnedModel.TaxesDeductions.CanUpdate(t_taxesdeductions));
            t_taxesdeductions.taxesdeductions_name = "XX3";
            Assert.IsTrue(_dentnedModel.TaxesDeductions.CanUpdate(t_taxesdeductions));

            _dentnedModel.TaxesDeductions.Remove(_dentnedModel.TaxesDeductions.List(r => r.taxesdeductions_name == "XX1").ToArray());
            _dentnedModel.TaxesDeductions.Remove(_dentnedModel.TaxesDeductions.List(r => r.taxesdeductions_name == "XX2").ToArray());
        }
    }
}
