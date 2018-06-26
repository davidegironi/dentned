#region License
// Copyright (c) 2016 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System.ServiceProcess;

namespace DG.DentneD.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (System.Environment.UserInteractive)
                AB.Service.ABServiceConsole.ConsoleApp(args, System.Reflection.Assembly.GetExecutingAssembly().Location, new ServiceMain());

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServiceMain()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
