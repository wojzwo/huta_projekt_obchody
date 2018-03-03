using System;
using System.Net;
using System.Collections.Generic;

using Lidgren.Network;
using MySql.Data.MySqlClient;

namespace MasterServer
{
    public static class Config
    {
        public static string databaseServerIp = "localhost";
        public static string databaseName = "hutadb";
        public static string databaseUsername = "huta_admin";
        public static string databasePassword = "jp2gmd2137";
    }

    public partial class DataMessageHandler
	{
		NetPeer Peer;
	    private MySqlConnection connection_;
		
		public DataMessageHandler(NetPeer Peer) {
			this.Peer = Peer;

		    string connectionString = "SERVER=" + Config.databaseServerIp + "; PORT=3306 ;" + "DATABASE=" + Config.databaseName + ";" + "UID=" + Config.databaseUsername + ";" + "PASSWORD=" + Config.databasePassword + ";";
		    connection_ = new MySqlConnection(connectionString);

		    try {
		        connection_.Open();
		    } catch (Exception ex) {
		        Logger.Append("Error when connecting with database: \n" + ex.ToString(), true);
		    }

            //connection_.Close();
        }
		
		public void ProcessUnknownMessage(string MsgType, NetIncomingMessage Msg) {
			Logger.Append("Received unknown message type: " + MsgType + " from " + Msg.SenderEndPoint.ToString(), true);
		}
	}
}