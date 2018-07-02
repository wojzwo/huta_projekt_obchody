using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SteelWorks_Utils.Model
{
    public class ReportInfo
    {
        public string placeName;
        public string[] shiftInfo = { "-", "-", "-" };
        public string[] comment = new string[3];
        public string[] employeeName = new string[3];
        public string[] status = new string[3];
        public string[] visitDate = new string[3];
        public string[] mark = new string[3];

        public DateTime[] actualDatesDateTimes = new DateTime[3];
    }

    public class EmployeeReportInfo
    {
        public EmployeeReportInfo() {
            names = new List<string>();
            durations = new List<string>();
            startTimes = new List<DateTime>();
            endTimes = new List<DateTime>();
        }

        public List<string> names;
        public List<string> durations;

        public List<DateTime> startTimes;
        public List<DateTime> endTimes;
    }

    public class DbReportGenerator
    {
        public List<string> individualReportPaths = new List<string>();

        const float normalTextSize = 13.0f;
        static BaseFont ARIAL = BaseFont.CreateFont(@"Fonts/consola.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        Font tFont = new Font(ARIAL, normalTextSize, Font.NORMAL);
        Font bFont = new Font(ARIAL, normalTextSize, Font.BOLD);
        Font boldSmallFont = new Font(ARIAL, 10.0f, Font.BOLD);
        Font smallFont = new Font(ARIAL, 10.0f, Font.NORMAL);
        BaseColor grayColor = new BaseColor(200, 200, 200);
        BaseColor lightGrayColor = new BaseColor(225, 225, 225);
        BaseColor ultraLightGrayColor = new BaseColor(240, 240, 240);

        public void GenerateShiftBasedReport(int shift) {
            Debug.Log("Generating reports for shift: " + shift, LogType.Info);
            Dictionary<string, List<ReportInfo>> dictionary = GetReportInfo(DateTime.Today, shift);
            DateTime visibleDate = (DateTime.Now.Hour <= 6) ? DateTime.Today - TimeSpan.FromDays(1) : DateTime.Today;
            ReportMask mask = (shift == 1) ? ReportMask.SHIFT_1 : (shift == 2) ? ReportMask.SHIFT_2 : ReportMask.SHIFT_3;

            try {
                using (FileStream stream = new FileStream("Reports/ReportShift_" + shift + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None)) {
                    Document doc = new Document(PageSize.A4, 36.0f, 36.0f, 36.0f, 36.0f);
                    PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                    doc.Open();
                    GeneratePDFHeader(doc, visibleDate, (int)mask);
                    GeneratePDFReportShift(doc, (int)mask, dictionary);
                    doc.Close();
                }
            } catch (Exception ex) {
                Debug.Log("Error while generating full report:\n" + ex.ToString(), LogType.Error);
            }
        }

        public void AddNewReports(List<DbRoutine> routines) {
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

        public void GenerateOldReports(DateTime day, DateTime visibleDate) {
            Debug.Log("Generating reports...", LogType.Info);
            individualReportPaths = new List<string>();

            //try {
            //    System.IO.Directory.CreateDirectory("Reports");
            //    System.IO.Directory.CreateDirectory("Reports/Individual");
            //} catch (Exception ex) {
            //    Debug.Log("Couldn't create directory\n" + ex.ToString(), LogType.Error);
            //}

            Dictionary<string, List<ReportInfo>> dictionary = GetReportInfo(day);

            try {
                using (FileStream stream = new FileStream("Reports/Report_Full.pdf", FileMode.Create, FileAccess.Write, FileShare.None)) {
                    Document doc = new Document(PageSize.A4, 36.0f, 36.0f, 36.0f, 36.0f);
                    PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                    doc.Open();
                    GeneratePDFHeader(doc, visibleDate, (int)ReportMask.FULL);
                    GeneratePDFReport(doc, (int)ReportMask.FULL, dictionary);
                    doc.Close();
                }
            } catch (Exception ex) {
                Debug.Log("Error while generating full report:\n" + ex.ToString(), LogType.Error);
            }

            try {
                using (FileStream stream = new FileStream("Reports/Report_General.pdf", FileMode.Create, FileAccess.Write, FileShare.None)) {
                    Document doc = new Document(PageSize.A4, 36.0f, 36.0f, 36.0f, 36.0f);
                    PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                    doc.Open();
                    GeneratePDFHeader(doc, visibleDate, (int)ReportMask.GENERAL);
                    GeneratePDFReport(doc, (int)ReportMask.GENERAL, dictionary);
                    doc.Close();
                }
            } catch (Exception ex) {
                Debug.Log("Error while generating partial report:\n" + ex.ToString(), LogType.Error);
            }

            try {
                using (FileStream stream = new FileStream("Reports/Report_Minimal.pdf", FileMode.Create, FileAccess.Write, FileShare.None)) {
                    Document doc = new Document(PageSize.A4, 36.0f, 36.0f, 36.0f, 36.0f);
                    PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                    doc.Open();
                    GeneratePDFHeader(doc, visibleDate, (int)ReportMask.MINIMAL);
                    GeneratePDFReport(doc, (int)ReportMask.MINIMAL, dictionary);
                    doc.Close();
                }
            } catch (Exception ex) {
                Debug.Log("Error while generating partial report:\n" + ex.ToString(), LogType.Error);
            }
        }

        private void GeneratePDFHeader(Document doc, DateTime day, int reportMask) {
            PdfPTable headerTable = new PdfPTable(3);
            headerTable.TotalWidth = doc.PageSize.Width - 72.0f;
            headerTable.LockedWidth = true;
            headerTable.SetWidths(new float[] { 0.05f, 0.45f, 0.5f });

            PdfPCell firstRowFirstColumn = new PdfPCell(new Phrase(""));
            firstRowFirstColumn.Border = Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            headerTable.AddCell(firstRowFirstColumn);

            Phrase companyNamePhrase = Phrase.GetInstance(0, "ARCELOR MITTAL HUTA WARSZAWA", new Font(ARIAL, 18.0f, Font.BOLD));
            PdfPCell companyName = new PdfPCell(companyNamePhrase);
            companyName.Colspan = 2;
            companyName.UseAscender = true;
            companyName.VerticalAlignment = Element.ALIGN_MIDDLE;
            companyName.Padding = 8;
            headerTable.AddCell(companyName);

            PdfPCell secondRowFirstColumn = new PdfPCell(new Phrase(""));
            secondRowFirstColumn.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            headerTable.AddCell(secondRowFirstColumn);

            string reportType = "";
            if ((reportMask & (int)ReportMask.FULL) == (int)ReportMask.FULL) {
                reportType = "Raport pełny";
            } else if ((reportMask & (int)ReportMask.GENERAL) == (int)ReportMask.GENERAL) {
                reportType = "Raport ogólny";
            } else if ((reportMask & (int)ReportMask.MINIMAL) == (int)ReportMask.MINIMAL) {
                reportType = "Raport minimalny";
            } else if ((reportMask & (int)ReportMask.SHIFT_1) == (int)ReportMask.SHIFT_1) {
                reportType = "Raport zmiany 1";
            } else if ((reportMask & (int)ReportMask.SHIFT_2) == (int)ReportMask.SHIFT_2) {
                reportType = "Raport zmiany 2";
            } else if ((reportMask & (int)ReportMask.SHIFT_3) == (int)ReportMask.SHIFT_3) {
                reportType = "Raport zmiany 3";
            }

            Phrase inspectionCardPhrase = Phrase.GetInstance(0, "Automatyczny raport z inspekcji - " + reportType, new Font(ARIAL, normalTextSize, Font.BOLD));
            PdfPCell inspectionCard = new PdfPCell(inspectionCardPhrase);
            inspectionCard.UseAscender = true;
            inspectionCard.HorizontalAlignment = 1;
            inspectionCard.VerticalAlignment = Element.ALIGN_MIDDLE;
            inspectionCard.Padding = 3;
            headerTable.AddCell(inspectionCard);

            Phrase legendPhrase = new Phrase();
            legendPhrase.Add(
                new Chunk("Kontrola stanu urządzeń:\n", new Font(ARIAL, normalTextSize, Font.NORMAL))
            );
            legendPhrase.Add(
                new Chunk("T", new Font(ARIAL, normalTextSize, Font.BOLD))
            );
            legendPhrase.Add(
                new Chunk("  = sprawne\n", new Font(ARIAL, normalTextSize, Font.NORMAL))
            );
            legendPhrase.Add(
                new Chunk("N", new Font(ARIAL, normalTextSize, Font.BOLD))
            );
            legendPhrase.Add(
                new Chunk("  = niesprawne\n", new Font(ARIAL, normalTextSize, Font.NORMAL))
            );
            legendPhrase.Add(
                new Chunk("*", new Font(ARIAL, normalTextSize, Font.BOLD))
            );
            legendPhrase.Add(
                new Chunk(" = nieodwiedzone\n", new Font(ARIAL, normalTextSize, Font.NORMAL))
            );
            legendPhrase.Add(
                new Chunk("-", new Font(ARIAL, normalTextSize, Font.BOLD))
            );
            legendPhrase.Add(
                new Chunk("  = kontrola niezlecona", new Font(ARIAL, normalTextSize, Font.NORMAL))
            );
            PdfPCell legend = new PdfPCell(legendPhrase);
            legend.UseAscender = true;
            legend.VerticalAlignment = Element.ALIGN_MIDDLE;
            legend.Padding = 3;
            headerTable.AddCell(legend);

            PdfPCell thirdRowFirstColumn = new PdfPCell(new Phrase(""));
            thirdRowFirstColumn.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
            headerTable.AddCell(thirdRowFirstColumn);

            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("pl-PL");
            Phrase dateTimePhrase = new Phrase();
            dateTimePhrase.Add(
                new Chunk("Data: ", new Font(ARIAL, normalTextSize, Font.BOLD))
            );
            dateTimePhrase.Add(
                new Chunk(day.ToString("dddd, dd.MM.yyyy", cultureInfo), new Font(ARIAL, normalTextSize, Font.NORMAL))
            );
            PdfPCell dateTime = new PdfPCell(dateTimePhrase);
            dateTime.Padding = 8;
            dateTime.Colspan = 2;
            dateTime.UseAscender = true;
            dateTime.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerTable.AddCell(dateTime);
            headerTable.SplitLate = false;

            //PdfPTable borderTable = new PdfPTable(1);
            //borderTable.TotalWidth = doc.PageSize.Width - 72.0f;
            //borderTable.LockedWidth = true;
            //borderTable.SpacingAfter = 0.0f;
            //PdfPCell headerCell = new PdfPCell(headerTable);
            //headerCell.BorderWidth = 1.0f;
            //borderTable.AddCell(headerCell);
            //borderTable.SplitLate = false;

            doc.Add(headerTable);
        }

        private void GeneratePDFReport(Document doc, int reportMask, Dictionary<string, List<ReportInfo>> dictionary) {
            PdfPTable mainTable = new PdfPTable(6);
            mainTable.TotalWidth = doc.PageSize.Width - 72.0f;
            mainTable.LockedWidth = true;
            mainTable.SetWidths(new float[] { 0.05f, 0.4f, 0.05f, 0.05f, 0.05f, 0.4f });

            GenerateReportHeader(mainTable);
            Dictionary<int, EmployeeReportInfo> employeeByShift = GenerateReportContent(doc, mainTable, reportMask, dictionary);

            //PdfPTable borderTable = new PdfPTable(1);
            //borderTable.TotalWidth = doc.PageSize.Width - 72.0f;
            //borderTable.LockedWidth = true;
            //borderTable.SpacingBefore = 0.0f;
            //PdfPCell headerCell = new PdfPCell(mainTable);
            //headerCell.BorderWidth = 1.0f;
            //borderTable.AddCell(headerCell);

            doc.Add(mainTable);

            PdfPTable employeeTable = new PdfPTable(2);
            employeeTable.TotalWidth = mainTable.TotalWidth;
            employeeTable.LockedWidth = true;
            employeeTable.SetWidths(new float[] { 0.2f, 0.8f });
            employeeTable.SpacingBefore = 20;

            PdfPCell headerEmployee = new PdfPCell(new Phrase("Pracownicy przeprowadzający inspekcje", bFont));
            headerEmployee.Padding = 8;
            headerEmployee.UseAscender = true;
            headerEmployee.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerEmployee.HorizontalAlignment = 1;
            headerEmployee.Colspan = 2;
            headerEmployee.BackgroundColor = grayColor;
            employeeTable.AddCell(headerEmployee);

            for (int u = 0; u < 3; u++) {
                PdfPCell shiftNumberCell = new PdfPCell(new Phrase("Zmiana " + (u + 1).ToString(), bFont));
                shiftNumberCell.Padding = 5;
                shiftNumberCell.UseAscender = true;
                shiftNumberCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                shiftNumberCell.HorizontalAlignment = 1;
                employeeTable.AddCell(shiftNumberCell);

                Phrase employeeNamesPhrase = new Phrase();
                for (int l = 0; l < employeeByShift[u + 1].names.Count - 1; l++) {
                    if (employeeByShift[u + 1].names[l] == "")
                        continue;

                    employeeNamesPhrase.Add(
                        new Chunk(employeeByShift[u + 1].names[l] + " " + employeeByShift[u + 1].durations[l] + "\n", tFont)
                    );
                }

                if (employeeByShift[u + 1].names.Count > 0 && employeeByShift[u + 1].names[employeeByShift[u + 1].names.Count - 1] != "") {
                    employeeNamesPhrase.Add(
                        new Chunk(employeeByShift[u + 1].names[employeeByShift[u + 1].names.Count - 1] + " " + employeeByShift[u + 1].durations[employeeByShift[u + 1].names.Count - 1], tFont)
                    );
                }

                PdfPCell emploeeNameCell = new PdfPCell(employeeNamesPhrase);
                emploeeNameCell.Padding = 5;
                emploeeNameCell.UseAscender = true;
                emploeeNameCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                emploeeNameCell.HorizontalAlignment = 0;
                employeeTable.AddCell(emploeeNameCell);
            }

            doc.Add(employeeTable);
        }

        private void GenerateReportHeader(PdfPTable mainTable) {
            PdfPCell spacingCell = new PdfPCell(new Phrase("  "));
            spacingCell.Colspan = 6;
            mainTable.AddCell(spacingCell);

            PdfPCell[] headerCells = new PdfPCell[6];
            headerCells[0] = new PdfPCell(new Phrase("Lp", bFont));
            headerCells[1] = new PdfPCell(new Phrase("Nazwa", bFont));
            headerCells[2] = new PdfPCell(new Phrase("Z1", bFont));
            headerCells[3] = new PdfPCell(new Phrase("Z2", bFont));
            headerCells[4] = new PdfPCell(new Phrase("Z3", bFont));
            headerCells[5] = new PdfPCell(new Phrase("Komentarze", bFont));
            for (int i = 0; i < 6; i++) {
                headerCells[i].UseAscender = true;
                headerCells[i].VerticalAlignment = Element.ALIGN_MIDDLE;
                headerCells[i].Padding = 5;
                mainTable.AddCell(headerCells[i]);
            }
        }

        private Dictionary<int, EmployeeReportInfo> GenerateReportContent(Document doc, PdfPTable mainTable, int reportMask, Dictionary<string, List<ReportInfo>> dictionary) {
            //actual table fill
            Dictionary<int, EmployeeReportInfo> employeeByShift = new Dictionary<int, EmployeeReportInfo>();
            employeeByShift.Add(1, new EmployeeReportInfo());
            employeeByShift.Add(2, new EmployeeReportInfo());
            employeeByShift.Add(3, new EmployeeReportInfo());

            foreach (KeyValuePair<string, List<ReportInfo>> pair in dictionary) {
                uint globalCounter = 1;

                Phrase departmentPhrase = new Phrase(pair.Key, bFont);
                PdfPCell departmentCell = new PdfPCell(departmentPhrase);
                departmentCell.HorizontalAlignment = 1;
                departmentCell.UseAscender = true;
                departmentCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                departmentCell.Padding = 8;
                departmentCell.Colspan = 6;
                departmentCell.BackgroundColor = grayColor;
                mainTable.AddCell(departmentCell);

                foreach (ReportInfo i in pair.Value) {
                    if (((reportMask & (int)ReportMask.MINIMAL) == (int)ReportMask.MINIMAL)
                        && (i.shiftInfo[0] == "T" || i.shiftInfo[0] == "-" || i.shiftInfo[0] == "T")
                        && (i.shiftInfo[1] == "T" || i.shiftInfo[1] == "-" || i.shiftInfo[1] == "T*")
                        && (i.shiftInfo[2] == "T" || i.shiftInfo[2] == "-" || i.shiftInfo[2] == "T*"))
                        continue;

                    for (int z = 0; z < 3; z++) {
                        if (i.employeeName[z] != null && !i.employeeName[z].StartsWith("Grupa:")) {
                            if (!employeeByShift[z + 1].names.Contains(i.employeeName[z])) {
                                employeeByShift[z + 1].names.Add(i.employeeName[z]);
                                employeeByShift[z + 1].startTimes.Add(DateTime.MaxValue);
                                employeeByShift[z + 1].endTimes.Add(DateTime.MinValue);
                                employeeByShift[z + 1].durations.Add("");
                            }
                        }
                    }

                    PdfPCell numberCell = new PdfPCell(new Phrase(globalCounter.ToString(), tFont));
                    numberCell.Padding = 5;
                    numberCell.UseAscender = true;
                    numberCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    numberCell.HorizontalAlignment = 2;
                    mainTable.AddCell(numberCell);

                    PdfPCell nameCell = new PdfPCell(new Phrase(i.placeName, tFont));
                    nameCell.Padding = 5;
                    nameCell.UseAscender = true;
                    nameCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    nameCell.HorizontalAlignment = 0;
                    mainTable.AddCell(nameCell);

                    PdfPCell shift1cell = new PdfPCell(new Phrase(i.shiftInfo[0], tFont));
                    shift1cell.Padding = 5;
                    shift1cell.UseAscender = true;
                    shift1cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    shift1cell.HorizontalAlignment = 1;
                    if (i.shiftInfo[0] == "T" || i.shiftInfo[0] == "-") {

                    } else if (i.shiftInfo[0] == "T*") {
                        shift1cell.BackgroundColor = ultraLightGrayColor;
                    } else {
                        shift1cell.BackgroundColor = lightGrayColor;
                    }
                    mainTable.AddCell(shift1cell);

                    PdfPCell shift2cell = new PdfPCell(new Phrase(i.shiftInfo[1], tFont));
                    shift2cell.Padding = 5;
                    shift2cell.UseAscender = true;
                    shift2cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    shift2cell.HorizontalAlignment = 1;
                    if (i.shiftInfo[1] == "T" || i.shiftInfo[1] == "-") {

                    } else if (i.shiftInfo[1] == "T*") {
                        shift2cell.BackgroundColor = ultraLightGrayColor;
                    } else {
                        shift2cell.BackgroundColor = lightGrayColor;
                    }
                    mainTable.AddCell(shift2cell);

                    PdfPCell shift3cell = new PdfPCell(new Phrase(i.shiftInfo[2], tFont));
                    shift3cell.Padding = 5;
                    shift3cell.UseAscender = true;
                    shift3cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    shift3cell.HorizontalAlignment = 1;
                    if (i.shiftInfo[2] == "T" || i.shiftInfo[2] == "-") {

                    } else if (i.shiftInfo[2] == "T*") {
                        shift3cell.BackgroundColor = ultraLightGrayColor;
                    } else {
                        shift3cell.BackgroundColor = lightGrayColor;
                    }
                    mainTable.AddCell(shift3cell);

                    Phrase commentPhrase = new Phrase();
                    for (int j = 0; j < i.comment.Length; j++) {
                        if (i.comment[j] != String.Empty && i.comment[j] != null) {
                            commentPhrase.Add(
                                new Chunk("Z" + (j + 1) + ": ", boldSmallFont)
                            );
                            commentPhrase.Add(
                                new Chunk(i.comment[j] + "\n", smallFont)
                            );
                        }
                    }
                    PdfPCell commentCell = new PdfPCell(commentPhrase);
                    commentCell.Padding = 5;
                    commentCell.UseAscender = true;
                    commentCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    commentCell.HorizontalAlignment = 0;
                    mainTable.AddCell(commentCell);

                    if ((reportMask & (int)ReportMask.FULL) == (int)ReportMask.FULL) {
                        PdfPCell emptyCell = new PdfPCell(new Phrase(""));
                        mainTable.AddCell("");

                        PdfPTable additionalTable = new PdfPTable(5);
                        additionalTable.TotalWidth = mainTable.TotalWidth - 25.0f;
                        additionalTable.LockedWidth = true;
                        additionalTable.SetWidths(new float[] { 0.05f, 0.25f, 0.25f, 0.25f, 0.2f });

                        for (int k = 0; k < i.shiftInfo.Length; k++) {
                            if (i.shiftInfo[k] == "-")
                                continue;

                            PdfPCell additionalShiftCell = new PdfPCell(new Phrase("Z" + (k + 1).ToString(), boldSmallFont));
                            additionalShiftCell.Padding = 5;
                            additionalShiftCell.UseAscender = true;
                            additionalShiftCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            additionalShiftCell.HorizontalAlignment = 1;
                            additionalTable.AddCell(additionalShiftCell);

                            PdfPCell additionalNameCell = new PdfPCell(new Phrase(i.employeeName[k], smallFont));
                            additionalNameCell.Padding = 5;
                            additionalNameCell.Padding = 5;
                            additionalNameCell.UseAscender = true;
                            additionalNameCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            additionalNameCell.HorizontalAlignment = 1;
                            additionalTable.AddCell(additionalNameCell);

                            PdfPCell additionalStatusCell = new PdfPCell(new Phrase(i.status[k], smallFont));
                            additionalStatusCell.Padding = 5;
                            additionalStatusCell.Padding = 5;
                            additionalStatusCell.UseAscender = true;
                            additionalStatusCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            additionalStatusCell.HorizontalAlignment = 1;
                            additionalTable.AddCell(additionalStatusCell);

                            PdfPCell additionalMarkCell = new PdfPCell(new Phrase(i.mark[k], smallFont));
                            additionalMarkCell.Padding = 5;
                            additionalMarkCell.Padding = 5;
                            additionalMarkCell.UseAscender = true;
                            additionalMarkCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            additionalMarkCell.HorizontalAlignment = 1;
                            additionalTable.AddCell(additionalMarkCell);

                            PdfPCell additionalDateCell = new PdfPCell(new Phrase(i.visitDate[k], smallFont));
                            additionalDateCell.Padding = 5;
                            additionalDateCell.Padding = 5;
                            additionalDateCell.UseAscender = true;
                            additionalDateCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            additionalDateCell.HorizontalAlignment = 1;
                            additionalTable.AddCell(additionalDateCell);
                        }

                        PdfPCell additionalCell = new PdfPCell(additionalTable);
                        additionalCell.Colspan = 5;
                        mainTable.AddCell(additionalCell);
                    }

                    globalCounter++;
                }

                foreach (ReportInfo i in pair.Value) {
                    for (int z = 0; z < 3; z++) {
                        EmployeeReportInfo info = employeeByShift[z + 1];
                        int index = info.names.FindIndex((x) => x == i.employeeName[z]);
                        if (index == -1)
                            continue;

                        if (i.actualDatesDateTimes[z] < info.startTimes[index])
                            info.startTimes[index] = i.actualDatesDateTimes[z];

                        if (i.actualDatesDateTimes[z] > info.endTimes[index])
                            info.endTimes[index] = i.actualDatesDateTimes[z];
                    }
                }
            }

            foreach (KeyValuePair<int, EmployeeReportInfo> pair in employeeByShift) {
                EmployeeReportInfo info = pair.Value;
                for (int i = 0; i < info.names.Count; i++) {
                    TimeSpan delta = info.endTimes[i] - info.startTimes[i];
                    info.durations[i] = "(" + delta.Hours + "h " + delta.Minutes + "m)";
                }
            }

            return employeeByShift;
        }

        private Dictionary<string, List<ReportInfo>> GetReportInfo(DateTime day, int supposedShift = 0) {
            Dictionary<DbReport, List<DbReportPlace>> reportPlaces = new Dictionary<DbReport, List<DbReportPlace>>();

            try {
                if (day == DateTime.Today) {
                    List<DbReport> reports = Repository.report.GetAll();
                    foreach (DbReport r in reports) {
                        List<DbReportPlace> rp = Repository.reportPlace.GetAllByReport(r.id);
                        reportPlaces.Add(r, rp);
                    }
                } else {
                    List<DbReport> reports = Repository.report.GetAllForDay(day);
                    Debug.Log(reports.Count.ToString());
                    foreach (DbReport r in reports) {
                        List<DbReportPlace> rp = Repository.reportPlace.GetAllByArchivedReport(r.id);
                        reportPlaces.Add(r, rp);
                    }
                }
            } catch (Exception ex) {
                Debug.Log(ex.ToString(), LogType.DatabaseError);
            }

            Dictionary<string, List<ReportInfo>> departmentToReports = new Dictionary<string, List<ReportInfo>>();

            foreach (KeyValuePair<DbReport, List<DbReportPlace>> pair in reportPlaces) {
                foreach (DbReportPlace p in pair.Value) {
                    int shift = pair.Key.shift;
                    if (supposedShift != 0) {
                        if (shift != supposedShift) {
                            break;
                        }
                    }

                    if (shift == 0) {
                        GenerateIndividual(pair.Key, pair.Value, day);
                        break;
                    }

                    if (shift < 1 || shift > 3) {
                        Debug.Log("Incorrect shift = " + shift + " in Report nr" + pair.Key.id + " -> skipping", LogType.Error);
                        continue;
                    }

                    string department = p.department;
                    if (!departmentToReports.ContainsKey(department)) {
                        departmentToReports.Add(department, new List<ReportInfo>());
                    }

                    ReportInfo info = departmentToReports[department].Find(x => x.placeName == p.placeName);
                    if (info == default(ReportInfo)) {
                        info = new ReportInfo();
                        info.placeName = p.placeName;
                        departmentToReports[department].Add(info);
                    }

                    shift -= 1; //indexes are [0..2] not [1..3]

                    if (info.shiftInfo[shift] != "-" && info.shiftInfo[shift] != "*") {
                        if (!p.markCommentRequired) {
                            if (p.comment != default(string))
                                info.comment[shift] += "\n-> " + p.comment;
                            continue;
                        }
                    }

                    info.employeeName[shift] = pair.Key.signedEmployeeName;
                    info.status[shift] = p.status;
                    info.comment[shift] = p.comment;

                    info.visitDate[shift] = p.visitDate.ToString("HH:mm");
                    info.actualDatesDateTimes[shift] = p.visitDate;
                    info.mark[shift] = p.markDescription;

                    if (info.shiftInfo[shift] != "-") {
                        Debug.Log("Duplicate entry: Place = " + p.placeName + "; Shift = " + (shift + 1), LogType.Warning);
                    }

                    if (!pair.Key.isFinished) {
                        info.shiftInfo[shift] = "*";
                    } else {
                        if (info.status[shift] == "Nieodwiedzono") {
                            if (p.markCommentRequired)
                                info.shiftInfo[shift] = "N*";
                            else
                                info.shiftInfo[shift] = "T*";
                        } else {
                            if (p.markCommentRequired)
                                info.shiftInfo[shift] = "N";
                            else
                                info.shiftInfo[shift] = "T";
                        }
                    }
                }
            }

            return departmentToReports;
        }

        private void GenerateIndividual(DbReport report, List<DbReportPlace> places, DateTime visibleDate) {
            try {
                string employeeNameNoSpace = report.signedEmployeeName.Replace(" ", string.Empty).Replace(":", string.Empty).Replace(".", string.Empty);
                string reportFileName = "Reports/Individual/" + report.id + "_" + employeeNameNoSpace + ".pdf";
                using (FileStream stream = new FileStream(reportFileName, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    Document doc = new Document(PageSize.A4, 36.0f, 36.0f, 36.0f, 36.0f);
                    PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    PdfPTable headerTable = new PdfPTable(3);
                    headerTable.TotalWidth = doc.PageSize.Width - 72.0f;
                    headerTable.LockedWidth = true;
                    headerTable.SetWidths(new float[] { 0.05f, 0.45f, 0.5f });

                    PdfPCell firstRowFirstColumn = new PdfPCell(new Phrase(""));
                    firstRowFirstColumn.Border = Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    headerTable.AddCell(firstRowFirstColumn);

                    Phrase companyNamePhrase = Phrase.GetInstance(0, "ARCELOR MITTAL HUTA WARSZAWA", new Font(ARIAL, 18.0f, Font.BOLD));
                    PdfPCell companyName = new PdfPCell(companyNamePhrase);
                    companyName.Colspan = 2;
                    companyName.UseAscender = true;
                    companyName.VerticalAlignment = Element.ALIGN_MIDDLE;
                    companyName.Padding = 8;
                    headerTable.AddCell(companyName);

                    PdfPCell secondRowFirstColumn = new PdfPCell(new Phrase(""));
                    secondRowFirstColumn.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    headerTable.AddCell(secondRowFirstColumn);

                    Phrase inspectionCardPhrase = Phrase.GetInstance(0, "Automatyczny raport z indywidualnej inspekcji", new Font(ARIAL, normalTextSize, Font.BOLD));
                    PdfPCell inspectionCard = new PdfPCell(inspectionCardPhrase);
                    inspectionCard.UseAscender = true;
                    inspectionCard.HorizontalAlignment = 1;
                    inspectionCard.VerticalAlignment = Element.ALIGN_MIDDLE;
                    inspectionCard.Padding = 3;
                    headerTable.AddCell(inspectionCard);

                    Phrase legendPhrase = new Phrase();
                    legendPhrase.Add(
                        new Chunk("Kontrola stanu urządzeń:\n", new Font(ARIAL, normalTextSize, Font.NORMAL))
                    );
                    legendPhrase.Add(
                        new Chunk("T", new Font(ARIAL, normalTextSize, Font.BOLD))
                    );
                    legendPhrase.Add(
                        new Chunk("  = sprawne\n", new Font(ARIAL, normalTextSize, Font.NORMAL))
                    );
                    legendPhrase.Add(
                        new Chunk("N", new Font(ARIAL, normalTextSize, Font.BOLD))
                    );
                    legendPhrase.Add(
                        new Chunk("  = niesprawne\n", new Font(ARIAL, normalTextSize, Font.NORMAL))
                    );
                    legendPhrase.Add(
                        new Chunk("*", new Font(ARIAL, normalTextSize, Font.BOLD))
                    );
                    legendPhrase.Add(
                        new Chunk(" = nieodwiedzone\n", new Font(ARIAL, normalTextSize, Font.NORMAL))
                    );

                    PdfPCell legend = new PdfPCell(legendPhrase);
                    legend.UseAscender = true;
                    legend.VerticalAlignment = Element.ALIGN_MIDDLE;
                    legend.Padding = 3;
                    headerTable.AddCell(legend);

                    PdfPCell thirdRowFirstColumn = new PdfPCell(new Phrase(""));
                    thirdRowFirstColumn.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    headerTable.AddCell(thirdRowFirstColumn);

                    CultureInfo cultureInfo = CultureInfo.GetCultureInfo("pl-PL");
                    Phrase dateTimePhrase = new Phrase();
                    dateTimePhrase.Add(
                        new Chunk("Data: ", new Font(ARIAL, normalTextSize, Font.BOLD))
                    );
                    dateTimePhrase.Add(
                        new Chunk(visibleDate.ToString("dddd, dd.MM.yyyy", cultureInfo), new Font(ARIAL, normalTextSize, Font.NORMAL))
                    );
                    PdfPCell dateTime = new PdfPCell(dateTimePhrase);
                    dateTime.Padding = 8;
                    dateTime.Colspan = 2;
                    dateTime.UseAscender = true;
                    dateTime.VerticalAlignment = Element.ALIGN_MIDDLE;
                    headerTable.AddCell(dateTime);

                    PdfPCell fourthRowFirstColumn = new PdfPCell(new Phrase(""));
                    fourthRowFirstColumn.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
                    headerTable.AddCell(fourthRowFirstColumn);

                    PdfPCell employeeNameCell = new PdfPCell(new Phrase("Pracownik: " + report.signedEmployeeName, bFont));
                    employeeNameCell.Padding = 8;
                    employeeNameCell.Colspan = 2;
                    employeeNameCell.UseAscender = true;
                    employeeNameCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    headerTable.AddCell(employeeNameCell);

                    //PdfPTable borderTable = new PdfPTable(1);
                    //borderTable.TotalWidth = doc.PageSize.Width - 72.0f;
                    //borderTable.LockedWidth = true;
                    //borderTable.SpacingAfter = 0.0f;
                    //PdfPCell headerCell = new PdfPCell(headerTable);
                    //headerCell.BorderWidth = 1.0f;
                    //borderTable.AddCell(headerCell);

                    headerTable.SplitLate = false;
                    doc.Add(headerTable);

                    //-------------------------------------

                    PdfPTable contentTableHeader = new PdfPTable(5);
                    contentTableHeader.TotalWidth = doc.PageSize.Width - 72.0f;
                    contentTableHeader.LockedWidth = true;
                    contentTableHeader.SetWidths(new float[] { 0.05f, 0.35f, 0.05f, 0.45f, 0.1f });

                    PdfPCell[] headerCells = new PdfPCell[5];
                    headerCells[0] = new PdfPCell(new Phrase("Lp", bFont));
                    headerCells[1] = new PdfPCell(new Phrase("Nazwa", bFont));
                    headerCells[2] = new PdfPCell(new Phrase("St", bFont));
                    headerCells[3] = new PdfPCell(new Phrase("Komentarz", bFont));
                    headerCells[4] = new PdfPCell(new Phrase("Godz.", bFont));
                    for (int i = 0; i < 5; i++) {
                        headerCells[i].UseAscender = true;
                        headerCells[i].VerticalAlignment = Element.ALIGN_MIDDLE;
                        headerCells[i].Padding = 5;
                        contentTableHeader.AddCell(headerCells[i]);
                    }

                    //PdfPTable borderTable2 = new PdfPTable(1);
                    //borderTable2.TotalWidth = doc.PageSize.Width - 72.0f;
                    //borderTable2.LockedWidth = true;
                    //borderTable2.SpacingAfter = 0.0f;
                    //PdfPCell headerCell2 = new PdfPCell(contentTableHeader);
                    //headerCell2.BorderWidth = 1.0f;
                    //borderTable2.AddCell(headerCell2);
                    doc.Add(contentTableHeader);

                    //-----------------------------------

                    PdfPTable contentTable = new PdfPTable(5);
                    contentTable.TotalWidth = doc.PageSize.Width - 72.0f;
                    contentTable.LockedWidth = true;
                    contentTable.SetWidths(new float[] { 0.05f, 0.35f, 0.05f, 0.45f, 0.1f });

                    for (int i = 0; i < places.Count; i++) {
                        PdfPCell lpCell = new PdfPCell(new Phrase((i + 1).ToString(), tFont));
                        lpCell.UseAscender = true;
                        lpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        lpCell.HorizontalAlignment = 1;
                        lpCell.Padding = 5;
                        contentTable.AddCell(lpCell);

                        PdfPCell placeCell = new PdfPCell(new Phrase("Dział: " + places[i].department + "\nMiejsce: " + places[i].placeName, tFont));
                        placeCell.UseAscender = true;
                        placeCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        placeCell.HorizontalAlignment = 0;
                        placeCell.Padding = 5;
                        contentTable.AddCell(placeCell);

                        string status = "";
                        if (places[i].status == "Nieodwiedzono") {
                            status = "*";
                        } else {
                            status = (places[i].markCommentRequired) ? "N" : "T";
                        }

                        PdfPCell statusCell = new PdfPCell(new Phrase(status, tFont));
                        statusCell.UseAscender = true;
                        statusCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        statusCell.HorizontalAlignment = 1;
                        statusCell.Padding = 5;
                        contentTable.AddCell(statusCell);

                        Phrase commentPhrase = new Phrase();
                        commentPhrase.Add(new Chunk(places[i].markDescription + "\n", bFont));
                        commentPhrase.Add(new Chunk(places[i].comment, tFont));
                        PdfPCell commentCell = new PdfPCell(commentPhrase);
                        commentCell.UseAscender = true;
                        commentCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        commentCell.HorizontalAlignment = 0;
                        commentCell.Padding = 5;
                        contentTable.AddCell(commentCell);

                        CultureInfo cultureInfo2 = CultureInfo.GetCultureInfo("pl-PL");
                        PdfPCell hourCell = new PdfPCell(new Phrase(places[i].visitDate.ToString("HH:mm", cultureInfo2), tFont));
                        hourCell.UseAscender = true;
                        hourCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        hourCell.HorizontalAlignment = 1;
                        hourCell.Padding = 5;
                        contentTable.AddCell(hourCell);
                    }

                    //PdfPTable borderTable3 = new PdfPTable(1);
                    //borderTable3.TotalWidth = doc.PageSize.Width - 72.0f;
                    //borderTable3.LockedWidth = true;
                    //borderTable3.SpacingAfter = 0.0f;
                    //PdfPCell headerCell3 = new PdfPCell(contentTable);
                    //headerCell3.BorderWidth = 1.0f;
                    //borderTable3.AddCell(headerCell3);
                    doc.Add(contentTable);

                    doc.Close();
                }

                individualReportPaths.Add(reportFileName);
            } catch (Exception ex) {
                Debug.Log("Error while generating full report:\n" + ex.ToString(), LogType.Error);
            }
        }

        private void GeneratePDFReportShift(Document doc, int reportMask, Dictionary<string, List<ReportInfo>> dictionary) {
            int actualShift = (reportMask == (int)ReportMask.SHIFT_1) ? 1 : (reportMask == (int)ReportMask.SHIFT_2) ? 2 : 3;

            PdfPTable mainTable = new PdfPTable(4);
            mainTable.TotalWidth = doc.PageSize.Width - 72.0f;
            mainTable.LockedWidth = true;
            mainTable.SetWidths(new float[] { 0.05f, 0.45f, 0.05f, 0.45f });

            GenerateReportHeaderShift(mainTable);
            EmployeeReportInfo employeeInShift = GenerateReportContentShift(doc, mainTable, reportMask, dictionary);

            //PdfPTable borderTable = new PdfPTable(1);
            //borderTable.TotalWidth = doc.PageSize.Width - 72.0f;
            //borderTable.LockedWidth = true;
            //borderTable.SpacingBefore = 0.0f;
            //PdfPCell headerCell = new PdfPCell(mainTable);
            //headerCell.BorderWidth = 1.0f;
            //borderTable.AddCell(headerCell);

            doc.Add(mainTable);

            PdfPTable employeeTable = new PdfPTable(2);
            employeeTable.TotalWidth = mainTable.TotalWidth;
            employeeTable.LockedWidth = true;
            employeeTable.SetWidths(new float[] { 0.2f, 0.8f });
            employeeTable.SpacingBefore = 20;

            PdfPCell headerEmployee = new PdfPCell(new Phrase("Pracownicy przeprowadzający inspekcje", bFont));
            headerEmployee.Padding = 8;
            headerEmployee.UseAscender = true;
            headerEmployee.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerEmployee.HorizontalAlignment = 1;
            headerEmployee.Colspan = 2;
            headerEmployee.BackgroundColor = grayColor;
            employeeTable.AddCell(headerEmployee);

            PdfPCell shiftNumberCell = new PdfPCell(new Phrase("Zmiana " + (actualShift).ToString(), bFont));
            shiftNumberCell.Padding = 5;
            shiftNumberCell.UseAscender = true;
            shiftNumberCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            shiftNumberCell.HorizontalAlignment = 1;
            employeeTable.AddCell(shiftNumberCell);

            Phrase employeeNamesPhrase = new Phrase();
            for (int l = 0; l < employeeInShift.names.Count - 1; l++) {
                if (employeeInShift.names[l] == "")
                    continue;

                employeeNamesPhrase.Add(
                    new Chunk(employeeInShift.names[l] + " " + employeeInShift.durations[l] + "\n", tFont)
                );
            }

            if (employeeInShift.names.Count > 0 && employeeInShift.names[employeeInShift.names.Count - 1] != "") {
                employeeNamesPhrase.Add(
                    new Chunk(employeeInShift.names[employeeInShift.names.Count - 1] + " " + employeeInShift.durations[employeeInShift.names.Count - 1], tFont)
                );
            }

            PdfPCell emploeeNameCell = new PdfPCell(employeeNamesPhrase);
            emploeeNameCell.Padding = 5;
            emploeeNameCell.UseAscender = true;
            emploeeNameCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            emploeeNameCell.HorizontalAlignment = 0;
            employeeTable.AddCell(emploeeNameCell);

            doc.Add(employeeTable);
        }

        private void GenerateReportHeaderShift(PdfPTable mainTable) {
            PdfPCell[] headerCells = new PdfPCell[4];
            headerCells[0] = new PdfPCell(new Phrase("Lp", bFont));
            headerCells[1] = new PdfPCell(new Phrase("Nazwa", bFont));
            headerCells[2] = new PdfPCell(new Phrase("Z", bFont));
            headerCells[3] = new PdfPCell(new Phrase("Komentarze", bFont));
            for (int i = 0; i < 4; i++) {
                headerCells[i].UseAscender = true;
                headerCells[i].VerticalAlignment = Element.ALIGN_MIDDLE;
                headerCells[i].Padding = 5;
                mainTable.AddCell(headerCells[i]);
            }
        }

        private EmployeeReportInfo GenerateReportContentShift(Document doc, PdfPTable mainTable, int reportMask, Dictionary<string, List<ReportInfo>> dictionary) {
            EmployeeReportInfo employeeInShift = new EmployeeReportInfo();
            int actualShiftMinus1 = (reportMask == (int)ReportMask.SHIFT_1) ? 0 : (reportMask == (int)ReportMask.SHIFT_2) ? 1 : 2;

            foreach (KeyValuePair<string, List<ReportInfo>> pair in dictionary) {
                uint globalCounter = 1;

                Phrase departmentPhrase = new Phrase(pair.Key, bFont);
                PdfPCell departmentCell = new PdfPCell(departmentPhrase);
                departmentCell.HorizontalAlignment = 1;
                departmentCell.UseAscender = true;
                departmentCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                departmentCell.Padding = 8;
                departmentCell.Colspan = 4;
                departmentCell.BackgroundColor = grayColor;
                mainTable.AddCell(departmentCell);

                foreach (ReportInfo i in pair.Value) {
                    if (i.employeeName[actualShiftMinus1] != null && !i.employeeName[actualShiftMinus1].StartsWith("Grupa:"))
                        if (!employeeInShift.names.Contains(i.employeeName[actualShiftMinus1])) {
                            employeeInShift.names.Add(i.employeeName[actualShiftMinus1]);
                            employeeInShift.durations.Add("");
                            employeeInShift.startTimes.Add(DateTime.MaxValue);
                            employeeInShift.endTimes.Add(DateTime.MinValue);
                        }

                    PdfPCell numberCell = new PdfPCell(new Phrase(globalCounter.ToString(), tFont));
                    numberCell.Padding = 5;
                    numberCell.UseAscender = true;
                    numberCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    numberCell.HorizontalAlignment = 2;
                    mainTable.AddCell(numberCell);

                    PdfPCell nameCell = new PdfPCell(new Phrase(i.placeName, tFont));
                    nameCell.Padding = 5;
                    nameCell.UseAscender = true;
                    nameCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    nameCell.HorizontalAlignment = 0;
                    mainTable.AddCell(nameCell);

                    PdfPCell shiftCell = new PdfPCell(new Phrase(i.shiftInfo[actualShiftMinus1], tFont));
                    shiftCell.Padding = 5;
                    shiftCell.UseAscender = true;
                    shiftCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    shiftCell.HorizontalAlignment = 1;
                    if (i.shiftInfo[actualShiftMinus1] == "T" || i.shiftInfo[actualShiftMinus1] == "-") {

                    } else if (i.shiftInfo[actualShiftMinus1] == "T*") {
                        shiftCell.BackgroundColor = ultraLightGrayColor;
                    } else {
                        shiftCell.BackgroundColor = lightGrayColor;
                    }
                    mainTable.AddCell(shiftCell);

                    Phrase commentPhrase = new Phrase();
                    for (int j = 0; j < i.comment.Length; j++) {
                        if (i.comment[j] != String.Empty && i.comment[j] != null) {
                            commentPhrase.Add(
                                new Chunk("Z" + (j + 1) + ": ", boldSmallFont)
                            );
                            commentPhrase.Add(
                                new Chunk(i.comment[j] + "\n", smallFont)
                            );
                        }
                    }
                    PdfPCell commentCell = new PdfPCell(commentPhrase);
                    commentCell.Padding = 5;
                    commentCell.UseAscender = true;
                    commentCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    commentCell.HorizontalAlignment = 0;
                    mainTable.AddCell(commentCell);

                    PdfPCell emptyCell = new PdfPCell(new Phrase(""));
                    mainTable.AddCell("");

                    PdfPTable additionalTable = new PdfPTable(5);
                    additionalTable.TotalWidth = mainTable.TotalWidth - 25.0f;
                    additionalTable.LockedWidth = true;
                    additionalTable.SetWidths(new float[] { 0.05f, 0.25f, 0.25f, 0.25f, 0.2f });

                    if (i.shiftInfo[actualShiftMinus1] != "-") {
                        PdfPCell additionalShiftCell = new PdfPCell(new Phrase("Z" + (actualShiftMinus1 + 1).ToString(), boldSmallFont));
                        additionalShiftCell.Padding = 5;
                        additionalShiftCell.UseAscender = true;
                        additionalShiftCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        additionalShiftCell.HorizontalAlignment = 1;
                        additionalTable.AddCell(additionalShiftCell);

                        PdfPCell additionalNameCell = new PdfPCell(new Phrase(i.employeeName[actualShiftMinus1], smallFont));
                        additionalNameCell.Padding = 5;
                        additionalNameCell.Padding = 5;
                        additionalNameCell.UseAscender = true;
                        additionalNameCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        additionalNameCell.HorizontalAlignment = 1;
                        additionalTable.AddCell(additionalNameCell);

                        PdfPCell additionalStatusCell = new PdfPCell(new Phrase(i.status[actualShiftMinus1], smallFont));
                        additionalStatusCell.Padding = 5;
                        additionalStatusCell.Padding = 5;
                        additionalStatusCell.UseAscender = true;
                        additionalStatusCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        additionalStatusCell.HorizontalAlignment = 1;
                        additionalTable.AddCell(additionalStatusCell);

                        PdfPCell additionalMarkCell = new PdfPCell(new Phrase(i.mark[actualShiftMinus1], smallFont));
                        additionalMarkCell.Padding = 5;
                        additionalMarkCell.Padding = 5;
                        additionalMarkCell.UseAscender = true;
                        additionalMarkCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        additionalMarkCell.HorizontalAlignment = 1;
                        additionalTable.AddCell(additionalMarkCell);

                        PdfPCell additionalDateCell = new PdfPCell(new Phrase(i.visitDate[actualShiftMinus1], smallFont));
                        additionalDateCell.Padding = 5;
                        additionalDateCell.Padding = 5;
                        additionalDateCell.UseAscender = true;
                        additionalDateCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        additionalDateCell.HorizontalAlignment = 1;
                        additionalTable.AddCell(additionalDateCell);
                    }

                    PdfPCell additionalCell = new PdfPCell(additionalTable);
                    additionalCell.Colspan = 5;
                    mainTable.AddCell(additionalCell);

                    globalCounter++;
                }

                foreach (ReportInfo i in pair.Value) {
                    for (int z = 0; z < 3; z++) {
                        EmployeeReportInfo info = employeeInShift;
                        int index = info.names.FindIndex((x) => x == i.employeeName[z]);
                        if (index == -1)
                            continue;

                        if (i.actualDatesDateTimes[z] < info.startTimes[index])
                            info.startTimes[index] = i.actualDatesDateTimes[z];

                        if (i.actualDatesDateTimes[z] > info.endTimes[index])
                            info.endTimes[index] = i.actualDatesDateTimes[z];
                    }
                }
            }

            EmployeeReportInfo einfo = employeeInShift;
            for (int i = 0; i < einfo.names.Count; i++) {
                TimeSpan delta = einfo.endTimes[i] - einfo.startTimes[i];
                einfo.durations[i] = "(" + delta.Hours + "h " + delta.Minutes + "m)";
            }

            return employeeInShift;
        }
    }
}
