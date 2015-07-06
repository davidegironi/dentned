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
        public void TreatmentsPricesLists_Test1()
        {
            string[] errors = new string[] { };
            treatmentspriceslists t_treatmentspriceslists = null;

            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX1").ToArray());
            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX2").ToArray());
            
            t_treatmentspriceslists = new treatmentspriceslists()
            {
                //treatmentspriceslists_name = "XX1",
                treatmentspriceslists_multiplier = 1
            };
            Assert.IsFalse(_dentnedModel.TreatmentsPricesLists.CanAdd(t_treatmentspriceslists));
            
            t_treatmentspriceslists = new treatmentspriceslists()
            {
                treatmentspriceslists_name = "XX1",
                treatmentspriceslists_multiplier = 1
            };
            Assert.IsTrue(_dentnedModel.TreatmentsPricesLists.CanAdd(t_treatmentspriceslists));
            _dentnedModel.TreatmentsPricesLists.Add(t_treatmentspriceslists);

            t_treatmentspriceslists = new treatmentspriceslists()
            {
                treatmentspriceslists_name = "XX1",
                treatmentspriceslists_multiplier = 1
            };
            Assert.IsFalse(_dentnedModel.TreatmentsPricesLists.CanAdd(t_treatmentspriceslists));

            t_treatmentspriceslists = new treatmentspriceslists()
            {
                treatmentspriceslists_name = "XX2",
                treatmentspriceslists_multiplier = 1
            };
            _dentnedModel.TreatmentsPricesLists.Add(t_treatmentspriceslists);

            t_treatmentspriceslists = _dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX1").FirstOrDefault();
            t_treatmentspriceslists.treatmentspriceslists_name = "XX2";
            Assert.IsFalse(_dentnedModel.TreatmentsPricesLists.CanUpdate(t_treatmentspriceslists));
            t_treatmentspriceslists.treatmentspriceslists_name = "XX3";
            Assert.IsTrue(_dentnedModel.TreatmentsPricesLists.CanUpdate(t_treatmentspriceslists));

            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX1").ToArray());
            _dentnedModel.TreatmentsPricesLists.Remove(_dentnedModel.TreatmentsPricesLists.List(r => r.treatmentspriceslists_name == "XX2").ToArray());
        }
    }
}
