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

namespace SteelWorks_Worker.View
{
    public partial class DataRemoveOrLoadSelectionUserControl : UserControl
    {
        public DataRemoveOrLoadSelectionUserControl() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {
            WorkerMainView view = (WorkerMainView)this.ParentForm;
            if (view == null) {
                Debug.Log("Couldn't retrieve WorkerMainView", LogType.Error);
                return;
            }

            view.ChangeUserControlToSendReport();
        }

        private void button1_Click(object sender, EventArgs e) {
            WorkerMainView view = (WorkerMainView)this.ParentForm;
            if (view == null) {
                Debug.Log("Couldn't retrieve WorkerMainView", LogType.Error);
                return;
            }

            view.ChangeUserControlToRemoveData();
        }

        private void fullReportButton_Click(object sender, EventArgs e) {
            try {
                label4.Text = "Proszę czekać...";
                label4.ForeColor = Color.Black;
                GenerateReports(DateTime.Now.AddHours(-6).Date);
                Process.Start(@"Reports\Report_Full.pdf");
            } catch (Exception ex) {
                Debug.Log("Couldn't generate full report\n" + ex.ToString(), LogType.Error);
                label4.Text = "Nie udało się wygenerować raportu. Zamknij wszystkie pliki PDF";
                label4.ForeColor = Color.Red;
                label4.Visible = true;
                return;
            }

            label4.Text = "Wygenerowano raport!";
            label4.ForeColor = Color.Green;
            label4.Visible = true;
        }

        private void generalReportButton_Click(object sender, EventArgs e) {
            try {
                label4.Text = "Proszę czekać...";
                label4.ForeColor = Color.Black;
                GenerateReports(DateTime.Now.AddHours(-6).Date);
                Process.Start(@"Reports\Report_General.pdf");
            } catch (Exception ex) {
                Debug.Log("Couldn't generate general report\n" + ex.ToString(), LogType.Error);
                label4.Text = "Nie udało się wygenerować raportu. Zamknij wszystkie pliki PDF";
                label4.ForeColor = Color.Red;
                label4.Visible = true;
                return;
            }

            label4.Text = "Wygenerowano raport!";
            label4.ForeColor = Color.Green;
            label4.Visible = true;
        }

        private void minimalReportButton_Click(object sender, EventArgs e) {
            try {
                label4.Text = "Proszę czekać...";
                label4.ForeColor = Color.Black;
                GenerateReports(DateTime.Now.AddHours(-6).Date);
                Process.Start(@"Reports\Report_Minimal.pdf");
            } catch (Exception ex) {
                Debug.Log("Couldn't generate minimal report\n" + ex.ToString(), LogType.Error);
                label4.Text = "Nie udało się wygenerować raportu. Zamknij wszystkie pliki PDF";
                label4.ForeColor = Color.Red;
                label4.Visible = true;
                return;
            }

            label4.Text = "Wygenerowano raport!";
            label4.ForeColor = Color.Green;
            label4.Visible = true;
        }

        private void individualReportButton_Click(object sender, EventArgs e) {
            try {
                label4.Text = "Proszę czekać...";
                label4.ForeColor = Color.Black;
                GenerateReports(DateTime.Now.AddHours(-6).Date);
                Process.Start("explorer.exe", @"Reports\Individual");
            } catch (Exception ex) {
                Debug.Log("Couldn't generate individual report\n" + ex.ToString(), LogType.Error);
                label4.Text = "Nie udało się wygenerować raportu. Zamknij wszystkie pliki PDF";
                label4.ForeColor = Color.Red;
                label4.Visible = true;
                return;
            }

            label4.Text = "Wygenerowano raport!";
            label4.ForeColor = Color.Green;
            label4.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e) {

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
    }
}
