#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;

namespace DG.DentneD.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulateTestDatabase populateTestDatabase = new PopulateTestDatabase();

            Console.WriteLine(" > Empty and populate the new database.");
            Console.WriteLine("");

            Console.WriteLine(" > Clean database.");
            populateTestDatabase.Empty();
            Console.WriteLine("");

            Console.WriteLine(" > Populate database.");
            populateTestDatabase.Populate();
            Console.WriteLine("");
        }
    }
}
