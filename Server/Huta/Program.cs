using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Lidgren.Network;

namespace MasterServer
{
	public class Program
	{
		static void Main(string[] args) {
			NetPeerConfiguration config = new NetPeerConfiguration("HutaDB");
			config.SetMessageTypeEnabled(NetIncomingMessageType.ConnectionApproval, true);
			config.SetMessageTypeEnabled(NetIncomingMessageType.UnconnectedData, true);
			config.SetMessageTypeEnabled(NetIncomingMessageType.StatusChanged, true);
			config.SetMessageTypeEnabled(NetIncomingMessageType.Data, true);
			config.AcceptIncomingConnections = true;
			config.Port = 2137;

			NetPeer peer = new NetPeer(config);
			peer.Start();

			DataMessageHandler dataHand = new DataMessageHandler(peer);

			Console.WriteLine("Started server! Press F12 to stop");
			while (!Console.KeyAvailable || Console.ReadKey().Key != ConsoleKey.F12) {
				NetIncomingMessage msg;
				while((msg = peer.ReadMessage()) != null) {
					switch (msg.MessageType) {
						case NetIncomingMessageType.ConnectionApproval:
							Logger.Append("Connected");
						    msg.SenderConnection.Approve();
                            break;

						case NetIncomingMessageType.Data:
							ProcessDataMessage(dataHand, msg);
							break;

						case NetIncomingMessageType.UnconnectedData:
							Logger.Append( "Unconnected!" );
							break;
							
       					case NetIncomingMessageType.StatusChanged:
            				switch( msg.SenderConnection.Status ) {
								case NetConnectionStatus.InitiatedConnect:
									Logger.Append( "Initiated" );
									break;
								
								case NetConnectionStatus.Disconnected:
									break;
            				}
            				break;

						case NetIncomingMessageType.DebugMessage:
						case NetIncomingMessageType.VerboseDebugMessage:
						case NetIncomingMessageType.WarningMessage:
						case NetIncomingMessageType.ErrorMessage:
							Logger.Append( msg.ReadString( ) );
							break;
							
						default:
							Logger.Append( "Unhandled message type!" );
							break;
					}
					
					peer.Recycle( msg );
				}
			}
			
			Logger.Append("Server expected shutdown!\n\n", true);
		}

		static void ProcessDataMessage(DataMessageHandler dataHand, NetIncomingMessage msg) {
			MessageType data;
			string dataString = msg.ReadString();
			if(!Enum.TryParse(dataString, out data))
				dataHand.ProcessUnknownMessage(dataString, msg);
			
			MethodInfo method = dataHand.GetType().GetMethod("Handle" + dataString);
			if(method != null)
				method.Invoke(dataHand, new object[] { msg });
			else
				Logger.Append("Couldn't invoke method: " + dataString, true);
		}
	}
}
