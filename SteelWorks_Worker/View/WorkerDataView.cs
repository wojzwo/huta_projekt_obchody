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

namespace SteelWorks_Worker.View
{
    public partial class WorkerDataView : Form
    {
        private WorkerDataController controller_ = null;

        public void AddData(DataItemUserControl control) {
            dataUserControl.AddData(control);
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
    }
}
