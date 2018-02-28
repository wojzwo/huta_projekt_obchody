using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Admin.Controller;
using SteelWorks_Admin.View;

namespace SteelWorks_Admin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainWindowView view = new MainWindowView();
            MainWindowController controller = new MainWindowController(view);

            Application.Run(view);
        }
    }
}
