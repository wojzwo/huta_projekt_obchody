using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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

        private static MySqlConnection connection_;

        static Repository() {
            connection_ = new MySqlConnection(ParseDatabaseConfig());

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
                        ret = "Server=" + serverName + ";Port=" + portNr + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";CharSet=utf8";
                    }
                }
            } catch (Exception ex) {
                Debug.Log("Error while parsing database config file\n" + ex.ToString(), LogType.Error);
            }

            return ret;
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
