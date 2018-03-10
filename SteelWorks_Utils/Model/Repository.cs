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
    public enum EChipType
    {
        ErrorLoading = -1,
        None = 0,
        Employee,
        Place
    }

	public class Repository
    {
        public static Repository instance;
        private MySqlConnection connection_;



        /// <summary> 
        /// DB_Mark mark = Repository.instance.GetMark(3); 
        /// mark.name = "Inna nazwa na ocene";
        /// Repository.instance.UpdateMark(mark);
        /// </summary>
        public bool UpdateMark(DB_Mark newMark) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                return false;
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "UPDATE Mark SET name = @name, isCommentRequired = @isCommentRequired WHERE id = @id";
            query.Parameters.AddWithValue("@name", newMark.name);
            query.Parameters.AddWithValue("@isCommentRequired", newMark.bCommentRequired);
            query.Parameters.AddWithValue("@id", newMark.id);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while updating Mark\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

        public EChipType CheckChipType(string chipId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                return EChipType.ErrorLoading;
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Chip WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DB_Chip chip = new DB_Chip() {
                        chipId = reader.GetString("chipId"),
                        bIsEmployee = reader.GetBoolean("isEmployee")
                    };

                    return (chip.bIsEmployee) ? EChipType.Employee : EChipType.Place;
                }
            } catch (Exception ex) {
                Debug.Log("Error while checking chip type\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return EChipType.None;
        }

        public DB_Employee GetEmployeeByChip(string chipId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                return null;
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Employee WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DB_Employee employee = new DB_Employee() {
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

            return null;
        }

        public DB_Place GetPlaceByChip(string chipId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                return null;
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Place WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DB_Place place = new DB_Place() {
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

            return null;
        }

        public DB_Mark GetMark(int number) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                return null;
            }

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

            return null;
        }

        public List<DB_Employee> GetAllEmployees() {
            List<DB_Employee> employees = new List<DB_Employee>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                return employees;
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Employee";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DB_Employee employee = new DB_Employee() {
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

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                return marks;
            }

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

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                return places;
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Place";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DB_Place place = new DB_Place() {
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

        public bool InsertEmployee(DB_Employee employee) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                return false;
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Employee(name, chipId) VALUES(@name, @chipId)";
            query.Parameters.AddWithValue("@name", employee.name);
            query.Parameters.AddWithValue("@chipId", employee.chipId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting Employee\n" + ex.ToString(), LogType.DatabaseError);
            }

            query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Chip(chipId, isEmployee) VALUES(@chipId, @isEmployee)";
            query.Parameters.AddWithValue("@chipId", employee.chipId);
            query.Parameters.AddWithValue("@isEmployee", 1);

            int rowsAffected2 = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting Chip\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1 && rowsAffected2 == 1);
        }

        public bool InsertPlace(DB_Place place) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                return false;
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Place(name, chipId) VALUES(@name, @chipId)";
            query.Parameters.AddWithValue("@name", place.name);
            query.Parameters.AddWithValue("@chipId", place.chipId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting Place\n" + ex.ToString(), LogType.DatabaseError);
            }

            query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Chip(chipId, isEmployee) VALUES(@chipId, @isEmployee)";
            query.Parameters.AddWithValue("@chipId", place.chipId);
            query.Parameters.AddWithValue("@isEmployee", 0);

            int rowsAffected2 = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting Chip\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1 && rowsAffected2 == 1);
        }

        public bool DeleteEmployee(string chipId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                return false;
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM Employee WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting Employee\n" + ex.ToString(), LogType.DatabaseError);
            }

            query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM Chip WHERE chipId = @chipId)";
            query.Parameters.AddWithValue("@chipId", chipId);

            int rowsAffected2 = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting Chip\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1 && rowsAffected2 == 1);
        }

        public bool DeletePlace(string chipId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                return false;
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM Place WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting Place\n" + ex.ToString(), LogType.DatabaseError);
            }

            query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM Chip WHERE chipId = @chipId)";
            query.Parameters.AddWithValue("@chipId", chipId);

            int rowsAffected2 = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting Chip\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1 && rowsAffected2 == 1);
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
