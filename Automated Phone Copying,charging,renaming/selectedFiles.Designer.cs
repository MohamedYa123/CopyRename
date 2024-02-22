namespace Automated_Phone_Copying_charging_renaming
{
    partial class selectedFiles
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
            listView1 = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            panel1 = new Panel();
            button1 = new Button();
            rmv = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader1, columnHeader2, columnHeader3 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(3, 32);
            listView1.Name = "listView1";
            listView1.Size = new Size(918, 439);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.KeyPress += listView1_KeyPress;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Id";
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "File name";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Type";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Location";
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(rmv);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 477);
            panel1.Name = "panel1";
            panel1.Size = new Size(933, 52);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(170, 3);
            button1.Name = "button1";
            button1.Size = new Size(147, 46);
            button1.TabIndex = 1;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // rmv
            // 
            rmv.Location = new Point(3, 3);
            rmv.Name = "rmv";
            rmv.Size = new Size(147, 46);
            rmv.TabIndex = 0;
            rmv.Text = "Remove";
            rmv.UseVisualStyleBackColor = true;
            rmv.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 8);
            label1.Name = "label1";
            label1.Size = new Size(329, 20);
            label1.TabIndex = 1;
            label1.Text = "Press 'd' to remove selcted items using keyboard";
            // 
            // selectedFiles
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 529);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "selectedFiles";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "selectedFiles";
            Load += selectedFiles_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Panel panel1;
        private Button rmv;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label label1;
        private Button button1;
    }
}