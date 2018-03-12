using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils.Model;
using SteelWorks_Worker.Controller;
using SteelWorks_Worker.Model;

namespace SteelWorks_Worker.View
{
    public partial class WorkerDataView : Form
    {
        public ReportProcessData reportData = new ReportProcessData();

        private WorkerDataController controller_ = null;

        public void ChangeUserControlToTrackSelection() {
            dataUserControl.Visible = false;
            reportData = dataUserControl.GetReportInfo();

            trackSelectionUserControl_.Visible = true;
            trackSelectionUserControl_.GetTracks();
        }

        public void ChangeUserControlToCommentUnvisited() {
            trackSelectionUserControl_.Visible = false;
            reportData.reportId = trackSelectionUserControl_.finalReportId;

            dataUserControl.DeleteAllDataItems();

            List<DbPlace> placesUnvisited = trackSelectionUserControl_.finalPlaces;
            foreach (ReportDataItem i in reportData.items) {
                DbPlace matchedPlace = placesUnvisited.Find(p => p.name == i.placeName);
                if (matchedPlace != null)
                    placesUnvisited.Remove(matchedPlace);
            }

            dataUserControl.bCorrectionMode = true;
            dataUserControl.AddEmployee(reportData.employeeName);
            foreach (DbPlace p in placesUnvisited) {
                dataUserControl.AddData(p);
            }

            dataUserControl.Visible = true;
        }

        public void ChangeUserControlToDeleteReader() {
            dataUserControl.Visible = false;

            ReportProcessData newData = dataUserControl.GetReportInfo();
            reportData.items.AddRange(newData.items);

            SaveReportToDatabase();
        }

        public void AddEmployee(ChipData data) {
            dataUserControl.AddEmployee(data);
        }

        public void AddData(ChipData chip, KeypadData mark) {
            dataUserControl.AddData(chip, mark);
        }

        public void InitController(WorkerDataController controller) {
            controller_ = controller;
        }

        public WorkerDataView() {
            InitializeComponent();
        }

        private void WorkerDataView_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void dataUserControl_Load(object sender, EventArgs e) {

        }

        private void SaveReportToDatabase() {
            try {
                DbReport report = Repository.report.Get(reportData.reportId);
                report.isFinished = true;
                report.signedEmployeeName = reportData.employeeName;
                Repository.report.Update(report);

                foreach (ReportDataItem item in reportData.items) {
                    string department = Repository.place.GetDepartmentByName(item.placeName);
                    string status;
                    if (item.placeStatus == DataItemStatus.ProperlyLoaded) {
                        status = "Odwiedzono";
                    } else if (item.placeStatus == DataItemStatus.ChangedMark) {
                        status = "Odwiedzono - Poprawiano ocenę";
                    } else if (item.placeStatus == DataItemStatus.ChangedPlace) {
                        status = "Odwiedzono - Poprawiano miejsce";
                    } else {
                        status = "Nieodwiedzono";
                    }

                    DbReportPlace reportPlace = new DbReportPlace() {
                        reportId = reportData.reportId,
                        status = status,
                        placeName = item.placeName,
                        visitDate = item.placeVisitDate,
                        markDescription = item.placeMark,
                        comment = item.placeComment,
                        department = department
                    };

                    //separate try/catch because of possible duplicates
                    try {
                        Repository.reportPlace.Insert(reportPlace);
                    } catch (Exception ex) {

                    }
                }
            } catch (Exception ex) {
                //TODO: Exception handling code
            }
        }
    }
}
