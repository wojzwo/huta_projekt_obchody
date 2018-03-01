using System;
using System.Drawing;
using System.Windows.Forms;
using SteelWorks_Worker.Controller;

namespace SteelWorks_Worker.View
{
    public partial class WorkerMainView : Form
    {
        private WorkerMainController controller_;

        public WorkerMainView() {
            InitializeComponent();
        }

        public void InitController(WorkerMainController controller) {
            controller_ = controller;
        }

        private void BeforeLoad(object sender, EventArgs e) {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void StartApp_Click(object sender, EventArgs e) {
            controller_.OnStartApp();
        }

        private void startUserControl1_Load(object sender, EventArgs e) {

        }
    }
}
