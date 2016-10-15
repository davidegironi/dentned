#region License
// Copyright (c) 2016 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System.ComponentModel;

namespace DG.DentneD.Service
{
    [RunInstaller(true)]
    public partial class InstallerMain : AB.Service.ABServiceInstaller
    {
        public InstallerMain()
        {
            InitInstaller(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString());

            InitializeComponent();
        }
    }
}
