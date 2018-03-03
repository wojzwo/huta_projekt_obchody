using System;
using System.Net;
using System.Collections.Generic;
using Huta.Model;
using Lidgren.Network;
using MySql.Data.MySqlClient;

namespace MasterServer
{
	public partial class DataMessageHandler
	{
	    public void HandleInsertChip(NetIncomingMessage Msg) {
	        DB_Chip c = DB_Chip.Deserialize(Msg.ReadString());

	        try {
	            MySqlCommand cmd = new MySqlCommand();
	            cmd.Connection = connection_;
	            cmd.CommandText = "INSERT INTO Chip VALUES(?chipId, ?isEmployee)";
	            cmd.Parameters.Add("?chipId", MySqlDbType.VarChar).Value = c.chipId;
	            cmd.Parameters.Add("?isEmployee", MySqlDbType.Int16).Value = (c.bIsEmployee == true) ? 1 : 0;
	            cmd.ExecuteNonQuery();
	            Logger.Append("Inserting chip...", true);
            } catch (MySqlException ex) {
	            Logger.Append("Couldn't insert chip || " + ex.Message, true);
	        }
	    }

		/*
		public void HandleChangePoints(NetIncomingMessage Msg) {
			string roomName = Msg.ReadString();
			string userName = Msg.ReadString();
			string points = Msg.ReadString();
			
			NetOutgoingMessage outMsg = Peer.CreateMessage();
			outMsg.Write(MessageType.ChangePoints.ToString());
			outMsg.Write(userName);
			outMsg.Write(points);
			
			List<NetConnection> clientsConn = Reg.GetConnectionsFromRoom(roomName);
			if (clientsConn.Count == 0) {
				return;
			}
			
			Peer.SendMessage(outMsg, clientsConn, NetDeliveryMethod.ReliableSequenced, 0);
		}
		*/
	}
}