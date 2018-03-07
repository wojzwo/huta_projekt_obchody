using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Admin.View;
using SteelWorks_Utils;
using SteelWorks_Utils.Model;

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

			Debug.Log("Program start", LogType.Info);
			Repository repository = new Repository();

			AdminMainView adminMainView = new AdminMainView();

            Application.Run(adminMainView);
        }
    }
}
