namespace Automated_Phone_Copying_charging_renaming
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            panel1 = new Panel();
            panel8 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label8 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel7 = new Panel();
            panel9 = new Panel();
            button6 = new Button();
            label7 = new Label();
            AN = new TextBox();
            label5 = new Label();
            L1 = new TextBox();
            SF = new TextBox();
            DF1 = new TextBox();
            DF2 = new TextBox();
            CN = new TextBox();
            T1 = new TextBox();
            panel6 = new Panel();
            Process_selected_files = new CheckBox();
            button5 = new Button();
            button4 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel2 = new Panel();
            richTextBox1 = new RichTextBox();
            label6 = new Label();
            panel3 = new Panel();
            panel5 = new Panel();
            progressBar = new ProgressBar();
            panel4 = new Panel();
            linkLabel1 = new LinkLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            appToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            logsToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel9.SuspendLayout();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(4, 24);
            button1.Name = "button1";
            button1.Size = new Size(163, 27);
            button1.TabIndex = 0;
            button1.Text = "Select SF";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel6);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(1325, 300);
            panel1.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.Controls.Add(label1);
            panel8.Controls.Add(label2);
            panel8.Controls.Add(label8);
            panel8.Controls.Add(label3);
            panel8.Controls.Add(label4);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(222, 298);
            panel8.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 24);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 2;
            label1.Text = "Source Folder (SF)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 79);
            label2.Name = "label2";
            label2.Size = new Size(183, 20);
            label2.TabIndex = 5;
            label2.Text = "Destination Folder 1 (DF1)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(24, 235);
            label8.Name = "label8";
            label8.Size = new Size(130, 20);
            label8.TabIndex = 13;
            label8.Text = "Actor Names (AN)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 131);
            label3.Name = "label3";
            label3.Size = new Size(183, 20);
            label3.TabIndex = 8;
            label3.Text = "Destination Folder 2 (DF2)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 183);
            label4.Name = "label4";
            label4.Size = new Size(152, 20);
            label4.TabIndex = 10;
            label4.Text = "Camera Number (CN)";
            // 
            // panel7
            // 
            panel7.Controls.Add(panel9);
            panel7.Controls.Add(label7);
            panel7.Controls.Add(AN);
            panel7.Controls.Add(label5);
            panel7.Controls.Add(L1);
            panel7.Controls.Add(SF);
            panel7.Controls.Add(DF1);
            panel7.Controls.Add(DF2);
            panel7.Controls.Add(CN);
            panel7.Controls.Add(T1);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(1144, 298);
            panel7.TabIndex = 15;
            panel7.Paint += panel7_Paint;
            // 
            // panel9
            // 
            panel9.Controls.Add(button6);
            panel9.Dock = DockStyle.Right;
            panel9.Location = new Point(1102, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(42, 298);
            panel9.TabIndex = 16;
            // 
            // button6
            // 
            button6.Location = new Point(3, 24);
            button6.Name = "button6";
            button6.Size = new Size(36, 27);
            button6.TabIndex = 15;
            button6.Text = "•";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(620, 235);
            label7.Name = "label7";
            label7.Size = new Size(95, 20);
            label7.TabIndex = 14;
            label7.Text = "Location (L1)";
            // 
            // AN
            // 
            AN.BackColor = Color.White;
            AN.Location = new Point(241, 234);
            AN.Name = "AN";
            AN.Size = new Size(329, 27);
            AN.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(620, 183);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 12;
            label5.Text = "Title1 (T1)";
            // 
            // L1
            // 
            L1.BackColor = Color.White;
            L1.Location = new Point(742, 234);
            L1.Name = "L1";
            L1.Size = new Size(329, 27);
            L1.TabIndex = 13;
            // 
            // SF
            // 
            SF.BackColor = Color.White;
            SF.Location = new Point(241, 24);
            SF.Name = "SF";
            SF.ReadOnly = true;
            SF.Size = new Size(833, 27);
            SF.TabIndex = 1;
            // 
            // DF1
            // 
            DF1.BackColor = Color.White;
            DF1.Location = new Point(241, 76);
            DF1.Name = "DF1";
            DF1.ReadOnly = true;
            DF1.Size = new Size(833, 27);
            DF1.TabIndex = 4;
            DF1.Text = "D:\\AV\\1_Shoot";
            // 
            // DF2
            // 
            DF2.BackColor = Color.White;
            DF2.Location = new Point(241, 128);
            DF2.Name = "DF2";
            DF2.ReadOnly = true;
            DF2.Size = new Size(833, 27);
            DF2.TabIndex = 7;
            DF2.Text = "Z:\\AV\\1_Shoot";
            // 
            // CN
            // 
            CN.BackColor = Color.White;
            CN.Location = new Point(241, 180);
            CN.Name = "CN";
            CN.Size = new Size(329, 27);
            CN.TabIndex = 9;
            // 
            // T1
            // 
            T1.BackColor = Color.White;
            T1.Location = new Point(742, 180);
            T1.Name = "T1";
            T1.Size = new Size(329, 27);
            T1.TabIndex = 11;
            // 
            // panel6
            // 
            panel6.Controls.Add(Process_selected_files);
            panel6.Controls.Add(button5);
            panel6.Controls.Add(button4);
            panel6.Controls.Add(button1);
            panel6.Controls.Add(button2);
            panel6.Controls.Add(button3);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(1144, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(179, 298);
            panel6.TabIndex = 14;
            panel6.Paint += panel6_Paint;
            // 
            // Process_selected_files
            // 
            Process_selected_files.AutoSize = true;
            Process_selected_files.Location = new Point(6, 183);
            Process_selected_files.Name = "Process_selected_files";
            Process_selected_files.Size = new Size(170, 24);
            Process_selected_files.TabIndex = 15;
            Process_selected_files.Text = "Process selected files";
            Process_selected_files.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(5, 230);
            button5.Name = "button5";
            button5.Size = new Size(162, 31);
            button5.TabIndex = 14;
            button5.Text = "Start";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button4_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(499, 85);
            button4.Name = "button4";
            button4.Size = new Size(51, 27);
            button4.TabIndex = 13;
            button4.Text = "Start";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.Location = new Point(4, 76);
            button2.Name = "button2";
            button2.Size = new Size(163, 27);
            button2.TabIndex = 3;
            button2.Text = "Select DF1";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(3, 128);
            button3.Name = "button3";
            button3.Size = new Size(163, 27);
            button3.TabIndex = 6;
            button3.Text = "Select DF2";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(richTextBox1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 328);
            panel2.Name = "panel2";
            panel2.Size = new Size(1325, 618);
            panel2.TabIndex = 2;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Black;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(1323, 559);
            richTextBox1.TabIndex = 16;
            richTextBox1.Text = "";
            // 
            // label6
            // 
            label6.BackColor = Color.Black;
            label6.Dock = DockStyle.Bottom;
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, 559);
            label6.Name = "label6";
            label6.Size = new Size(1323, 25);
            label6.TabIndex = 15;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 584);
            panel3.Name = "panel3";
            panel3.Size = new Size(1323, 32);
            panel3.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(progressBar);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(250, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1073, 32);
            panel5.TabIndex = 16;
            // 
            // progressBar
            // 
            progressBar.Dock = DockStyle.Fill;
            progressBar.Location = new Point(0, 0);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(1073, 32);
            progressBar.TabIndex = 16;
            // 
            // panel4
            // 
            panel4.Controls.Add(linkLabel1);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(250, 32);
            panel4.TabIndex = 15;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(73, 5);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(89, 20);
            linkLabel1.TabIndex = 14;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Hide details";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { appToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1325, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // appToolStripMenuItem
            // 
            appToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, logsToolStripMenuItem });
            appToolStripMenuItem.Image = Properties.Resources.menu;
            appToolStripMenuItem.Name = "appToolStripMenuItem";
            appToolStripMenuItem.Size = new Size(71, 24);
            appToolStripMenuItem.Text = "App";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Image = Properties.Resources.settings;
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(145, 26);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // logsToolStripMenuItem
            // 
            logsToolStripMenuItem.Image = Properties.Resources.logs;
            logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            logsToolStripMenuItem.Size = new Size(145, 26);
            logsToolStripMenuItem.Text = "Logs";
            logsToolStripMenuItem.Click += logsToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 946);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CopyRename v17";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel9.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private Label label1;
        private TextBox SF;
        private Label label3;
        private TextBox DF2;
        private Button button3;
        private Label label2;
        private TextBox DF1;
        private Button button2;
        private Label label5;
        private TextBox T1;
        private Label label4;
        private TextBox CN;
        private Button button4;
        private Panel panel2;
        private LinkLabel linkLabel1;
        //private ProgressBar progressBar;
        private Panel panel3;
        private Label label6;
        private ProgressBar progressBar;
        private System.Windows.Forms.Timer timer1;
        private RichTextBox richTextBox1;
        private Panel panel4;
        private Panel panel5;
        private Panel panel8;
        private Panel panel7;
        private Panel panel6;
        private Label label7;
        private Label label8;
        private TextBox AN;
        private TextBox L1;
        private Button button5;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem appToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Button button6;
        private Panel panel9;
        private CheckBox Process_selected_files;
        private ToolStripMenuItem logsToolStripMenuItem;
    }
}