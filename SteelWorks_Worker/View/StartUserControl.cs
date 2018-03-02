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
    public partial class StartUserControl : UserControl
    {
        private const string START_BUTTON_ERROR_MESSAGE = "Spróbuj ponownie...";

        public StartUserControl() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            WorkerMainView view = (WorkerMainView) this.ParentForm;
            if (view == null) {
                Debug.Log("Couldn't retrieve WorkerMainView", LogType.Error);
                return;
            }

            if (Tester.bIsInTestMode) {
                view.ChangeUserControlToLoadReader();
                return;
            }

            bool bSuccess = view.controller.OnStartApp();
            if (bSuccess) {
                view.ChangeUserControlToLoadReader();
            } else {
                ErrorBox.Visible = true;
                StartButton.Text = START_BUTTON_ERROR_MESSAGE;
            }
        }

        private void StartUserControl_Load(object sender, EventArgs e) {

        }
    }
}
