using System;
using System.Windows.Forms;
using SteelWorks.Controller;
using SteelWorks.Model;
using SteelWorks.Utilities;
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

            Repository repository = new Repository();

            WorkerMainView workerMainView = new WorkerMainView();
            WorkerMainController workerMainController = new  WorkerMainController(workerMainView, repository);

            Application.Run(workerMainView);

            repository.CloseConnection();
        }
    }
}
