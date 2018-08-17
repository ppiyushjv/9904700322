using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.Areas.User.Models;
using MOSSWORKLOG.DATA;

namespace MOSSWORKLOG.Areas.User.Controllers
{
    public class UserController : Controller
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
        // GET: User/User
        [Authorize]
        public ActionResult Index()
        {
            UserViewModel vm = new UserViewModel();

            _context.tblUsers.ToList().ForEach(c => vm.Users.Add(new UserModel()
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
            return View(vm);
        }
        public ActionResult ViewUser(int id = 0)
        {
            UserModel vm = new UserModel();
            vm.UserId = id;
            vm.IsEdit = id != 0 ? true : false;

            if (vm.IsEdit)
            {
                var user = _context.tblUsers.SingleOrDefault(x => x.UserId == id);
                vm.Email = user.email;
                vm.FullName = user.FullName;
                vm.Mobile = user.Mobile;
                vm.Password = user.Password;
                vm.RoleId = user.RoleId;
                vm.UserId = user.UserId;
                vm.UserName = user.UserName;
                vm.ManagerId = user.ManagerId;
                vm.SupervisorId = user.SupervisorId;
            }

            vm.AllRole = new SelectList(_context.tblRoles.ToList(), "RoleId", "RoleDesc");
            vm.AllManager = new SelectList(_context.tblUsers.Where(x=>x.RoleId == 3).ToList(), "UserId", "FullName");
            vm.AllSupervisor = new SelectList(_context.tblUsers.Where(x => x.RoleId == 4).ToList(), "UserId", "FullName");

            return PartialView("_AddUser", vm);
        }
        [HttpPost]
        public ActionResult CreateUser(UserModel vm)
        {
            tblUser user = new tblUser();

            if (vm.IsEdit)
                user = _context.tblUsers.SingleOrDefault(x => x.UserId == vm.UserId);

            user.UserName = vm.UserName;
            user.FullName = vm.FullName;
            user.Mobile = vm.Mobile;
            user.email = vm.Email;
            user.Password = vm.Password;
            user.RoleId = vm.RoleId;
            user.SupervisorId = vm.SupervisorId; ;
            user.ManagerId = vm.ManagerId;

            if (!vm.IsEdit)
                _context.tblUsers.Add(user);

            _context.SaveChanges();

            return RedirectToAction("Index", new { area = "User" });
        }
        public ActionResult DeleteUser(int id)
        {
            var user = _context.tblUsers.SingleOrDefault(x => x.UserId == id);
            _context.tblUsers.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index", new { area = "User" });
        }

        public ActionResult CheckExistingUser(string UserName, string EditName)
        {
            bool ifExist = false;
            try
            {
                if (UserName == EditName)
                    ifExist = false;
                else
                    ifExist = _context.tblUsers.Any(z => z.UserName == UserName);
                return Json(!ifExist, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
    }
}