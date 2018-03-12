using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbReportPlace
    {
        public Int64 reportId = -1;
        public string placeName;
        public string areaName;
        public string status;
        public string markName;
        public string comment;
    }

    public class RepositoryReportPlace
    {
        private readonly MySqlConnection connection_;

        public RepositoryReportPlace(MySqlConnection connection) {
            connection_ = connection;
        }
    }
}
