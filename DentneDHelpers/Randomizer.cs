#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.Text;

namespace DG.DentneD.Helpers
{
    public class Randomizer
    {
        /// <summary>
        /// Build a random string of a given size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string BuildRandomString(int size)
        {
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                //26 letters in the alfabet, ascii + 65 for the capital letters
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65))));
            }
            return builder.ToString();
        }

        /// <summary>
        /// Build a random number string of a given size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string BuildRandomNumberString(int size)
        {
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = input[r.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Build a random number of a given size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string BuildRandomNumber(int size)
        {
            string input = "0123456789";
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = input[r.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
