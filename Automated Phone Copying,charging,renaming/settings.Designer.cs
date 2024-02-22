namespace Automated_Phone_Copying_charging_renaming
{
    partial class settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settings));
            label1 = new Label();
            label2 = new Label();
            DirectoriesinDF1formula = new RichTextBox();
            DirectoriesinDF2formula = new RichTextBox();
            DF1Filesformula = new RichTextBox();
            label3 = new Label();
            DF2Filesformula = new RichTextBox();
            label4 = new Label();
            panel1 = new Panel();
            button2 = new Button();
            todate = new DateTimePicker();
            label6 = new Label();
            fromdate = new DateTimePicker();
            label5 = new Label();
            selectfilesbycreationdate = new CheckBox();
            panel2 = new Panel();
            Copytodf2 = new CheckBox();
            Copytodf1 = new CheckBox();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 41);
            label1.Name = "label1";
            label1.Size = new Size(263, 23);
            label1.TabIndex = 0;
            label1.Text = "DF1 Directory Naming Formula";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 153);
            label2.Name = "label2";
            label2.Size = new Size(263, 23);
            label2.TabIndex = 2;
            label2.Text = "DF2 Directory Naming Formula";
            // 
            // DirectoriesinDF1formula
            // 
            DirectoriesinDF1formula.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DirectoriesinDF1formula.Location = new Point(437, 41);
            DirectoriesinDF1formula.Name = "DirectoriesinDF1formula";
            DirectoriesinDF1formula.Size = new Size(488, 78);
            DirectoriesinDF1formula.TabIndex = 3;
            DirectoriesinDF1formula.Text = "^yyMMdd^";
            // 
            // DirectoriesinDF2formula
            // 
            DirectoriesinDF2formula.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DirectoriesinDF2formula.Location = new Point(437, 153);
            DirectoriesinDF2formula.Name = "DirectoriesinDF2formula";
            DirectoriesinDF2formula.Size = new Size(488, 78);
            DirectoriesinDF2formula.TabIndex = 4;
            DirectoriesinDF2formula.Text = "^yyMMdd^";
            // 
            // DF1Filesformula
            // 
            DF1Filesformula.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DF1Filesformula.Location = new Point(437, 256);
            DF1Filesformula.Name = "DF1Filesformula";
            DF1Filesformula.Size = new Size(488, 78);
            DF1Filesformula.TabIndex = 6;
            DF1Filesformula.Text = "%NAME%.%EXTENSION%";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 256);
            label3.Name = "label3";
            label3.Size = new Size(232, 23);
            label3.TabIndex = 5;
            label3.Text = "DF1 File Renaming Formula";
            // 
            // DF2Filesformula
            // 
            DF2Filesformula.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DF2Filesformula.Location = new Point(437, 377);
            DF2Filesformula.Name = "DF2Filesformula";
            DF2Filesformula.Size = new Size(488, 78);
            DF2Filesformula.TabIndex = 8;
            DF2Filesformula.Text = "%T1%?T1?'_'%AN%?AN?'_'%L1%?L1?'_'%CN%_^yyMMdd^_%NAME%.%EXTENSION%";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 377);
            label4.Name = "label4";
            label4.Size = new Size(232, 23);
            label4.TabIndex = 7;
            label4.Text = "DF2 File Renaming Formula";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(todate);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(fromdate);
            panel1.Controls.Add(label5);
            panel1.Enabled = false;
            panel1.Location = new Point(12, 481);
            panel1.Name = "panel1";
            panel1.Size = new Size(913, 125);
            panel1.TabIndex = 9;
            // 
            // button2
            // 
            button2.Location = new Point(844, 47);
            button2.Name = "button2";
            button2.Size = new Size(35, 29);
            button2.TabIndex = 4;
            button2.Text = "•";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // todate
            // 
            todate.Location = new Point(530, 47);
            todate.Name = "todate";
            todate.Size = new Size(250, 27);
            todate.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(452, 50);
            label6.Name = "label6";
            label6.Size = new Size(23, 20);
            label6.TabIndex = 2;
            label6.Text = "to";
            // 
            // fromdate
            // 
            fromdate.Location = new Point(101, 49);
            fromdate.Name = "fromdate";
            fromdate.Size = new Size(250, 27);
            fromdate.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 52);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 0;
            label5.Text = "from";
            // 
            // selectfilesbycreationdate
            // 
            selectfilesbycreationdate.AutoSize = true;
            selectfilesbycreationdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            selectfilesbycreationdate.Location = new Point(19, 471);
            selectfilesbycreationdate.Name = "selectfilesbycreationdate";
            selectfilesbycreationdate.Size = new Size(261, 27);
            selectfilesbycreationdate.TabIndex = 10;
            selectfilesbycreationdate.Text = "Select Files by Creation Date";
            selectfilesbycreationdate.UseVisualStyleBackColor = true;
            selectfilesbycreationdate.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(Copytodf2);
            panel2.Controls.Add(Copytodf1);
            panel2.Location = new Point(24, 631);
            panel2.Name = "panel2";
            panel2.Size = new Size(901, 45);
            panel2.TabIndex = 11;
            // 
            // Copytodf2
            // 
            Copytodf2.AutoSize = true;
            Copytodf2.Checked = true;
            Copytodf2.CheckState = CheckState.Checked;
            Copytodf2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Copytodf2.Location = new Point(440, 7);
            Copytodf2.Name = "Copytodf2";
            Copytodf2.Size = new Size(132, 27);
            Copytodf2.TabIndex = 1;
            Copytodf2.Text = "Copy to DF2";
            Copytodf2.UseVisualStyleBackColor = true;
            // 
            // Copytodf1
            // 
            Copytodf1.AutoSize = true;
            Copytodf1.Checked = true;
            Copytodf1.CheckState = CheckState.Checked;
            Copytodf1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Copytodf1.Location = new Point(25, 7);
            Copytodf1.Name = "Copytodf1";
            Copytodf1.Size = new Size(132, 27);
            Copytodf1.TabIndex = 0;
            Copytodf1.Text = "Copy to DF1";
            Copytodf1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(799, 6);
            button1.Name = "button1";
            button1.Size = new Size(126, 29);
            button1.TabIndex = 12;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 699);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(selectfilesbycreationdate);
            Controls.Add(panel1);
            Controls.Add(DF2Filesformula);
            Controls.Add(label4);
            Controls.Add(DF1Filesformula);
            Controls.Add(label3);
            Controls.Add(DirectoriesinDF2formula);
            Controls.Add(DirectoriesinDF1formula);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "settings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "settings";
            FormClosing += settings_FormClosing;
            Load += settings_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private RichTextBox DirectoriesinDF1formula;
        private RichTextBox DirectoriesinDF2formula;
        private RichTextBox DF1Filesformula;
        private Label label3;
        private RichTextBox DF2Filesformula;
        private Label label4;
        private Panel panel1;
        private CheckBox selectfilesbycreationdate;
        private DateTimePicker fromdate;
        private Label label5;
        private DateTimePicker todate;
        private Label label6;
        private Panel panel2;
        private CheckBox Copytodf2;
        private CheckBox Copytodf1;
        private Button button1;
        private Button button2;
    }
}