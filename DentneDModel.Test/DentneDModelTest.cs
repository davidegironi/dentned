#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using NUnit.Framework;
using System.IO;

namespace DG.DentneD.Model.Test
{
    [TestFixture]
    public partial class DentneDModelTest
    {
        private DentneDModel _dentnedModel = null;

        public DentneDModelTest()
        {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);

            _dentnedModel = new DentneDModel();
        }
    }
}
