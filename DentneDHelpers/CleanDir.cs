using DG.DentneD.Model;
using System;
using System.IO;
using System.Linq;

namespace DG.DentneD.Helpers
{
    public class CleanDir
    {
        /// <summary>
        /// Purge the temporary folder
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="doSecureDelete"></param>
        /// <param name="days"></param>
        /// <param name="messages"></param>
        /// <param name="errors"></param>
        public static void CleanTmpdir(string folder, bool doSecureDelete, Nullable<int> days, ref string[] messages, ref string[] errors)
        {
            messages = new string[] { };
            errors = new string[] { };

            //clean all folders
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
            foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetDirectories())
            {
                FileHelper.DeleteFolder(subDirectoryInfo.FullName, doSecureDelete);

                if (!Directory.Exists(subDirectoryInfo.FullName))
                {
                    messages = messages.Concat(new string[] { String.Format("Folder \"{0}\" was deleted successfully.", subDirectoryInfo.FullName) }).ToArray();
                }
                else
                {
                    errors = errors.Concat(new string[] { String.Format("Error: Can not delete folder \"{0}\".", subDirectoryInfo.FullName) }).ToArray();
                }
            }

            //purge files
            if (FileHelper.PurgeFolder(folder, doSecureDelete, days))
            {
                messages = messages.Concat(new string[] { String.Format("Folder \"{0}\" was successfully purged.", folder) }).ToArray();
            }
            else
            {
                errors = errors.Concat(new string[] { String.Format("Error: Can not purge folder \"{0}\".", folder) }).ToArray();
            }
        }

        /// <summary>
        /// Delete sub folders without patients attached
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="doSecureDelete"></param>
        /// <param name="messages"></param>
        /// <param name="errors"></param>
        public static void CleanPatientDir(string folder, bool doSecureDelete, ref string[] messages, ref string[] errors)
        {
            messages = new string[] { };
            errors = new string[] { };

            DentneDModel dentnedModel = new DentneDModel();

            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
            DirectoryInfo[] subDirectoriesInfo = directoryInfo.GetDirectories();

            //clean files
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                FileHelper.DeleteFile(file.FullName, doSecureDelete);
            }

            //clean folder
            foreach (DirectoryInfo subDirectoryInfo in subDirectoriesInfo)
            {
                int patients_id = -1;
                try
                {
                    patients_id = Convert.ToInt32(subDirectoryInfo.Name);
                }
                catch { }
                bool deleteFolder = false;
                if (patients_id != -1)
                {
                    //check if folder patient exists
                    if (dentnedModel.Patients.Find(patients_id) == null)
                    {
                        deleteFolder = true;
                    }
                }
                else
                {
                    deleteFolder = true;
                }
                if (deleteFolder)
                {
                    FileHelper.DeleteFolder(subDirectoryInfo.FullName, doSecureDelete);

                    if (!Directory.Exists(subDirectoryInfo.FullName))
                    {
                        messages = messages.Concat(new string[] { String.Format("Folder \"{0}\" does not have any patient attached, it was deleted successfully.", subDirectoryInfo.FullName) }).ToArray();
                    }
                    else
                    {
                        errors = errors.Concat(new string[] { String.Format("Error: Can not delete folder \"{0}\".", subDirectoryInfo.FullName) }).ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Delete sub folders without patients attachment attached
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="doSecureDelete"></param>
        /// <param name="messages"></param>
        /// <param name="errors"></param>
        public static void CleanPatientAttachmentsDir(string folder, bool doSecureDelete, ref string[] messages, ref string[] errors)
        {
            messages = new string[] { };
            errors = new string[] { };

            DentneDModel dentnedModel = new DentneDModel();

            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
            DirectoryInfo[] subDirectoriesInfo = directoryInfo.GetDirectories();

            //clean files
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                FileHelper.DeleteFile(file.FullName, doSecureDelete);
            }

            //clean folder
            foreach (DirectoryInfo subDirectoryInfo in subDirectoriesInfo)
            {
                int patients_id = -1;
                try
                {
                    patients_id = Convert.ToInt32(subDirectoryInfo.Name);
                }
                catch { }
                bool deleteFolder = false;
                if (patients_id != -1)
                {
                    //check if folder patient exists
                    if (dentnedModel.Patients.Find(patients_id) == null)
                    {
                        deleteFolder = true;
                    }
                }
                else
                {
                    deleteFolder = true;
                }
                if (deleteFolder)
                {
                    FileHelper.DeleteFolder(subDirectoryInfo.FullName, doSecureDelete);

                    if (!Directory.Exists(subDirectoryInfo.FullName))
                    {
                        messages = messages.Concat(new string[] { String.Format("Folder \"{0}\" does not have any patient attached, it was deleted successfully.", subDirectoryInfo.FullName) }).ToArray();
                    }
                    else
                    {
                        errors = errors.Concat(new string[] { String.Format("Error: Can not delete folder \"{0}\".", subDirectoryInfo.FullName) }).ToArray();
                    }
                }
                else
                {
                    //check attachments
                    DirectoryInfo sdirectoryInfo = new DirectoryInfo(subDirectoryInfo.FullName);
                    DirectoryInfo[] subsDirectoriesInfo = sdirectoryInfo.GetDirectories();

                    foreach (DirectoryInfo subsDirectoryInfo in subsDirectoriesInfo)
                    {
                        FileHelper.DeleteFolder(subsDirectoryInfo.FullName, doSecureDelete);

                        if (!Directory.Exists(subsDirectoryInfo.FullName))
                        {
                            messages = messages.Concat(new string[] { String.Format("Folder \"{0}\" does not have any attachment binded, it was deleted successfully.", subsDirectoryInfo.FullName) }).ToArray();
                        }
                        else
                        {
                            errors = errors.Concat(new string[] { String.Format("Error: Can not delete folder \"{0}\".", subsDirectoryInfo.FullName) }).ToArray();
                        }
                    }

                    //clean attachments if needed
                    foreach (FileInfo file in sdirectoryInfo.GetFiles())
                    {
                        if (!dentnedModel.PatientsAttachments.Any(r => r.patients_id == patients_id && r.patientsattachments_filename == file.Name))
                        {
                            FileHelper.DeleteFile(file.FullName, doSecureDelete);

                            if (!File.Exists(file.FullName))
                            {
                                messages = messages.Concat(new string[] { String.Format("File \"{0}\" does not belong to any patient attachment, it was deleted successfully.", file.FullName) }).ToArray();
                            }
                            else
                            {
                                errors = errors.Concat(new string[] { String.Format("Error: Can not delete file \"{0}\".", file.FullName) }).ToArray();
                            }
                        }
                    }

                    //check if folder is empty
                    if (subDirectoryInfo.GetDirectories().Count() == 0 && subDirectoryInfo.GetFiles().Count() == 0)
                    {
                        FileHelper.DeleteFolder(subDirectoryInfo.FullName, doSecureDelete);

                        if (!Directory.Exists(subDirectoryInfo.FullName))
                        {
                            messages = messages.Concat(new string[] { String.Format("Folder \"{0}\" is empty, it was deleted successfully.", subDirectoryInfo.FullName) }).ToArray();
                        }
                        else
                        {
                            errors = errors.Concat(new string[] { String.Format("Error: Can not delete empty folder \"{0}\".", subDirectoryInfo.FullName) }).ToArray();
                        }
                    }
                }
            }
        }
    }
}
