using System;
using System.Windows.Forms;
using SteelWorks.Controller;
using SteelWorks.View;

namespace SteelWorks
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            WorkerMainView workerMainView = new WorkerMainView();
            WorkerMainController workerMainController = new  WorkerMainController(workerMainView);

            Application.Run(workerMainView);
        }
    }
}
