using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.Areas.Project.Models;
using MOSSWORKLOG.DATA;

namespace MOSSWORKLOG.Areas.Project.Controllers
{
    public class ProjectController : Controller
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
        // GET: Project/Project
        [Authorize]
        public ActionResult Index()
        {
            
            ProjectViewModel vm = new ProjectViewModel();
            Extension.GetProejcts().ForEach(c => vm.Projects.Add(new ProjectModel()
            {
                ProjectName = c.ProjectName,
                ProjectId = c.ProjectId,
                ClientId = c.ClientId,
                ClientName = _context.tblClients.SingleOrDefault(x => x.ClientId == c.ClientId).ClientName,
                Description = c.Description,
                Email = c.Email
            }));
            return View(vm);
        }
        public ActionResult ViewProject(int id = 0)
        {
            ProjectModel vm = new ProjectModel();
            vm.ProjectId = id;
            vm.IsEdit = id != 0 ? true : false;

            if (vm.IsEdit)
            {
                var project = _context.tblProjects.SingleOrDefault(x => x.ProjectId == id);
                vm.ClientName = _context.tblClients.SingleOrDefault(x => x.ClientId == project.ClientId).ClientName;
                vm.ClientId = project.ClientId;
                vm.ProjectName = project.ProjectName;
                vm.Description = project.Description;
                vm.Email = project.Email;
            }

            vm.AllClient = new SelectList(Extension.GetClient(), "ClientId", "ClientName");

            return PartialView("_AddProject", vm);
        }
        [HttpPost]
        public ActionResult CreateProject(ProjectModel vm)
        {
            tblProject Project = new tblProject();

            if (vm.IsEdit)
                Project = _context.tblProjects.SingleOrDefault(x => x.ProjectId == vm.ProjectId);

            Project.ClientId = vm.ClientId;
            Project.ProjectName = vm.ProjectName;
            Project.Description = vm.Description;
            Project.Email = vm.Email;

            if (!vm.IsEdit)
                _context.tblProjects.Add(Project);

            _context.SaveChanges();

            if (!User.IsInRole("1"))
            {
                int userId = Extension.GetUserId();
                var user = _context.tblUserRoleAssigns.SingleOrDefault(x => x.ProjectId == vm.ProjectId && x.AssignUserId == userId && x.ClientId == 0 && x.TaskId == 0);
                if (user == null)
                {
                    user = new tblUserRoleAssign();
                    //user.ClientId = 0;
                    user.ProjectId = Project.ProjectId;
                    //user.TaskId = 0;
                    user.AssignUserId = Extension.GetUserId();
                    _context.tblUserRoleAssigns.Add(user);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index", new { area = "Project" });
        }
        public ActionResult DeleteProject(int id)
        {
            var project = _context.tblProjects.SingleOrDefault(x => x.ProjectId == id);
            _context.tblProjects.Remove(project);
            _context.SaveChanges();

            return RedirectToAction("Index", new { area = "Project" });
        }
        public ActionResult ViewProjectUser(int id)
        {
            ProjectUserModel vm = new ProjectUserModel();
            vm.ProjectId = id;
            vm.AllUsers = new SelectList((from user in _context.tblUsers
                                          join role in _context.tblRoles on user.RoleId equals role.RoleId
                                          where role.RoleId == 1 || role.RoleId == 3 || role.RoleId == 4
                                          select new { UserId = user.UserId.ToString(), UserName = user.FullName, role.RoleDesc }).ToList(), "UserId", "UserName", "RoleDesc ", 0);

            vm.UserSelected = _context.tblUserRoleAssigns.Where(x => x.ProjectId == id).ToList().Select(e => e.AssignUserId.ToString().Trim()).ToArray();
            return PartialView("_AddProjectUser", vm);
        }
        [HttpPost]
        public ActionResult CreateProjectUser(ProjectUserModel vm)
        {
            var list = _context.tblUserRoleAssigns.Where(x => x.ProjectId == vm.ProjectId);
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
                    //roleassign.TaskId = 0;
                    roleassign.AssignUserId = userId;
                    roleassign.ProjectId = vm.ProjectId;
                    _context.tblUserRoleAssigns.Add(roleassign);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index", new { area = "Project" });
        }

    }
}