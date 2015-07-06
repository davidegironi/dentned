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
        public void MedicalrecordsTypes_Test1()
        {
            string[] errors = new string[] { };
            medicalrecordstypes t_medicalrecordstypes = null;

            _dentnedModel.MedicalrecordsTypes.Remove(_dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX1").ToArray());
            _dentnedModel.MedicalrecordsTypes.Remove(_dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX2").ToArray());
            
            t_medicalrecordstypes = new medicalrecordstypes()
            {
                //medicalrecordstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.MedicalrecordsTypes.CanAdd(t_medicalrecordstypes));
            
            t_medicalrecordstypes = new medicalrecordstypes()
            {
                medicalrecordstypes_name = "XX1"
            };
            Assert.IsTrue(_dentnedModel.MedicalrecordsTypes.CanAdd(t_medicalrecordstypes));
            _dentnedModel.MedicalrecordsTypes.Add(t_medicalrecordstypes);

            t_medicalrecordstypes = new medicalrecordstypes()
            {
                medicalrecordstypes_name = "XX1"
            };
            Assert.IsFalse(_dentnedModel.MedicalrecordsTypes.CanAdd(t_medicalrecordstypes));

            t_medicalrecordstypes = new medicalrecordstypes()
            {
                medicalrecordstypes_name = "XX2"
            };
            _dentnedModel.MedicalrecordsTypes.Add(t_medicalrecordstypes);

            t_medicalrecordstypes = _dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX1").FirstOrDefault();
            t_medicalrecordstypes.medicalrecordstypes_name = "XX2";
            Assert.IsFalse(_dentnedModel.MedicalrecordsTypes.CanUpdate(t_medicalrecordstypes));
            t_medicalrecordstypes.medicalrecordstypes_name = "XX3";
            Assert.IsTrue(_dentnedModel.MedicalrecordsTypes.CanUpdate(t_medicalrecordstypes));

            _dentnedModel.MedicalrecordsTypes.Remove(_dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX1").ToArray());
            _dentnedModel.MedicalrecordsTypes.Remove(_dentnedModel.MedicalrecordsTypes.List(r => r.medicalrecordstypes_name == "XX2").ToArray());
        }
    }
}
