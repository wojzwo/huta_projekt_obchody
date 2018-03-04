using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils;
using SteelWorks_Utils.Model;
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

        public void InitData(ChipData employee, List<ChipData> chips, List<KeypadData> keypads) {
            if (Tester.bIsInTestMode) {
                employee = new ChipData(DateTime.Now, "EFD576");
                chips = new List<ChipData>();
                chips.Add(new ChipData(DateTime.Now, "F06516"));
                chips.Add(new ChipData());
                chips.Add(new ChipData(DateTime.Now, "F0DFC9"));

                keypads = new List<KeypadData>();
                keypads.Add(new KeypadData(DateTime.Now, 1));
                keypads.Add(new KeypadData(DateTime.Now, 2));
                keypads.Add(new KeypadData());
            }

            while (chips.Count < keypads.Count) {
                Debug.Log("Too few chips as comapred to keypads detected", LogType.Error);
            }

            while (keypads.Count < chips.Count) {
                Debug.Log("Too few keypads as compared to chips detected", LogType.Warning);
                keypads.Add(new KeypadData());
            }

            view_.AddEmployee(employee);
            for (int i = 0; i < chips.Count; i++) {
                view_.AddData(chips[i], keypads[i]);
            }
        }

        public WorkerDataController(Repository repository) {
            repo_ = repository;
        }
    }
}
