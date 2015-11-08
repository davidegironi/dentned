#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.Diagnostics;
using System.IO;

namespace DG.DentneD.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// Secure delete filename
        /// </summary>
        private const string SRMFileName = "srm.exe";

        /// <summary>
        /// Find a random filename that does not exists on a folder
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="prefix"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static string FindRandomFileName(string folder, string prefix, string extension)
        {
            string filename = null;
            int tries = 0;
            do
            {
                filename = folder + "\\" + (!String.IsNullOrEmpty(prefix) ? prefix + "_" : "") + String.Format("{0:yyyyMMddHHmm}", DateTime.Now) + "-" + Randomizer.BuildRandomString(12) + "." + extension;
                tries++;
            } while (File.Exists(filename) || tries < 100);
            return filename;
        }

        /// <summary>
        /// Build a folder
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public static bool CreateFolder(string folder)
        {
            bool ret = false;
            try
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                ret = true;
            }
            catch { }
            return ret;
        }

        /// <summary>
        /// Purge files older than days, set to -1 to delete all folder
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="doSecureDelete"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static bool PurgeFolder(string foldername, bool doSecureDelete, int days)
        {
            bool ret = false;

            DirectoryInfo directoryInfo = new DirectoryInfo(foldername);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*.*");
            foreach (FileInfo fileInfo in fileInfos)
            {
                bool dodelete = false;
                if (days != -1)
                {
                    if (fileInfo.LastWriteTime < DateTime.Now.AddDays(-days))
                        dodelete = true;
                }
                else
                {
                    dodelete = true;
                }

                if (dodelete)
                {
                    try
                    {
                        if (doSecureDelete)
                        {
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.CreateNoWindow = true;
                            startInfo.UseShellExecute = false;
                            startInfo.FileName = SRMFileName;
                            startInfo.Arguments = "-s -f \"" + fileInfo.FullName + "\"";
                            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            Process exeProcess = Process.Start(startInfo);
                            exeProcess.WaitForExit();

                            ret = true;
                        }
                        else
                        {
                            fileInfo.Delete();

                            ret = true;
                        }
                    }
                    catch { }
                }
            }

            return ret;
        }

        /// <summary>
        /// Delete a folder, recursive
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="doSecureDelete"></param>
        public static bool DeleteFolder(string foldername, bool doSecureDelete)
        {
            bool ret = false;

            try
            {
                if (doSecureDelete)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.CreateNoWindow = true;
                    startInfo.UseShellExecute = false;
                    startInfo.FileName = SRMFileName;
                    startInfo.Arguments = "-r -s -f \"" + foldername + "\"";
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    Process exeProcess = Process.Start(startInfo);
                    exeProcess.WaitForExit();

                    ret = true;
                }
                else
                {
                    Directory.Delete(foldername, true);

                    ret = true;
                }
            }
            catch
            { }

            return ret;
        }

        /// <summary>
        /// Delete a file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="doSecureDelete"></param>
        /// <returns></returns>
        public static bool DeleteFile(string filename, bool doSecureDelete)
        {
            bool ret = false;

            try
            {
                if (doSecureDelete)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.CreateNoWindow = true;
                    startInfo.UseShellExecute = false;
                    startInfo.FileName = SRMFileName;
                    startInfo.Arguments = "-s -f \"" + filename + "\"";
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    Process exeProcess = Process.Start(startInfo);
                    exeProcess.WaitForExit();

                    ret = true;
                }
                else
                {
                    File.Delete(filename);

                    ret = true;
                }
            }
            catch
            { }

            return ret;
        }
    }
}
