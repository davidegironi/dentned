#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.UI.GHF;
using NDesk.Options;
using System;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DG.DentneD
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
                languageFolder = "lang",
                language = ConfigurationManager.AppSettings["language"],
                aboutLogo = new Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DG.DentneD.about_logoimg.png")),
                splashScreenLogo = new Bitmap(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DG.DentneD.splashscreen_logo.png"))
            });
        
        // Defines native methods for command out
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool showhelp = false;
            bool defaultlanguagerebuild = false;
            bool languagerebuild = false;
            bool cleandatadir = false;

            var p = new OptionSet() {
                { "l|languagerebuilt", "rebuild the loaded language file against default values",
                    v => languagerebuild = v != null },
                { "r|defaultlanguagerebuild", "rebuild the default language file",
                    v => defaultlanguagerebuild = v != null },
                { "d|cleandatadir", "clean the data folder",
                    v => cleandatadir = v != null },
                { "h|help",  "show help", 
                    v => showhelp = v != null }
            };

            //attach the console
            if (args.Length > 0)
            {
                AttachConsole(ATTACH_PARENT_PROCESS);

                try
                {
                    p.Parse(args);
                }
                catch (OptionException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Name);
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try `--help' for more information.");
                    return;
                }

                if (defaultlanguagerebuild && languagerebuild ||
                    defaultlanguagerebuild && cleandatadir ||
                    languagerebuild && cleandatadir ||
                    !defaultlanguagerebuild && !languagerebuild && !cleandatadir)
                {
                    showhelp = true;
                }

                Console.WriteLine();

                if (showhelp)
                {
                    //show help
                    Console.WriteLine("Usage: " + Assembly.GetExecutingAssembly().GetName().Name + " [OPTIONS]");
                    Console.WriteLine();
                    Console.WriteLine("Options:");
                    p.WriteOptionDescriptions(Console.Out);
                }
                else if (defaultlanguagerebuild)
                {
                    //rebuilt the default language
                    Console.WriteLine("Rebuilding the default language file \"" + DGUIGHFLanguageHelper.DefaultLanguageFilename + "\"...");
                    if (DGUIGHFLanguageHelper.RebuiltDefaultLanguage(DGUIGHFLanguageHelper.DefaultLanguageFilename))
                        Console.WriteLine("File successfully rebuilt.");
                    else
                        Console.WriteLine("Rebuild ends with errors.");
                }
                else if (languagerebuild)
                {
                    //rebuilt the loaded language
                    string[] messages = new string[] { };
                    Console.WriteLine("Rebuilt the language file \"" + Program.uighfApplication.LanguageFilename + "\"...");
                    if (DGUIGHFLanguageHelper.RebuiltLanguage(Program.uighfApplication.LanguageFilename, false, ref messages))
                    {
                        foreach (string message in messages)
                            Console.WriteLine("  " + message);
                        Console.WriteLine("File successfully rebuilt.");
                    }
                    else
                    {
                        Console.WriteLine("Rebuild ends with errors.");
                    }
                }
                else if (cleandatadir)
                {
                    //clean the datadir
                }

                Console.WriteLine();
                SendKeys.SendWait("{ENTER}");
                Application.Exit();
            }
            else
            {
                //show main form
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                DGUIGHFApplication.Run(Program.uighfApplication);
            }
        }
    }
}
