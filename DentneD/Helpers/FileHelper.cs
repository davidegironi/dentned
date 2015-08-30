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
        /// <param name="folder"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static void PurgeFolder(string folder, bool doSecureDelete, int days)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
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

                if(dodelete)
                {
                    try
                    {
                        if (doSecureDelete)
                        {
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.CreateNoWindow = true;
                            startInfo.UseShellExecute = false;
                            startInfo.FileName = Program.SRMFileName;
                            startInfo.Arguments = "-s -f \"" + fileInfo.FullName + "\"";
                            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            Process exeProcess = Process.Start(startInfo);
                            exeProcess.WaitForExit();
                        }
                        else
                        {
                            fileInfo.Delete();
                        }
                    }
                    catch { }
                }                
            }
        }
    }
}
