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
        public void ComputedLines_Test1()
        {
            string[] errors = new string[] { };
            taxes t_taxes = null;
            computedlines t_computedlines = null;

            _dentnedModel.ComputedLines.Remove(_dentnedModel.ComputedLines.List(r => r.computedlines_code == "XX1").ToArray());
            _dentnedModel.ComputedLines.Remove(_dentnedModel.ComputedLines.List(r => r.computedlines_code == "XX2").ToArray());
            _dentnedModel.Taxes.Remove(_dentnedModel.Taxes.List(r => r.taxes_name == "XX1").ToArray());

            t_taxes = new taxes()
            {
                taxes_name = "XX1",
                taxes_rate = 20
            };
            _dentnedModel.Taxes.Add(t_taxes);

            t_computedlines = new computedlines()
            {
                //computedlines_code = "XX1",
                computedlines_name = "XX1",
                taxes_id = t_taxes.taxes_id,
                computedlines_rate = 20
            };
            Assert.That(_dentnedModel.ComputedLines.CanAdd(t_computedlines), Is.EqualTo(false));

            t_computedlines = new computedlines()
            {
                computedlines_code = "XX1",
                //computedlines_name = "XX1",
                taxes_id = t_taxes.taxes_id,
                computedlines_rate = 20
            };
            Assert.That(_dentnedModel.ComputedLines.CanAdd(t_computedlines), Is.EqualTo(false));

            t_computedlines = new computedlines()
            {
                computedlines_code = "XX1",
                computedlines_name = "XX1",
                //taxes_id = t_taxes.taxes_id,
                computedlines_rate = 20
            };
            Assert.That(_dentnedModel.ComputedLines.CanAdd(t_computedlines), Is.EqualTo(true));

            t_computedlines = new computedlines()
            {
                computedlines_code = "XX1",
                computedlines_name = "XX1",
                taxes_id = -999,
                computedlines_rate = 20
            };
            Assert.That(_dentnedModel.ComputedLines.CanAdd(t_computedlines), Is.EqualTo(false));

            t_computedlines = new computedlines()
            {
                computedlines_code = "XX1",
                computedlines_name = "XX1",
                taxes_id = t_taxes.taxes_id,
                computedlines_rate = 20
            };
            Assert.That(_dentnedModel.ComputedLines.CanAdd(t_computedlines), Is.EqualTo(true));
            _dentnedModel.ComputedLines.Add(t_computedlines);

            t_computedlines = new computedlines()
            {
                computedlines_code = "XX1",
                computedlines_name = "XX1",
                computedlines_rate = 20
            };
            Assert.That(_dentnedModel.ComputedLines.CanAdd(t_computedlines), Is.EqualTo(false));

            t_computedlines = new computedlines()
            {
                computedlines_code = "XX2",
                computedlines_name = "XX2",
                computedlines_rate = 20
            };
            _dentnedModel.ComputedLines.Add(t_computedlines);

            t_computedlines = _dentnedModel.ComputedLines.FirstOrDefault(r => r.computedlines_code == "XX1");
            t_computedlines.computedlines_code = "XX2";
            Assert.That(_dentnedModel.ComputedLines.CanUpdate(t_computedlines), Is.EqualTo(false));
            t_computedlines.computedlines_code = "XX3";
            Assert.That(_dentnedModel.ComputedLines.CanUpdate(t_computedlines), Is.EqualTo(true));

            _dentnedModel.ComputedLines.Remove(_dentnedModel.ComputedLines.List(r => r.computedlines_code == "XX1").ToArray());
            _dentnedModel.ComputedLines.Remove(_dentnedModel.ComputedLines.List(r => r.computedlines_code == "XX2").ToArray());
            _dentnedModel.Taxes.Remove(_dentnedModel.Taxes.List(r => r.taxes_name == "XX1").ToArray());
        }
    }
}
