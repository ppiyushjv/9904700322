using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using MOSSWORKLOG.DATA;
using MOSSWORKLOG.Areas.Task.Models;
using MOSSWORKLOG.Areas.User.Models;
using MOSSWORKLOG.Areas.WorkLog.Models;
using MOSSWORKLOG.Filters;
using System.Web;
using MOSSWORKLOG.Helpers;

namespace MOSSWORKLOG.Controllers
{
    public class WebApiController : ApiController
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();

        // GET: api/WebApi
        [HttpGet]
        public tblUser GetLogin(string userName, string passWord,string timeStamp)
        {
            var user = _context.tblUsers.SingleOrDefault(u => u.UserName == userName && u.Password == passWord);
            if (user != null)
            {
                DateTime timeLog = DateTime.Now;

                if (!string.IsNullOrEmpty(timeStamp))
                    timeLog = Convert.ToDateTime(timeStamp);

                _context.tblUserLogs.Add(new tblUserLog()
                {
                    UserId = user.UserId,
                    Type = "LOGIN",
                    TimeLog = DateTime.Now
                });
                _context.SaveChanges();
            }
            return user;
        }

        [HttpGet]
        public void GetLogOff(int userId, string timeStamp)
        {
            DateTime timeLog = DateTime.Now;

            if (!string.IsNullOrEmpty(timeStamp))
                timeLog = Convert.ToDateTime(timeStamp);

            _context.tblUserLogs.Add(new tblUserLog()
            {
                UserId = userId,
                Type = "LOGOFF",
                TimeLog = DateTime.Now
            });
            _context.SaveChanges();
        }

        [HttpGet]
        public List<TaskModel> GetTask(int userId)
        {
            var tasks = (from task in _context.tblTasks
                         join role in _context.tblUserRoleAssigns on task.TaskId equals role.TaskId
                         join proj in _context.tblProjects on task.ProjectId equals proj.ProjectId
                         where role.AssignUserId == userId
                         select new TaskModel()
                         {
                             TaskId = task.TaskId,
                             TaskName = task.TaskName,
                             ProjectId = task.ProjectId,
                             ProjectName = proj.ProjectName,
                             TaskDescription = task.TaskDescription,
                             TaskFrequency = task.TaskFrequency,
                             Email = task.Email,
                             TaskTick = task.TaskTick,
                             CreatedOn = task.CreatedOn
                         }).ToList();

            return tasks;
        }

        [HttpGet]
        public int StartTask(int taskId, int userId, string timeStamp)
        {
            var wo = new tblWorkLog();

            wo.TaskId = taskId;
            wo.StartTime = Convert.ToDateTime(timeStamp);
            wo.CreatedById = userId;
            _context.tblWorkLogs.Add(wo);
            _context.SaveChanges();

            return wo.WorkLogId;
        }

        [HttpGet]
        public void EndTask(int workLogId, string timeStamp)
        {
            var wl = _context.tblWorkLogs.SingleOrDefault(x => x.WorkLogId == workLogId);
            wl.EndTime = Convert.ToDateTime(timeStamp);
            wl.Duration = Convert.ToDecimal(wl.EndTime.Value.Subtract(wl.StartTime.Value).TotalMinutes);

            if (wl.Duration != 0 && wl.Unit != 0)
                wl.AverageTime = wl.Unit / wl.Duration;

            _context.SaveChanges();
        }

        [HttpGet]
        public IList<UserModel> Getusers(int id)
        {
            IList<UserModel> Users = new List<UserModel>();
            _context.tblUsers.Where(x=>x.UserId == id).ToList().ForEach(c => Users.Add(new UserModel()
            {
                UserId = c.UserId,
                FullName = c.FullName,
                UserName = c.UserName,
                Password = c.Password,
                Mobile = c.Mobile,
                RoleId = c.RoleId,
                Email = c.email,
                RoleName = _context.tblRoles.SingleOrDefault(x => x.RoleId == c.RoleId).RoleDesc
            }));
            return Users.ToList();
        }

        [HttpGet]
        public string GetIncreaseUnit(int Id)
        {
            var wl = _context.tblWorkLogs.SingleOrDefault(x => x.WorkLogId == Id);
            wl.Unit = wl.Unit.GetValueOrDefault() + 1;
            _context.SaveChanges();
            return wl.Unit.GetValueOrDefault().ToString();
        }

        [HttpGet]
        public WorkLogModel GetWorkLog(int workLogId)
        {
            WorkLogModel workLog = new WorkLogModel();
            var w = _context.tblWorkLogs.SingleOrDefault(x => x.WorkLogId == workLogId);
            workLog.TaskName = _context.tblTasks.SingleOrDefault(X => X.TaskId == w.TaskId).TaskName;
            workLog.StartTime = w.StartTime.ToString();
            workLog.Unit = w.Unit;

            return workLog;
        }

        [HttpGet]
        public int GetWorkLogByUserId(int userId)
        {
            int returnVal = 0;
            var wl = _context.tblWorkLogs.SingleOrDefault(x => x.EndTime == null && x.CreatedById == userId);

            if (wl != null)
                returnVal = wl.WorkLogId;


            return returnVal;
        }
    }
}