using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbPlace
    {
        public string chipId;
        public string name;
        public string department;
	}

    public class RepositoryPlace
    {
        private readonly MySqlConnection connection_;

        public RepositoryPlace(MySqlConnection connection) {
            connection_ = connection;
        }

        public string GetDepartmentByName(string name) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT department FROM Place WHERE name = @name";
            query.Parameters.AddWithValue("@name", name);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    string department = reader.GetString("department");

                    return department;
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting department by Place name\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return null;
        }

        public DbPlace Get(string chipId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Place WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbPlace place = new DbPlace() {
                        name = reader.GetString("name"),
                        chipId = reader.GetString("chipId"),
                        department = reader.GetString("department")
                    };

                    return place;
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting place\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return null;
        }

        public List<DbPlace> GetAllInTrack(int trackId) {
            List<DbPlace> places = new List<DbPlace>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Place WHERE chipId IN" +
                                "(SELECT placeId FROM TrackPlace WHERE trackId = @trackId)";
            query.Parameters.AddWithValue("@trackId", trackId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbPlace place = new DbPlace() {
                        chipId = reader.GetString("chipId"),
                        name = reader.GetString("name"),
                        department = reader.GetString("department")
                    };

                    places.Add(place);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all Places by Track\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return places;
        }

		public List<DbPlace> GetAllNotInTrack(int trackId)
		{
			List<DbPlace> places = new List<DbPlace>();

			try
			{
				connection_.Open();
			}
			catch (Exception ex)
			{
				Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
				throw new NoInternetConnectionException();
			}

			MySqlCommand query = connection_.CreateCommand();
			query.CommandText = "SELECT * FROM Place WHERE chipId NOT IN" +
								"(SELECT placeId FROM TrackPlace WHERE trackId = @trackId)";
			query.Parameters.AddWithValue("@trackId", trackId);

			try
			{
				MySqlDataReader reader = query.ExecuteReader();
				while (reader.Read())
				{
					DbPlace place = new DbPlace()
					{
						chipId = reader.GetString("chipId"),
						name = reader.GetString("name"),
						department = reader.GetString("department")
					};

					places.Add(place);
				}
			}
			catch (Exception ex)
			{
				Debug.Log("Error while getting all Places not in Track\n" + ex.ToString(), LogType.DatabaseError);
				throw new QueryExecutionException();
			}
			finally
			{
				connection_.Close();
			}

			return places;
		}

		public List<DbPlace> GetAll() {
            List<DbPlace> places = new List<DbPlace>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Place";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbPlace place = new DbPlace() {
                        name = reader.GetString("name"),
                        chipId = reader.GetString("chipId"),
                        department = reader.GetString("department")
                    };

                    places.Add(place);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all places\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return places;
        }

        public bool Insert(DbPlace place) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Place(name, chipId, department) VALUES(@name, @chipId, @department)";
            query.Parameters.AddWithValue("@name", place.name);
            query.Parameters.AddWithValue("@chipId", place.chipId);
            query.Parameters.AddWithValue("@department", place.department);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting Place\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            DbChip chip = new DbChip() {
                chipId = place.chipId,
                isEmployee = false
            };

            bool isChipInserted = false;
            try {
                isChipInserted = Repository.chip.Insert(chip);
            } catch (Exception ex) {
                throw;
            }

            return (rowsAffected == 1 && isChipInserted);
        }

        public bool Delete(string chipId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM Place WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting Place\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            bool isChipDeleted = false;
            try {
                isChipDeleted = Repository.chip.Delete(chipId);
            } catch (Exception ex) {
                throw;
            }

            return (rowsAffected == 1 && isChipDeleted);
        }
    }
}
