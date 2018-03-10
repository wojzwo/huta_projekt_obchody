using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelWorks_Utils.Model
{
    public class DB_Report
    {
        public int id = -1;
        public int trackId;
        public int employeeId;
        public DateTime dueDate;
        public bool isFinished;
        public bool isRepeating;
        public bool isEmployeeAdded;
    }
}
