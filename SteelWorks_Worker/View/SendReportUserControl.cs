using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SteelWorks_Utils;
using SteelWorks_Utils.Model;
using SteelWorks_Worker.Model;

namespace SteelWorks_Worker.View
{
    public partial class SendReportUserControl : UserControl
    {
        private const string EMAIL_NAME = "huta.raporty@gmail.com";
        private const string EMAIL_PASSWORD = "zX2eKod6";
        private ReportProcessData lastData_;
        private bool bIsFinished_ = false;

        public void GenerateReport(ReportProcessData data) {
            lastData_ = data;

            using (FileStream stream = new FileStream("TestReport.pdf", FileMode.Create, FileAccess.Write, FileShare.None)) {
                Document doc = new Document(PageSize.A4, 36.0f, 36.0f, 36.0f, 36.0f);
                PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                doc.Open();

                BaseFont arial = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                Paragraph p1 = new Paragraph(
                    "Raport z obchodu",
                    new Font(arial, 30.0f, iTextSharp.text.Font.BOLD)
                );
                p1.Alignment = Element.ALIGN_LEFT;
                doc.Add(p1);

                Paragraph p2 = new Paragraph(
                    "Data wysłania: " + DateTime.Now.ToString("g") + "\n" +
                    data.employeeName + "\n\n",
                    new Font(arial, 15.0f, iTextSharp.text.Font.NORMAL)
                );
                p2.Alignment = Element.ALIGN_LEFT;
                doc.Add(p2);

                List<DbMark> marks = new List<DbMark>();

                bool bSuccess = false;
                PopupNoInternetView noInternetView = null;
                while (!bSuccess) {
                    try {
                        marks = Repository.mark.GetAll();

                        bSuccess = true;
                        noInternetView?.Close();
                    } catch (NoInternetConnectionException ex) {
                        if (noInternetView == null || !noInternetView.Visible) {
                            noInternetView = new PopupNoInternetView();
                            noInternetView.Show();
                        }

                        for (int ij = 0; ij < 5; ij++) {
                            Thread.Sleep(200);
                            Application.DoEvents();
                        }
                    } catch (Exception ex) {

                    }
                }

                List<ReportDataItem> crucialItems = new List<ReportDataItem>();
                string crucialString = "";
                List<ReportDataItem> changedItems = new List<ReportDataItem>();
                string changedString = "";
                List<ReportDataItem> normalItems = new List<ReportDataItem>();
                string normalString = "";

                foreach (ReportDataItem i in data.items) {
                    bool bRequiresComment = marks.Find((x) => x.description == i.placeMark).requiresComment;
                    if (bRequiresComment) {
                        crucialItems.Add(i);
                        crucialString += "Godzina odwiedzenia: " + i.placeVisitDate.ToString("g") + "\nMiejsce: " + i.placeName + "\nOcena: " + i.placeMark + "\nKomentarz: " + i.placeComment + "\n\n";
                        continue;
                    }

                    if (i.placeStatus != DataItemStatus.ProperlyLoaded) {
                        changedItems.Add(i);
                        changedString += "Godzina odwiedzenia: " + i.placeVisitDate.ToString("g") + "\nMiejsce: " + i.placeName + "\nOcena: " + i.placeMark + "\n\n";
                        continue;
                    }

                    normalItems.Add(i);
                    normalString += "Godzina odwiedzenia: " + i.placeVisitDate.ToString("g") + "\nMiejsce: " + i.placeName + "\nOcena: " + i.placeMark + "\n\n";
                }

                Paragraph p3 = new Paragraph(
                    crucialString + "\n\n",
                    new Font(arial, 15.0f, iTextSharp.text.Font.NORMAL, BaseColor.RED)
                );
                doc.Add(p3);

                Paragraph p4 = new Paragraph(
                    changedString + "\n\n",
                    new Font(arial, 15.0f, iTextSharp.text.Font.NORMAL, BaseColor.BLUE)
                );
                doc.Add(p4);

                Paragraph p5 = new Paragraph(
                    normalString,
                    new Font(arial, 15.0f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                );
                doc.Add(p5);

                doc.Close();

                try {
                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(EMAIL_NAME, EMAIL_PASSWORD);

                    MailMessage mm = new MailMessage(EMAIL_NAME, EMAIL_NAME, "Huta", "fff");
                    mm.Attachments.Add(new Attachment("TestReport.pdf"));
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                    client.Send(mm);
                } catch (Exception ex) {
                    Debug.Log("Couldn't send mail\n" + ex.ToString(), LogType.Error);
                    StartButton.Text = "Wyślij ponownie";
                    StartButton.Enabled = true;
                    return;
                }
            }

            StartButton.Text = "Wysłano poprawnie. Zakończ program";
            StartButton.Enabled = true;
            bIsFinished_ = true;
        }

        public SendReportUserControl() {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e) {
            if (!bIsFinished_) {
                StartButton.Enabled = false;
                GenerateReport(lastData_);
            } else {
                Application.Restart();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }
    }
}
