using System;
using System.Windows.Forms;

namespace WebForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Data.Files.ConfigExists())
            {
                Application.Run(new FormConfig());
            }

            Application.Run(new FormMain());


        }
    }
}
