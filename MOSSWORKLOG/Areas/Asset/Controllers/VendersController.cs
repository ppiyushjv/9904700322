using MOSSWORKLOG.Areas.Asset.Models;
using MOSSWORKLOG.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.Asset.Controllers
{
    public class VendersController : Controller
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
        // GET: Asset/Venders
        public ActionResult Index()
        {
            VenderViewModel vm = new VenderViewModel();
            _context.tblVender.ToList().ForEach(c => vm.Venders.Add(new VenderModel()
            {
                VenderName = c.VenderName,
                VenderId = c.VenderId,
                Contact = c.Contact,
                Email = c.Email,
                VenderShortName = c.VenderShortName
            }));


            return View(vm);
        }

        public ActionResult ViewVender(int id = 0)
        {

            VenderModel vm = new VenderModel();
            vm.IsEdit = id != 0 ? true : false;

            if (vm.IsEdit)
            {
                var vender = _context.tblVender.SingleOrDefault(x => x.VenderId == id);
                vm.VenderName = vender.VenderName;
                vm.VenderShortName = vender.VenderShortName;
                vm.Email = vender.Email;
                vm.Contact = vender.Contact;
                vm.VenderId = vender.VenderId;
            }

            return PartialView("_AddVender", vm);
        }

        public ActionResult CreateVender(VenderModel vm)
        {
            tblVender vender = new tblVender();

            if (vm.IsEdit)
                vender = _context.tblVender.SingleOrDefault(x => x.VenderId == vm.VenderId);

            vender.VenderName = vm.VenderName;
            vender.VenderShortName = vm.VenderShortName;
            vender.Contact = vm.Contact;
            vender.Email = vm.Email;

            if (!vm.IsEdit)
                _context.tblVender.Add(vender);

            _context.SaveChanges();

            return RedirectToAction("Index", "Venders", new { area = "Asset" });
        }

        public ActionResult DeleteVender(int id)
        {
            var vender = _context.tblVender.SingleOrDefault(x => x.VenderId == id);
            _context.tblVender.Remove(vender);
            _context.SaveChanges();

            return RedirectToAction("Index", "Venders", new { area = "Asset" });
        }
        
    }
}