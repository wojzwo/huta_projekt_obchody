using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils;
using SteelWorks_Utils.Model;
using SteelWorks_Worker.Model;

namespace SteelWorks_Worker.View
{
    public partial class TrackSelectionUserControl : UserControl
    {
        public Int64 finalReportId;
        public List<DbPlace> finalPlaces;

        private Dictionary<string, Int64> trackIdByListName_ = new Dictionary<string, Int64>();
        private string currentItem_ = "";

        public void GetTracks(string employeeName) {
            List<DbReport> reports = new List<DbReport>();
            Repository.RepeatQueryWhileNoConnection<PopupNoInternetView>(this, 1000, () => {
                reports = Repository.report.GetAllTodaysForEmployee(employeeName);
            });

            foreach (DbReport r in reports) {
                string listName;
                if (r.shift > 0) {
                    listName = "Zmiana: " + r.shift.ToString() + ", Trasa: " + r.trackName;
                } else {
                    listName = "INDYWIDUALNY, Trasa: " + r.trackName;
                }
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

            finalReportId = trackIdByListName_[currentItem_];

            view.ChangeUserControlToCommentUnvisited();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBox1.SelectedItem == null)
                return;

            currentItem_ = listBox1.SelectedItem.ToString();
            listBox2.Items.Clear();


            Repository.RepeatQueryWhileNoConnection<PopupNoInternetView>(this, 1000, () => {
                int routineId = Repository.report.Get(trackIdByListName_[currentItem_]).routineId;
                int trackId = Repository.routine.Get(routineId).trackId;

                List<DbPlace> places = Repository.place.GetAllInTrack(trackId);
                finalPlaces = places;
                foreach (DbPlace p in places) {
                    listBox2.Items.Add("Dział: " + p.department + ", Miejsce: " + p.name);
                }
            });
        }
    }
}
