using System;
using System.Drawing;
using System.Windows.Forms;
using SteelWorks_Worker.Controller;

namespace SteelWorks_Worker.View
{
    public partial class WorkerMainView : Form
    {
        public WorkerMainController controller;

        public void ChangeUserControlToMenuFromSuccess() {
            dataRemoveSuccessUserControl_.Visible = false;
            dataRemoveOrLoadSelectionUserControl.Visible = true;
        }

        public void ChangeUserControlToRemoveDataSuccess() {
            dataRemoveUserControl_.Visible = false;
            dataRemoveSuccessUserControl_.Visible = true;
        }

        public void ChangeUserControlToSendReport() {
            dataRemoveOrLoadSelectionUserControl.Visible = false;
            loadReaderUserControl.Visible = true;
        }

        public void ChangeUserControlToRemoveData() {
            dataRemoveOrLoadSelectionUserControl.Visible = false;
            dataRemoveUserControl_.Visible = true;
        }

        public void ChangeUserControlToProcessData() {
            loadReaderUserControl.Visible = false;
            controller.ChangeToDataMode();
        }

        public void ChangeUserControlToLoadReader() {
            startUserControl.Visible = false;
            dataRemoveOrLoadSelectionUserControl.Visible = true;
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

        private void startUserControl1_Load(object sender, EventArgs e) {

        }

        private void startUserControl1_Load_1(object sender, EventArgs e) {

        }

        private void loadReaderUserControl_Load(object sender, EventArgs e) {

        }

        private void dataRemoveOrLoadSelectionUserControl_Load(object sender, EventArgs e) {

        }
    }
}
