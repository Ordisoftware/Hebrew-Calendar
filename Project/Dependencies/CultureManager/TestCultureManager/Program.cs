using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Infralution.Localization;
using System.Globalization;
namespace TestCultureManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // set the ApplicationUICulture to the current culture (which defaults
            // to the culture set in Control Panel Regional Settings)
            //
            CultureManager.ApplicationUICulture = CultureInfo.CurrentCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}