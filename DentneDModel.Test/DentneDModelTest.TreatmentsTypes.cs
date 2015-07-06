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

            t_treatmentstypes = _dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").FirstOrDefault();
            t_treatmentstypes.treatmentstypes_name = "XX2";
            Assert.IsFalse(_dentnedModel.TreatmentsTypes.CanUpdate(t_treatmentstypes));
            t_treatmentstypes.treatmentstypes_name = "XX3";
            Assert.IsTrue(_dentnedModel.TreatmentsTypes.CanUpdate(t_treatmentstypes));

            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX1").ToArray());
            _dentnedModel.TreatmentsTypes.Remove(_dentnedModel.TreatmentsTypes.List(r => r.treatmentstypes_name == "XX2").ToArray());
        }
    }
}
