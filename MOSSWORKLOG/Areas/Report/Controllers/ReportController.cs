using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.Areas.WorkLog.Models;
using MOSSWORKLOG.DATA;

namespace MOSSWORKLOG.Areas.Report.Controllers
{
    public class ReportController : Controller
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
        // GET: Report/Report
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetWorkLog()
        {
            DateTime startDate = DateTime.Now.Date;
            DateTime endDate = DateTime.Now.Date;

            if (Request.QueryString["startDate"] != null)
                startDate = DateTime.ParseExact(Request.QueryString["startDate"].ToString(), "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);

            if (Request.QueryString["endDate"] != null)
                endDate = DateTime.ParseExact(Request.QueryString["endDate"].ToString(), "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);


            WorkLogViewModel vm = new WorkLogViewModel();
            var worklog = _context.tblWorkLogs.ToList();

            worklog.Where(x => x.StartTime <= startDate || x.StartTime >= endDate)
                .ToList().ForEach(c => vm.WorkLogs.Add(new WorkLogModel()
                {
                    WorkLogId = c.WorkLogId,
                    StartTime = c.StartTime.Value.ToString("dd/MM/yyyy HH:mm"),
                    EndTime = c.EndTime.Value.ToString("dd/MM/yyyy HH:mm"),
                    Duration = (c.Duration / 60),
                    TaskId = c.TaskId,
                    Unit = c.Unit,
                    AverageTime = c.AverageTime,
                    TaskName = _context.tblTasks.FirstOrDefault(x => x.TaskId == c.TaskId).TaskName,
                    ProjectId = _context.tblTasks.FirstOrDefault(x => x.TaskId == c.TaskId).ProjectId,
                    ProjectName = _context.tblProjects.FirstOrDefault(v => v.ProjectId == _context.tblTasks.FirstOrDefault(x => x.TaskId == c.TaskId).ProjectId).ProjectName
                }));

            var list = from s in vm.WorkLogs
                       select s;

            var json = Json(new
            {
                data = list.ToList()
            }, JsonRequestBehavior.AllowGet);

            return json;
        }

        [Authorize]
        public ActionResult WorkLog()
        {

            //DateTime startDate = DateTime.Now.Date;
            //DateTime endDate = DateTime.Now.Date;

            //if (Request.QueryString["startDate"] != null)
            //    startDate = DateTime.ParseExact(Request.QueryString["startDate"].ToString(), "dd/MM/yyyy",
            //                           System.Globalization.CultureInfo.InvariantCulture);

            //if (Request.QueryString["endDate"] != null)
            //    endDate = DateTime.ParseExact(Request.QueryString["endDate"].ToString(), "dd/MM/yyyy",
            //                           System.Globalization.CultureInfo.InvariantCulture);

            WorkLogViewModel vm = new WorkLogViewModel();

            return View(vm);
        }
    }
}