using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SteelWorks_Utils;

namespace SteelWorks_Utils.Model
{


    public class Repository
    {
        public static RepositoryChip chip { get; }
        public static RepositoryEmployee employee { get; }
        public static RepositoryMark mark { get; }
        public static RepositoryPlace place { get; }
        public static RepositoryReport report { get; }
        public static RepositoryReportPlace reportPlace { get; }
        public static RepositoryTrack track { get; }
        public static RepositoryTrackPlace trackPlace { get; }
        public static RepositoryRoutine routine { get; }
        public static RepositoryTeam team { get; }
        public static RepositoryTeamEmployee teamEmployee { get; }
        public static RepositoryMail mail { get; }
        public static RepositoryReportEmployee reportEmployee { get; }

        public static DbReportGenerator generator { get; }

        public static MySqlConnection connection_;

        public static string XorText(string text, int key) {
            string newText = "";

            for (int i = 0; i < text.Length; i++) {
                int charValue = Convert.ToInt32(text[i]); //get the ASCII value of the character
                charValue ^= key; //xor the value

                newText += char.ConvertFromUtf32(charValue); //convert back to string
            }

            return newText;
        }

        public static void RepeatQueryWhileNoConnection<T>(ContainerControl currentControl, int repeatDelayMs, Action lambda) where T : Form, new() {
            bool bSuccess = false;
            T errorView = null;
            while (!bSuccess) {
                try {
                    lambda();

                    bSuccess = true;
                    if (currentControl != null)
                        currentControl.Enabled = true;
                    errorView?.Close();
                } catch (NoInternetConnectionException ex) {
                    if (errorView == null || !errorView.Visible) {
                        errorView = new T();
                        errorView.Show();
                        if (currentControl != null)
                            currentControl.Enabled = false;
                    }

                    for (int ij = 0; ij < 10; ij++) {
                        Thread.Sleep(repeatDelayMs / 10);
                        Application.DoEvents();
                    }
                } catch (Exception ex) {

                }
            }
        }

        public static void BackupDatabase(string path) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            try {
                MySqlCommand cmd = new MySqlCommand();
                using (MySqlBackup mb = new MySqlBackup(cmd)) {
                    cmd.Connection = connection_;
                    mb.ExportToFile(path);
                }
            } catch (Exception ex) {
                Debug.Log("Error while doing database backup\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }
        }

        //USE WITH CAUTION - IT'S IRREVERSIBLE
        public static void RestoreDatabase(string path) {
            try {
                connection_.Open();
            } catch (Exception ex) {
                Debug.Log("Error while opening db connection\n" + ex.ToString(), LogType.DatabaseError);
                throw new NoInternetConnectionException();
            }

            try {
                MySqlCommand cmd = new MySqlCommand();
                using (MySqlBackup mb = new MySqlBackup(cmd)) {
                    cmd.Connection = connection_;
                    mb.ImportFromFile(path);
                }
            } catch (Exception ex) {
                Debug.Log("Error while doing database restore\n" + ex.ToString(), LogType.DatabaseError);
            } finally {
                connection_.Close();
            }
        }

        static Repository() {
            connection_ = new MySqlConnection(ParseDatabaseConfig());
            //connection_.Open();
            //var command = new MySqlCommand("SHOW SESSION STATUS LIKE \'Ssl_cipher\'", connection_);
            //MySqlDataReader reader = command.ExecuteReader();
            //while (reader.Read()) {
            //    string s = reader.GetString(0);
            //    int a = 5;
            //    //Console.WriteLine(reader.GetString(0));
            //}
            //connection_.Close();

            chip = new RepositoryChip(connection_);
            employee = new RepositoryEmployee(connection_);
            mark = new RepositoryMark(connection_);
            place = new RepositoryPlace(connection_);
            report = new RepositoryReport(connection_);
            reportPlace = new RepositoryReportPlace(connection_);
            track = new RepositoryTrack(connection_);
            trackPlace = new RepositoryTrackPlace(connection_);
            routine = new RepositoryRoutine(connection_);
            team = new RepositoryTeam(connection_);
            teamEmployee = new RepositoryTeamEmployee(connection_);
            mail = new RepositoryMail(connection_);
            reportEmployee = new RepositoryReportEmployee(connection_);

            generator = new DbReportGenerator();
        }

        private static string ParseDatabaseConfig() {
            string ret = "";
            try {
                using (FileStream stream = new FileStream("DatabaseCredentials.config", FileMode.Open, FileAccess.Read, FileShare.Read)) {
                    using (StreamReader reader = new StreamReader(stream)) {
                        //Server = myServerAddress; Port = 1234; Database = myDataBase; Uid = myUsername;
                        //Pwd = myPassword;
                        string serverName = reader.ReadLine().Split('=')[1];
                        string portNr = reader.ReadLine().Split('=')[1];
                        string database = reader.ReadLine().Split('=')[1];
                        string user = reader.ReadLine().Split('=')[1];
                        string password = reader.ReadLine().Split('=')[1];
                        password = XorText(password, 1);

                        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                        //builder.CertificateFile = "client.pfx";
                        //builder.CertificatePassword = "Px6jr^M*";
                        builder.CharacterSet = "utf8";
                        builder.Server = serverName;
                        builder.Port = UInt32.Parse(portNr);
                        builder.Database = database;
                        builder.UserID = user;
                        //builder.SslEnable = true;
                        //builder.SslMode = MySqlSslMode.Required;
                        builder.Password = password;
                        ret = builder.GetConnectionString(true);
                    }
                }
            } catch (Exception ex) {
                Debug.Log("Error while parsing database config file\n" + ex.ToString(), LogType.Error);
            }

            return ret;
        }

		public static string GetAdminPanelPassword()
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
			query.CommandText = "SELECT * FROM AdminPanelPassword";

			try
			{
				MySqlDataReader reader = query.ExecuteReader();
				while (reader.Read())
				{
					return reader.GetString("password");
				}
			}
			catch (Exception ex)
			{
				Debug.Log("Error while getting Password\n" + ex.ToString(), LogType.DatabaseError);
				throw new QueryExecutionException();
			}
			finally
			{
				connection_.Close();
			}

			return null;
		}

	}

    public class QueryExecutionException : Exception
    {
        public QueryExecutionException() { }
        public QueryExecutionException(string message) : base(message) { }
        public QueryExecutionException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class NoInternetConnectionException : Exception
    {
        public NoInternetConnectionException() { }
        public NoInternetConnectionException(string message) : base(message) { }
        public NoInternetConnectionException(string message, Exception innerException) : base(message, innerException) { }
    }



}
