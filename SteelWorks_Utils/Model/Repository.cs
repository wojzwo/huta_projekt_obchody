using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SteelWorks_Utils;

namespace SteelWorks_Utils.Model
{
    public class Repository
    {
        public static Repository instance;

        private MySqlConnection connection_;

        public DB_Employee GetEmployeeByChip(string chipId) {
            connection_.Open();
            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Employee WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DB_Employee employee = new DB_Employee() {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        chipId = reader.GetString("chipId")
                    };

                    return employee;
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting employee\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return new DB_Employee();
        }

        public DB_Place GetPlaceByChip(string chipId) {
            connection_.Open();
            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Place WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DB_Place place = new DB_Place() {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        chipId = reader.GetString("chipId"),
                    };

                    return place;
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting place\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return new DB_Place();
        }

        public DB_Mark GetMark(int number) {
            connection_.Open();
            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Mark WHERE id = @id";
            query.Parameters.AddWithValue("@id", number);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DB_Mark mark = new DB_Mark() {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        bCommentRequired = reader.GetBoolean("isCommentRequired")
                    };

                    return mark;
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting mark\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return new DB_Mark();
        }

        public List<DB_Employee> GetAllEmployees() {
            List<DB_Employee> employees = new List<DB_Employee>();

            connection_.Open();
            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Employee";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DB_Employee employee = new DB_Employee() {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        chipId = reader.GetString("chipId")
                    };

                    employees.Add(employee);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all employees\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return employees;
        }

        public List<DB_Mark> GetAllMarks() {
            List<DB_Mark> marks = new List<DB_Mark>();

            connection_.Open();
            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Mark";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DB_Mark mark = new DB_Mark() {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        bCommentRequired = reader.GetBoolean("isCommentRequired")
                    };

                    marks.Add(mark);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all marks\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return marks;
        }

        public List<DB_Place> GetAllPlaces() {
            List<DB_Place> places = new List<DB_Place>();

            connection_.Open();
            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Place";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DB_Place place = new DB_Place() {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        chipId = reader.GetString("chipId"),
                    };

                    places.Add(place);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all places\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return places;
        }

        public bool InsertChip(DB_Chip chip) {
            connection_.Open();
            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Chip VALUES(@chipId, @isEmployee)";
            query.Parameters.AddWithValue("@chipId", chip.chipId);
            query.Parameters.AddWithValue("@isEmployee", chip.bIsEmployee);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting chip\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

        public Repository() {
            instance = this;
            connection_ = new MySqlConnection(ParseDatabaseConfig());
        }

        private string ParseDatabaseConfig() {
            string ret = "";
            try {
                using (FileStream stream = new FileStream("DatabaseCredentials.config", FileMode.Open, FileAccess.Read, FileShare.Read)) {
                    using (StreamReader reader = new StreamReader(stream)) {
                        //Server = myServerAddress; Port = 1234; Database = myDataBase; Uid = myUsername;
                        //Pwd = myPassword;
                        string serverName = reader.ReadLine().Split('=')[1];
                        string portNr = reader.ReadLine().Split('=')[1];
                        string database = reader.ReadLine().Split('=')[1];
                        string user = reader.ReadLine().Split('=')[1];
                        string password = reader.ReadLine().Split('=')[1];
                        ret = "Server=" + serverName + ";Port=" + portNr + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";";
                    }
                }
            } catch (Exception ex) {
                Debug.Log("Error while parsing database config file\n" + ex.ToString(), LogType.Error);
            }

            return ret;
        }
    }
}
