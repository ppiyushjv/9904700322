using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserActivityMonitor;

namespace MOSSWORKLOGAPP
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            // Add handler to handle the exception raised by additional threads
            AppDomain.CurrentDomain.UnhandledException +=
            new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            //HookManager.KeyDown += HookManager_KeyDown;
            //HookManager.MouseDown += HookManager_MouseDown;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        private static void HookManager_MouseDown(object sender, MouseEventArgs e)
        {
            _Application.isActive = true;
        }

        private static void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            _Application.CheckActivity(e.KeyValue);
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            if (_Application._CurrentUser != null)
            {
                var restclient = new RestClient(_Application.HostName);
                var request = new RestRequest("/api/WebApi/LogOut?userId=" + _Application._CurrentUser.UserId.ToString(), Method.POST) { RequestFormat = DataFormat.Json };
                IRestResponse response = restclient.Execute(request);
            }
        }

        // All exceptions thrown by the main thread are handled over this method
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ShowExceptionDetails(e.Exception);
        }

        // All exceptions thrown by additional threads are handled in this method
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowExceptionDetails(e.ExceptionObject as Exception);
            //Thread.CurrentThread.Suspend();
        }

        // Do logging of exception details
        static void ShowExceptionDetails(Exception Ex)
        {
            MessageBox.Show(Ex.Message, Ex.TargetSite.ToString(),MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static class _Application
    {
        public const string HostName = "http://mossworklog.com";
        public static tblUser _CurrentUser = null;
        public static bool isActive = false;
        public static int DefineKey1 = 162, DefineKey2 = 164, DefineKey3 = 107; // CTRL ALT +
        public static int PressedKey1 = 0, PressedKey2 = 0, PressedKey3 = 0;
        public static bool isIncreseKeyPressed = false;
        public static void CheckActivity(int KeyValue)
        {
            _Application.isActive = true;

            if (_Application._CurrentUser != null)
            {
                if (_Application.PressedKey1 == 0)
                {
                    if (KeyValue == _Application.DefineKey1)
                        _Application.PressedKey1 = KeyValue;
                }
                else
                {
                    if (_Application.PressedKey1 != 0 && _Application.PressedKey2 == 0 && _Application.PressedKey1 != KeyValue)
                    {
                        if (KeyValue == _Application.DefineKey2)
                            _Application.PressedKey2 = KeyValue;
                        else
                            _Application.PressedKey1 = 0;
                    }
                    else
                    {
                        if (_Application.PressedKey1 != 0 && _Application.PressedKey2 != 0 && _Application.PressedKey3 == 0 && _Application.PressedKey2 != KeyValue)
                        {
                            if (KeyValue == _Application.DefineKey3)
                                _Application.PressedKey3 = KeyValue;

                            _Application.isIncreseKeyPressed = _Application.PressedKey1 == _Application.DefineKey1 && _Application.PressedKey2 == _Application.DefineKey2 && _Application.PressedKey3 == _Application.DefineKey3;
                            _Application.PressedKey1 = 0;
                            _Application.PressedKey2 = 0;
                            _Application.PressedKey3 = 0;
                        }
                    }
                }
            }
        }
    }
}