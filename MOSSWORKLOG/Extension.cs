using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSSWORKLOG.DATA;
using System.Net.Mail;
using System.Web.Mvc;

namespace MOSSWORKLOG
{
    public static class Extension
    {
        public static MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
        public static bool CheckRole(string roleId)
        {
            var currentThread = System.Threading.Thread.CurrentPrincipal;
            var currentRoleId = ((System.Security.Claims.ClaimsIdentity)currentThread.Identity).FindFirst(System.Security.Claims.ClaimTypes.Role).Value;
            return currentRoleId == roleId;
        }

        public static int GetUserId()
        {
            var currentThread = System.Threading.Thread.CurrentPrincipal;
            var user = ((System.Security.Claims.ClaimsIdentity)currentThread.Identity);
            return Convert.ToInt32(user.FindFirst("UserId").Value);
        }


        public static List<tblProject> GetProejcts()
        {
            int UserId = GetUserId();
            List<tblProject> projects = new List<tblProject>();
            if (CheckRole("1")) // Super visor
                projects = _context.tblProjects.ToList();
            else
            {
                projects = (from project in _context.tblProjects
                            join role in _context.tblUserRoleAssigns on project.ProjectId equals role.ProjectId
                            where role.AssignUserId == UserId
                            select project).ToList();
            }
            return projects;
        }

        public static List<tblTask> GetTask()
        {
            int UserId = GetUserId();
            List<tblTask> tasks = new List<tblTask>();
            if (CheckRole("1")) // Super visor
                tasks = _context.tblTasks.ToList();
            else
            {
                tasks = (from task in _context.tblTasks
                         join role in _context.tblUserRoleAssigns on task.TaskId equals role.TaskId
                         where role.AssignUserId == UserId
                         select task).ToList();
            }
            return tasks;
        }
        public static SelectList GetTaskProjectName()
        {
            int UserId = GetUserId();

            var tasks = from task in _context.tblTasks
                    join role in _context.tblUserRoleAssigns on task.TaskId equals role.TaskId
                    join p in _context.tblProjects on task.ProjectId equals p.ProjectId
                    select new { TaskId = task.TaskId, TaskName = task.TaskName + " | " + p.ProjectName,role.AssignUserId };

            if (!CheckRole("1")) // Super visor
                tasks = from task in tasks
                    where task.AssignUserId == UserId
                    select task;

            return new SelectList(tasks, "TaskId", "TaskName");
        }


        public static List<tblClient> GetClient()
        {
            int UserId = GetUserId();
            List<tblClient> clients = new List<tblClient>();
            if (CheckRole("1")) // Super visor
                clients = _context.tblClients.ToList();
            else
            {
                clients = (from cl in _context.tblClients
                         join role in _context.tblUserRoleAssigns on cl.ClientId equals role.ClientId
                         where role.AssignUserId == UserId
                           select cl).ToList();
            }
            return clients;
        }

        public static List<tblCategory> GetCategory()
        {
            return _context.tblCategories.Where(x=>x.Type == "C").ToList();
        }

        public static List<ComplianceCategory> GetComplianceCategory()
        {
            return _context.ComplianceCategorys.Where(x => x.Type == "C").ToList();
        }

        public static List<tblDocumentKeyWord> GetKeyWord()
        {
            return _context.tblDocumentKeyWords.ToList();
        }

        public static List<tblCategory> GetSubCategory()
        {
            return _context.tblCategories.Where(x => x.Type == "S").ToList();
        }

        public static List<ChangeManagementType> GetChangeManagementType()
        {
            return _context.ChangeManagementTypes.ToList();
        }

        public static List<ChangeManagementSubType> GetChangeManagementSubType()
        {
            return _context.ChangeManagementSubTypes.ToList();
        }

        public static List<tblUser> GetUser()
        {
            return _context.tblUsers.ToList();
        }
        public static void SendPassswordResetEmail(string email, string requestUrl)
        {

            StringBuilder mailHtml = new StringBuilder();
            mailHtml.Append("Hi!!<br/>");
            mailHtml.Append("We have received a request to reset your <b>MOSS</b> account password.<br/>");
            mailHtml.Append($"<a href=\"{requestUrl}\">Click here</a> to reset your password. This link will expire in 1 hour<br/><br/>");
            mailHtml.Append("Thanks");

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("piyush_jv@yahoo.co.uk");
            mail.Subject = "MOSS - Reset Password";
            mail.Body = mailHtml.ToString();
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.mail.yahoo.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("piyush_jv@yahoo.co.uk", "In@ia1947"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);

            //RestRequest request = new RestRequest();
            //request.AddParameter("domain", "MOSS.com", ParameterType.UrlSegment);
            //request.Resource = "{domain}/messages";
            //request.AddParameter("from", "MOSS <postmaster@MOSS.com>");
            //request.AddParameter("to", email);
            //request.AddParameter("subject", );


            //request.AddParameter("html", mailHtml.ToString());
            //request.Method = Method.POST;
        }

        public static void SendEmailVerify(string email, string requestUrl)
        {

            StringBuilder mailHtml = new StringBuilder();
            mailHtml.Append("Hi!!<br/>");
            mailHtml.Append("We have received a request to verify your <b>TrakME</b> account.<br/>");
            mailHtml.Append($"<a href=\"{requestUrl}\">Click here</a> to verify your email. This link will expire in 1 hour<br/><br/>");
            mailHtml.Append("Thanks");

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("piyush_jv@yahoo.co.uk");
            mail.Subject = "TrakMe - Verify Email";
            mail.Body = mailHtml.ToString();
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.mail.yahoo.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("piyush_jv@yahoo.co.uk", "In@ia1947"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }


        public static void SendEmailForgot(string email, string password)
        {

            StringBuilder mailHtml = new StringBuilder();
            mailHtml.Append("Hi!!<br/>");
            mailHtml.Append("We have received a request to reset your <b>TrakME</b> account.<br/>");
            mailHtml.Append($"Your password is : <b>\"{password}\"</b><br/><br/>");
            mailHtml.Append("Thanks");

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("piyush_jv@yahoo.co.uk");
            mail.Subject = "TrakMe - forgot Password";
            mail.Body = mailHtml.ToString();
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.mail.yahoo.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("piyush_jv@yahoo.co.uk", "In@ia1947"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        public static SelectList GetVendor()
        {
            var vendores = _context.tblVender.ToList();

            return new SelectList(vendores, "VenderId", "VenderName");
        }

    }
}