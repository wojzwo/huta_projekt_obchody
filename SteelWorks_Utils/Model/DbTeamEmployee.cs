using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SteelWorks_Utils.Model
{
    public class DbTeamEmployee
    {
        public int teamId;
        public string employeeId;
    }

    public class RepositoryTeamEmployee
    {
        private readonly MySqlConnection connection_;

        public RepositoryTeamEmployee(MySqlConnection connection) {
            connection_ = connection;
        }

		public bool Insert(DbTeamEmployee teamEmployee)
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
			query.CommandText = "INSERT INTO TeamEmployee(teamId, employeeId) VALUES(@teamId, @employeeId)";
			query.Parameters.AddWithValue("@teamId", teamEmployee.teamId);
			query.Parameters.AddWithValue("@employeeId", teamEmployee.employeeId);

			int rowsAffected = 0;
			try
			{
				rowsAffected = query.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Debug.Log("Error while inserting TeamEmployee\n" + ex.ToString(), LogType.DatabaseError);
				throw new QueryExecutionException();
			}
			finally
			{
				connection_.Close();
			}

			return (rowsAffected == 1);
		}

		public bool Delete(int teamId, string employeeId)
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
			query.CommandText = "DELETE FROM TeamEmployee WHERE teamId = @teamId AND employeeId = @employeeId";
			query.Parameters.AddWithValue("@teamId", teamId);
			query.Parameters.AddWithValue("@employeeId", employeeId);

			int rowsAffected = 0;
			try
			{
				rowsAffected = query.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Debug.Log("Error while deleting TeamEmployee\n" + ex.ToString(), LogType.DatabaseError);
				throw new QueryExecutionException();
			}
			finally
			{
				connection_.Close();
			}

			return (rowsAffected == 1);
		}

		public bool DeleteAllFromTeam(int teamId)
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
			query.CommandText = "DELETE FROM TeamEmployee WHERE teamId = @teamId";
			query.Parameters.AddWithValue("@teamId", teamId);

			int rowsAffected = 0;
			try
			{
				rowsAffected = query.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Debug.Log("Error while deleting TeamEmployees\n" + ex.ToString(), LogType.DatabaseError);
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
