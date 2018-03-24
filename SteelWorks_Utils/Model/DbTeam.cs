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

        public DbTeam Get(int teamId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Team WHERE id = @teamId";
            query.Parameters.AddWithValue("@teamId", teamId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbTeam team = new DbTeam() {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name")
                    };

                    return team;
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting Team\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return null;
        }

        public List<DbTeam> GetAll() {
            List<DbTeam> teams = new List<DbTeam>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Team";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbTeam team = new DbTeam() {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name")
                    };

                    teams.Add(team);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all Teams\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return teams;
        }

        public int Insert(DbTeam team) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Team(name) VALUES(@name);" +
                "SELECT LAST_INSERT_ID();";
            query.Parameters.AddWithValue("@name", team.name);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                int i = 0;
                while (reader.Read()) {
                    return reader.GetInt32("LAST_INSERT_ID()");
                }
            } catch (Exception ex) {
                Debug.Log("Error while inserting Team\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }
            return -1;
        }

        public bool UpdateName(int teamId, string newName) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "UPDATE Team SET name = @newName WHERE id = @teamid";
            query.Parameters.AddWithValue("@newName", newName);
            query.Parameters.AddWithValue("@teamid", teamId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while updating Team\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

        public bool Delete(int teamId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }


            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM Team WHERE id = @teamId";
            query.Parameters.AddWithValue("@teamId", teamId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting Team\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            }

            query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM TeamEmployee WHERE teamId = @teamId";
            query.Parameters.AddWithValue("@teamId", teamId);

            int rowsAffected2 = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting TeamEmployee\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }
    }
}
