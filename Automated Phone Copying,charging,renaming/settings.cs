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
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = selectfilesbycreationdate.Checked;
        }

        private void settings_Load(object sender, EventArgs e)
        {
            DirectoriesinDF1formula.Text = Properties.Settings.Default.DirectoriesinDF1formula;
            DirectoriesinDF2formula.Text = Properties.Settings.Default.DirectoriesinDF2formula;
            DF1Filesformula.Text = Properties.Settings.Default.DF1Filesformula;
            DF2Filesformula.Text = Properties.Settings.Default.DF2Filesformula;
            Copytodf1.Checked = Properties.Settings.Default.Copytodf1;
            Copytodf2.Checked = Properties.Settings.Default.Copytodf2;
            fromdate.Value = Properties.Settings.Default.fromdate;
            todate.Value = Properties.Settings.Default.todate;
            //fromdate.Value = DateTime.Now.AddDays(-1);// Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy 12:00:00 A\\M"));
            //todate.Value = DateTime.Now.AddDays(-1); // Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy 12:00:00 A\\M"));

            selectfilesbycreationdate.Checked = Properties.Settings.Default.selectfilesbycreationdate;
        }

        private void settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromdate.Value = new DateTime(fromdate.Value.Year, fromdate.Value.Month, fromdate.Value.Day, 0, 0, 0);// Convert.ToDateTime(fromdate.ToString("MM/dd/yyyy 12:00:00 A\\M"));
            todate.Value = new DateTime(todate.Value.Year, todate.Value.Month, todate.Value.Day, 23, 59, 59);// Convert.ToDateTime(fromdate.ToString("MM/dd/yyyy 12:00:00 A\\M"));
            Properties.Settings.Default.DirectoriesinDF1formula = DirectoriesinDF1formula.Text;
            Properties.Settings.Default.DirectoriesinDF2formula = DirectoriesinDF2formula.Text;
            Properties.Settings.Default.DF1Filesformula = DF1Filesformula.Text;
            Properties.Settings.Default.DF2Filesformula = DF2Filesformula.Text;
            Properties.Settings.Default.Copytodf1 = Copytodf1.Checked;
            Properties.Settings.Default.Copytodf2 = Copytodf2.Checked;
            Properties.Settings.Default.fromdate = fromdate.Value;
            Properties.Settings.Default.todate = todate.Value;
            Properties.Settings.Default.selectfilesbycreationdate = selectfilesbycreationdate.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to reset the settings ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                settings_Load(null, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fromdate.Value = DateTime.Now.AddDays(-1);// Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy 12:00:00 A\\M"));
            todate.Value = DateTime.Now.AddDays(-1); // Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy 12:00:00 A\\M"));
        }
    }
}
