using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelWorks_Utils.Model
{
    public class DB_Report
    {
        public Int64 id = -1;
        public string trackName;
        public int shift;
        public DateTime reportDay;
        public string employeeName;
        public bool isFinished;
        public bool isRepeating;
    }
}
