using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public enum EChipType
    {
        None = 0,
        Employee,
        Place
    }

    public class DbChip
    {
        public string chipId = "";
        public bool isEmployee;
    }

    public class RepositoryChip
    {
        private readonly MySqlConnection connection_;

        public RepositoryChip(MySqlConnection connection) {
            connection_ = connection;
        }

        public EChipType CheckType(string chipId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Chip WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbChip chip = new DbChip() {
                        chipId = reader.GetString("chipId"),
                        isEmployee = reader.GetBoolean("isEmployee")
                    };

                    return (chip.isEmployee) ? EChipType.Employee : EChipType.Place;
                }
            } catch (Exception ex) {
                Debug.Log("Error while checking chip type\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return EChipType.None;
        }

        public bool Insert(DbChip chip) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Chip(chipId, isEmployee) VALUES(@chipId, @isEmployee)";
            query.Parameters.AddWithValue("@chipId", chip.chipId);
            query.Parameters.AddWithValue("@isEmployee", chip.isEmployee);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting Chip\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }

        public bool Delete(string chipId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM Chip WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting Chip\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return (rowsAffected == 1);
        }
    }
}
