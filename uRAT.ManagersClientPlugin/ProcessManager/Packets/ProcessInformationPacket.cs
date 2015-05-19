using System.IO;
using uNet2.Packet;

namespace uRAT.ManagersClientPlugin.ProcessManager.Packets
{
    public class ProcessInformationPacket : IDataPacket
    {
        public int PacketId
        {
            get { return 5; }
        }

        public string ProcessName { get; set; }
        public int Pid { get; set; }
        public bool IsThis { get; set; }
        public long MemUsage { get; set; }

        public ProcessInformationPacket()
        {
        }

        public ProcessInformationPacket(string processName, int pid, bool isThis, long memUsage)
        {
            ProcessName = processName;
            Pid = pid;
            IsThis = isThis;
            MemUsage = memUsage;
        }

        public void SerializeTo(Stream stream)
        {
            var bw = new BinaryWriter(stream);
            bw.Write(PacketId);
            bw.Write(ProcessName);
            bw.Write(Pid);
            bw.Write(IsThis);
            bw.Write(MemUsage);
        }

        public void DeserializeFrom(Stream stream)
        {
            var br = new BinaryReader(stream);
            ProcessName = br.ReadString();
            Pid = br.ReadInt32();
            IsThis = br.ReadBoolean();
            MemUsage = br.ReadInt64();
        }
    }
}
