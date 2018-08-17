using MOSSWORKLOG.Models;
using MOSSWORKLOG.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Net;
using Microsoft.Owin.Security;

namespace MOSSWORKLOG.Controllers
{
    public class HomeController : Controller
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();
            vm.PorjectCount = Extension.GetProejcts().Count();
            vm.ClientCount = Extension.GetClient().Count();
            vm.TaskCount = Extension.GetTask().Count();
            vm.UserCount = _context.tblUsers.Count();
            return View(vm);
        }

        public ActionResult GetMenu(string MainId)
        {
            MenuModel vm = new MenuModel();
            vm.Menu = _context.tblMenus.Where(x=>x.MainId==MainId).OrderBy(x=>x.SerialNo).ToList();
            return PartialView("_Menu", vm);
        }

    }
}