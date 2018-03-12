using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbReport
    {
        public Int64 id = -1;
        public int routineId;
        public DateTime assignmentDate;
        public string signedEmployeeName;
        public string trackName;
        public int shift;
        public bool isFinished;
    }

    public class RepositoryReport
    {
        private readonly MySqlConnection connection_;

        public RepositoryReport(MySqlConnection connection) {
            connection_ = connection;
        }
    }
}
