#region License
// Copyright (c) 2016 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;

namespace DG.DentneD.Helpers.Test
{
    class Program
    {
        /// <summary>
        /// Available test categories
        /// </summary>
        private enum Category { None, RunSolo, All };

        static void Main(string[] args)
        {
            // Select tests to run
            Category category = Category.All;

            // Run tests
            if (category != Category.None)
            {
                Type testclass = typeof(DentneDHelpersTest);
                if (category == Category.All)
                    NUnit.ConsoleRunner.Runner.Main(new string[] {
                    "/exclude:Initialize", testclass.Assembly.Location, "/basepath="+"../../../" + testclass.Assembly.ManifestModule.Name.Substring(0, testclass.Assembly.ManifestModule.Name.Length - 4) + "/bin/Debug"
                });
                else
                    NUnit.ConsoleRunner.Runner.Main(new string[] {
                    "/include:" + category.ToString(), testclass.Assembly.Location, "/basepath="+"../../../" + testclass.Assembly.ManifestModule.Name.Substring(0, testclass.Assembly.ManifestModule.Name.Length - 4) + "/bin/Debug"
                });
            }
            Console.ReadKey();
        }
    }
}
