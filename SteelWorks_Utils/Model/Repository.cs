using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using SteelWorks_Utils;

namespace SteelWorks_Utils.Model
{
    public class Repository
    {
        public static Repository instance;
        private NetClient client_;

        public void InsertChip(DB_Chip chip) {
            NetOutgoingMessage msg = client_.CreateMessage();
            msg.Write(MessageType.InsertChip.ToString());
            msg.Write(chip.Serialize());
            client_.SendMessage(msg, NetDeliveryMethod.ReliableUnordered, 0);
        }

        public Repository() {
            NetPeerConfiguration config = new NetPeerConfiguration("HutaDB");
            config.SetMessageTypeEnabled(NetIncomingMessageType.UnconnectedData, true);
            config.SetMessageTypeEnabled(NetIncomingMessageType.Data, true);
            client_ = new NetClient(config);

            NetOutgoingMessage loginMsg = client_.CreateMessage();
            loginMsg.Write("App");

            client_.Start();
            client_.Connect(new IPEndPoint(new IPAddress(new byte[] { 217, 182, 74, 73 }), 2137), loginMsg);

            instance = this;
        }
    }
}
