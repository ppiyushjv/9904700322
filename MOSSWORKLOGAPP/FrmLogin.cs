using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOSSWORKLOGAPP
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            try
            {
                textUserName.Text =  ConfigurationManager.AppSettings["userName"];
                textPassWord.Text = ConfigurationManager.AppSettings["passWord"];
            }
            catch { }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textUserName.Text))
                textUserName.Focus();

            if (string.IsNullOrEmpty(textPassWord.Text))
                textPassWord.Focus();

            var url = string.Format("/api/WebApi/Login?userName={0}&passWord={1}&timeStamp={2}", textUserName.Text, textPassWord.Text, DateTime.Now.ToString());
            var restclient = new RestClient(_Application.HostName);
            var request = new RestRequest(url, Method.POST) { RequestFormat = DataFormat.Json };
            IRestResponse<tblUser> response = restclient.Execute<tblUser>(request);

            if (true || response.Data == null)
            {
                MessageBox.Show("Enter valid User name or password..");
                textUserName.Text = "";
                textPassWord.Text = "";
                textUserName.Focus();
            }
            else
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Add an Application Setting.app
                config.AppSettings.Settings.Add("userName", textUserName.Text);
                config.AppSettings.Settings.Add("passWord", textPassWord.Text);
                // Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified, true);
                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");

                _Application._CurrentUser = response.Data;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void textUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void textPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(this.textPassWord.Text))
                btnLogin.PerformClick();
        }

        private void linkLabelForget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://mossworklog.com/");
            Process.Start(sInfo);
        }
    }
}
