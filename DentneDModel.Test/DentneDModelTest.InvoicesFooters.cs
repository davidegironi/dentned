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
        public void InvoicesFooters_Test1()
        {
            string[] errors = new string[] { };
            invoicesfooters t_invoicesfooters = null;

            _dentnedModel.InvoicesFooters.Remove(_dentnedModel.InvoicesFooters.List(r => r.invoicesfooters_name == "XX1").ToArray());
            _dentnedModel.InvoicesFooters.Remove(_dentnedModel.InvoicesFooters.List(r => r.invoicesfooters_name == "XX2").ToArray());

            t_invoicesfooters = new invoicesfooters()
            {
                //invoicesfooters_name = "XX1",
                invoicesfooters_doctext = "xxx"
            };
            Assert.IsFalse(_dentnedModel.InvoicesFooters.CanAdd(t_invoicesfooters));

            t_invoicesfooters = new invoicesfooters()
            {
                invoicesfooters_name = "XX1",
                //invoicesfooters_doctext = "xxx"
            };
            Assert.IsFalse(_dentnedModel.InvoicesFooters.CanAdd(t_invoicesfooters));

            t_invoicesfooters = new invoicesfooters()
            {
                invoicesfooters_name = "XX1",
                invoicesfooters_doctext = "xxx"
            };
            Assert.IsTrue(_dentnedModel.InvoicesFooters.CanAdd(t_invoicesfooters));
            _dentnedModel.InvoicesFooters.Add(t_invoicesfooters);

            t_invoicesfooters = new invoicesfooters()
            {
                invoicesfooters_name = "XX1",
                invoicesfooters_doctext = "xxx"
            };
            Assert.IsFalse(_dentnedModel.InvoicesFooters.CanAdd(t_invoicesfooters));

            t_invoicesfooters = new invoicesfooters()
            {
                invoicesfooters_name = "XX2",
                invoicesfooters_doctext = "xxx"
            };
            _dentnedModel.InvoicesFooters.Add(t_invoicesfooters);

            t_invoicesfooters = _dentnedModel.InvoicesFooters.FirstOrDefault(r => r.invoicesfooters_name == "XX1");
            t_invoicesfooters.invoicesfooters_name = "XX2";
            Assert.IsFalse(_dentnedModel.InvoicesFooters.CanUpdate(t_invoicesfooters));
            t_invoicesfooters.invoicesfooters_name = "XX3";
            Assert.IsTrue(_dentnedModel.InvoicesFooters.CanUpdate(t_invoicesfooters));

            _dentnedModel.InvoicesFooters.Remove(_dentnedModel.InvoicesFooters.List(r => r.invoicesfooters_name == "XX1").ToArray());
            _dentnedModel.InvoicesFooters.Remove(_dentnedModel.InvoicesFooters.List(r => r.invoicesfooters_name == "XX2").ToArray());
        }
    }
}
