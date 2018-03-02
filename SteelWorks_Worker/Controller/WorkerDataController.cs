using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Worker.Model;
using SteelWorks_Worker.View;

namespace SteelWorks_Worker.Controller
{
    public class WorkerDataController
    {
        private WorkerDataView view_ = null;
        private Repository repo_ = null;

        public void Activate(WorkerMainView view) {
            view_ = new WorkerDataView();
            view_.InitController(this);

            view_.Show();
            view_.Left = view.Left;
            view_.Top = view.Top;
            view_.Size = view.Size;
            view_.WindowState = view.WindowState;
        }

        public void InitData() {
            if (Tester.bIsInTestMode) {
                DataItemUserControl c = new DataItemUserControl();
                view_.AddData(c);
                view_.AddData(new DataItemUserControl());
            }
        }

        public WorkerDataController(Repository repository) {
            repo_ = repository;
        }
    }
}
