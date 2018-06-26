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
        public void PaymentsTypes_Test1()
        {
            string[] errors = new string[] { };
            paymentstypes t_paymentstypes = null;

            _dentnedModel.PaymentsTypes.Remove(_dentnedModel.PaymentsTypes.List(r => r.paymentstypes_name == "XX1").ToArray());
            _dentnedModel.PaymentsTypes.Remove(_dentnedModel.PaymentsTypes.List(r => r.paymentstypes_name == "XX2").ToArray());

            t_paymentstypes = new paymentstypes()
            {
                //paymentstypes_name = "XX1",
                paymentstypes_doctext = "xxx"
            };
            Assert.IsFalse(_dentnedModel.PaymentsTypes.CanAdd(t_paymentstypes));

            t_paymentstypes = new paymentstypes()
            {
                paymentstypes_name = "XX1",
                //paymentstypes_doctext = "xxx"
            };
            Assert.IsFalse(_dentnedModel.PaymentsTypes.CanAdd(t_paymentstypes));

            t_paymentstypes = new paymentstypes()
            {
                paymentstypes_name = "XX1",
                paymentstypes_doctext = "xxx"
            };
            Assert.IsTrue(_dentnedModel.PaymentsTypes.CanAdd(t_paymentstypes));
            _dentnedModel.PaymentsTypes.Add(t_paymentstypes);

            t_paymentstypes = new paymentstypes()
            {
                paymentstypes_name = "XX1",
                paymentstypes_doctext = "xxx"
            };
            Assert.IsFalse(_dentnedModel.PaymentsTypes.CanAdd(t_paymentstypes));

            t_paymentstypes = new paymentstypes()
            {
                paymentstypes_name = "XX2",
                paymentstypes_doctext = "xxx"
            };
            _dentnedModel.PaymentsTypes.Add(t_paymentstypes);

            t_paymentstypes = _dentnedModel.PaymentsTypes.FirstOrDefault(r => r.paymentstypes_name == "XX1");
            t_paymentstypes.paymentstypes_name = "XX2";
            Assert.IsFalse(_dentnedModel.PaymentsTypes.CanUpdate(t_paymentstypes));
            t_paymentstypes.paymentstypes_name = "XX3";
            Assert.IsTrue(_dentnedModel.PaymentsTypes.CanUpdate(t_paymentstypes));

            _dentnedModel.PaymentsTypes.Remove(_dentnedModel.PaymentsTypes.List(r => r.paymentstypes_name == "XX1").ToArray());
            _dentnedModel.PaymentsTypes.Remove(_dentnedModel.PaymentsTypes.List(r => r.paymentstypes_name == "XX2").ToArray());
        }
    }
}
