using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbTrack
    {
        public int id = -1;
        public string name;
        public DateTime creationDate;
    }

    public class RepositoryTrack
    {
        private readonly MySqlConnection connection_;

        public RepositoryTrack(MySqlConnection connection) {
            connection_ = connection;
        }

        public DbTrack Get(int trackId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Track WHERE trackId = @trackId";
            query.Parameters.AddWithValue("@trackId", trackId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbTrack track = new DbTrack() {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        creationDate = reader.GetDateTime("creationDate")
                    };

                    return track;
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting Track\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return null;
        }

        public List<DbTrack> GetAll() {
            List<DbTrack> tracks = new List<DbTrack>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Track";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbTrack track = new DbTrack() {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        creationDate = reader.GetDateTime("creationDate")
                    };

                    tracks.Add(track);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all Tracks\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return tracks;
        }

        public bool Insert(DbTrack track) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Track(name, creationDate) VALUES(@name, @creationDate)";
            query.Parameters.AddWithValue("@name", track.name);
            query.Parameters.AddWithValue("@creationDate", track.creationDate);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting Track\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

        public bool UpdateName(int trackId, string newName) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "UPDATE Track SET name = @newName WHERE id = @trackid";
            query.Parameters.AddWithValue("@newName", newName);
            query.Parameters.AddWithValue("@trackid", trackId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while updating Track\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

        public bool Delete(int trackId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }


            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM Track WHERE id = @trackId";
            query.Parameters.AddWithValue("@trackId", trackId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting Track\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            }

            query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM TrackPlace WHERE trackId = @trackId";
            query.Parameters.AddWithValue("@trackId", trackId);

            int rowsAffected2 = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting TrackPlace\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }
    }
}
