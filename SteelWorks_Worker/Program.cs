using System;
using System.Windows.Forms;
using SteelWorks_Utils;
using SteelWorks_Utils.Model;
using SteelWorks_Worker.Controller;
using SteelWorks_Worker.Model;
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

            Debug.Log("Program start", LogType.Info);
            Repository repository = new Repository();

            WorkerMainView workerMainView = new WorkerMainView();
            WorkerDataView workerDataView = new WorkerDataView();
            WorkerDataController workerDataController = new WorkerDataController(repository);
            WorkerMainController workerMainController = new  WorkerMainController(workerMainView, workerDataController);

            Application.Run(workerMainView);
        }
    }
}
