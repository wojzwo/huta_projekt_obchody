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
    }

    public class RepositoryReportPlace
    {
        private readonly MySqlConnection connection_;

        public RepositoryReportPlace(MySqlConnection connection) {
            connection_ = connection;
        }

        public bool Insert(DbReportPlace reportPlace) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO ReportPlace(reportId, placeName, department, status, markDescription, comment, visitDate) VALUES(@reportId, @placeName, @department, @status, @markDescription, @comment, @visitDate)";
            query.Parameters.AddWithValue("@reportId", reportPlace.reportId);
            query.Parameters.AddWithValue("@placeName", reportPlace.placeName);
            query.Parameters.AddWithValue("@department", reportPlace.department);
            query.Parameters.AddWithValue("@status", reportPlace.status);
            query.Parameters.AddWithValue("@markDescription", reportPlace.markDescription);
            query.Parameters.AddWithValue("@comment", reportPlace.comment);
            query.Parameters.AddWithValue("@visitDate", reportPlace.visitDate);

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
    }
}
