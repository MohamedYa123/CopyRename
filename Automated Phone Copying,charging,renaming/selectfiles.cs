using Shell32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Automated_Phone_Copying_charging_renaming
{
    public partial class selectfiles : Form
    {
        public selectfiles()
        {
            InitializeComponent();
        }
        DialogResult dialogResult = DialogResult.Cancel;
        string SF = "";
        public DialogResult ShowDialog(string SF)
        {
            this.SF = SF;
            a2sgb = SF;
            lastbs.Push(SF);
            ShowDialog();
            return dialogResult;
        }
        private void selectfiles_Load(object sender, EventArgs e)
        {
            load_foldersandfiles(SF);
            itemspanel.Focus();
            SelectedFilesButton.Text = $"Selected Files ({files.Count})";
        }
        string split(string s)
        {
            string s2 = "";
            for (int i = 0; i < s.Length; i++)
            {
                s2 += s[i];
                if ((i + 1) % 12 == 0)
                {
                    s2 += "\r\n";
                }
            }
            return s2;
        }
        void addtofiles(FolderItem a,Folder owner, Filetype gf, string folderpath)
        {
            if (!added.ContainsKey(a.Path))
            {
                files.Add(a, new file_toselect { File = a, filetype = gf, Foldername = folderpath, name = a.Name,Folder=owner,FilePath=a.Path,FolderPath= folderpath});
                added.Add(a.Path, "");
            }
            SelectedFilesButton.Text = $"Selected Files ({files.Count})";
        }
        public Dictionary<FolderItem, file_toselect> files = new Dictionary<FolderItem, file_toselect>();
        public static Dictionary<string,string> added= new Dictionary<string,string>();
        double dty = 0;
        int ogtop = 0;
        Stack<string> lastbs = new Stack<string>();
        void load_foldersandfiles(string path)
        {
            try
            {
                Shell32.Shell shell = new Shell32.Shell();
                var folder = shell.NameSpace(path);
                itemspanel.Top = panel3.Height + 30;
                //itemspanel.Left = 20;
                ogtop = panel3.Height + 30;

                int x = itemspanel.Left + 5; int y = itemspanel.Top + 10;
                int increamentx = 10;
                int increamenty = 30;
                int maxh = 0;
                List<Control> list = new List<Control>();
                var results = folder.Items();
                for (int i = 0; i < 2; i++)
                {
                    foreach (FolderItem a in results)
                    {

                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Height = pictureBox1.Height;
                        pictureBox.Width = pictureBox1.Width;
                        pictureBox.SizeMode = pictureBox1.SizeMode;
                        pictureBox.MouseEnter += delegate
                        {
                            pictureBox.BackColor = Color.Gray;
                        };
                        pictureBox.MouseLeave += delegate
                        {
                            pictureBox.BackColor = Color.Transparent;
                        };
                        //to check if it's a right click or left click////
                        pictureBox.MouseDown += delegate (object sender, MouseEventArgs e)
                        {
                            if (e.Button == MouseButtons.Right)
                            {
                                pictureBox.Tag = 1;
                            }
                            else
                            {
                                pictureBox.Tag = 0;
                            }
                        };
                        if (a.IsFolder && i == 0)
                        {
                            pictureBox.Image = Properties.Resources.Folder;
                            pictureBox.DoubleClick += delegate
                            {
                                lastbs.Push(a.Path);
                                a2sgb = a.Path;
                                load_foldersandfiles(a.Path);
                            };
                            pictureBox.MouseUp += delegate
                            {
                                try
                                {
                                    if ((int)pictureBox.Tag == 1)
                                    {
                                        void searchinside(string folderpath)
                                        {
                                            var folder2 = shell.NameSpace(folderpath);
                                            var filesin = folder2.Items();
                                            foreach (FolderItem item in filesin)
                                            {
                                                if (!item.IsFolder)
                                                {
                                                    addtofiles(item, shell.NameSpace(folderpath), GetFiletype(item.Name), folderpath);
                                                }
                                                else
                                                {
                                                    searchinside(item.Path);
                                                }

                                            }
                                        }
                                        searchinside(a.Path);
                                    }
                                }
                                catch { }
                            };
                        }
                        else if (i == 1 && !a.IsFolder)
                        {
                            pictureBox.Image = Properties.Resources.File;
                            var gf = GetFiletype(a.Name);
                            switch (gf)
                            {
                                case Filetype.Video:
                                    pictureBox.Image = Properties.Resources.video;
                                    break;
                                case Filetype.Music:
                                    pictureBox.Image = Properties.Resources.music;
                                    break;
                                case Filetype.Picture:
                                    pictureBox.Image = Properties.Resources.picture;
                                    break;
                            }

                            pictureBox.DoubleClick += delegate
                            {
                                addtofiles(a, shell.NameSpace(label2.Text), gf, label2.Text);
                                button1_Click(null, null);
                            };

                            pictureBox.MouseUp += delegate
                            {
                                try
                                {
                                    if ((int)pictureBox.Tag == 1)
                                    {
                                        addtofiles(a,shell.NameSpace(label2.Text), gf, label2.Text);
                                    }
                                }
                                catch { }
                            };
                        }
                        else
                        {
                            continue;
                        }
                        pictureBox.Location = new Point(x, y);
                        Label label = new Label();
                        label.Location = new Point(x + 35, y + pictureBox.Height + 10);
                        label.AutoSize = true;
                        label.Text = split(a.Name);
                        Graphics g = Graphics.FromImage(pictureBox.Image);
                        var heightY = (int)g.MeasureString(split(a.Name), label.Font).Height / 2;//MeasureString
                        if (heightY > maxh)
                        {
                            maxh = heightY;
                        }
                        //
                        x += pictureBox.Width + increamentx;
                        if (x >= itemspanel.Width - itemspanel.Left - pictureBox.Width / 2)
                        {
                            x = itemspanel.Left + increamentx;
                            y += increamenty + pictureBox.Height + maxh;
                            maxh = 0;
                        }
                        list.Add(pictureBox);
                        list.Add(label);

                    }
                }
                itemspanel.Controls.Clear();
                itemspanel.Controls.AddRange(list.ToArray());
                dty = (Height - 200) / ((double)(y));
                ogtop = itemspanel.Top;
                vScrollBar1.Maximum = (int)(Math.Ceiling((1 - dty) * 100));
                itemspanel.Height = y + pictureBox1.Height * 2 + label1.Height + maxh;

                label2.Text = path;
                vScrollBar1.Minimum = 0;
                vScrollBar1.Value = 0;
            }
            catch
            {

            }
        }
        public enum Filetype { File, Video, Music, Picture }
        Filetype GetFiletype(string filename)
        {
            Filetype filetype = Filetype.File;
            var a = filename.ToLower().Split('.');
            if (a.Length > 1)
            {
                var extension = a[1];
                switch (extension)
                {
                    case "mp4":
                    case "mkv":
                    case "wmv":
                    case "mov":
                    case "avchd":
                    case "flv":
                    case "f4v":
                    case "swf":
                    case "webm":
                    case "html5":
                    case "mpeg-2":
                        return Filetype.Video;
                    case "m4a":
                    case "flag":
                    case "mp3":
                    case "wav":
                    case "wma":
                    case "aac":
                        return Filetype.Music;
                    case "jpg":
                    case "jpeg":
                    case "png":
                    case "gif":
                    case "tiff":
                    case "raw":
                        return Filetype.Picture;

                }
            }
            return filetype;
        }
        public static string Filter(string s)
        {
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
            return s;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear selected files ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                files.Clear();
                added.Clear();
            }
            Close();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (vScrollBar1.Maximum <= 0)
            {
                vScrollBar1.Maximum = 1;
            }
            double fact = (vScrollBar1.Maximum) / (vScrollBar1.Maximum - 9.0);
            var c = (itemspanel.Height - 550);
            if (itemspanel.Height < Height)
            {
                c = itemspanel.Height;
            }
            itemspanel.Top = ogtop - (int)((vScrollBar1.Value * fact + 0.0) / vScrollBar1.Maximum * c);
        }
        int waswidth = 0;
        int washeight = 0;
        private void selectfiles_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                waswidth = itemspanel.Width;
                washeight = itemspanel.Height;
                itemspanel.Width = Width - 100;
            }
            else
            {
                itemspanel.Width = waswidth;
                itemspanel.Height = washeight;
            }
            itemspanel.Top = ogtop;
            load_foldersandfiles(a2sgb);
        }
        string a2sgb = "";
        private void button3_Click(object sender, EventArgs e)
        {
            if (lastbs.Count == 1)
            {
                return;
            }
            try
            {

                var a2s = lastbs.ToList().Last();
                lastbs.Pop();
                a2s = lastbs.Pop();
                a2sgb = a2s;
                load_foldersandfiles(a2s);
                lastbs.Push(a2s);
            }
            catch (Exception ex) { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectedFiles selectedFiles = new selectedFiles();
            selectedFiles.files = files;
            selectedFiles.ShowDialog();
            SelectedFilesButton.Text = $"Selected Files ({files.Count})";
        }

        private void selectfiles_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
