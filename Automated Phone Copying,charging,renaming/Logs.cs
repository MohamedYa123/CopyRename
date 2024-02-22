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
    public partial class Logs : Form
    {
        public Logs()
        {
            InitializeComponent();
        }

        private void Logs_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            Program.Loadlogs();
            int id = 1;
            List<ListViewItem> list = new List<ListViewItem>();
            foreach (var item in Program.logs)
            {
                string[] s = { id + "", item.date + "", item.SF, item.DF1, item.DF2, item.Settings.Substring(0, 40) + " ..." };
                ListViewItem itemlv = new ListViewItem(s);
                list.Add(itemlv);
                id++;
            }
            listView1.Items.AddRange(list.ToArray());
        }
        string view(ListViewItem lvitem, int index)
        {
            string ans = $"Log {lvitem.Text}" +
                $"\r\nDate : {lvitem.SubItems[1].Text}" +
                $"\r\nSF: {lvitem.SubItems[2].Text}" +
                $"\r\nDF1: {lvitem.SubItems[3].Text}" +
                $"\r\nDF2: {lvitem.SubItems[4].Text}" +
                $"\r\nSettings: {Program.logs[index].Settings}";
            return ans;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = view(listView1.SelectedItems[0], listView1.SelectedIndices[0]);
            }
            catch { }
        }
    }
}
