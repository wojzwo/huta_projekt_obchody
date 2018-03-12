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
        public int shift;
        public bool isFinished;
    }

    public class RepositoryReport
    {
        private readonly MySqlConnection connection_;

        public RepositoryReport(MySqlConnection connection) {
            connection_ = connection;
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

            return (rowsAffected == 1);
        } 

        public List<DbReport> GetAllTodays(bool bIncludeFinished) {
            List<DbReport> reports = new List<DbReport>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            if (bIncludeFinished) {
                query.CommandText = "SELECT * FROM Report WHERE assignmentDate = CURDATE()";
            } else {
                query.CommandText = "SELECT * FROM Report WHERE assignmentDate = CURDATE() AND isFinished = 0";
            }

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
    }
}
