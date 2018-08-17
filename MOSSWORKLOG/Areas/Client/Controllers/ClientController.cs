using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.Areas.Client.Models;
using MOSSWORKLOG.DATA;

namespace MOSSWORKLOG.Areas.Client.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client/Client
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();

        [Authorize]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {
            ClientViewModel vm = new ClientViewModel();
            _context.tblClients.ToList().ForEach(c => vm.Clients.Add(new ClientModel()
            {
                ShortName = c.ShortName,
                ClientId = c.ClientId,
                ClientName = c.ClientName,
                Email = c.Email,
                Contact = c.Contact
            }));


            return View(vm);
        }
        public ActionResult ViewClient(int id = 0)
        {

            ClientModel vm = new ClientModel();
            vm.ClientId = id;
            vm.IsEdit = id != 0 ? true : false;

            if (vm.IsEdit)
            {
                var client = _context.tblClients.SingleOrDefault(x => x.ClientId == id);
                vm.ClientName = client.ClientName;
                vm.ShortName = client.ShortName;
                vm.Email = client.Email;
                vm.Contact = client.Contact;
            }
            return PartialView("_AddClient", vm);
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult CreateClient(ClientModel vm)
        {
            tblClient client = new tblClient();

            if (vm.IsEdit)
                client = _context.tblClients.SingleOrDefault(x => x.ClientId == vm.ClientId);

            client.ClientName = vm.ClientName;
            client.ShortName = vm.ShortName;
            client.Contact = vm.Contact;
            client.Email = vm.Email;

            if (!vm.IsEdit)
                _context.tblClients.Add(client);

            _context.SaveChanges();

            return RedirectToAction("Index", new { area = "Client" });
        }
        public ActionResult DeleteClient(int id)
        {
            var client = _context.tblClients.SingleOrDefault(x => x.ClientId == id);
            _context.tblClients.Remove(client);
            _context.SaveChanges();

            return RedirectToAction("Index", new { area = "Client" });
        }
        [Authorize(Roles = "1")]
        public ActionResult ViewClientUser(int id)
        {
            ClientUserModel vm = new ClientUserModel();
            vm.ClientId = id;
            vm.AllUsers = new SelectList((from user in _context.tblUsers
                                          join role in _context.tblRoles on user.RoleId equals role.RoleId
                                          where role.RoleId == 1  || role.RoleId == 3
                                          select new { UserId = user.UserId.ToString(), user.FullName, role.RoleDesc }).ToList(), "UserId", "FullName", "RoleDesc ",0);

            vm.UserSelected = _context.tblUserRoleAssigns.Where(x => x.ClientId == id).ToList().Select(e => e.AssignUserId.ToString().Trim()).ToArray();
            return PartialView("_AddClientUser", vm);
        }
        [HttpPost]
        public ActionResult CreateClientUser(ClientUserModel vm)
        {
            var list = _context.tblUserRoleAssigns.Where(x => x.ClientId == vm.ClientId);
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
                    roleassign.ClientId = vm.ClientId;
                    roleassign.AssignUserId = userId;
                    roleassign.TaskId = 0;
                    roleassign.ProjectId = 0;
                    _context.tblUserRoleAssigns.Add(roleassign);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index", new { area = "Client" });
        }
    }
}