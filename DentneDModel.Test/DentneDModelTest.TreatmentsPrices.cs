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
        public void TreatmentsPrices_Test1()
        {
            string[] errors = new string[] { };
            treatmentsprices t_treatmentsprices = null;
            treatments t_treatments1 = null;
            treatments t_treatments2 = null;
            treatmentstypes t_treatmentstypes = null;
            treatmentspriceslists t_treatmentspriceslists = null;

            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX2").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX1").ToArray());

            t_treatmentspriceslists = new treatmentspriceslists()
            {
                treatmentspriceslists_name = "XX1"
            };
            _dentnedModel.TreatmentsPricesLists.Add(t_treatmentspriceslists);
            
            t_treatmentstypes = new treatmentstypes()
            {
                treatmentstypes_name = "XX1"
            };
            _dentnedModel.TreatmentsTypes.Add(t_treatmentstypes);

            t_treatments1 = new treatments()
            {
                treatmentstypes_id = t_treatmentstypes.treatmentstypes_id,
                treatments_code = "XX1",
                treatments_name = "XX1",
                treatments_price = 10
            };
            _dentnedModel.Treatments.Add(t_treatments1);

            t_treatments2 = new treatments()
            {
                treatmentstypes_id = t_treatmentstypes.treatmentstypes_id,
                treatments_code = "XX2",
                treatments_name = "XX2",
                treatments_price = 10
            };
            _dentnedModel.Treatments.Add(t_treatments2);

            t_treatmentsprices = new treatmentsprices()
            {
                //treatments_id = t_treatments1.treatments_id,
                treatmentspriceslists_id = t_treatmentspriceslists.treatmentspriceslists_id,
                treatmentsprices_price = 10
            };
            Assert.IsFalse(_dentnedModel.TreatmentsPrices.CanAdd(t_treatmentsprices));

            t_treatmentsprices = new treatmentsprices()
            {
                treatments_id = t_treatments1.treatments_id,
                //treatmentspriceslists_id = t_treatmentspriceslists.treatmentspriceslists_id,
                treatmentsprices_price = 10
            };
            Assert.IsFalse(_dentnedModel.TreatmentsPrices.CanAdd(t_treatmentsprices));

            t_treatmentsprices = new treatmentsprices()
            {
                treatments_id = t_treatments1.treatments_id,
                treatmentspriceslists_id = t_treatmentspriceslists.treatmentspriceslists_id,
                treatmentsprices_price = 10
            };
            Assert.IsTrue(_dentnedModel.TreatmentsPrices.CanAdd(t_treatmentsprices));
            _dentnedModel.TreatmentsPrices.Add(t_treatmentsprices);

            t_treatmentsprices = new treatmentsprices()
            {
                treatments_id = t_treatments1.treatments_id,
                treatmentspriceslists_id = t_treatmentspriceslists.treatmentspriceslists_id,
                treatmentsprices_price = 10
            };
            Assert.IsFalse(_dentnedModel.TreatmentsPrices.CanAdd(t_treatmentsprices));

            t_treatmentsprices = new treatmentsprices()
            {
                treatments_id = t_treatments2.treatments_id,
                treatmentspriceslists_id = t_treatmentspriceslists.treatmentspriceslists_id,
                treatmentsprices_price = 20
            };
            Assert.IsTrue(_dentnedModel.TreatmentsPrices.CanAdd(t_treatmentsprices));
            _dentnedModel.TreatmentsPrices.Add(t_treatmentsprices);

            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX1").ToArray());
            _dentnedModel.Treatments.Remove(_dentnedModel.Treatments.List(r => r.treatments_code == "XX2").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX1").ToArray());
        }
    }
}
