using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils;
using SteelWorks_Worker.Model;

namespace SteelWorks_Worker.View
{
    public partial class LoadReaderUserControl : UserControl
    {
        private const string START_BUTTON_ERROR_MESSAGE = "Czytnik przyłożony, spróbuj ponownie...";

        public LoadReaderUserControl() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void StartButton_Click(object sender, EventArgs e) {
            WorkerMainView view = (WorkerMainView)this.ParentForm;
            if (view == null) {
                Debug.Log("Couldn't retrieve WorkerMainView", LogType.Error);
                return;
            }

            if (Tester.bIsInTestMode) {
                view.ChangeUserControlToProcessData();
                return;
            }

            bool bSuccess = view.controller.OnLoadReader();
            if (bSuccess) {
                view.ChangeUserControlToProcessData();
            } else {
                ErrorBox.Visible = true;
                StartButton.Text = START_BUTTON_ERROR_MESSAGE;
            }
        }

        private void ErrorBox_TextChanged(object sender, EventArgs e) {

        }
    }
}
