using MOSSWORKLOG.Areas.Task.Models;
using MOSSWORKLOG.Areas.User.Models;
using MOSSWORKLOG.Areas.WorkLog.Models;
using MOSSWORKLOG.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.Api.Controllers
{
    public class V1Controller : Controller
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();

        // GET: V1Api
        [HttpGet]
        public JsonResult GetLogin(string userName, string passWord, string timeStamp)
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
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void GetLogOff(int id, string timeStamp)
        {
            DateTime timeLog = DateTime.Now;

            if (!string.IsNullOrEmpty(timeStamp))
                timeLog = Convert.ToDateTime(timeStamp);

            _context.tblUserLogs.Add(new tblUserLog()
            {
                UserId = id,
                Type = "LOGOFF",
                TimeLog = DateTime.Now
            });
            _context.SaveChanges();
        }

        [HttpGet]
        public JsonResult GetTask(int id)
        {
            var tasks = (from task in _context.tblTasks
                         join role in _context.tblUserRoleAssigns on task.TaskId equals role.TaskId
                         join proj in _context.tblProjects on task.ProjectId equals proj.ProjectId
                         where role.AssignUserId == id
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

            return Json(tasks, JsonRequestBehavior.AllowGet);
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
        public JsonResult Getusers(int id)
        {
            IList<UserModel> Users = new List<UserModel>();
            _context.tblUsers.Where(x => x.UserId == id).ToList().ForEach(c => Users.Add(new UserModel()
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
            return Json(Users.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public string GetIncreaseUnit(int id)
        {
            var wl = _context.tblWorkLogs.SingleOrDefault(x => x.WorkLogId == id);
            wl.Unit = wl.Unit.GetValueOrDefault() + 1;
            _context.SaveChanges();
            return wl.Unit.GetValueOrDefault().ToString();
        }

        [HttpGet]
        public WorkLogModel GetWorkLog(int id)
        {
            WorkLogModel workLog = new WorkLogModel();
            var w = _context.tblWorkLogs.SingleOrDefault(x => x.WorkLogId == id);
            workLog.TaskName = _context.tblTasks.SingleOrDefault(X => X.TaskId == w.TaskId).TaskName;
            workLog.StartTime = w.StartTime.ToString();
            workLog.Unit = w.Unit;

            return workLog;
        }

        [HttpGet]
        public int GetWorkLogByUserId(int id)
        {
            int returnVal = 0;
            var wl = _context.tblWorkLogs.SingleOrDefault(x => x.EndTime == null && x.CreatedById == id);

            if (wl != null)
                returnVal = wl.WorkLogId;


            return returnVal;
        }
    }
}