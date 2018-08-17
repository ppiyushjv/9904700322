using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.DATA;
using MOSSWORKLOG.Areas.Task.Models;
using System.Globalization;

namespace MOSSWORKLOG.Areas.Task.Controllers
{
    public class TaskController : Controller
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
        // GET: Project/Project
        [Authorize]
        public ActionResult Index()
        {
            TaskViewModel vm = new TaskViewModel();
            Extension.GetTask().ForEach(c => vm.Tasks.Add(new TaskModel()
            {
                TaskDescription = c.TaskDescription,
                TaskName = c.TaskName,
                TaskId = c.TaskId,
                ProjectId = c.ProjectId,
                ProjectName = _context.tblProjects.SingleOrDefault(x=>x.ProjectId == c.ProjectId).ProjectName,
                CreatedOn = c.CreatedOn
            }));
            return View(vm);
        }
        public ActionResult ViewTask(int id = 0)
        {
            TaskModel vm = new TaskModel();
            vm.TaskId = id;
            vm.IsEdit = id != 0 ? true : false;
            vm.AllProject = new SelectList(Extension.GetProejcts(), "ProjectId", "ProjectName");
            vm.AllTaskFrequency = new SelectList(new List<string>() { "OneTime", "Daily", "Weekly", "Monthly" });
            vm.AllTaskTickWeekly = new SelectList(new List<string>() { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });

            List<string> month = new List<string>();
            for (int i = 0; i < 31; i++)
            {
                month.Add((i + 1).ToString());
            }
            vm.AllTaskTickMonthly = new SelectList(month);

            if (vm.IsEdit)
            {
                var tasks = _context.tblTasks.SingleOrDefault(x => x.TaskId == id);
                vm.TaskId = tasks.TaskId;
                vm.ProjectId = tasks.ProjectId;
                vm.TaskDescription = tasks.TaskDescription;
                vm.TaskName = tasks.TaskName;
                vm.TaskFrequency = tasks.TaskFrequency;
                vm.TaskTick = tasks.TaskTick;
                vm.TaskStartDate = tasks.TaskStartDate.HasValue ? tasks.TaskStartDate.Value.ToString("dd/MM/yyyy") : "";
                vm.TaskEndDate = tasks.TaskEndDate.HasValue ? tasks.TaskEndDate.Value.ToString("dd/MM/yyyy") : "" ;
                vm.Email = tasks.Email;
                vm.TaskTickselect = _context.tblTaskTicks.Where(x => x.TaskId == vm.TaskId).ToList().Select(e => e.TaskTick.ToString().Trim()).ToArray();
            }

            return PartialView("_AddTask", vm);
        }
        [HttpPost]
        public ActionResult CreateTask(TaskModel vm)
        {
            int UserId = Convert.ToUInt16((this.User.Identity as System.Security.Claims.ClaimsIdentity).FindFirst("UserId").Value);

            tblTask task = new tblTask();

            if (vm.IsEdit)
                task = _context.tblTasks.SingleOrDefault(x => x.TaskId== vm.TaskId);

            task.TaskName = vm.TaskName;
            task.TaskDescription = vm.TaskDescription;
            task.ProjectId = vm.ProjectId;
            task.ClientId = _context.tblProjects.SingleOrDefault(x => x.ProjectId == vm.ProjectId).ClientId;
            task.TaskDescription = vm.TaskDescription;

            if (!string.IsNullOrEmpty(vm.TaskStartDate.ToString()))
                task.TaskStartDate = DateTime.ParseExact(vm.TaskStartDate.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (!string.IsNullOrEmpty(vm.TaskEndDate.ToString()))
                task.TaskEndDate = DateTime.ParseExact(vm.TaskEndDate.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            task.TaskFrequency = vm.TaskFrequency;
            task.TaskName = vm.TaskName;
            task.TaskTick = vm.TaskTick;
            task.Email = vm.Email;

            if (!vm.IsEdit)
            {
                task.CreatedOn = DateTime.Now;
                task.CreatedBy = UserId;
                _context.tblTasks.Add(task);
            }
            else
            {
                var taskTick = _context.tblTaskTicks.Where(x => x.TaskId == vm.TaskId);
                _context.tblTaskTicks.RemoveRange(taskTick);

                task.UpdatedOn = DateTime.Now;
                task.UpdatedBy = UserId;

            }
            _context.SaveChanges();

            if (vm.TaskTickselect != null)
            {
                vm.TaskTickselect.ToList().ForEach(t => _context.tblTaskTicks.Add(new tblTaskTick()
                {
                    TaskId = task.TaskId,
                    TaskTick = t.ToString()
                }));
            }
            _context.SaveChanges();


            if (!User.IsInRole("1"))
            {
                int userId = Extension.GetUserId();
                var user = _context.tblUserRoleAssigns.SingleOrDefault(x => x.ProjectId == 0 && x.AssignUserId == userId && x.ClientId == 0 && x.TaskId == vm.TaskId);
                if (user == null)
                {
                    user = new tblUserRoleAssign();
                    //user.ClientId = 0;
                    //user.ProjectId = 0;
                    user.TaskId = vm.TaskId;
                    user.AssignUserId = Extension.GetUserId();
                    _context.tblUserRoleAssigns.Add(user);
                    _context.SaveChanges();
                }
            }


            return RedirectToAction("Index", new { area = "Task" });
        }
        public ActionResult DeleteTask(int id)
        {
            var task = _context.tblTasks.SingleOrDefault(x => x.TaskId == id);
            _context.tblTasks.Remove(task);
            _context.SaveChanges();

            return RedirectToAction("Index", new { area = "Task" });
        }
        public ActionResult ViewTaskUser(int id)
        {
            TaskUserModel vm = new TaskUserModel();
            vm.TaskId = id;
            vm.AllUsers = new SelectList((from user in _context.tblUsers
                                          join role in _context.tblRoles on user.RoleId equals role.RoleId
                                          select new { UserId = user.UserId.ToString(), UserName = user.FullName, role.RoleDesc }).ToList(), "UserId", "UserName", "RoleDesc ", 0);

            vm.UserSelected = _context.tblUserRoleAssigns.Where(x => x.TaskId == id).ToList().Select(e => e.AssignUserId.ToString().Trim()).ToArray();
            return PartialView("_AddTaskUser", vm);
        }
        [HttpPost]
        public ActionResult CreateTaskUser(TaskUserModel vm)
        {
            var list = _context.tblUserRoleAssigns.Where(x => x.TaskId == vm.TaskId);
            if (list != null)
            {
                _context.tblUserRoleAssigns.RemoveRange(list);
                _context.SaveChanges();
            }

            if (vm.UserSelected != null)
            {
                foreach (var user in vm.UserSelected)
                {
                    int userId = Convert.ToInt16(user);
                    var roleassign = new tblUserRoleAssign();
                    //roleassign.ClientId = 0;
                    //roleassign.ProjectId = 0;
                    roleassign.TaskId = vm.TaskId;
                    roleassign.AssignUserId = userId;
                    _context.tblUserRoleAssigns.Add(roleassign);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index", new { area = "Task" });
        }
    }
}
