#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Forms;
using DG.DentneD.Helpers;
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
            string formprotectedpassword = null;
            string reportprotectedpassword = null;

            var p = new OptionSet() {
                { "l|languagerebuilt", "rebuild the loaded language file against default values",
                    v => languagerebuild = v != null },
                { "r|defaultlanguagerebuild", "rebuild the default language file",
                    v => defaultlanguagerebuild = v != null },
                { "d|cleandatadir", "clean data directories",
                    v => cleandatadir = v != null },
                { "f|formprotectedpassword=", "get entrypted password for protected forms",
                    v => formprotectedpassword = v },
                { "t|reportprotectedpassword=", "get entrypted password for protected reports",
                    v => reportprotectedpassword = v },
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

                if (
                    (languagerebuild ? 1 : 0) + (defaultlanguagerebuild ? 1 : 0) + (cleandatadir ? 1 : 0) +
                        (!String.IsNullOrEmpty(formprotectedpassword) || !String.IsNullOrEmpty(reportprotectedpassword) ? 1 : 0) > 1 ||
                    !defaultlanguagerebuild && !languagerebuild && !cleandatadir && String.IsNullOrEmpty(formprotectedpassword) && String.IsNullOrEmpty(reportprotectedpassword))
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
                    Console.WriteLine("Rebuilding the default language file to \"" + DGUIGHFLanguageHelper.DefaultLanguageFilename + "\"...");
                    if (DGUIGHFLanguageHelper.RebuiltDefaultLanguage(DGUIGHFLanguageHelper.DefaultLanguageFilename))
                        Console.WriteLine("File successfully rebuilt.");
                    else
                        Console.WriteLine("Rebuild ends with errors.");
                }
                else if (languagerebuild)
                {
                    //rebuilt the loaded language
                    string[] messages = new string[] { };
                    Console.WriteLine("Rebuilt the current language file to \"" + Program.uighfApplication.LanguageFilename + "\"...");
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
                    string[] messages = new string[] { };
                    string[] errors = new string[] { };

                    string tmpdir = ConfigurationManager.AppSettings["tmpdir"];
                    string patientsDatadir = ConfigurationManager.AppSettings["patientsDatadir"];
                    string patientsAttachmentsdir = ConfigurationManager.AppSettings["patientsAttachmentsdir"];
                    bool doSecureDelete = Convert.ToBoolean(ConfigurationManager.AppSettings["doSecureDelete"]);

                    //clean the tmpdir
                    Console.WriteLine("Cleaning Temp folder \"" + tmpdir + "\"...");
                    FileHelper.PurgeFolder(tmpdir, true, -1);
                    Console.WriteLine("Folder processed.");

                    Console.WriteLine();

                    //clean the patient datadir
                    Console.WriteLine("Cleaning Patient Data folder \"" + patientsDatadir + "\"...");
                    FormPatients.CleanPatientDir(patientsDatadir, doSecureDelete, ref messages, ref errors);
                    foreach (string message in messages)
                        Console.WriteLine("  " + message);
                    foreach (string error in errors)
                        Console.WriteLine("  " + error);
                    Console.WriteLine("Folder processed.");

                    Console.WriteLine();

                    //clean the patient attachment dir
                    Console.WriteLine("Cleaning Patient Attachments folder \"" + patientsAttachmentsdir + "\"...");
                    FormPatients.CleanPatientAttachmentsDir(patientsAttachmentsdir, doSecureDelete, ref messages, ref errors);
                    foreach (string message in messages)
                        Console.WriteLine("  " + message);
                    foreach (string error in errors)
                        Console.WriteLine("  " + error);
                    Console.WriteLine("Folder processed.");
                }
                else if (!String.IsNullOrEmpty(formprotectedpassword) && !String.IsNullOrEmpty(reportprotectedpassword))
                {
                    //Build encrypted passwords
                    Console.WriteLine("Building the encrypted passwords for protected forms and reports...");
                    Console.WriteLine(String.Format("Your form entrypted password is: {0} ", PasswordHelper.EncryptPassword(formprotectedpassword)));
                    Console.WriteLine(String.Format("Your check for proteted form list is: {0} ", PasswordHelper.EncryptPassword(String.Join(",", ConfigurationManager.AppSettings["passwordProtectedForms"].Split(',')))));
                    Console.WriteLine(String.Format("Your report entrypted password is: {0} ", PasswordHelper.EncryptPassword(reportprotectedpassword)));
                }
                else if (!String.IsNullOrEmpty(formprotectedpassword))
                {
                    //Build encrypted password
                    Console.WriteLine("Building the encrypted password for protected forms...");
                    Console.WriteLine(String.Format("Your form entrypted password is: {0} ", PasswordHelper.EncryptPassword(formprotectedpassword)));
                    Console.WriteLine(String.Format("Your check for proteted form list is: {0} ", PasswordHelper.EncryptPassword(String.Join(",", ConfigurationManager.AppSettings["passwordProtectedForms"].Split(',')))));
                }
                else if (!String.IsNullOrEmpty(reportprotectedpassword))
                {
                    //Build encrypted password
                    Console.WriteLine("Building the encrypted password for protected reports...");
                    Console.WriteLine(String.Format("Your report entrypted password is: {0} ", PasswordHelper.EncryptPassword(reportprotectedpassword)));
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
