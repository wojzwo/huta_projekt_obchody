using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbEmployee
    {
        public string chipId;
        public string name;
    }

    public class RepositoryEmployee
    {
        private readonly MySqlConnection connection_;

        public RepositoryEmployee(MySqlConnection connection) {
            connection_ = connection;
        }

        public DbEmployee Get(string chipId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Employee WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbEmployee employee = new DbEmployee() {
                        name = reader.GetString("name"),
                        chipId = reader.GetString("chipId")
                    };

                    return employee;
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting employee\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return null;
        }

        public List<DbEmployee> GetAll() {
            List<DbEmployee> employees = new List<DbEmployee>();

            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "SELECT * FROM Employee";

            try {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    DbEmployee employee = new DbEmployee() {
                        name = reader.GetString("name"),
                        chipId = reader.GetString("chipId")
                    };

                    employees.Add(employee);
                }
            } catch (Exception ex) {
                Debug.Log("Error while getting all employees\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            return employees;
        }

        public bool Insert(DbEmployee employee) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "INSERT INTO Employee(name, chipId) VALUES(@name, @chipId)";
            query.Parameters.AddWithValue("@name", employee.name);
            query.Parameters.AddWithValue("@chipId", employee.chipId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while inserting Employee\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            DbChip chip = new DbChip() {
                chipId = employee.chipId,
                isEmployee = true
            };

            bool isChipInserted = false;
            try {
                isChipInserted = Repository.chip.Insert(chip);
            } catch (Exception ex) {
                throw;
            }

            return (rowsAffected == 1 && isChipInserted);
        }

        public bool Delete(string chipId) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            MySqlCommand query = connection_.CreateCommand();
            query.CommandText = "DELETE FROM Employee WHERE chipId = @chipId";
            query.Parameters.AddWithValue("@chipId", chipId);

            int rowsAffected = 0;
            try {
                rowsAffected = query.ExecuteNonQuery();
            } catch (Exception ex) {
                Debug.Log("Error while deleting Employee\n" + ex.ToString(), LogType.DatabaseError);
                throw new QueryExecutionException();
            } finally {
                connection_.Close();
            }

            bool isChipDeleted = false;
            try {
                isChipDeleted = Repository.chip.Delete(chipId);
            } catch (Exception ex) {
                throw;
            }

            return (rowsAffected == 1 && isChipDeleted);
        }


		public List<DbEmployee> GetAllInTeam(int teamId)
		{
			List<DbEmployee> teams = new List<DbEmployee>();

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
			query.CommandText = "SELECT * FROM Employee WHERE chipId IN" +
								"(SELECT employeeId FROM TeamEmployee WHERE teamId = @teamId)";
			query.Parameters.AddWithValue("@teamId", teamId);

			try
			{
				MySqlDataReader reader = query.ExecuteReader();
				while (reader.Read())
				{
					DbEmployee place = new DbEmployee()
					{
						chipId = reader.GetString("chipId"),
						name = reader.GetString("name")
					};

					teams.Add(place);
				}
			}
			catch (Exception ex)
			{
				Debug.Log("Error while getting all Places by Team\n" + ex.ToString(), LogType.DatabaseError);
				throw new QueryExecutionException();
			}
			finally
			{
				connection_.Close();
			}

			return teams;
		}

		public List<DbEmployee> GetAllNotInTeam(int teamId)
		{
			List<DbEmployee> teams = new List<DbEmployee>();

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
			query.CommandText = "SELECT * FROM Employee WHERE chipId NOT IN" +
								"(SELECT employeeId FROM TeamEmployee WHERE teamId = @teamId)";
			query.Parameters.AddWithValue("@teamId", teamId);

			try
			{
				MySqlDataReader reader = query.ExecuteReader();
				while (reader.Read())
				{
					DbEmployee place = new DbEmployee()
					{
						chipId = reader.GetString("chipId"),
						name = reader.GetString("name")
					};

					teams.Add(place);
				}
			}
			catch (Exception ex)
			{
				Debug.Log("Error while getting all Places not in Team\n" + ex.ToString(), LogType.DatabaseError);
				throw new QueryExecutionException();
			}
			finally
			{
				connection_.Close();
			}

			return teams;
		}
	}
}
