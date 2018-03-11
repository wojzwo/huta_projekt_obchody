using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Worker.Controller;
using SteelWorks_Worker.Model;

namespace SteelWorks_Worker.View
{
    public partial class WorkerDataView : Form
    {
        private WorkerDataController controller_ = null;

        public void ChangeUserControlToTrackSelection() {
            dataUserControl.Visible = false;


        }

        public void ChangeUserControlToSending() {
            dataUserControl.Visible = false;

            sendReportUserControl_.Visible = true;
            sendReportUserControl_.GenerateReport(dataUserControl.GetReportInfo());
        }

        public void AddEmployee(ChipData data) {
            dataUserControl.AddEmployee(data);
        }

        public void AddData(ChipData chip, KeypadData mark) {
            dataUserControl.AddData(chip, mark);
        }

        public void InitController(WorkerDataController controller) {
            controller_ = controller;
        }

        public WorkerDataView() {
            InitializeComponent();
        }

        private void WorkerDataView_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void dataUserControl_Load(object sender, EventArgs e) {

        }
    }
}
