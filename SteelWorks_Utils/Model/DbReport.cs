using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbReport
    {
        public Int64 id = -1;
        public int routineId;
        public DateTime assignmentDate;
        public string signedEmployeeName;
        public string trackName;
        public int shift; //values from 1 to 3
        public bool isFinished;
    }

    public class RepositoryReport
    {
        private readonly MySqlConnection connection_;

        public RepositoryReport(MySqlConnection connection) {
            connection_ = connection;
        }

        public Int64 GetLastInsertedIndex() {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT LAST_INSERT_ID() AS reportLastId FROM Report";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    Int64 reportLastId = reader.GetInt64("reportLastId");
                    return reportLastId;
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all todays Reports\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return -1;
        }

        public bool Update(DbReport report) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "UPDATE Report SET signedEmployeeName = @signedEmployeeName, isFinished = @isFinished WHERE id = @id";
            query.Parameters.AddWithValue("@id", report.id);
            query.Parameters.AddWithValue("@signedEmployeeName", report.signedEmployeeName);
            query.Parameters.AddWithValue("@isFinished", report.isFinished);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while updating Report\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

        public bool Insert(DbReport report) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Report(routineId, assignmentDate, signedEmployeeName, trackName, shift, isFinished) VALUES(@routineId, @assignmentDate, @signedEmployeeName, @trackName, @shift, @isFinished)";
            query.Parameters.AddWithValue("@routineId", report.routineId);
            query.Parameters.AddWithValue("@assignmentDate", report.assignmentDate);
            query.Parameters.AddWithValue("@signedEmployeeName", report.signedEmployeeName);
            query.Parameters.AddWithValue("@trackName", report.trackName);
            query.Parameters.AddWithValue("@shift", report.shift);
            query.Parameters.AddWithValue("@isFinished", report.isFinished);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting Report\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            try {
                int reportCount = Repository.reportPlace.GetReportPlaceCount(report.id);
                if (reportCount > 0)
                    return rowsAffected == 1;
            } catch (Exception ex) {
                throw;
            }

            List<DbPlace> places = new List<DbPlace>();
            Int64 reportId;
            try {
                DbRoutine routine = Repository.routine.Get(report.routineId);
                places = Repository.place.GetAllInTrack(routine.trackId);
                reportId = GetLastInsertedIndex();
            } catch (Exception ex) {
                throw;
            }

            foreach (DbPlace place in places) {
                DbReportPlace reportPlace = new DbReportPlace() {
                    reportId = reportId,
                    placeName = place.name,
                    department = place.department,
                    status = "Nieodwiedzono",
                    comment = "",
                    visitDate = DateTime.MinValue,
                    markDescription = "",
                    markCommentRequired = false
                };

                try {
                    Repository.reportPlace.Insert(reportPlace);
                } catch (Exception ex) {
                    throw;
                }
            }

            return (rowsAffected == 1);
        }

        public List<DbReport> GetAll() {
            List<DbReport> reports = new List<DbReport>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Report";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbReport report = new DbReport() {
                        id = reader.GetInt64("id"),
                        trackName = reader.GetString("trackName"),
                        shift = reader.GetInt32("shift"),
                        isFinished = reader.GetBoolean("isFinished"),
                        assignmentDate = reader.GetDateTime("assignmentDate"),
                        routineId = reader.GetInt32("routineId"),
                        signedEmployeeName = reader.GetString("signedEmployeeName")
                    };

                    reports.Add(report);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all todays Reports\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return reports;
        }

        public List<DbReport> GetAllTodaysForEmployee(string employeeName) {
            List<DbReport> reports = new List<DbReport>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Report WHERE assignmentDate = CURDATE() AND isFinished = 0 AND routineId IN" +
                                "(SELECT id FROM Routine WHERE teamId = 0 OR teamId IN" +
                                "(SELECT teamId FROM TeamEmployee WHERE employeeId = " +
                                "(SELECT employeeId FROM Employee WHERE name = @employeeName)));";
            query.Parameters.AddWithValue("@employeeName", employeeName);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbReport report = new DbReport() {
                        id = reader.GetInt64("id"),
                        trackName = reader.GetString("trackName"),
                        shift = reader.GetInt32("shift"),
                        isFinished = reader.GetBoolean("isFinished"),
                        assignmentDate = reader.GetDateTime("assignmentDate"),
                        routineId = reader.GetInt32("routineId"),
                        signedEmployeeName = reader.GetString("signedEmployeeName")
                    };

                    reports.Add(report);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all todays Reports for employee\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return reports;
        }

        public DbReport Get(Int64 reportId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Report WHERE id = @id";
            query.Parameters.AddWithValue("@id", reportId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbReport report = new DbReport() {
                        id = reader.GetInt64("id"),
                        trackName = reader.GetString("trackName"),
                        shift = reader.GetInt32("shift"),
                        isFinished = reader.GetBoolean("isFinished"),
                        assignmentDate = reader.GetDateTime("assignmentDate"),
                        routineId = reader.GetInt32("routineId"),
                        signedEmployeeName = reader.GetString("signedEmployeeName")
                    };

                    return report;
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting Report\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return null;
        }

        public bool Archive(Int64 reportId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO ArchiveReport SELECT * FROM Report WHERE id = @id";
            query.Parameters.AddWithValue("@id", reportId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while archiving-adding Report\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM Report WHERE id = @id";
            query.Parameters.AddWithValue("@id", reportId);

            int rowsAffected2 = 0;
            try {
                rowsAffected2 = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while archiving-deletng Report\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return rowsAffected == 1 && rowsAffected2 == 1;
        }
    }
}
