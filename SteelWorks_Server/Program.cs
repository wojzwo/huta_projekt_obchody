using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SteelWorks_Utils;
using SteelWorks_Utils.Model;

namespace SteelWorks_Server
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
    }

    class Program
    {
        private static float normalTextSize = 13.0f;
        static BaseFont ARIAL = BaseFont.CreateFont(@"Fonts\consola.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        static Font tFont = new Font(ARIAL, normalTextSize, Font.NORMAL);
        static Font bFont = new Font(ARIAL, normalTextSize, Font.BOLD);
        static Font boldSmallFont = new Font(ARIAL, 10.0f, Font.BOLD);
        static Font smallFont = new Font(ARIAL, 10.0f, Font.NORMAL);
        static BaseColor grayColor = new BaseColor(200, 200, 200);
        static BaseColor lightGrayColor = new BaseColor(225, 225, 225);
        static BaseColor ultraLightGrayColor = new BaseColor(240, 240, 240);

        static void Main(string[] args) {
            SendOldReports();
            AddNewReports();
        }

        private static void AddNewReports() {
            
        }

        private static void SendOldReports() {
            Dictionary<string, List<ReportInfo>> dictionary = GetReportInfo();

            using (FileStream stream = new FileStream("Report_Full.pdf", FileMode.Create, FileAccess.Write, FileShare.None)) {
                Document doc = new Document(PageSize.A4, 36.0f, 36.0f, 36.0f, 36.0f);
                PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                doc.Open();
                GeneratePDFHeader(doc, true);
                GeneratePDFReport(doc, true, dictionary);
                doc.Close();
            }

            using (FileStream stream = new FileStream("Report_General.pdf", FileMode.Create, FileAccess.Write, FileShare.None)) {
                Document doc = new Document(PageSize.A4, 36.0f, 36.0f, 36.0f, 36.0f);
                PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                doc.Open();
                GeneratePDFHeader(doc, false);
                GeneratePDFReport(doc, false, dictionary);
                doc.Close();
            }
        }

        private static void GeneratePDFHeader(Document doc, bool bFullReport) {
            PdfPTable headerTable = new PdfPTable(3);
            headerTable.TotalWidth = doc.PageSize.Width - 72.0f;
            headerTable.LockedWidth = true;
            headerTable.SetWidths(new float[] { 0.05f, 0.45f, 0.5f });

            PdfPCell firstRowFirstColumn = new PdfPCell(new Phrase(""));
            firstRowFirstColumn.Border = Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            headerTable.AddCell(firstRowFirstColumn);

            Phrase companyNamePhrase = Phrase.GetInstance(0, "ARCELOR MITTAL HUTA WARSZAWA Wydz. P-20", new Font(ARIAL, 18.0f, Font.BOLD));
            PdfPCell companyName = new PdfPCell(companyNamePhrase);
            companyName.Colspan = 2;
            companyName.UseAscender = true;
            companyName.VerticalAlignment = Element.ALIGN_MIDDLE;
            companyName.Padding = 8;
            headerTable.AddCell(companyName);

            PdfPCell secondRowFirstColumn = new PdfPCell(new Phrase(""));
            secondRowFirstColumn.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            headerTable.AddCell(secondRowFirstColumn);

            Phrase inspectionCardPhrase = Phrase.GetInstance(0, "Automatyczny raport z inspekcji P-20" + ((bFullReport) ? " - Raport Szczegółowy" : " - Raport ogólny"), new Font(ARIAL, normalTextSize, Font.BOLD));
            PdfPCell inspectionCard = new PdfPCell(inspectionCardPhrase);
            inspectionCard.UseAscender = true;
            inspectionCard.HorizontalAlignment = 1;
            inspectionCard.VerticalAlignment = Element.ALIGN_MIDDLE;
            inspectionCard.Padding = 3;
            headerTable.AddCell(inspectionCard);

            Phrase legendPhrase = new Phrase();
            legendPhrase.Add(
                new Chunk("Kontrola wizualna stanu urządzeń:\n", new Font(ARIAL, normalTextSize, Font.NORMAL))
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
                new Chunk(DateTime.Now.ToString("dddd, dd.MM.yyyy, HH:mm", cultureInfo), new Font(ARIAL, normalTextSize, Font.NORMAL))
            );
            PdfPCell dateTime = new PdfPCell(dateTimePhrase);
            dateTime.Padding = 8;
            dateTime.Colspan = 2;
            dateTime.UseAscender = true;
            dateTime.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerTable.AddCell(dateTime);

            PdfPTable borderTable = new PdfPTable(1);
            borderTable.TotalWidth = doc.PageSize.Width - 72.0f;
            borderTable.LockedWidth = true;
            borderTable.SpacingAfter = 0.0f;
            PdfPCell headerCell = new PdfPCell(headerTable);
            headerCell.BorderWidth = 1.0f;
            borderTable.AddCell(headerCell);

            doc.Add(borderTable);
        }

        private static void GeneratePDFReport(Document doc, bool bFullReport, Dictionary<string, List<ReportInfo>> dictionary) {
            PdfPTable mainTable = new PdfPTable(6);
            mainTable.TotalWidth = doc.PageSize.Width - 72.0f;
            mainTable.LockedWidth = true;
            mainTable.SetWidths(new float[] { 0.05f, 0.4f, 0.05f, 0.05f, 0.05f, 0.4f });

            GenerateReportHeader(mainTable);
            Dictionary<int, List<string>> employeeByShift = GenerateReportContent(doc, mainTable, bFullReport, dictionary);

            PdfPTable borderTable = new PdfPTable(1);
            borderTable.TotalWidth = doc.PageSize.Width - 72.0f;
            borderTable.LockedWidth = true;
            borderTable.SpacingBefore = 0.0f;
            PdfPCell headerCell = new PdfPCell(mainTable);
            headerCell.BorderWidth = 1.0f;
            borderTable.AddCell(headerCell);

            doc.Add(borderTable);

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
                for (int l = 0; l < employeeByShift[u + 1].Count - 1; l++) {
                    employeeNamesPhrase.Add(
                        new Chunk(employeeByShift[u + 1][l] + "\n", tFont)
                    );
                }

                if (employeeByShift[u + 1].Count > 0) {
                    employeeNamesPhrase.Add(
                        new Chunk(employeeByShift[u + 1][employeeByShift[u + 1].Count - 1], tFont)
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

        private static void GenerateReportHeader(PdfPTable mainTable) {
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

        private static Dictionary<int, List<string>> GenerateReportContent(Document doc, PdfPTable mainTable, bool bFullReport, Dictionary<string, List<ReportInfo>> dictionary) {
            //actual table fill
            Dictionary<int, List<string>> employeeByShift = new Dictionary<int, List<string>>();
            employeeByShift.Add(1, new List<string>());
            employeeByShift.Add(2, new List<string>());
            employeeByShift.Add(3, new List<string>());

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
                    for (int z = 0; z < 3; z++)
                        if (!employeeByShift[z+1].Contains(i.employeeName[z]))
                            employeeByShift[z+1].Add(i.employeeName[z]);

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

                    if (bFullReport) {
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
            }

            return employeeByShift;
        }

        private static Dictionary<string, List<ReportInfo>> GetReportInfo() {
            List<DbReport> reports = Repository.report.GetAll();
            Dictionary<DbReport, List<DbReportPlace>> reportPlaces = new Dictionary<DbReport, List<DbReportPlace>>();
            foreach (DbReport r in reports) {
                List<DbReportPlace> rp = Repository.reportPlace.GetAllByReport(r.id);
                reportPlaces.Add(r, rp);
            }

            Dictionary<string, List<ReportInfo>> departmentToReports = new Dictionary<string, List<ReportInfo>>();
            foreach (KeyValuePair<DbReport, List<DbReportPlace>> pair in reportPlaces) {
                foreach (DbReportPlace p in pair.Value) {
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

                    int shift = pair.Key.shift;
                    shift -= 1; //indexes are [0..2] not [1..3]
                    info.employeeName[shift] = pair.Key.signedEmployeeName;
                    info.status[shift] = p.status;
                    info.comment[shift] = p.comment;
                    info.visitDate[shift] = p.visitDate.ToString("HH:mm");
                    info.mark[shift] = p.markDescription;

                    if (p.status == "Nieodwiedzono") {
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

            return departmentToReports;
        }
    }
}
