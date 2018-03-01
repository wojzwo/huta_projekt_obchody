using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SteelWorks_Worker.Utilities;

namespace SteelWorks_Worker.Model
{
    public class Repository
    {
        public List<string> GetTest() {
            List<string> retStrings = new List<string>();
            try {
                string query = "SELECT * FROM test";
                MySqlCommand cmd = new MySqlCommand(query, connection_);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read()) {
                    retStrings.Add(rdr[0] + " -- " + rdr[1]);
                }

                rdr.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            return retStrings;
        }

        public void CloseConnection() {
            connection_.Close();
        }

        public Repository() {
            string connectionString = "SERVER=" + Config.databaseServerIp + "; PORT=3306 ;" + "DATABASE=" + Config.databaseName + ";" + "UID=" + Config.databaseUsername + ";" + "PASSWORD=" + Config.databasePassword + ";";
            connection_ = new MySqlConnection(connectionString);

            try {
                //connection_.Open();
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        private MySqlConnection connection_ = null;
    }
}
