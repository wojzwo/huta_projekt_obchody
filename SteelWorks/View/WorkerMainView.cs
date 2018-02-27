using System;
using System.Drawing;
using System.Windows.Forms;
using SteelWorks.Controller;

namespace SteelWorks.View
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

        public void ToggleButtons(bool bEnabled) {
            btReadDevice.Enabled = bEnabled;
            btOpenAdapter.Enabled = bEnabled;
        }

        public void AddDebug(string text, Color color) {
            ListViewItem item = DebugView.Items.Add(text);
            item.BackColor = color;
            Application.DoEvents();
        }

        private void btReadDevice_Click(object sender, EventArgs e) {
            controller_.btReadDevice_Click();
        }

        private void btOpenAdapter_Click(object sender, EventArgs e) {
            controller_.btOpenAdapter_Click();
        }

        private void BeforeLoad(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            controller_.TestConnect();
        }
    }
}
