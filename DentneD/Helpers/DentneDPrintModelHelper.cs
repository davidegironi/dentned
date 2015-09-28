#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.IO;
using System.Reflection;

namespace DG.DentneD.Helpers
{
    public class DentneDPrintModelHelper
    {
        /// <summary>
        /// Build and instance of a printmodel
        /// </summary>
        /// <param name="assemblyPath"></param>
        /// <returns></returns>
        public static IDentneDPrintModel DentneDPrintModelInstance(string assemblyPath)
        {
            IDentneDPrintModel printModel = null;

            string assemblyType = "DG.DentneD.DentneDPrintModel";
            try
            {
                Assembly a = Assembly.Load(File.ReadAllBytes(Path.GetFullPath(assemblyPath)));
                Type t = a.GetType(assemblyType);
                printModel = (IDentneDPrintModel)Activator.CreateInstance(t, null);
            }
            catch { }

            return printModel;
        }
    }
}
