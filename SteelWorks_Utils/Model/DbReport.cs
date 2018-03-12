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
        public string trackName;
        public int shift;
        public DateTime reportDay;
        public string employeeName;
        public bool isFinished;
        public bool isRepeating;
    }

    public class RepositoryReport
    {
        private readonly MySqlConnection connection_;

        public RepositoryReport(MySqlConnection connection) {
            connection_ = connection;
        }
    }
}
