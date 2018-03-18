using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbMark
    {
        /// <summary> This id is also value on keypad </summary>
        public int id = -1;
        public string description;
        public bool requiresComment;
    }

    public class RepositoryMark
    {
        private readonly MySqlConnection connection_;

        public RepositoryMark(MySqlConnection connection) {
            connection_ = connection;
        }

        public bool Update(DbMark newMark) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "UPDATE Mark SET description = @description, requiresComment = @requiresComment WHERE id = @id";
            query.Parameters.AddWithValue("@description", newMark.description);
            query.Parameters.AddWithValue("@requiresComment", newMark.requiresComment);
            query.Parameters.AddWithValue("@id", newMark.id);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while updating Mark\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

        public DbMark Get(int number) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Mark WHERE id = @id";
            query.Parameters.AddWithValue("@id", number);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbMark mark = new DbMark() {
                        id = reader.GetInt32("id"),
                        description = reader.GetString("description"),
                        requiresComment = reader.GetBoolean("requiresComment")
                    };

                    return mark;
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting mark\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return null;
        }

        public List<DbMark> GetAll() {
            List<DbMark> marks = new List<DbMark>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Mark";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbMark mark = new DbMark() {
                        id = reader.GetInt32("id"),
                        description = reader.GetString("description"),
                        requiresComment = reader.GetBoolean("requiresComment")
                    };

                    marks.Add(mark);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all marks\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return marks;
        }
    }
}
