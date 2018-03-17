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
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Debug.Log("Program start", LogType.Info);

            WorkerMainView workerMainView = new WorkerMainView();
            WorkerDataView workerDataView = new WorkerDataView();
            WorkerDataController workerDataController = new WorkerDataController();
            WorkerMainController workerMainController = new WorkerMainController(workerMainView, workerDataController);

            Application.Run(workerMainView);

            //DbReport report = new DbReport() {
            //    assignmentDate = DateTime.Now,
            //    isFinished = false,
            //    routineId = 4,
            //    shift = 1,
            //    signedEmployeeName = "",
            //    trackName = "Trasa testowa"
            //};

            //Repository.report.Insert(report);

            //DbRoutine routine = new DbRoutine() {
            //    cycleLength = 0,
            //    cycleMask = 0,
            //    shift = 1,
            //    startDay = DateTime.Now,
            //    teamId = 0,
            //    trackId = 1
            //};

            //Repository.routine.Insert(routine);
        }
    }
}
