using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbReportPlace
    {
        public Int64 reportId = -1;
        public string placeName;
        public string department;
        public string status;
        public string markDescription;
        public string comment;
        public DateTime visitDate;
        public bool markCommentRequired;
    }

    public class RepositoryReportPlace
    {
        private readonly MySqlConnection connection_;

        public RepositoryReportPlace(MySqlConnection connection) {
            connection_ = connection;
        }

        public int GetReportPlaceCount(Int64 reportId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT COUNT(*) AS reportCount FROM ReportPlace WHERE reportId = @reportId";
            query.Parameters.AddWithValue("@reportId", reportId);

            int rowsAffected = 0;
            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    int reportCount = reader.GetInt32("reportCount");
                    return reportCount;
                }
            } catch (Exception ex) {
                Debug.Log("Error while inserting ReportPlace\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return -1;
        }

        public bool Update(DbReportPlace reportPlace) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "UPDATE ReportPlace SET status = @status, markDescription = @markDescription, comment = @comment, visitDate = @visitDate, markCommentRequired = @markCommentRequired WHERE reportId = @reportId AND placeName = @placeName AND department = @department";
            query.Parameters.AddWithValue("@reportId", reportPlace.reportId);
            query.Parameters.AddWithValue("@placeName", reportPlace.placeName);
            query.Parameters.AddWithValue("@department", reportPlace.department);
            query.Parameters.AddWithValue("@status", reportPlace.status);
            query.Parameters.AddWithValue("@markDescription", reportPlace.markDescription);
            query.Parameters.AddWithValue("@comment", reportPlace.comment);
            query.Parameters.AddWithValue("@visitDate", reportPlace.visitDate);
            query.Parameters.AddWithValue("@markCommentRequired", reportPlace.markCommentRequired);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while updating ReportPlace\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

        public bool Insert(DbReportPlace reportPlace) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO ReportPlace(reportId, placeName, department, status, markDescription, comment, visitDate, markCommentRequired) VALUES(@reportId, @placeName, @department, @status, @markDescription, @comment, @visitDate, @markCommentRequired)";
            query.Parameters.AddWithValue("@reportId", reportPlace.reportId);
            query.Parameters.AddWithValue("@placeName", reportPlace.placeName);
            query.Parameters.AddWithValue("@department", reportPlace.department);
            query.Parameters.AddWithValue("@status", reportPlace.status);
            query.Parameters.AddWithValue("@markDescription", reportPlace.markDescription);
            query.Parameters.AddWithValue("@comment", reportPlace.comment);
            query.Parameters.AddWithValue("@visitDate", reportPlace.visitDate);
            query.Parameters.AddWithValue("@markCommentRequired", reportPlace.markCommentRequired);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting ReportPlace\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

        public List<DbReportPlace> GetAll() {
            List<DbReportPlace> reports = new List<DbReportPlace>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM ReportPlace";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbReportPlace reportPlace = new DbReportPlace() {
                        reportId = reader.GetInt64("reportId"),
                        placeName = reader.GetString("placeName"),
                        department = reader.GetString("department"),
                        status = reader.GetString("status"),
                        markDescription = reader.GetString("markDescription"),
                        comment = reader.GetString("comment"),
                        visitDate = reader.GetDateTime("visitDate"),
                        markCommentRequired = reader.GetBoolean("markCommentRequired")
                    };

                    reports.Add(reportPlace);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all ReportPlaces\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return reports;
        }

        public List<DbReportPlace> GetAllByReport(Int64 reportId) {
            List<DbReportPlace> reports = new List<DbReportPlace>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM ReportPlace WHERE reportId = @reportId";
            query.Parameters.AddWithValue("@reportId", reportId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbReportPlace reportPlace = new DbReportPlace() {
                        reportId = reader.GetInt64("reportId"),
                        placeName = reader.GetString("placeName"),
                        department = reader.GetString("department"),
                        status = reader.GetString("status"),
                        markDescription = reader.GetString("markDescription"),
                        comment = reader.GetString("comment"),
                        visitDate = reader.GetDateTime("visitDate"),
                        markCommentRequired = reader.GetBoolean("markCommentRequired")
                    };

                    reports.Add(reportPlace);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all todays ReportPlaces\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return reports;
        }

        public List<DbReportPlace> GetAllByArchivedReport(Int64 reportId) {
            List<DbReportPlace> reports = new List<DbReportPlace>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM ArchiveReportPlace WHERE reportId = @reportId";
            query.Parameters.AddWithValue("@reportId", reportId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbReportPlace reportPlace = new DbReportPlace() {
                        reportId = reader.GetInt64("reportId"),
                        placeName = reader.GetString("placeName"),
                        department = reader.GetString("department"),
                        status = reader.GetString("status"),
                        markDescription = reader.GetString("markDescription"),
                        comment = reader.GetString("comment"),
                        visitDate = reader.GetDateTime("visitDate"),
                        markCommentRequired = reader.GetBoolean("markCommentRequired")
                    };

                    reports.Add(reportPlace);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting certain archived ReportPlaces\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return reports;
        }

        public bool Archive(Int64 reportId, string placeName) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO ArchiveReportPlace SELECT * FROM ReportPlace WHERE (reportId = @reportId AND placeName = @placeName)";
            query.Parameters.AddWithValue("@reportId", reportId);
            query.Parameters.AddWithValue("@placeName", placeName);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while archiving-adding ReportPlace\n" + ex.ToString(), LogType.DatabaseError);
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
            query.CommandText = "DELETE FROM ReportPlace WHERE reportId = @reportId AND placeName = @placeName";
            query.Parameters.AddWithValue("@reportId", reportId);
            query.Parameters.AddWithValue("@placeName", placeName);

            int rowsAffected2 = 0;
            try {
                rowsAffected2 = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while archiving-deleting ReportPlace\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return rowsAffected == 1 && rowsAffected2 == 1;
        }
    }
}
