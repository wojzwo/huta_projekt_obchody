using System;
using System.Drawing;
using System.Windows.Forms;
using SteelWorks_Worker.Controller;

namespace SteelWorks_Worker.View
{
    public partial class WorkerMainView : Form
    {
        public WorkerMainController controller;

        public void ChangeUserControlToLoadReader() {
            startUserControl.Visible = false;
            loadReaderUserControl.Visible = true;
        }

        public void InitController(WorkerMainController controller) {
            this.controller = controller;
        }

        public WorkerMainView() {
            InitializeComponent();
        }

        private void BeforeLoad(object sender, EventArgs e) {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void StartApp_Click(object sender, EventArgs e) {
            controller.OnStartApp();
        }

        private void startUserControl1_Load(object sender, EventArgs e) {

        }

        private void startUserControl1_Load_1(object sender, EventArgs e) {

        }
    }
}
