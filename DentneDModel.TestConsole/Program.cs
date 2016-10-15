#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;

namespace DG.DentneD.Model.Test
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
            Category category = Category.RunSolo;

            // Run tests
            if (category != Category.None)
            {
                Type testclass = typeof(DentneDModelTest);
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
