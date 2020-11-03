using ArcConfigViewer.UI;
using System;
using System.Windows.Forms;

namespace ArcConfigViewer.Internal
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //handle missing assemblies
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve.HandleResolve;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}