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
using SteelWorks_Worker.Controller;
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

            FlashlightLoadState bSuccess = view.controller.OnLoadReader();
            if (bSuccess == FlashlightLoadState.Success) {
                view.ChangeUserControlToProcessData();
            } else if (bSuccess == FlashlightLoadState.EmptySet) {
                ErrorBox.Visible = true;
                ErrorBox.Text = "Czytnik jest pusty. Wczytaj chipy przed wysyłaniem raportu";
                StartButton.Text = START_BUTTON_ERROR_MESSAGE;
            } else {
                ErrorBox.Visible = true;
                ErrorBox.Text = "Nie udało się odczytać danych. Podnieś czytnik, przyłóż go ponownie i naciśnij przycisk poniżej";
                StartButton.Text = START_BUTTON_ERROR_MESSAGE;
            }
        }

        private void ErrorBox_TextChanged(object sender, EventArgs e) {

        }
    }
}
