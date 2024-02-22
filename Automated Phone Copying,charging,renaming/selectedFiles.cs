using Shell32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automated_Phone_Copying_charging_renaming
{
    public partial class selectedFiles : Form
    {
        public selectedFiles()
        {
            InitializeComponent();
        }
        public Dictionary<FolderItem, file_toselect> files = new Dictionary<FolderItem, file_toselect>();
        List<FolderItem> folderItems = new List<FolderItem>();
        private void selectedFiles_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            load();
        }
        void load()
        {
            folderItems.Clear();
            listView1.Items.Clear();
            var flist = new List<ListViewItem>();
            int id = 1;
            foreach (var item in files)
            {
                var it = item.Value;
                string[] fileprops = { id + "", it.name, it.filetype.ToString(), it.Foldername };
                var lv = new ListViewItem(fileprops);
                flist.Add(lv);
                folderItems.Add(item.Key);
                id++;
            }
            listView1.Items.AddRange(flist.ToArray());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var x = listView1.SelectedIndices[0];
                files.Remove(folderItems[x]);
                selectfiles.added.Remove(folderItems[x].Path);
                load();
                if (x < listView1.Items.Count)
                {
                    listView1.Items[x].Selected = true;
                }
                else
                {
                    listView1.Items[listView1.Items.Count - 1].Selected = true;
                }
                listView1.Focus();
            }
            catch { }
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd' || e.KeyChar == 'D')
            {
                button1_Click(null, null);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all items?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                files.Clear();
                selectfiles.added.Clear();
                load();
                
            }
        }
    }
}
