namespace Demo_1
{
    partial class Email
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
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.sendBut = new System.Windows.Forms.Button();
            this.newPassTb = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.userTb = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.emailTb = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(75, 329);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(353, 149);
            this.richTextBox1.TabIndex = 22;
            this.richTextBox1.Text = "Body";
            // 
            // sendBut
            // 
            this.sendBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.sendBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.sendBut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sendBut.Location = new System.Drawing.Point(150, 524);
            this.sendBut.Name = "sendBut";
            this.sendBut.Size = new System.Drawing.Size(200, 37);
            this.sendBut.TabIndex = 20;
            this.sendBut.Text = "Send";
            this.sendBut.UseVisualStyleBackColor = false;
            // 
            // newPassTb
            // 
            this.newPassTb.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.newPassTb.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.newPassTb.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.newPassTb.BorderThickness = 1;
            this.newPassTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.newPassTb.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.newPassTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newPassTb.isPassword = false;
            this.newPassTb.Location = new System.Drawing.Point(75, 287);
            this.newPassTb.Margin = new System.Windows.Forms.Padding(4);
            this.newPassTb.Name = "newPassTb";
            this.newPassTb.Size = new System.Drawing.Size(353, 35);
            this.newPassTb.TabIndex = 19;
            this.newPassTb.Tag = "";
            this.newPassTb.Text = "Subject";
            this.newPassTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // userTb
            // 
            this.userTb.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.userTb.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.userTb.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.userTb.BorderThickness = 1;
            this.userTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.userTb.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.userTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userTb.isPassword = false;
            this.userTb.Location = new System.Drawing.Point(75, 244);
            this.userTb.Margin = new System.Windows.Forms.Padding(4);
            this.userTb.Name = "userTb";
            this.userTb.Size = new System.Drawing.Size(353, 35);
            this.userTb.TabIndex = 18;
            this.userTb.Text = "To";
            this.userTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // emailTb
            // 
            this.emailTb.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.emailTb.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.emailTb.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.emailTb.BorderThickness = 1;
            this.emailTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.emailTb.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.emailTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.emailTb.isPassword = false;
            this.emailTb.Location = new System.Drawing.Point(75, 201);
            this.emailTb.Margin = new System.Windows.Forms.Padding(4);
            this.emailTb.Name = "emailTb";
            this.emailTb.Size = new System.Drawing.Size(353, 35);
            this.emailTb.TabIndex = 17;
            this.emailTb.Tag = "";
            this.emailTb.Text = "From";
            this.emailTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 30);
            this.panel1.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "EMAIL";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Demo_1.Properties.Resources.Delete_24px;
            this.button1.Location = new System.Drawing.Point(460, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 30);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Demo_1.Properties.Resources.Ebay_96px;
            this.pictureBox1.Location = new System.Drawing.Point(198, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sendBut);
            this.Controls.Add(this.newPassTb);
            this.Controls.Add(this.userTb);
            this.Controls.Add(this.emailTb);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Email";
            this.Text = "Email";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button sendBut;
        private Bunifu.Framework.UI.BunifuMetroTextbox newPassTb;
        private Bunifu.Framework.UI.BunifuMetroTextbox userTb;
        private Bunifu.Framework.UI.BunifuMetroTextbox emailTb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}