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
        public void TreatmentsTypes_Test1()
        {
            string[] errors = new string[] { };
            treatmentstypes t_treatmentstypes = null;

            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX2").ToArray());

            t_treatmentstypes = new treatmentstypes()
            {
                //treatmentstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.TreatmentsTypes.CanAdd(t_treatmentstypes));

            t_treatmentstypes = new treatmentstypes()
            {
                treatmentstypes_name = "XX1"
            };
            Assert.IsTrue(_dentnedModel.TreatmentsTypes.CanAdd(t_treatmentstypes));
            _dentnedModel.TreatmentsTypes.Add(t_treatmentstypes);

            t_treatmentstypes = new treatmentstypes()
            {
                treatmentstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.TreatmentsTypes.CanAdd(t_treatmentstypes));

            t_treatmentstypes = new treatmentstypes()
            {
                treatmentstypes_name = "XX2"
            };
            _dentnedModel.TreatmentsTypes.Add(t_treatmentstypes);

            t_treatmentstypes = _dentnedModel.TreatmentsTypes.FirstOrDefault(r => r.treatmentstypes_name == "XX1");
            t_treatmentstypes.treatmentstypes_name = "XX2";
            Assert.IsFalse(_dentnedModel.TreatmentsTypes.CanUpdate(t_treatmentstypes));
            t_treatmentstypes.treatmentstypes_name = "XX3";
            Assert.IsTrue(_dentnedModel.TreatmentsTypes.CanUpdate(t_treatmentstypes));

            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX2").ToArray());
        }

        [Test]
        public void TreatmentsTypes_Test2()
        {
            string[] errors = new string[] { };
            taxes t_taxes = null;
            treatments t_treatments = null;
            treatmentstypes t_treatmentstypes = null;

            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _dentnedModel.Taxes.Remove(_dentnedModel.Taxes.List(r => r.taxes_name == "XX1").ToArray());

            t_taxes = new taxes()
            {
                taxes_name = "XX1",
                taxes_rate = 20
            };
            _dentnedModel.Taxes.Add(t_taxes);

            t_treatmentstypes = new treatmentstypes()
            {
                treatmentstypes_name = "XX1"
            };
            _dentnedModel.TreatmentsTypes.Add(t_treatmentstypes);

            t_treatments = new treatments()
            {
                treatmentstypes_id = t_treatmentstypes.treatmentstypes_id,
                taxes_id = t_taxes.taxes_id,
                treatments_code = "XX1",
                treatments_name = "XX1",
                treatments_price = 10
            };
            _dentnedModel.Treatments.Add(t_treatments);

            Assert.IsFalse(_dentnedModel.TreatmentsTypes.CanRemove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray()));

            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());

            Assert.IsTrue(_dentnedModel.TreatmentsTypes.CanRemove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray()));

            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _dentnedModel.Taxes.Remove(_dentnedModel.Taxes.List(r => r.taxes_name == "XX1").ToArray());
        }
    }
}
