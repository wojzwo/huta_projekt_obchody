using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbMail
    {
        public int id;
        public string address;
        public bool isFullReport;
    }

    public class RepositoryMail
    {
        private readonly MySqlConnection connection_;

        public RepositoryMail(MySqlConnection connection) {
            connection_ = connection;
        }

        public List<DbMail> GetAll() {
            List<DbMail> mails = new List<DbMail>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Mail";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbMail mail = new DbMail() {
                        id = reader.GetInt32("id"),
                        address = reader.GetString("address"),
                        isFullReport = reader.GetBoolean("isFullReport")
                    };

                    mails.Add(mail);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all Mails\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return mails;
        }

        public bool Insert(DbMail mail) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Mail(address, isFullReport) VALUES(@address, @isFullReport)";
            query.Parameters.AddWithValue("@address", mail.address);
            query.Parameters.AddWithValue("@isFullReport", mail.isFullReport);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting Mail\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return rowsAffected == 1;
        }

        public bool Delete(int id) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM Mail WHERE id = @id";
            query.Parameters.AddWithValue("@id", id);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting Mail\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }
    }
}
