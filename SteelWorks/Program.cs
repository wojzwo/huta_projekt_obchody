using System;
using System.Windows.Forms;
using SteelWorks_Worker.Controller;
using SteelWorks_Worker.Model;
using SteelWorks_Worker.Utilities;
using SteelWorks_Worker.View;

namespace SteelWorks_Worker
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
