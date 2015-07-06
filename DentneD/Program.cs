#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.UI.GHF;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DentneD
{
    static class Program
    {
        /// <summary>
        /// Application static configuration
        /// </summary>
        public static DGUIGHFApplication uighfApplication = new DGUIGHFApplication(
            new DGUIGHFApplication.DGUIGHFApplicationConfig
            {
                entryFormType = typeof(FormMain),
                entryFormParameters = null,
                displaySplashScreen = true,
                isStackTracerEnabled = true,
                stackTracerSenderMail = null,
                stackTracerSenderFrom = "DentneD",
                appWeblink = "https://github.com/davidegironi/dentned",
                aboutLogo = new Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DG.DentneD.about_logoimg.png")),
                splashScreenLogo = new Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DG.DentneD.splashscreen_logo.png"))
            });

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DGUIGHFApplication.Run(Program.uighfApplication);
        }
    }
}
