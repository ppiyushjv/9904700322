using RestSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UserActivityMonitor;

namespace MOSSWORKLOGAPP
{
    public partial class FormMain : Form
    {
        List<TaskModel> tasks = new List<TaskModel>();
        Timer tmrLoginCheck;
        Timer tmrActivity;
        int CurrentTaskWorkLog;
        public FormMain()
        {
            InitializeComponent();
            tmrLoginCheck = new Timer();
            tmrLoginCheck.Tick += TmrLoginCheck_Tick;
            tmrLoginCheck.Interval = 300000; // 5 min
            tmrLoginCheck.Enabled = false;

            tmrActivity = new Timer();
            tmrActivity.Tick += tmrActivity_Tick;
            tmrActivity.Interval = 100; // 5 min
            tmrActivity.Enabled = false;

            HookManager.KeyDown += HookManager_KeyDown;
            HookManager.MouseDown += HookManager_MouseDown;
        }

        private void HookManager_MouseDown(object sender, MouseEventArgs e)
        {
            _Application.isActive = true;
        }

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            _Application.CheckActivity(e.KeyValue);
        }

        private void TmrLoginCheck_Tick(object sender, EventArgs e)
        {
            tmrLoginCheck.Stop();
            if (!_Application.isActive)
            {
                LogOff(true);
            }
            else
                tmrLoginCheck.Start();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            LogOff(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void tmrActivity_Tick(object sender, EventArgs e)
        {
            //lbltest.Text = string.Format("{0},{1},{2}", Program.Key1.ToString(), Program.Key2.ToString(), Program.Key3.ToString());
            //if (CurrentTaskWorkLog != 0 &&  Program.isIncreseKeyPressed)
            //{
            //    Program.isIncreseKeyPressed = false;
            //    tmrActivity.Stop();
            //    buttonIncrease.PerformClick();
            //    tmrActivity.Start();
            //}
            _Application.isActive = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void ExitApplication()
        {
            tmrLoginCheck.Stop();
            tmrLoginCheck.Enabled = false;

            tmrActivity.Stop();
            tmrActivity.Enabled = false;

            LogOff(false);

            Application.Exit();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var currentTime = DateTime.Now.ToString();

            var restclient = new RestClient(_Application.HostName);
            var url = string.Format("/api/WebApi/StartTask?taskId={0}&userId={1}&timeStamp={2}", comboBoxTask.SelectedValue.ToString(),
                     _Application._CurrentUser.UserId.ToString(), currentTime);

            var request = new RestRequest(url, Method.POST) { RequestFormat = DataFormat.Json };
            IRestResponse response = restclient.Execute(request);

            CurrentTaskWorkLog = Convert.ToUInt16(response.Content);

            buttonStart.Enabled = false;
            comboBoxTask.Enabled = false;
            buttonStop.Enabled = true;
            buttonIncrease.Enabled = true;

            CurrenTask.Text = "Current Runnig Task :" + comboBoxTask.Text;
            lblUnit.Text = "Unit : 0";
            lblStartTime.Text = "Start Time :" + currentTime;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            var restclient = new RestClient(_Application.HostName);
            var url = string.Format("/api/WebApi/EndTask?workLogId={0}&timeStamp={1}", CurrentTaskWorkLog.ToString(),
                     DateTime.Now.ToString());

            var request = new RestRequest(url, Method.PUT) { RequestFormat = DataFormat.Json };
            IRestResponse response = restclient.Execute(request);

            buttonStart.Enabled = true;
            comboBoxTask.Enabled = true;
            buttonStop.Enabled = false;
            buttonIncrease.Enabled = false;

            CurrenTask.Text = "Current Runnig Task :";
            lblUnit.Text = "Unit :";
            lblStartTime.Text = "Start Time :";
        }

        private void Login()
        {
            tmrActivity.Enabled = false;
            tmrActivity.Stop();

            tmrLoginCheck.Enabled = false;
            tmrLoginCheck.Stop();

            this.Text = "MOSS WORKLOG";

            this.Hide();

            FrmLogin logon = new FrmLogin();
            if (logon.ShowDialog() != DialogResult.OK)
            {
                ExitApplication();
            }
            else
            {
                this.Show();

                this.Text = this.Text + "( " + _Application._CurrentUser.UserName + " )";

                tmrActivity.Enabled = true;
                tmrActivity.Start();

                tmrLoginCheck.Enabled = true;
                tmrLoginCheck.Start();

                var restclient = new RestClient(_Application.HostName);
                var request = new RestRequest("/api/WebApi/GetTask?userId=" + _Application._CurrentUser.UserId.ToString(), Method.POST) { RequestFormat = DataFormat.Json };

                IRestResponse<List<TaskModel>> response = restclient.Execute<List<TaskModel>>(request);

                tasks = response.Data;

                comboBoxTask.DataSource = tasks;
                comboBoxTask.DisplayMember = "DisplayName";
                comboBoxTask.ValueMember = "TaskId";

                CheckAnyTaskRunning();

            }
        }

        private void LogOff(bool LoginAgain)
        {
            tmrActivity.Enabled = false;
            tmrActivity.Stop();

            tmrLoginCheck.Enabled = false;
            tmrLoginCheck.Stop();

            if (_Application._CurrentUser != null)
            {

                var restclient = new RestClient(_Application.HostName);
                var url = string.Format("/api/WebApi/LogOff?userId={0}&timeStamp={1}", _Application._CurrentUser.UserId.ToString(), DateTime.Now.ToString());
                var request = new RestRequest(url, Method.POST) { RequestFormat = DataFormat.Json };
                IRestResponse response = restclient.Execute(request);

                _Application._CurrentUser = null;
            }

            if (LoginAgain)
                Login();
        }

        private void buttonIncrease_Click(object sender, EventArgs e)
        {
            Increase();
        }

        private void CheckAnyTaskRunning()
        {

            var restclient = new RestClient(_Application.HostName);
            var url = string.Format("/api/WebApi/GetWorkLogByUserId?userId={0}", _Application._CurrentUser.UserId.ToString());
            var request = new RestRequest(url, Method.GET) { RequestFormat = DataFormat.Json };
            IRestResponse response = restclient.Execute(request);

            int workLogId = Convert.ToUInt16(response.Content);

            if (workLogId != 0)
            {
                CurrentTaskWorkLog = workLogId;


                restclient = new RestClient(_Application.HostName);
                request = new RestRequest("/api/WebApi/GetWorkLog?workLogId=" + workLogId.ToString(), Method.POST) { RequestFormat = DataFormat.Json };

                IRestResponse<WorkLogModel> responseW = restclient.Execute<WorkLogModel>(request);
                var workLog = responseW.Data;

                buttonStart.Enabled = false;
                comboBoxTask.Enabled = false;
                buttonStop.Enabled = true;
                buttonIncrease.Enabled = true;

                CurrenTask.Text = "Current Runnig Task :" + workLog.TaskName.ToString();
                lblUnit.Text = "Unit : " + workLog.Unit.ToString();
                lblStartTime.Text = "Start Time :" + workLog.StartTime.ToString();
            }

        }

        private void Increase()
        {
            var restclient = new RestClient(_Application.HostName);
            var url = string.Format("/api/WebApi/GetIncreaseUnit?Id={0}", CurrentTaskWorkLog.ToString());
            var request = new RestRequest(url, Method.DELETE) { RequestFormat = DataFormat.Json };
            IRestResponse response = restclient.Execute(request);
            lblUnit.Text = "Unit :" + response.Content.ToString();
        }
    }
}