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

namespace SteelWorks_Worker.View
{
    public partial class DataRemoveUserControl : UserControl
    {
        public DataRemoveUserControl() {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e) {
            WorkerMainView view = (WorkerMainView)this.ParentForm;
            if (view == null) {
                Debug.Log("Couldn't retrieve WorkerMainView", LogType.Error);
                return;
            }

            StartButton.Text = "Proszę czekać...";
            StartButton.Enabled = false;
            if (view.controller.EraseReader()) {
                view.ChangeUserControlToRemoveDataSuccess();
            } else {
                ErrorBox.Visible = true;
                StartButton.Text = "Spróbuj jeszcze raz, trzymając czytnik na adapterze";
                StartButton.Enabled = true;
            }
        }
    }
}
