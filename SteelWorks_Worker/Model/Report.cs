using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelWorks_Worker.View;

namespace SteelWorks_Worker.Model
{
    public class ReportDataItem
    {
        public string placeName;
        public DataItemStatus placeStatus;
        public string placeMark;
        public string placeComment;
        public DateTime placeVisitDate;
    }

    public class ReportProcessData
    {
        public string employeeName;
        public List<ReportDataItem> items;
    }
}
