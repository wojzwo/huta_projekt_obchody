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
using SteelWorks_Utils.Model;

namespace SteelWorks_Worker.View
{
    public partial class TrackSelectionUserControl : UserControl
    {
        private Dictionary<string, Int64> trackIdByListName_ = new Dictionary<string, Int64>();
        private string currentItem_ = "";

        public void GetTracks() {
            List<DB_Report> reports = new List<DB_Report>();
            try {
                reports = Repository.instance.GetAllTodaysReports(true);
            } catch (Exception ex) {
                //TODO: Exception handling code
            }

            foreach (DB_Report r in reports) {
                string listName = "Zmiana: " + r.shift.ToString() + ",   Trasa: " + r.trackName;
                trackIdByListName_.Add(listName, r.id);
                listBox1.Items.Add(listName);
            }
        }

        public TrackSelectionUserControl() {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e) {
            if (currentItem_ == "")
                return;

            WorkerDataView view = (WorkerDataView)this.ParentForm;
            if (view == null) {
                Debug.Log("Couldn't retrieve WorkerMainView", LogType.Error);
                return;
            }

            view.ChangeUserControlToSending();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            currentItem_ = listBox1.SelectedItem.ToString();
        }
    }
}
