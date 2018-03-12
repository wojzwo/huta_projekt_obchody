using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbTeamEmployee
    {
        public int teamId;
        public string employeeId;
    }

    public class RepositoryTeamEmployee
    {
        private readonly MySqlConnection connection_;

        public RepositoryTeamEmployee(MySqlConnection connection) {
            connection_ = connection;
        }
    }
}
