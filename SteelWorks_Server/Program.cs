using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SteelWorks_Utils;
using SteelWorks_Utils.Model;

namespace SteelWorks_Server
{
    class Program
    {
        private const string EMAIL_NAME = "huta.raporty@gmail.com";
        private const string EMAIL_PASSWORD = "zX2eKod6";

        private static Dictionary<int, string> reportMaskToPath_ = new Dictionary<int, string>();

        static void Main(string[] args) {
            Debug.Log("Started program", LogType.Info);
            //InsertTestData();

            Directory.Delete("Reports", true);
            Directory.CreateDirectory("Reports");
            Directory.CreateDirectory("Reports/Individual");

            Repository.generator.GenerateOldReports(DateTime.Today, DateTime.Today - TimeSpan.FromDays(1));
            SendOldReports();
            ArchiveOldReports();

            List<DbRoutine> routines = new List<DbRoutine>();
            try {
                routines = Repository.routine.GetAll();
            } catch (Exception ex) {
                Debug.Log(ex.ToString(), LogType.DatabaseError);
            }

            Repository.generator.AddNewReports(routines);
            DeleteOldRoutines(routines);
        }

        private static void InsertTestData() {
            DbReport report3 = new DbReport() {
                assignmentDate = DateTime.Now,
                isFinished = false,
                routineId = 5,
                shift = 2,
                signedEmployeeName = "",
                trackName = "Trasa testowa"
            };
            Repository.report.Insert(report3);

            DbReport report2 = new DbReport() {
                assignmentDate = DateTime.Now,
                isFinished = false,
                routineId = 5,
                shift = 3,
                signedEmployeeName = "",
                trackName = "Trasa testowa"
            };
            Repository.report.Insert(report2);

            DbReport report = new DbReport() {
                assignmentDate = DateTime.Now,
                isFinished = false,
                routineId = 5,
                shift = 1,
                signedEmployeeName = "",
                trackName = "Trasa testowa"
            };

            Repository.report.Insert(report);

            DbReport report5 = new DbReport() {
                assignmentDate = DateTime.Now,
                isFinished = false,
                routineId = 6,
                shift = 2,
                signedEmployeeName = "",
                trackName = "Trasa testowa 2"
            };
            Repository.report.Insert(report5);

            DbReport report4 = new DbReport() {
                assignmentDate = DateTime.Now,
                isFinished = false,
                routineId = 6,
                shift = 3,
                signedEmployeeName = "",
                trackName = "Trasa testowa 2"
            };
            Repository.report.Insert(report4);


            //DbRoutine routine = new DbRoutine() {
            //    cycleLength = 0,
            //    cycleMask = 0,
            //    shift = 1,
            //    startDay = DateTime.Now,
            //    teamId = 0,
            //    trackId = 1
            //};

            //Repository.routine.Insert(routine);
        }

        private static void ArchiveOldReports() {
            Debug.Log("Archiving reports...", LogType.Info);

            List<DbReport> reports = new List<DbReport>();
            List<DbReportPlace> reportPlaces = new List<DbReportPlace>();
            try {
                reports = Repository.report.GetAll();
                reportPlaces = Repository.reportPlace.GetAll();
            } catch (Exception ex) {
                Debug.Log(ex.ToString(), LogType.DatabaseError);
            }

            try {
                foreach (DbReport r in reports) {
                    Repository.report.Archive(r.id);
                }

                foreach (DbReportPlace p in reportPlaces) {
                    Repository.reportPlace.Archive(p.reportId, p.placeName);
                }

                Repository.reportEmployee.DeleteAll();
            } catch (Exception ex) {
                Debug.Log(ex.ToString(), LogType.DatabaseError);
            }
        }

        private static void DeleteOldRoutines(List<DbRoutine> routines) {
            Debug.Log("Deleting old routines...", LogType.Info);

            foreach (DbRoutine routine in routines) {
                if (routine.cycleLength != 0)
                    continue;

                if (routine.startDay.Date >= DateTime.Today.Date)
                    continue;

                try {
                    Repository.routine.Delete(routine.id);
                } catch (Exception ex) {
                    Debug.Log(ex.ToString(), LogType.DatabaseError);
                }
            }
        }

        private static void SendOldReports() {
            Debug.Log("Sending reports...", LogType.Info);

            List<DbMail> mails = new List<DbMail>();
            try {
                mails = Repository.mail.GetAll();
            } catch (Exception ex) {
                Debug.Log(ex.ToString(), LogType.DatabaseError);
            }

            try {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(EMAIL_NAME, EMAIL_PASSWORD);

                DateTime yesterday = DateTime.Now - new TimeSpan(1, 0, 0, 0);
                foreach (DbMail m in mails) {
                    MailMessage mm = new MailMessage(EMAIL_NAME, m.address, "Huta - Raport z dnia " + yesterday.ToString("d"), "Automatyczny raport zawarty w załączniku.");

                    //report sending part
                    if (reportMaskToPath_.ContainsKey(m.reportMask)) {
                        mm.Attachments.Add(new Attachment(reportMaskToPath_[m.reportMask]));
                    } else {
                        List<string> pathsToMerge = new List<string>();
                        if ((m.reportMask & (int) ReportMask.FULL) == (int) ReportMask.FULL)
                            pathsToMerge.Add("Reports/Report_Full.pdf");
                        if ((m.reportMask & (int)ReportMask.GENERAL) == (int)ReportMask.GENERAL)
                            pathsToMerge.Add("Reports/Report_General.pdf");
                        if ((m.reportMask & (int)ReportMask.MINIMAL) == (int)ReportMask.MINIMAL)
                            pathsToMerge.Add("Reports/Report_Minimal.pdf");
                        if ((m.reportMask & (int)ReportMask.INDIVIDUAL) == (int)ReportMask.INDIVIDUAL)
                            foreach (string indString in Repository.generator.individualReportPaths)
                                pathsToMerge.Add(indString);
                        try {
                            string mergedPath = "Reports/RaportLaczony_" + m.reportMask.ToString() + "_" + (DateTime.Today - TimeSpan.FromDays(1)).ToString("dd-MM-yyyy") + ".pdf";
                            Merge(pathsToMerge, mergedPath);
                            reportMaskToPath_.Add(m.reportMask, mergedPath);
                            mm.Attachments.Add(new Attachment(mergedPath));
                        } catch (Exception ex) {
                            Debug.Log("Couldn't merge reports:\n" + ex.ToString(), LogType.Error);
                        }
                    }



                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                    int counter = 0;
                    while (counter < 10) {
                        try {
                            client.Send(mm);
                            break;
                        } catch (Exception ex) {
                            Debug.Log(ex.ToString(), LogType.Error);
                        }

                        counter++;
                        if (counter == 10) {
                            Debug.Log("Couldn't send email to " + m.address, LogType.Error);
                        }
                    }
                }
            } catch (Exception ex) {
                Debug.Log(ex.ToString(), LogType.DatabaseError);
            }
        }

        public static void Merge(List<String> inFiles, String outFile) {
            using (FileStream stream = new FileStream(outFile, FileMode.Create))
            using (Document doc = new Document())
            using (PdfCopy pdf = new PdfCopy(doc, stream)) {
                doc.Open();
                PdfReader reader = null;
                PdfImportedPage page = null;

                inFiles.ForEach(file => {
                    reader = new PdfReader(file);

                    for (int i = 0; i < reader.NumberOfPages; i++) {
                        page = pdf.GetImportedPage(reader, i + 1);
                        pdf.AddPage(page);
                    }

                    pdf.FreeReader(reader);
                    reader.Close();
                });
            }
        }
    }
}
