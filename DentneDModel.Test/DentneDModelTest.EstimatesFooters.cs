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
        public void EstimatesFooters_Test1()
        {
            string[] errors = new string[] { };
            estimatesfooters t_estimatesfooters = null;

            _dentnedModel.EstimatesFooters.Remove(_dentnedModel.EstimatesFooters.List(r => r.estimatesfooters_name == "XX1").ToArray());
            _dentnedModel.EstimatesFooters.Remove(_dentnedModel.EstimatesFooters.List(r => r.estimatesfooters_name == "XX2").ToArray());
            
            t_estimatesfooters = new estimatesfooters()
            {
                //estimatesfooters_name = "XX1",
                estimatesfooters_doctext = "xxx"
            };
            Assert.IsFalse(_dentnedModel.EstimatesFooters.CanAdd(t_estimatesfooters));

            t_estimatesfooters = new estimatesfooters()
            {
                estimatesfooters_name = "XX1",
                //estimatesfooters_doctext = "xxx"
            };
            Assert.IsFalse(_dentnedModel.EstimatesFooters.CanAdd(t_estimatesfooters));

            t_estimatesfooters = new estimatesfooters()
            {
                estimatesfooters_name = "XX1",
                estimatesfooters_doctext = "xxx"
            };
            Assert.IsTrue(_dentnedModel.EstimatesFooters.CanAdd(t_estimatesfooters));
            _dentnedModel.EstimatesFooters.Add(t_estimatesfooters);

            t_estimatesfooters = new estimatesfooters()
            {
                estimatesfooters_name = "XX1",
                estimatesfooters_doctext = "xxx"
            };
            Assert.IsFalse(_dentnedModel.EstimatesFooters.CanAdd(t_estimatesfooters));

            t_estimatesfooters = new estimatesfooters()
            {
                estimatesfooters_name = "XX2",
                estimatesfooters_doctext = "xxx"
            };
            _dentnedModel.EstimatesFooters.Add(t_estimatesfooters);

            t_estimatesfooters = _dentnedModel.EstimatesFooters.List(r => r.estimatesfooters_name == "XX1").FirstOrDefault();
            t_estimatesfooters.estimatesfooters_name = "XX2";
            Assert.IsFalse(_dentnedModel.EstimatesFooters.CanUpdate(t_estimatesfooters));
            t_estimatesfooters.estimatesfooters_name = "XX3";
            Assert.IsTrue(_dentnedModel.EstimatesFooters.CanUpdate(t_estimatesfooters));

            _dentnedModel.EstimatesFooters.Remove(_dentnedModel.EstimatesFooters.List(r => r.estimatesfooters_name == "XX1").ToArray());
            _dentnedModel.EstimatesFooters.Remove(_dentnedModel.EstimatesFooters.List(r => r.estimatesfooters_name == "XX2").ToArray());
        }
    }
}
