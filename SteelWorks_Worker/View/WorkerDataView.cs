﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private WorkerMainController mainController_ = null;

        public void ChangeUserControlToTrackSelection() {
            dataUserControl.Visible = false;
            reportData = dataUserControl.GetReportInfo();

            trackSelectionUserControl_.Visible = true;
            trackSelectionUserControl_.GetTracks(reportData.employeeName);
        }

        public void ChangeUserControlToCommentUnvisited() {
            trackSelectionUserControl_.Visible = false;
            reportData.reportId = trackSelectionUserControl_.finalReportId;

            dataUserControl.DeleteAllDataItems();

            List<ReportDataItem> placesUnnecessary = new List<ReportDataItem>();
            List<DbPlace> placesUnvisited = trackSelectionUserControl_.finalPlaces;
            foreach (ReportDataItem i in reportData.items) {
                DbPlace matchedPlace = placesUnvisited.Find(p => p.name == i.placeName);
                if (matchedPlace != null)
                    placesUnvisited.Remove(matchedPlace);
                else {
                    placesUnnecessary.Add(i);
                }
            }

            foreach (ReportDataItem i in placesUnnecessary) {
                reportData.items.Remove(i);
            }

            dataUserControl.bCorrectionMode = true;
            dataUserControl.AddEmployee(reportData.employeeName);
            foreach (DbPlace p in placesUnvisited) {
                dataUserControl.AddData(p);
            }

            dataUserControl.Visible = true;
        }

        public void ChangeUserControlToDeleteReader() {
            reportSendView_.Visible = false;

            ReaderRemoveView newView = new ReaderRemoveView(mainController_);
            newView.Show();
            Hide();
        }

        public void ChangeUserControlToSendReport() {
            dataUserControl.Visible = false;

            ReportProcessData newData = dataUserControl.GetReportInfo();
            reportData.items.AddRange(newData.items);

            SaveReportToDatabase();

            reportSendView_.Visible = true;
        }

        public void AddEmployee(ChipData data) {
            dataUserControl.AddEmployee(data);
        }

        public void AddData(ChipData chip, KeypadData mark) {
            dataUserControl.AddData(chip, mark);
        }

        public void InitController(WorkerDataController controller, WorkerMainController mainController) {
            controller_ = controller;
            mainController_ = mainController;
        }

        public WorkerDataView() {
            InitializeComponent();
        }

        private void WorkerDataView_FormClosed(object sender, FormClosedEventArgs e) {
            Environment.Exit(0);
        }

        private void dataUserControl_Load(object sender, EventArgs e) {

        }

        private void SaveReportToDatabase() {
            Repository.RepeatQueryWhileNoConnection<PopupNoInternetView>(this, 1000, () => {
                List<DbMark> marks = Repository.mark.GetAll();

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
                        department = department,
                        markCommentRequired = marks.Find(x => x.description == item.placeMark).requiresComment
                    };

                    //separate try/catch because of possible duplicates
                    try {
                        Repository.reportPlace.Update(reportPlace);
                    } catch (Exception ex) {

                    }
                }
            });
        }
    }
}
