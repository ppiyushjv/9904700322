namespace MOSSWORKLOGAPP
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.comboBoxTask = new System.Windows.Forms.ComboBox();
            this.labelTask = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.CurrenTask = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.buttonIncrease = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "MOSS WORKLOG";
            this.notifyIcon1.BalloonTipTitle = "MOSS WORKLOG";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "MOSS WORKLOG";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(371, 294);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(75, 23);
            this.buttonLogOut.TabIndex = 3;
            this.buttonLogOut.Text = "Log Off";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // comboBoxTask
            // 
            this.comboBoxTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTask.FormattingEnabled = true;
            this.comboBoxTask.Location = new System.Drawing.Point(105, 22);
            this.comboBoxTask.Name = "comboBoxTask";
            this.comboBoxTask.Size = new System.Drawing.Size(277, 21);
            this.comboBoxTask.TabIndex = 1;
            // 
            // labelTask
            // 
            this.labelTask.AutoSize = true;
            this.labelTask.Location = new System.Drawing.Point(45, 25);
            this.labelTask.Name = "labelTask";
            this.labelTask.Size = new System.Drawing.Size(31, 13);
            this.labelTask.TabIndex = 2;
            this.labelTask.Text = "Task";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(388, 22);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(452, 294);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(469, 22);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // CurrenTask
            // 
            this.CurrenTask.AutoSize = true;
            this.CurrenTask.Location = new System.Drawing.Point(45, 72);
            this.CurrenTask.Name = "CurrenTask";
            this.CurrenTask.Size = new System.Drawing.Size(111, 13);
            this.CurrenTask.TabIndex = 7;
            this.CurrenTask.Text = "Current Runnig Task :";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(45, 130);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(32, 13);
            this.lblUnit.TabIndex = 8;
            this.lblUnit.Text = "Unit :";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(45, 102);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(61, 13);
            this.lblStartTime.TabIndex = 9;
            this.lblStartTime.Text = "Start Time :";
            // 
            // buttonIncrease
            // 
            this.buttonIncrease.Enabled = false;
            this.buttonIncrease.Location = new System.Drawing.Point(388, 51);
            this.buttonIncrease.Name = "buttonIncrease";
            this.buttonIncrease.Size = new System.Drawing.Size(156, 23);
            this.buttonIncrease.TabIndex = 10;
            this.buttonIncrease.Text = "Increase Unit";
            this.buttonIncrease.UseVisualStyleBackColor = true;
            this.buttonIncrease.Click += new System.EventHandler(this.buttonIncrease_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(548, 329);
            this.Controls.Add(this.buttonIncrease);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.CurrenTask);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelTask);
            this.Controls.Add(this.comboBoxTask);
            this.Controls.Add(this.buttonLogOut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOSS WORKLOG ";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.ComboBox comboBoxTask;
        private System.Windows.Forms.Label labelTask;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label CurrenTask;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Button buttonIncrease;
    }
}