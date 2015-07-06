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
        public void PatientsAttachmentsTypes_Test1()
        {
            string[] errors = new string[] { };
            patientsattachmentstypes t_patientsattachmentstypes = null;

            _dentnedModel.PatientsAttachmentsTypes.Remove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray());
            _dentnedModel.PatientsAttachmentsTypes.Remove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX2").ToArray());
            
            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                //patientsattachmentstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes));
            
            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX1"
            };
            Assert.IsTrue(_dentnedModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes));
            _dentnedModel.PatientsAttachmentsTypes.Add(t_patientsattachmentstypes);

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.PatientsAttachmentsTypes.CanAdd(t_patientsattachmentstypes));

            t_patientsattachmentstypes = new patientsattachmentstypes()
            {
                patientsattachmentstypes_name = "XX2"
            };
            _dentnedModel.PatientsAttachmentsTypes.Add(t_patientsattachmentstypes);

            t_patientsattachmentstypes = _dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").FirstOrDefault();
            t_patientsattachmentstypes.patientsattachmentstypes_name = "XX2";
            Assert.IsFalse(_dentnedModel.PatientsAttachmentsTypes.CanUpdate(t_patientsattachmentstypes));
            t_patientsattachmentstypes.patientsattachmentstypes_name = "XX3";
            Assert.IsTrue(_dentnedModel.PatientsAttachmentsTypes.CanUpdate(t_patientsattachmentstypes));

            _dentnedModel.PatientsAttachmentsTypes.Remove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX1").ToArray());
            _dentnedModel.PatientsAttachmentsTypes.Remove(_dentnedModel.PatientsAttachmentsTypes.List(r => r.patientsattachmentstypes_name == "XX2").ToArray());
        }
    }
}
