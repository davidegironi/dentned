#region License
// Copyright (c) 2016 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Model;
using NUnit.Framework;
using System.Configuration;
using System.IO;

namespace DG.DentneD.Helpers.Test
{
    [TestFixture]
    public partial class DentneDHelpersTest
    {
        private DentneDModel _dentnedModel = null;
        private readonly string tmpdir = "";

        public DentneDHelpersTest()
        {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);

            _dentnedModel = new DentneDModel();
            tmpdir = ConfigurationManager.AppSettings["tmpdir"];
        }
    }
}
