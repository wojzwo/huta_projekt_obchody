using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbReportEmployee
    {
        public Int64 reportId;
        public string employeeId;
        public string employeeName;
    }

    public class RepositoryReportEmployee
    {
        private readonly MySqlConnection connection_;

        public RepositoryReportEmployee(MySqlConnection connection) {
            connection_ = connection;
        }

        public bool Insert(DbReportEmployee reportEmployee) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO ReportEmployee(reportId, employeeId, employeeName) VALUES(@reportId, @employeeId, @employeeName)";
            query.Parameters.AddWithValue("@reportId", reportEmployee.reportId);
            query.Parameters.AddWithValue("@employeeId", reportEmployee.employeeId);
            query.Parameters.AddWithValue("@employeeName", reportEmployee.employeeName);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting ReportEmployee\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

        public bool Delete(Int64 reportId, string employeeId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM ReportEmployee WHERE reportId = @reportId AND employeeId = @employeeId";
            query.Parameters.AddWithValue("@reportId", reportId);
            query.Parameters.AddWithValue("@employeeId", employeeId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting ReportEmployee\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

        public void DeleteAll() {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM ReportEmployee WHERE reportId > 0";

            try {
                query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting all ReportEmployee\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }
        }
    }
}
