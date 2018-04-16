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

        static void Main(string[] args) {
            Debug.Log("Started program", LogType.Info);
            //InsertTestData();

            DirectoryInfo info = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = info.GetFiles("Reports/*.pdf")
                .Where(p => p.Extension == ".pdf").ToArray();
            foreach (FileInfo file in files) {
                try {
                    file.Attributes = FileAttributes.Normal;
                    File.Delete(file.FullName);
                } catch {

                }
            }

            Repository.generator.GenerateOldReports(DateTime.Today);
            //SendOldReports();
            //ArchiveOldReports();

            List<DbRoutine> routines = new List<DbRoutine>();
            try {
                routines = Repository.routine.GetAll();
            } catch (Exception ex) {
                Debug.Log(ex.ToString(), LogType.DatabaseError);
            }

            //AddNewReports(routines);
            //DeleteOldRoutines(routines);
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

        private static void AddNewReports(List<DbRoutine> routines) {
            Debug.Log("Adding new reports...", LogType.Info);

            foreach (DbRoutine routine in routines) {
                string teamName = "";
                if (routine.teamId == 0) {
                    teamName = "--Dowolny pracownik--";
                } else {
                    try {
                        DbTeam team = Repository.team.Get(routine.teamId);
                        teamName = team.name;
                    } catch (Exception ex) {
                        //In case there is no such team (for example team 0 meaning everyone can complete report)
                    }
                }

                string trackName = "";
                try {
                    DbTrack track = Repository.track.Get(routine.trackId);
                    trackName = track.name;
                } catch (Exception ex) {
                    Debug.Log("Couldn't get requested track by id = " + routine.trackId, LogType.Error);
                    Debug.Log(ex.ToString(), LogType.DatabaseError);
                    continue;
                }

                if (routine.cycleLength == 0) {
                    if (routine.startDay.Date != DateTime.Today.Date)
                        continue;
                } else {
                    int dayDiff = (DateTime.Now.Date - routine.startDay).Days;
                    if (dayDiff < 0)
                        continue;

                    dayDiff = dayDiff % routine.cycleLength;
                    UInt64 shiftedMask = routine.cycleMask >> dayDiff;
                    if ((shiftedMask & 1) != 1)
                        continue;
                }

                DbReport newReport = new DbReport() {
                    shift = routine.shift,
                    id = 0,
                    routineId = routine.id,
                    signedEmployeeName = "Grupa: " + teamName,
                    isFinished = false,
                    trackName = trackName,
                    assignmentDate = DateTime.Now
                };

                try {
                    Repository.report.Insert(newReport);
                } catch (Exception ex) {
                    Debug.Log(ex.ToString(), LogType.DatabaseError);
                }
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
                    if ((m.reportMask & (int) ReportMask.FULL) == 1) {
                        mm.Attachments.Add(new Attachment("Reports/Report_Full.pdf"));
                    } else if ((m.reportMask & (int) ReportMask.GENERAL) == 1) {
                        mm.Attachments.Add(new Attachment("Reports/Report_General.pdf"));
                    } else if ((m.reportMask & (int) ReportMask.MINIMAL) == 1) {
                        mm.Attachments.Add(new Attachment("Reports/Report_Minimal.pdf"));
                    } else if ((m.reportMask & (int) ReportMask.INDIVIDUAL) == 1) {
                        foreach (string indString in Repository.generator.individualReportPaths)
                            mm.Attachments.Add(new Attachment(indString));
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
    }
}
