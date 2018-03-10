using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelWorks_Utils.Model
{
    public class DB_TrackRepeating
    {
        public int id = -1;
        public int trackId;
        public int employeeId;
        public DateTime dayStart;
        public int repeatLength;
        public Int64 repeatMask;
    }
}
