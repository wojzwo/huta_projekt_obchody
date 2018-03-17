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
    }

    class Program
    {
        private static float normalTextSize = 13.0f;
        static BaseFont ARIAL = BaseFont.CreateFont(@"Fonts\consola.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        static Font tFont = new Font(ARIAL, normalTextSize, Font.NORMAL);
        static Font bFont = new Font(ARIAL, normalTextSize, Font.BOLD);

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
                GeneratePDFHeader(doc);
                GeneratePDFReport(doc, true, dictionary);
                doc.Close();
            }

            using (FileStream stream = new FileStream("Report_General.pdf", FileMode.Create, FileAccess.Write, FileShare.None)) {
                Document doc = new Document(PageSize.A4, 36.0f, 36.0f, 36.0f, 36.0f);
                PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                doc.Open();
                GeneratePDFHeader(doc);
                GeneratePDFReport(doc, false, dictionary);
                doc.Close();
            }
        }

        private static void GeneratePDFHeader(Document doc) {
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

            Phrase inspectionCardPhrase = Phrase.GetInstance(0, "Automatyczny raport z inspekcji P-20", new Font(ARIAL, normalTextSize, Font.BOLD));
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
                new Chunk("  = sprawdzone i sprawne\n", new Font(ARIAL, normalTextSize, Font.NORMAL))
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
            GenerateReportContent(mainTable, bFullReport, dictionary);

            PdfPTable borderTable = new PdfPTable(1);
            borderTable.TotalWidth = doc.PageSize.Width - 72.0f;
            borderTable.LockedWidth = true;
            borderTable.SpacingBefore = 0.0f;
            PdfPCell headerCell = new PdfPCell(mainTable);
            headerCell.BorderWidth = 1.0f;
            borderTable.AddCell(headerCell);

            doc.Add(borderTable);
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
                headerCells[i].Padding = 4;
                mainTable.AddCell(headerCells[i]);
            }
        }

        private static void GenerateReportContent(PdfPTable mainTable, bool bFullReport, Dictionary<string, List<ReportInfo>> dictionary) {
            uint globalCounter = 1;

            //actual table fill
            foreach (KeyValuePair<string, List<ReportInfo>> pair in dictionary) {
                Phrase departmentPhrase = new Phrase(pair.Key, bFont);
                PdfPCell departmentCell = new PdfPCell(departmentPhrase);
                departmentCell.HorizontalAlignment = 1;
                departmentCell.UseAscender = true;
                departmentCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                departmentCell.Padding = 4;
                departmentCell.Colspan = 6;
                mainTable.AddCell(departmentCell);
            }
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
