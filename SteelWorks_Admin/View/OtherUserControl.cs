using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils;
using SteelWorks_Utils.Model;
using Debug = SteelWorks_Utils.Debug;

namespace SteelWorks_Admin.View
{
    public partial class OtherUserControl : UserControl
    {
        public OtherUserControl() {
            InitializeComponent();
			dateTimePicker1.Value = DateTime.Now.Date;
        }

        private void GenerateReports(DateTime day) {
            try {
                Directory.Delete("Reports", true);
            } catch (Exception ex) {
                Debug.Log("Couldn't remove directory:\n" + ex.ToString(), LogType.Error);
            }

            try {
                Directory.CreateDirectory("Reports");
            } catch (Exception ex) {
                Debug.Log("Couldn't create directory:\n" + ex.ToString(), LogType.Error);
            }

            try {
                Directory.CreateDirectory("Reports/Individual");
            } catch (Exception ex) {
                Debug.Log("Couldn't create directory:\n" + ex.ToString(), LogType.Error);
            }

            Repository.generator.GenerateOldReports(day, day);
        }

        private void databaseBackupButton_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Database Dump files (*.dump)|*.dump|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    Repository.BackupDatabase(saveFileDialog1.FileName);
                    errorBackupDatabase.Text = "Zapisano!";
                    errorBackupDatabase.ForeColor = Color.Green;
                    errorBackupDatabase.Visible = true;
                } catch (Exception ex) {
                    Debug.Log("Error while doing database backup\n" + ex.ToString(), LogType.Error);
                    errorBackupDatabase.Text = "Nie udało się zapisać kopii bazy!";
                    errorBackupDatabase.ForeColor = Color.Red;
                    errorBackupDatabase.Visible = true;
                }
            }
        }

        private void fullReportButton_Click(object sender, EventArgs e) {
            if (dateTimePicker1.Value > DateTime.Now) {
                archiveReportError.Text = "Wybierz dzisiejszą lub przeszłą datę!";
                archiveReportError.ForeColor = Color.Red;
                archiveReportError.Visible = true;
                return;
            }

            try {
                GenerateReports(dateTimePicker1.Value.Date);
                Process.Start(@"Reports\Report_Full.pdf");
            } catch (Exception ex) {
                Debug.Log("Couldn't generate full report\n" + ex.ToString(), LogType.Error);
                archiveReportError.Text = "Nie udało się wygenerować raportu. Zamknij wszystkie pliki PDF";
                archiveReportError.ForeColor = Color.Red;
                archiveReportError.Visible = true;
                return;
            }

            archiveReportError.Text = "Wygenerowano raport!";
            archiveReportError.ForeColor = Color.Green;
            archiveReportError.Visible = true;
        }

        private void generalReportButton_Click(object sender, EventArgs e) {
            if (dateTimePicker1.Value > DateTime.Now) {
                archiveReportError.Text = "Wybierz dzisiejszą lub przeszłą datę!";
                archiveReportError.ForeColor = Color.Red;
                archiveReportError.Visible = true;
                return;
            }

            try {
                GenerateReports(dateTimePicker1.Value.Date);
                Process.Start(@"Reports\Report_General.pdf");
            } catch (Exception ex) {
                Debug.Log("Couldn't generate general report\n" + ex.ToString(), LogType.Error);
                archiveReportError.Text = "Nie udało się wygenerować raportu. Zamknij wszystkie pliki PDF";
                archiveReportError.ForeColor = Color.Red;
                archiveReportError.Visible = true;
                return;
            }

            archiveReportError.Text = "Wygenerowano raport!";
            archiveReportError.ForeColor = Color.Green;
            archiveReportError.Visible = true;
        }

        private void minimalReportButton_Click(object sender, EventArgs e) {
            if (dateTimePicker1.Value > DateTime.Now) {
                archiveReportError.Text = "Wybierz dzisiejszą lub przeszłą datę!";
                archiveReportError.ForeColor = Color.Red;
                archiveReportError.Visible = true;
                return;
            }

            try {
                GenerateReports(dateTimePicker1.Value.Date);
                Process.Start(@"Reports\Report_Minimal.pdf");
            } catch (Exception ex) {
                Debug.Log("Couldn't generate minimal report\n" + ex.ToString(), LogType.Error);
                archiveReportError.Text = "Nie udało się wygenerować raportu. Zamknij wszystkie pliki PDF";
                archiveReportError.ForeColor = Color.Red;
                archiveReportError.Visible = true;
                return;
            }

            archiveReportError.Text = "Wygenerowano raport!";
            archiveReportError.ForeColor = Color.Green;
            archiveReportError.Visible = true;
        }

        private void individualReportButton_Click(object sender, EventArgs e) {
            if (dateTimePicker1.Value > DateTime.Now) {
                archiveReportError.Text = "Wybierz dzisiejszą lub przeszłą datę!";
                archiveReportError.ForeColor = Color.Red;
                archiveReportError.Visible = true;
                return;
            }

            try {
                GenerateReports(dateTimePicker1.Value.Date);
                Process.Start("explorer.exe", @"Reports\Individual");
            } catch (Exception ex) {
                Debug.Log("Couldn't generate individual report\n" + ex.ToString(), LogType.Error);
                archiveReportError.Text = "Nie udało się wygenerować raportu. Zamknij wszystkie pliki PDF";
                archiveReportError.ForeColor = Color.Red;
                archiveReportError.Visible = true;
                return;
            }

            archiveReportError.Text = "Wygenerowano raport!";
            archiveReportError.ForeColor = Color.Green;
            archiveReportError.Visible = true;
        }

        private void OtherUserControl_Load(object sender, EventArgs e) {

        }
    }
}
