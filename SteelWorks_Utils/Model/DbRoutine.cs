using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbRoutine
    {
        public int id;
		public string name;
        public int trackId;
        public int teamId;
        public DateTime startDay;
        public int cycleLength;
        public UInt64 cycleMask;
        public int shift; //0 means no shift routine
    }

    public class RepositoryRoutine
    {
        private readonly MySqlConnection connection_;

        public RepositoryRoutine(MySqlConnection connection) {
            connection_ = connection;
        }

        public bool Insert(DbRoutine routine) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Routine(cycleLength, shift, trackId, cycleMask, startDay, teamId) VALUES(@cycleLength, @shift, @trackId, @cycleMask, @startDay, @teamId)";
            query.Parameters.AddWithValue("@cycleLength", routine.cycleLength);
            query.Parameters.AddWithValue("@shift", routine.shift);
            query.Parameters.AddWithValue("@trackId", routine.trackId);
            query.Parameters.AddWithValue("@cycleMask", routine.cycleMask);
            query.Parameters.AddWithValue("@startDay", routine.startDay);
            query.Parameters.AddWithValue("@teamId", routine.teamId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting Routine\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

		public bool Update(DbRoutine routine)
		{
			try
			{
				connection_.Open();
			}
			catch (Exception ex)
			{
				Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
				throw new NoInternetConnectionException();
			}

			//TODO UPDATE NAME
			MySqlCommand query = connection_.CreateCommand();
			query.CommandText = "UPDATE Routine SET cycleLength = @cycleLength, shif = @shif, trackId=@trackId, cycleMask=@cycleMask, startDay=@startDay, teamId=@teamId WHERE id = @id";
			query.Parameters.AddWithValue("@cycleLength", routine.cycleLength);
			query.Parameters.AddWithValue("@shift", routine.shift);
			query.Parameters.AddWithValue("@trackId", routine.trackId);
			query.Parameters.AddWithValue("@cycleMask", routine.cycleMask);
			query.Parameters.AddWithValue("@startDay", routine.startDay);
			query.Parameters.AddWithValue("@teamId", routine.teamId);
			query.Parameters.AddWithValue("@id", routine.id);

			int rowsAffected = 0;
			try
			{
				rowsAffected = query.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Debug.Log("Error while updating Routine\n" + ex.ToString(), LogType.DatabaseError);
				throw new QueryExecutionException();
			}
			finally
			{
				connection_.Close();
			}

			return (rowsAffected == 1);
		}

		public List<DbRoutine> GetAll() {
            List<DbRoutine> routines = new List<DbRoutine>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Routine";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
					DbRoutine routine = new DbRoutine() {
						id = reader.GetInt32("id"),
						//TODO
						name = "",
						shift = reader.GetInt32("shift"),
                        trackId = reader.GetInt32("trackId"),
                        cycleLength = reader.GetInt32("cycleLength"),
                        teamId = reader.GetInt32("teamId"),
                        cycleMask = reader.GetUInt64("cycleMask"),
                        startDay = reader.GetDateTime("startDay")
                    };

                    routines.Add(routine);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all Routines\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return routines;
        }

        public DbRoutine Get(int routineId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Routine WHERE id = @id";
            query.Parameters.AddWithValue("@id", routineId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
					DbRoutine routine = new DbRoutine() {
						cycleLength = reader.GetInt32("cycleLength"),
						id = reader.GetInt32("id"),
						//TODO
						name = "",
                        shift = reader.GetInt32("shift"),
                        trackId = reader.GetInt32("trackId"),
                        cycleMask = reader.GetUInt64("cycleMask"),
                        startDay = reader.GetDateTime("startDay"),
                        teamId = reader.GetInt32("teamId")
                    };

                    return routine;
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting Routine\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return null;
        }



        public bool Delete(int routineId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM Routine WHERE id = @id";
            query.Parameters.AddWithValue("@id", routineId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting Routine\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }
    }
}
