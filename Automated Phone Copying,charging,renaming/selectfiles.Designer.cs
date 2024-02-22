namespace Automated_Phone_Copying_charging_renaming
{
    partial class selectfiles
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
            itemspanel = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel1 = new Panel();
            SelectedFilesButton = new Button();
            button2 = new Button();
            button1 = new Button();
            vScrollBar1 = new VScrollBar();
            panel3 = new Panel();
            label2 = new Label();
            backbutton = new Button();
            panel4 = new Panel();
            itemspanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // itemspanel
            // 
            itemspanel.BackColor = Color.White;
            itemspanel.BorderStyle = BorderStyle.FixedSingle;
            itemspanel.Controls.Add(label1);
            itemspanel.Controls.Add(pictureBox1);
            itemspanel.Location = new Point(0, 36);
            itemspanel.Name = "itemspanel";
            itemspanel.Size = new Size(1272, 571);
            itemspanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 166);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.picture;
            pictureBox1.Location = new Point(28, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(168, 145);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 623);
            panel2.Name = "panel2";
            panel2.Size = new Size(1309, 42);
            panel2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(SelectedFilesButton);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1063, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(246, 42);
            panel1.TabIndex = 2;
            // 
            // SelectedFilesButton
            // 
            SelectedFilesButton.Location = new Point(3, 5);
            SelectedFilesButton.Name = "SelectedFilesButton";
            SelectedFilesButton.Size = new Size(240, 29);
            SelectedFilesButton.TabIndex = 0;
            SelectedFilesButton.Text = "Selected Files (0)";
            SelectedFilesButton.UseVisualStyleBackColor = true;
            SelectedFilesButton.Click += button4_Click;
            // 
            // button2
            // 
            button2.Location = new Point(195, 3);
            button2.Name = "button2";
            button2.Size = new Size(160, 32);
            button2.TabIndex = 1;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 3);
            button1.Name = "button1";
            button1.Size = new Size(160, 32);
            button1.TabIndex = 0;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Dock = DockStyle.Fill;
            vScrollBar1.Location = new Point(0, 0);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(31, 587);
            vScrollBar1.TabIndex = 2;
            vScrollBar1.Scroll += vScrollBar1_Scroll;
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Controls.Add(backbutton);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1309, 36);
            panel3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(404, 8);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 1;
            // 
            // backbutton
            // 
            backbutton.Location = new Point(28, 4);
            backbutton.Name = "backbutton";
            backbutton.Size = new Size(94, 29);
            backbutton.TabIndex = 0;
            backbutton.Text = "Back";
            backbutton.UseVisualStyleBackColor = true;
            backbutton.Click += button3_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(vScrollBar1);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(1278, 36);
            panel4.Name = "panel4";
            panel4.Size = new Size(31, 587);
            panel4.TabIndex = 4;
            // 
            // selectfiles
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1309, 665);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(itemspanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "selectfiles";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "selectfiles";
            Load += selectfiles_Load;
            KeyPress += selectfiles_KeyPress;
            Resize += selectfiles_Resize;
            itemspanel.ResumeLayout(false);
            itemspanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel itemspanel;
        private Panel panel2;
        private Button button2;
        private Button button1;
        private VScrollBar vScrollBar1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Panel panel4;
        private Button backbutton;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private Button SelectedFilesButton;
    }
}