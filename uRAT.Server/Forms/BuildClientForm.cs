using System;
using System.Windows.Forms;
using uRAT.Server.Builder;

namespace uRAT.Server.Forms
{
    public partial class BuildClientForm : Form
    {
        public BuildClientForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstallationPath path;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    path = InstallationPath.Default;
                    break;
                case 1:
                    path = InstallationPath.AppData;
                    break;
                case 2:
                    path = InstallationPath.ProgramFiles;
                    break;
                default:
                    path = InstallationPath.Default;
                    break;
            }
            var settings = new BuildSettings(textBox1.Text, (int) numericUpDown1.Value, textBox2.Text, path);
            var builder = new StubBuilder(settings);
            using (var ofd = new SaveFileDialog())
            {
                ofd.Filter = "Executable|(*.exe)";
                if(ofd.ShowDialog() == DialogResult.OK)
                    builder.Build(ofd.FileName);
            }
        }
    }
}
