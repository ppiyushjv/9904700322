namespace MOSSWORKLOGAPP
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.textPassWord = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.linkLabelForget = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 252);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // textUserName
            // 
            this.textUserName.Location = new System.Drawing.Point(118, 126);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(100, 20);
            this.textUserName.TabIndex = 0;
            this.textUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textUserName_KeyDown);
            // 
            // textPassWord
            // 
            this.textPassWord.Location = new System.Drawing.Point(118, 159);
            this.textPassWord.Name = "textPassWord";
            this.textPassWord.PasswordChar = '*';
            this.textPassWord.Size = new System.Drawing.Size(100, 20);
            this.textPassWord.TabIndex = 1;
            this.textPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textPassWord_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(50, 234);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(223, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(50, 129);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "User Name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(50, 167);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // pictureLogo
            // 
            this.pictureLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
            this.pictureLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureLogo.InitialImage")));
            this.pictureLogo.Location = new System.Drawing.Point(126, 30);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(70, 71);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLogo.TabIndex = 5;
            this.pictureLogo.TabStop = false;
            // 
            // linkLabelForget
            // 
            this.linkLabelForget.AutoSize = true;
            this.linkLabelForget.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.linkLabelForget.Location = new System.Drawing.Point(227, 207);
            this.linkLabelForget.Name = "linkLabelForget";
            this.linkLabelForget.Size = new System.Drawing.Size(46, 13);
            this.linkLabelForget.TabIndex = 6;
            this.linkLabelForget.TabStop = true;
            this.linkLabelForget.Text = "Forget ?";
            this.linkLabelForget.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelForget_LinkClicked);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(321, 313);
            this.Controls.Add(this.linkLabelForget);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textPassWord);
            this.Controls.Add(this.textUserName);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOSS";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelForget;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox textPassWord;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

