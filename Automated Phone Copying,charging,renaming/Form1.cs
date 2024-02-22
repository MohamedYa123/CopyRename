//using Microsoft.WindowsAPICodePack.Dialogs;
//using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
//using System.Windows.Controls;
using Shell32;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
//using System.Windows.Shapes;
using System.Threading;
using System.Windows.Forms;

namespace Automated_Phone_Copying_charging_renaming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            manager = new Manager("", "", "", "", "", "", "");
        }
        public int Hwnd { get; private set; }
        string getdirectoryPhone()
        {
            Shell32.Shell shell = new Shell32.Shell();
            Folder folder = shell.BrowseForFolder((int)Hwnd, "Choose Folder", 0, 0);
            string s = "";
            if (folder == null)
            {
                // User cancelled
            }
            else
            {
                FolderItem fi = (folder as Folder3).Self;
                s = fi.Path;
            }
            Regex regex = new Regex(@"SID\-\{[^}]+\}");//-\{d+,,d+\}
                                                       //  var ssc = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\\\\\\?\\usb#vid_22d9&pid_2764#z5obr4gikzukhic6#{6ac27878-a6fa-4155-ba85-f98f491d4f33}\\SID-{10001,,53925658624}\\{E9205F67-FFFF-FFFF-0000-000000000000}\\{1C5AB153-0000-0000-0000-000000000000}";
            if (s != "")
            {
                var ss = regex.Match(s);
                string toremove = ss.Value;
                if (toremove.Length > 0)
                {
                    s = s.Replace(toremove + "\\", "");
                    s = s.Replace(toremove, "");
                }
            }
            Folder dir = shell.NameSpace(s);
            List<string> list = new List<string>();
            //int i = 0;
            //foreach (FolderItem curr in dir.Items())
            //{
            //    var sss = curr.Path;
            //    DateTime creationTime = curr.ModifyDate;
            //    var sz = curr.Size;
            //    list.Add(curr.Name);
            //    i++;
            //}
            return s;
        }
        string getdirectory(string txt)
        {

            var txt2 = getdirectoryPhone();
            if (txt2 == "")
            {
                return txt;
            }
            return txt2;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.ShowDialog();
            return folderBrowserDialog.SelectedPath;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SF.Text = getdirectory(SF.Text);
            try
            {
                manager.SF = SF.Text;
            }
            catch { }
        }
        Manager manager;
        private static readonly object lockObject = new object();

        static void Main2(string[] args)
        {
            Thread thread1 = new Thread(DoWork);
            Thread thread2 = new Thread(DoWork);
            Thread thread = new Thread(DoWork);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            //thread1.Start();
            //thread2.Start();

            //thread1.Join();
            //thread2.Join();
        }
        static void DoWork()
        {
            lock (lockObject)
            {
                Shell32.Shell shell = new Shell32.Shell();
                // Use the Shell object as needed.
                // ...
                // Release the COM object when done.
                System.Runtime.InteropServices.Marshal.ReleaseComObject(shell);
            }
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            if (CN.Text.Length == 0)
            {
                MessageBox.Show("Camera Number (CN) must be specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Process_selected_files.Checked && files.Count > 0)
            {
                if (MessageBox.Show("There are some custom selected files are you sure to not process them?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            manager = new Manager(SF.Text, DF1.Text, DF2.Text, CN.Text, T1.Text, AN.Text, L1.Text);
            manager.DirectoriesinDF1formula = Properties.Settings.Default.DirectoriesinDF1formula;
            manager.DirectoriesinDF2formula = Properties.Settings.Default.DirectoriesinDF2formula;
            manager.DF1Filesformula = Properties.Settings.Default.DF1Filesformula;
            manager.DF2Filesformula = Properties.Settings.Default.DF2Filesformula;
            manager.selectfilesbycreationdate = Properties.Settings.Default.selectfilesbycreationdate;
            manager.fromdate = Properties.Settings.Default.fromdate;
            manager.todate = Properties.Settings.Default.todate;
            manager.copytodf1 = Properties.Settings.Default.Copytodf1;
            manager.copytodf2 = Properties.Settings.Default.Copytodf2;
            manager.Process_selected_files = Process_selected_files.Checked;
            manager.files = files;
            //Thread th = new Thread(new ThreadStart(async () => { await manager.DoTheJob(); }));
            //  th.Start();
            //Main2(null);
            //
            string settingsDT = $"Directories in DF1 naming formula: {manager.DirectoriesinDF1formula}" +
                $"\r\nDirectories in DF2 naming formula: {manager.DF2Filesformula}" +
                $"\r\nDF1 Files renaming formula: {manager.DF1Filesformula}" +
                $"\r\nDF2 Files renaming formula: {manager.DF2Filesformula}" +
                $"\r\nProcess Selected Files: {manager.Process_selected_files}" +
                $"\r\nSelect files by Creation date: {manager.selectfilesbycreationdate}";
            if (manager.selectfilesbycreationdate)
            {
                settingsDT += $"\r\n  From date: {manager.fromdate} to date: {manager.todate}";
            }
            settingsDT += $"\r\nCopy to DF1: {manager.copytodf1}" +
            $"\r\nCopy to DF2: {manager.copytodf2}";
            log log = new log { date = DateTime.Now, SF = SF.Text, DF1 = DF1.Text, DF2 = DF2.Text, Settings = settingsDT };
            log.Saveme();
            //
            await manager.DoTheJob();
        }
        string last = "";
        int point = 0;
        string quicklast = "";
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // button4.Left = button3.Left + 1;
                var wd = (int)(panel7.Width * 74.5 / 100);
                var wd2 = (int)(panel7.Width * 29.7 / 100);
                if (WindowState == FormWindowState.Maximized)
                {
                    wd = (int)(panel7.Width * 83.5 / 100);
                    wd2 = (int)(panel7.Width * 85 / 74.5 * 49.3 / 100);
                }
                SF.Width = wd;
                DF1.Width = wd;
                DF2.Width = wd;
                //CN.Width = wd;
                wd2 = DF2.Width + DF2.Left - (T1.Width + T1.Left);
                T1.Width += wd2;
                L1.Width += wd2;
                //AN.Width = wd;
                button4.Left = wd * 55 / 90;
                label6.Text = manager.QuickReport;
                label6.Width = panel2.Width;
                if (last != manager.DetailedReport)
                {
                    last = manager.DetailedReport;
                    var selctionstart = richTextBox1.SelectionStart;
                    var selctionlength = richTextBox1.SelectionLength;
                    //richTextBox1.Text = manager.DetailedReport;
                    int count = manager.DetailedReportList.Count;
                    string s = "";
                    for (int i = point; i < count; i++)
                    {
                        s += manager.DetailedReportList[i];
                    }
                    quicklast = manager.QuickReport;
                    //s += quicklast;
                    //richTextBox1.Text= richTextBox1.Text.Replace(quicklast, "");
                    if (shown)
                    {
                        richTextBox1.AppendText(s);
                        selctionstart = richTextBox1.Text.Length;
                        selctionlength = 0;
                        richTextBox1.Select(selctionstart, selctionlength);
                    }
                    else
                    {
                        richTextBox1.Text = "";
                    }
                    if (point == 0)
                    {
                        richTextBox1.Focus();
                    }
                    point = count;
                }

                progressBar.Value = manager.Progress;
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DF1.Text = getdirectory(DF1.Text);
            try
            {
                if (Directory.GetFiles(DF1.Text).Length > 0)
                {
                    var a = MessageBox.Show("The Folder isn't empty, Do you want to clear it from all files (Recommended)?", "Q", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (a == DialogResult.Yes)
                    {
                        foreach (var c in Directory.GetFiles(DF1.Text))
                        {
                            File.Delete(c);
                        }
                    }
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DF2.Text = getdirectory(DF2.Text);
            try
            {
                if (Directory.GetFiles(DF2.Text).Length > 0)
                {
                    var a = MessageBox.Show("The Folder isn't empty, Do you want to clear it from all files (Recommended)?", "Q", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (a == DialogResult.Yes)
                    {
                        foreach (var c in Directory.GetFiles(DF2.Text))
                        {
                            File.Delete(c);
                        }
                    }
                }
            }
            catch { }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        bool shown = true;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (shown)
            {
                shown = false;
                linkLabel1.Text = "Show details";
            }
            else
            {

                shown = true;
                linkLabel1.Text = "Hide details";
                richTextBox1.Text = manager.DetailedReport;
                try
                {
                    richTextBox1.Focus();
                    richTextBox1.Select(richTextBox1.Text.Length, 0);
                }
                catch { }
            }
        }
        void d()
        {
            while (true)
            {

            }
        }
        [Obsolete]
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            int pid = Process.GetCurrentProcess().Id;
            Process process = new Process();
            process = Process.GetProcessById(pid);
            // Call the Kill() method on the Process object.
            process.Kill();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.fromdate = DateTime.Now.AddDays(-1);
            Properties.Settings.Default.todate = DateTime.Now.AddDays(-1);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings settings = new settings();
            settings.ShowDialog();
        }
        Dictionary<FolderItem, file_toselect> files = new Dictionary<FolderItem, file_toselect>();
        private void button6_Click(object sender, EventArgs e)
        {
            selectfiles selectfiles = new selectfiles();
            selectfiles.files = files;
            if (selectfiles.ShowDialog(SF.Text) == DialogResult.OK)
            {

            }
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logs logs = new Logs();
            logs.ShowDialog();
        }
    }
}