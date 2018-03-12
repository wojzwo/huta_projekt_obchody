using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbTeam
    {
        public int id;
        public string name;
    }

    public class RepositoryTeam
    {
        private readonly MySqlConnection connection_;

        public RepositoryTeam(MySqlConnection connection) {
            connection_ = connection;
        }
    }
}
