#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.Security.Cryptography;
using System.Text;

namespace DG.DentneD.Helpers
{
    public class PasswordHelper
    {
        /// <summary>
        /// Entropy bytes
        /// </summary>
        private static byte[] _salt = new byte[] { 0xF9, 0x73, 0x08, 0x65, 0x60, 0x35, 0x62, 0x6D, 0xC1, 0xB0, 0xCF, 0x85 };

        /// <summary>
        /// Encrypt a password
        /// </summary>
        /// <param name="password"></param>
        public static string EncryptPassword(string password)
        {
            if (String.IsNullOrEmpty(password))
                password = "";

            HMACMD5 hmacMD5 = new HMACMD5(_salt);
            return Convert.ToBase64String(hmacMD5.ComputeHash(Encoding.Unicode.GetBytes(password)));
        }

        /// <summary>
        /// Check if a prompt password is valid
        /// </summary>
        /// <param name="promptpassword"></param>
        /// <param name="encryptedpassword"></param>
        /// <returns></returns>
        public static bool CheckPassword(string promptpassword, string encryptedpassword)
        {
            return (EncryptPassword(promptpassword) == encryptedpassword);
        }
    }
}
