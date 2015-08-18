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
        public void Reports_Test1()
        {
            string[] errors = new string[] { };
            reports t_reports = null;

            _dentnedModel.Reports.Remove(_dentnedModel.Reports.List(r => r.reports_name == "XX1").ToArray());
            _dentnedModel.Reports.Remove(_dentnedModel.Reports.List(r => r.reports_name == "XX2").ToArray());
            
            t_reports = new reports()
            {
                //reports_name = "XX1",
                reports_query = "SELECT * FROM reports"
            };
            Assert.IsFalse(_dentnedModel.Reports.CanAdd(t_reports));
            t_reports = new reports()
            {
                reports_name = "XX1",
                //reports_query = "SELECT * FROM reports"
            };
            Assert.IsFalse(_dentnedModel.Reports.CanAdd(t_reports));

            t_reports = new reports()
            {
                reports_name = "XX1",
                reports_query = "SELECT * FROM reports"
            };
            Assert.IsTrue(_dentnedModel.Reports.CanAdd(t_reports));
            _dentnedModel.Reports.Add(t_reports);

            t_reports = new reports()
            {
                reports_name = "XX1",
                reports_query = "SELECT * FROM reports"
            };
            Assert.IsFalse(_dentnedModel.Reports.CanAdd(t_reports));

            t_reports = new reports()
            {
                reports_name = "XX2",
                reports_query = "SELECT * FROM reports"
            };
            _dentnedModel.Reports.Add(t_reports);

            t_reports = _dentnedModel.Reports.List(r => r.reports_name == "XX1").FirstOrDefault();
            t_reports.reports_name = "XX2";
            Assert.IsFalse(_dentnedModel.Reports.CanUpdate(t_reports));
            t_reports.reports_name = "XX3";
            Assert.IsTrue(_dentnedModel.Reports.CanUpdate(t_reports));

            _dentnedModel.Reports.Remove(_dentnedModel.Reports.List(r => r.reports_name == "XX1").ToArray());
            _dentnedModel.Reports.Remove(_dentnedModel.Reports.List(r => r.reports_name == "XX2").ToArray());
        }
    }
}
