using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.Areas.WorkLog.Models;
using MOSSWORKLOG.DATA;

namespace MOSSWORKLOG.Areas.WorkLog.Controllers
{
    public class WorkLogController : Controller
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
        // GET: WorkLog/WorkLog
        [Authorize]
        public ActionResult Index()
        {
            WorkLogViewModel vm = new WorkLogViewModel();
            _context.tblWorkLogs.ToList().ForEach(c => vm.WorkLogs.Add(new WorkLogModel()
            {
                WorkLogId = c.WorkLogId,
                StartTime = c.StartTime.Value.ToString("dd/MM/yyyy HH:mm"),
                EndTime = c.EndTime.Value.ToString("dd/MM/yyyy HH:mm"),
                Duration = (c.Duration/60),
                TaskId = c.TaskId,
                Unit = c.Unit,
                AverageTime = c.AverageTime,
                TaskName = _context.tblTasks.FirstOrDefault(x => x.TaskId == c.TaskId).TaskName,
                ProjectId = _context.tblTasks.FirstOrDefault(x => x.TaskId == c.TaskId).ProjectId,
                ProjectName = _context.tblProjects.FirstOrDefault( v=> v.ProjectId == _context.tblTasks.FirstOrDefault( x => x.TaskId == c.TaskId).ProjectId).ProjectName
            }));
            return View(vm);
        }
        public ActionResult ViewWorkLog(int id = 0)
        {
            WorkLogModel vm = new WorkLogModel();
            vm.WorkLogId = id;
            vm.IsEdit = id != 0 ? true : false;
            if (vm.IsEdit)
            {
                var worklog = _context.tblWorkLogs.SingleOrDefault(x => x.WorkLogId == id);
                vm.TaskId = worklog.TaskId;
                vm.StartTime = worklog.StartTime.Value.ToString("yyyy-MM-dd HH:mm");
                vm.EndTime = worklog.EndTime.Value.ToString("yyyy-MM-dd HH:mm");
                vm.Unit = worklog.Unit;
                //'2018 - 01 - 22 09:50'
            }

            vm.AllTask = Extension.GetTaskProjectName();

            return PartialView("_AddWorkLog", vm);
        }
        [HttpPost]
        public ActionResult CreateWorkLog(WorkLogModel vm)
        {
            tblWorkLog workLog = new tblWorkLog();

            int UserId = Convert.ToUInt16((this.User.Identity as System.Security.Claims.ClaimsIdentity).FindFirst("UserId").Value);

            if (vm.IsEdit)
                workLog = _context.tblWorkLogs.SingleOrDefault(x => x.WorkLogId == vm.WorkLogId);

            workLog.TaskId = vm.TaskId;
            workLog.StartTime = Convert.ToDateTime(vm.StartTime);
            workLog.EndTime = Convert.ToDateTime(vm.EndTime);
            workLog.Duration = Convert.ToDecimal(workLog.EndTime.Value.Subtract(workLog.StartTime.Value).TotalMinutes);
            workLog.Unit = vm.Unit;
            if (workLog.Duration != 0 && vm.Unit != 0)
                workLog.AverageTime = vm.Unit / workLog.Duration;

            if (!vm.IsEdit)
            {
                workLog.CreatedById = UserId;
                _context.tblWorkLogs.Add(workLog);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", new { area = "WorkLog" });
        }
        public ActionResult DeleteWorkLog(int id)
        {
            var WorkLog = _context.tblWorkLogs.SingleOrDefault(x => x.WorkLogId == id);
            _context.tblWorkLogs.Remove(WorkLog);
            _context.SaveChanges();
            return RedirectToAction("Index", new { area = "WorkLog" });
        }
    }
}