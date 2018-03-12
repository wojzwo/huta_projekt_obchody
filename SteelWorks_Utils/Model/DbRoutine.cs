using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbRoutine
    {
        public int id;
        public int trackId;
        public int teamId;
        public DateTime startDay;
        public int cycleLength;
        public Int64 cycleMask;
        public int shift; //0 means no shift routine
    }

    public class RepositoryRoutine
    {
        private readonly MySqlConnection connection_;

        public RepositoryRoutine(MySqlConnection connection) {
            connection_ = connection;
        }
    }
}
