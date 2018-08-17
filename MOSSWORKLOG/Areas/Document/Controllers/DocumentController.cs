using MOSSWORKLOG.Areas.Document.Models;
using MOSSWORKLOG.Areas.Project.Models;
using MOSSWORKLOG.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.Document.Controllers
{
    public class DocumentController : Controller
    {
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
        // GET: Document/Document

        [Authorize]
        public ActionResult Index()
        {
            var cat = _context.tblCategories.ToList();

            DocumentViewModel vm = new DocumentViewModel();
            _context.tblDocuments.ToList().ForEach(x => vm.Documents.Add(new DocumentModel()
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId,
                SubCategoryId = x.SubCategoryId,
                Descriptions = x.Descriptions,
                DocumentPath = x.DocumentPath,
                CategoryName = x.MainCategory.Name,
                SubCategoryName = x.SubCategory.Name,
            }));

            foreach (var doc in vm.Documents)
            {
                var keys = (from keyword in _context.tblDocumentKeyWords
                            join map in _context.tblDocumentKeyWordMaps on keyword.Id equals map.KeyWordId
                            where map.DocumentId == doc.Id
                            select new { keyword.KeyWordName }).ToArray();

                if (keys.Count() != 0)
                    doc.KeywordList = String.Join(",", keys.Select(x=>x.KeyWordName));
                else
                    doc.KeywordList = "";

            }
            return View(vm);
        }

        public ActionResult ViewDocument(int id = 0)
        {
            DocumentModel vm = new DocumentModel();

            if (id != 0)
            {
                var doc = _context.tblDocuments.SingleOrDefault(x => x.Id == id);
                vm.IsEdit = true;
                vm.Id = doc.Id;
                vm.Name = doc.Name;
                vm.CategoryId = doc.CategoryId;
                vm.SubCategoryId = doc.SubCategoryId;
                vm.DocumentPath = doc.DocumentPath;
                vm.Descriptions = doc.Descriptions;
                vm.Keywords = _context.tblDocumentKeyWordMaps.Where(x => x.DocumentId == doc.Id).Select(s => s.KeyWordId).ToArray();

            }
            vm.AllSubCategory = new SelectList(Extension.GetSubCategory(), "Id", "Name");
            vm.AllCategory = new SelectList(Extension.GetCategory(), "Id", "Name");
            vm.AllKeyword = new SelectList(Extension.GetKeyWord(), "Id", "KeyWordName");

            return PartialView("_AddDocument", vm);
        }

        public ActionResult CreateDocument(DocumentModel vm)
        {
            tblDocument doc = new tblDocument();

            if (vm.IsEdit)
                doc = _context.tblDocuments.SingleOrDefault(x => x.Id == vm.Id);

            doc.Name = vm.Name;
            doc.SubCategoryId = vm.SubCategoryId;
            doc.CategoryId = vm.CategoryId;
            doc.Descriptions = vm.Descriptions;
            doc.DocumentPath = vm.DocumentPath;

            if (!vm.IsEdit)
                _context.tblDocuments.Add(doc);

            _context.SaveChanges();

            var exstingkeyword = _context.tblDocumentKeyWordMaps.Where(x => x.DocumentId == doc.Id);
            if (exstingkeyword.Count() != 0)
                _context.tblDocumentKeyWordMaps.RemoveRange(exstingkeyword);

            vm.Keywords.ToList().ForEach(x => _context.tblDocumentKeyWordMaps.Add(new tblDocumentKeyWordMap()
            {
                DocumentId = doc.Id,
                KeyWordId = x
            }));
            _context.SaveChanges();

            return RedirectToAction("Index", new { area = "Document" });
        }

        public ActionResult DeleteDocument(int id)
        {
            var doc = _context.tblDocuments.SingleOrDefault(x => x.Id == id);
            _context.tblDocuments.Remove(doc);
            _context.SaveChanges();

            return RedirectToAction("Index", new { area = "Document" });
        }

        public JsonResult GetSubCategories(int categoryId)
        {
            var subcategories = _context.tblCategories.Where(s => s.CatId == categoryId)
                .Select(s => new { key = s.Id, value = s.Name }).ToList();
            return Json(subcategories.OrderBy(z => z.key),JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        // Category
        public ActionResult Category()
        {
            CategoryViewModel vm = new CategoryViewModel();

            _context.tblCategories.Where(x => x.Type == "C").ToList().ForEach(x => vm.Categories.Add(new CategoryModel()
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
                var cat = _context.tblCategories.SingleOrDefault(x => x.Id == id);
                vm.Name = cat.Name;
                vm.Id = cat.Id;
                vm.IsEdit = true;
            }

            return PartialView("_AddCategory", vm);
        }

        public ActionResult CreateCategory(CategoryModel vm)
        {
            tblCategory cat = new tblCategory();

            if (vm.IsEdit)
                cat = _context.tblCategories.SingleOrDefault(x => x.Id == vm.Id);

            cat.Name = vm.Name;
            cat.Type = "C";

            if (!vm.IsEdit)
                _context.tblCategories.Add(cat);

            _context.SaveChanges();

            return RedirectToAction("Category", new { area = "Document" });
        }

        public ActionResult DeleteCategory(int id)
        {
            var cat = _context.tblCategories.SingleOrDefault(x => x.Id == id);
            _context.tblCategories.Remove(cat);
            _context.SaveChanges();

            return RedirectToAction("Category", new { area = "Document" });
        }

        // SubCategory
        [Authorize]
        public ActionResult SubCategory()
        {
            CategoryViewModel vm = new CategoryViewModel();

            _context.tblCategories.Where(x => x.Type == "S").ToList().ForEach(x => vm.Categories.Add(new CategoryModel()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                CatId = x.CatId,
                CatName = _context.tblCategories.SingleOrDefault(y => y.Id == x.CatId).Name
            }));

            return View(vm);
        }

        public ActionResult ViewSubCategory(int id = 0)
        {
            CategoryModel vm = new CategoryModel();

            if (id != 0)
            {
                var cat = _context.tblCategories.SingleOrDefault(x => x.Id == id);
                vm.Name = cat.Name;
                vm.Id = cat.Id;
                vm.CatId = cat.CatId;
                vm.IsEdit = true;
            }

            vm.AllCat = new SelectList(Extension.GetCategory(), "Id", "Name");

            return PartialView("_AddSubCategory", vm);
        }

        public ActionResult CreateSubCategory(CategoryModel vm)
        {
            tblCategory cat = new tblCategory();

            if (vm.IsEdit)
                cat = _context.tblCategories.SingleOrDefault(x => x.Id == vm.Id);

            cat.Name = vm.Name;
            cat.Type = "S";
            cat.CatId = vm.CatId;

            if (!vm.IsEdit)
                _context.tblCategories.Add(cat);

            _context.SaveChanges();

            return RedirectToAction("SubCategory", new { area = "Document" });
        }

        public ActionResult DeleteSubCategory(int id)
        {
            var cat = _context.tblCategories.SingleOrDefault(x => x.Id == id);
            _context.tblCategories.Remove(cat);
            _context.SaveChanges();

            return RedirectToAction("SubCategory", new { area = "Document" });
        }

        // KeyWord
        [Authorize]
        public ActionResult KeyWord()
        {
            KeywordViewModel vm = new KeywordViewModel();

            _context.tblDocumentKeyWords.ToList().ForEach(x => vm.KeyWords.Add(new KeywordModel()
            {
                Id = x.Id,
                KeyWordName = x.KeyWordName
            }));

            return View(vm);
        }

        public ActionResult ViewKeyWord(int id = 0)
        {
            KeywordModel vm = new KeywordModel();

            if (id != 0)
            {
                var keyword = _context.tblDocumentKeyWords.SingleOrDefault(x => x.Id == id);
                vm.KeyWordName = keyword.KeyWordName;
                vm.Id = keyword.Id;
                vm.IsEdit = true;
            }

            return PartialView("_AddKeyword", vm);
        }

        public ActionResult CreateKeyWord(KeywordModel vm)
        {
            tblDocumentKeyWord keyword = new tblDocumentKeyWord();

            if (vm.IsEdit)
                keyword = _context.tblDocumentKeyWords.SingleOrDefault(x => x.Id == vm.Id);

            keyword.KeyWordName = vm.KeyWordName;
            keyword.Id = vm.Id;

            if (!vm.IsEdit)
                _context.tblDocumentKeyWords.Add(keyword);

            _context.SaveChanges();

            return RedirectToAction("Keyword", new { area = "Document" });
        }

        public ActionResult DeleteKeyWord(int id)
        {
            var keyword = _context.tblDocumentKeyWords.SingleOrDefault(x => x.Id == id);
            _context.tblDocumentKeyWords.Remove(keyword);
            _context.SaveChanges();

            return RedirectToAction("Keyword", new { area = "Document" });
        }


    }
}