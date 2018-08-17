using MOSSWORKLOG.Areas.Compliance.Models;
using MOSSWORKLOG.Areas.Document.Models;
using MOSSWORKLOG.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.Compliance.Controllers
{
    public class ComplianceController : Controller
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
        // GET: Compliance/Compliance
        public ActionResult Index()
        {
            ComplianceViewModel vm = new ComplianceViewModel();

            _context.Compliances.ToList().ForEach(x => vm.Compliances.Add(new ComplianceModel() {
                Id = x.Id,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                ComplianceDate = x.ComplianceDate,
                ContactEmail = x.ContactEmail,
                ContactName = x.ContactName,
                ContactPhone = x.ContactPhone,
                Descriptions = x.Descriptions,
                Status = x.Status,
                SubCategoryId = x.SubCategoryId,
                SubCategoryName = x.SubCategory.Name
            }));

            return View(vm);
        }

        public JsonResult GetSubCategories(int categoryId)
        {
            var subcategories = _context.ComplianceCategorys.Where(s => s.CategoryId == categoryId)
                .Select(s => new { key = s.Id, value = s.Name }).ToList();
            return Json(subcategories.OrderBy(z => z.key), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult ViewCompliance(int id = 0)
        {
            ComplianceModel vm = new ComplianceModel();

            if (id != 0)
            {
                var compliances = _context.Compliances.SingleOrDefault(x => x.Id == id);
                vm.Id = compliances.Id;
                vm.IsEdit = true;
                vm.CategoryId = compliances.CategoryId;
                vm.ComplianceDate = compliances.ComplianceDate;
                vm.ContactEmail = compliances.ContactEmail;
                vm.ContactName = compliances.ContactName;
                vm.ContactPhone = compliances.ContactPhone;
                vm.Descriptions = compliances.Descriptions;
                vm.Status = compliances.Status;
                vm.SubCategoryId = compliances.SubCategoryId;
            }
            else
            {
                vm.ComplianceDate = DateTime.Now.Date;
            }

            vm.AllSubCategory = new SelectList(_context.ComplianceCategorys.Where(x => x.Type == "S").ToList(), "Id", "Name");
            vm.AllCategory = new SelectList(_context.ComplianceCategorys.Where(x => x.Type == "C").ToList(), "Id", "Name");


            return PartialView("_AddCompliance", vm);
        }

        public ActionResult CreateCompliance(ComplianceModel vm)
        {
            MOSSWORKLOG.DATA.Compliance compliance = new MOSSWORKLOG.DATA.Compliance();

            if (vm.IsEdit)
                compliance = _context.Compliances.SingleOrDefault(x => x.Id == vm.Id);

            compliance.CategoryId = vm.CategoryId;
            compliance.SubCategoryId = vm.SubCategoryId;
            compliance.ComplianceDate = vm.ComplianceDate;
            compliance.ContactEmail = vm.ContactEmail;
            compliance.ContactName = vm.ContactName;
            compliance.ContactPhone = vm.ContactPhone;
            compliance.Descriptions = vm.Descriptions;

            if (!vm.IsEdit)
            {
                compliance.Status = DATA.Models.Enums.StatusEnum.Active; 
                _context.Compliances.Add(compliance);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", new { area = "Compliance" });
        }

        public ActionResult DeleteCompliance(int id)
        {
            var cat = _context.ComplianceCategorys.SingleOrDefault(x => x.Id == id);
            _context.ComplianceCategorys.Remove(cat);
            _context.SaveChanges();

            return RedirectToAction("Category", new { area = "Compliance" });
        }

        [Authorize]
        // Category
        public ActionResult Category()
        {
            CategoryViewModel vm = new CategoryViewModel();

            _context.ComplianceCategorys.Where(x => x.Type == "C").ToList().ForEach(x => vm.Categories.Add(new CategoryModel()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type
            }));

            return View(vm);
        }

        public ActionResult ViewCategory(int id = 0)
        {
            CategoryModel vm = new CategoryModel();

            if (id != 0)
            {
                var cat = _context.ComplianceCategorys.SingleOrDefault(x => x.Id == id);
                vm.Name = cat.Name;
                vm.Id = cat.Id;
                vm.IsEdit = true;
            }

            return PartialView("_AddCategory", vm);
        }

        public ActionResult CreateCategory(CategoryModel vm)
        {
            ComplianceCategory cat = new ComplianceCategory();

            if (vm.IsEdit)
                cat = _context.ComplianceCategorys.SingleOrDefault(x => x.Id == vm.Id);

            cat.Name = vm.Name;
            cat.Type = "C";

            if (!vm.IsEdit)
                _context.ComplianceCategorys.Add(cat);

            _context.SaveChanges();

            return RedirectToAction("Category", new { area = "Compliance" });
        }

        public ActionResult DeleteCategory(int id)
        {
            var cat = _context.ComplianceCategorys.SingleOrDefault(x => x.Id == id);
            _context.ComplianceCategorys.Remove(cat);
            _context.SaveChanges();

            return RedirectToAction("Category", new { area = "Compliance" });
        }

        // SubCategory
        [Authorize]
        public ActionResult SubCategory()
        {
            CategoryViewModel vm = new CategoryViewModel();

            _context.ComplianceCategorys.Where(x => x.Type == "S").ToList().ForEach(x => vm.Categories.Add(new CategoryModel()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                CatId = x.CategoryId,
                CatName = _context.ComplianceCategorys.SingleOrDefault(y => y.Id == x.CategoryId).Name
            }));

            return View(vm);
        }

        public ActionResult ViewSubCategory(int id = 0)
        {
            CategoryModel vm = new CategoryModel();

            if (id != 0)
            {
                var cat = _context.ComplianceCategorys.SingleOrDefault(x => x.Id == id);
                vm.Name = cat.Name;
                vm.Id = cat.Id;
                vm.CatId = cat.CategoryId;
                vm.IsEdit = true;
            }

            vm.AllCat = new SelectList(Extension.GetComplianceCategory(), "Id", "Name");

            return PartialView("_AddSubCategory", vm);
        }

        public ActionResult CreateSubCategory(CategoryModel vm)
        {
            ComplianceCategory cat = new ComplianceCategory();

            if (vm.IsEdit)
                cat = _context.ComplianceCategorys.SingleOrDefault(x => x.Id == vm.Id);

            cat.Name = vm.Name;
            cat.Type = "S";
            cat.CategoryId = vm.CatId;

            if (!vm.IsEdit)
                _context.ComplianceCategorys.Add(cat);

            _context.SaveChanges();

            return RedirectToAction("SubCategory", new { area = "Compliance" });
        }

        public ActionResult DeleteSubCategory(int id)
        {
            var cat = _context.ComplianceCategorys.SingleOrDefault(x => x.Id == id);
            _context.ComplianceCategorys.Remove(cat);
            _context.SaveChanges();

            return RedirectToAction("SubCategory", new { area = "Compliance" });
        }
    }
}