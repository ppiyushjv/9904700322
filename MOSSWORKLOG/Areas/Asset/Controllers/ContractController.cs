using MOSSWORKLOG.Areas.Asset.Models;
using MOSSWORKLOG.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.Asset.Controllers
{
    public class ContractController : Controller
    {

        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();

        public ActionResult Index()
        {
            ContractViewModel vm = new ContractViewModel();
            _context.tblContracts.ToList().ForEach(c => vm.Contracts.Add(new ContractModel()
            {
                ContractId = c.ContractId,
                VendorId = c.VenderId,
                VendorName = c.Vender.VenderName,
                Asset = c.Asset,
                Remarks = c.Remarks,
                Description = c.Description,
                StartDate = c.StartDate,
                EndDate = c.EndDate
            }));


            return View(vm);
        }

        // GET: Asset/Contract
        public ActionResult ViewContract(int id = 0)
        {

            ContractModel vm = new ContractModel();
            vm.IsEdit = id != 0 ? true : false;

            if (vm.IsEdit)
            {
                var contract = _context.tblContracts.SingleOrDefault(x => x.ContractId== id);
                vm.ContractId = contract.ContractId;
                vm.VendorId = contract.VenderId;
                vm.Remarks = contract.Remarks;
                vm.Description = contract.Description;
                vm.StartDate= contract.StartDate;
                vm.EndDate = contract.EndDate;
                vm.Asset = contract.Asset;
            }

            return PartialView("_AddContract", vm);
        }

        public ActionResult CreateContract(ContractModel vm)
        {
            tblContract contract = new tblContract();

            if (vm.IsEdit)
                contract = _context.tblContracts.SingleOrDefault(x => x.ContractId == vm.ContractId);

            contract.VenderId = vm.VendorId;
            contract.Remarks = vm.Remarks;
            contract.Description = vm.Description;
            contract.StartDate = vm.StartDate;
            contract.EndDate = vm.EndDate;
            contract.Asset = vm.Asset;

            if (!vm.IsEdit)
                _context.tblContracts.Add(contract);

            _context.SaveChanges();

            return RedirectToAction("Index", "Contract", new { area = "Asset" });
        }

        public ActionResult DeleteContract(int id)
        {
            var contract = _context.tblContracts.SingleOrDefault(x => x.VenderId == id);
            _context.tblContracts.Remove(contract);
            _context.SaveChanges();

            return RedirectToAction("Index", "Contract", new { area = "Asset" });
        }
    }
}