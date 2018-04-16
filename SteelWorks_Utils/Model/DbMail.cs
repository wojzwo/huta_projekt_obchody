using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    [Flags]
    public enum ReportMask
    {
        FULL = 1 << 0,
        GENERAL = 1 << 1,
        MINIMAL = 1 << 2,
        INDIVIDUAL = 1 << 3
    }

    public class DbMail
    {
        public int id;
        public string address;
        public int reportMask;
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
                        reportMask = reader.GetInt32("readerMask")
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
            query.CommandText = "INSERT INTO Mail(address, reportMask) VALUES(@address, @reportMask)";
            query.Parameters.AddWithValue("@address", mail.address);
            query.Parameters.AddWithValue("@reportMask", mail.reportMask);

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

		public bool Update(DbMail mail)
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

			MySqlCommand query = connection_.CreateCommand();
			query.CommandText = "UPDATE Mail SET address = @address, reportMask = @reportMask WHERE id = @id";
			query.Parameters.AddWithValue("@address", mail.address);
			query.Parameters.AddWithValue("@reportMask", mail.reportMask);
			query.Parameters.AddWithValue("@id", mail.id);

			int rowsAffected = 0;
			try
			{
				rowsAffected = query.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Debug.Log("Error while updating Mail\n" + ex.ToString(), LogType.DatabaseError);
				throw new QueryExecutionException();
			}
			finally
			{
				connection_.Close();
			}

			return (rowsAffected == 1);
		}
	}
}
