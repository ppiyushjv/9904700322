using MOSSWORKLOG.Areas.ChangeManagement.Models;
using MOSSWORKLOG.DATA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.ChangeManagement.Controllers
{
    public class ChangeManagementController : Controller
    {
        // GET: ChangeManagement/ChangeManagement
        public MossWorkLogDbEntities _context = new MossWorkLogDbEntities();

        [Authorize]
        public ActionResult Index()
        {
            ChangeManagementViewModel vm = new ChangeManagementViewModel();

            _context.ChangeManagementDetails.ToList().ForEach(x => 
                    vm.ChangeManagementModels.Add(
                    new ChangeManagementModel() { 
                     Id = x.Id,
                     AssignTo = x.AssignTo,
                     AssingUserName = x.AssingUserName,
                     ChangeSubType = x.ChangeSubType,
                     ChangeSubTypeId = x.ChangeSubTypeId,
                     ChangeType = x.ChangeType,
                     ChangeTypeId = x.ChangeTypeId,
                     Client = x.Client,
                     ClientId = x.ClientId,
                     CloseBy = x.CloseBy,
                     CloseByUserName = x.CloseByUserName,
                     CloseDate = x.CloseDate,
                     CreateBy = x.CreateBy,
                     CreateDate = x.CreateDate,
                     Description =x.Description,
                     DueDate = x.DueDate,
                     Priority = x.Priority,
                     Project = x.Project,
                     ProjectId = x.ProjectId,
                     ResolveBy = x.ResolveBy,
                     ResolveByUserName = x.ResolveByUserName,
                     ResolveDate = x.ResolveDate,
                     StepToReproduce = x.StepToReproduce,
                     Status = x.Status,
                     Title = x.Title,
                     CreateByUserName = x.CreateByUserName,
                     IsEdit = false
                }));

            return View(vm);
        }

        [Authorize]
        public ActionResult AddTicket(int id=0)
        {
            ChangeManagementModel vm = new ChangeManagementModel();

            if (id != 0)
            {
                var c = _context.ChangeManagementDetails.SingleOrDefault(x => x.Id == id);
                vm = new ChangeManagementModel()
                {
                    Id = c.Id,
                    AssignTo = c.AssignTo,
                    ChangeSubTypeId = c.ChangeSubTypeId,
                    ChangeTypeId = c.ChangeTypeId,
                    ClientId = c.ClientId,
                    CloseBy = c.CloseBy,
                    CloseDate = c.CloseDate,
                    CreateBy = c.CreateBy,
                    CreateDate = c.CreateDate,
                    Description = c.Description,
                    DueDate = c.DueDate,
                    Priority = c.Priority,
                    ProjectId = c.ProjectId,
                    ResolveBy = c.ResolveBy,
                    ResolveDate = c.ResolveDate,
                    StepToReproduce = c.StepToReproduce,
                    Status = c.Status,
                    Title = c.Title,
                    IsEdit = true
                };



                _context.ChangeManagementComments
                    .Where(x => x.ChangeManagementId == id)
                    .ToList().
                    ForEach(cm => vm.Comments.Add(new ChangeManagementCommentModel()
                    {
                        Id = cm.Id,
                        ChangeManagementId = cm.ChangeManagementId,
                        ChangeManagement = cm.ChangeManagement,
                        Comment = cm.Comment
                    }));

                _context.ChangeManagementAttachments
                    .Where(x => x.ChangeManagementId == id)
                    .ToList().
                    ForEach(cm => vm.Attachments.Add(new ChangeManagementAttachmentModel()
                    {
                        Id = cm.Id,
                        ChangeManagementId = cm.ChangeManagementId,
                        ChangeManagement = cm.ChangeManagement,
                        AttachmentPath = cm.AttachmentPath,
                        OriginalName = cm.OriginalName
                    }));

            }
            else
                vm.DueDate = DateTime.Now.Date;

            return View(vm);
        }

        public ActionResult CreateTicket(ChangeManagementModel vm)
        {
            var cm = new ChangeManagementDetail();

            if (vm.IsEdit)
                cm = _context.ChangeManagementDetails.SingleOrDefault(x => x.Id == vm.Id);

            cm.Id = vm.Id;
            cm.AssignTo = vm.AssignTo;
            cm.ChangeSubTypeId = vm.ChangeSubTypeId;
            cm.ChangeTypeId = vm.ChangeTypeId;
            cm.ClientId = vm.ClientId;
            cm.CloseBy = vm.CloseBy;
            cm.CloseDate = vm.CloseDate;
            cm.CreateBy = vm.CreateBy;
            cm.CreateDate = vm.CreateDate;
            cm.Description = vm.Description;
            cm.DueDate = vm.DueDate;
            cm.Priority = vm.Priority;
            cm.ProjectId = vm.ProjectId;
            cm.ResolveBy = vm.ResolveBy;
            cm.ResolveDate = vm.ResolveDate;
            cm.StepToReproduce = vm.StepToReproduce;
            cm.Status = vm.Status;
            cm.Title = vm.Title;

            if (!vm.IsEdit)
            {
                cm.CreateDate = DateTime.Now;
                cm.CreateBy = Extension.GetUserId();
                _context.ChangeManagementDetails.Add(cm);
            }

            _context.SaveChanges();


            if (vm.IsEdit)
            {
                var comments = _context.ChangeManagementComments.Where(x => x.ChangeManagementId == cm.Id);
                _context.ChangeManagementComments.RemoveRange(comments);

                var ats = _context.ChangeManagementAttachments.Where(x => x.ChangeManagementId == cm.Id);
                _context.ChangeManagementAttachments.RemoveRange(ats);

            }

            foreach (var commet in vm.Comments)
            {
                ChangeManagementComment c = new ChangeManagementComment();
                c.Comment = commet.Comment;
                c.CreatedAt = DateTime.Now;
                c.CreatedBy = Extension.GetUserId();
                c.ChangeManagementId = cm.Id;
                _context.ChangeManagementComments.Add(c);
            }

            foreach (var attachment in vm.Attachments)
            {
                ChangeManagementAttachment a = new ChangeManagementAttachment();
                a.ChangeManagementId = cm.Id;
                a.OriginalName = attachment.OriginalName;
                a.AttachmentPath = attachment.AttachmentPath;
                a.CreatedAt = DateTime.Now;
                a.CreatedBy = Extension.GetUserId();
                _context.ChangeManagementAttachments.Add(a);
            }

            _context.SaveChanges();



            return RedirectToAction("Index", "ChangeManagement");
        }

        public ActionResult DeleteTicket(int id)
        {
            var ticket = _context.ChangeManagementDetails.SingleOrDefault(x => x.Id == id);
            _context.ChangeManagementDetails.Remove(ticket);
            _context.SaveChanges();

            return RedirectToAction("Index", "ChangeManagement");
        }


        public JsonResult Upload(HttpPostedFileBase file)
        {

            Guid filnm = Guid.NewGuid();
            var uploadDir = "~/Upload/Ticket/";
            var fileName = string.Format("{0}{1}",filnm.ToString(), Path.GetExtension(file.FileName));
            var filePath = Path.Combine(Server.MapPath(uploadDir), fileName);
            file.SaveAs(filePath);

            return Json(new { OrignalFile = file.FileName, AttachmentPath = filePath });
        }

        // Type
        [Authorize]
        public ActionResult Type()
        {
            TypeViewModel vm = new TypeViewModel();

            _context.ChangeManagementTypes.ToList().ForEach(x => vm.Types.Add(new TypeModel()
            {
                Id = x.Id,
                Name = x.Name
            }));

            return View(vm);
        }

        public ActionResult ViewType(int id = 0)
        {
            TypeModel vm = new TypeModel();

            if (id != 0)
            {
                var type = _context.ChangeManagementTypes.SingleOrDefault(x => x.Id == id);
                vm.Name = type.Name;
                vm.Id = type.Id;
                vm.IsEdit = true;
            }

            return PartialView("_AddType", vm);
        }

        public ActionResult CreateType(TypeModel vm)
        {
            ChangeManagementType type = new ChangeManagementType();

            if (vm.IsEdit)
                type = _context.ChangeManagementTypes.SingleOrDefault(x => x.Id == vm.Id);

            type.Name = vm.Name;
            type.Id = vm.Id;

            if (!vm.IsEdit)
                _context.ChangeManagementTypes.Add(type);

            _context.SaveChanges();

            return RedirectToAction("Type", new { area = "ChangeManagement" });
        }

        public ActionResult DeleteType(int id)
        {
            var type = _context.ChangeManagementTypes.SingleOrDefault(x => x.Id == id);
            _context.ChangeManagementTypes.Remove(type);
            _context.SaveChanges();

            return RedirectToAction("Type", new { area = "ChangeManagement" });
        }

        // SubType
        [Authorize]
        public ActionResult SubType()
        {
            SubTypeViewModel vm = new SubTypeViewModel();

            _context.ChangeManagementSubTypes.ToList().ForEach(x => vm.SubTypes.Add(new SubTypeModel()
            {
                Id = x.Id,
                Name = x.Name,
                TypeName = x.Type.Name
            }));

            return View(vm);
        }

        public ActionResult ViewSubType(int id = 0)
        {
            SubTypeModel vm = new SubTypeModel();

            if (id != 0)
            {
                var subtype = _context.ChangeManagementSubTypes.SingleOrDefault(x => x.Id == id);
                vm.Name = subtype.Name;
                vm.Id = subtype.Id;
                vm.TypeId = subtype.TypeId;
                vm.IsEdit = true;
            }

            return PartialView("_AddSubType", vm);
        }

        public ActionResult CreateSubType(SubTypeModel vm)
        {
            ChangeManagementSubType subType = new ChangeManagementSubType();

            if (vm.IsEdit)
                subType = _context.ChangeManagementSubTypes.SingleOrDefault(x => x.Id == vm.Id);

            subType.Name = vm.Name;
            subType.Id = vm.Id;
            subType.TypeId = vm.TypeId;

            if (!vm.IsEdit)
                _context.ChangeManagementSubTypes.Add(subType);

            _context.SaveChanges();

            return RedirectToAction("SubType", new { area = "ChangeManagement" });
        }

        public ActionResult DeleteSubType(int id)
        {
            var Subtype = _context.ChangeManagementSubTypes.SingleOrDefault(x => x.Id == id);
            _context.ChangeManagementSubTypes.Remove(Subtype);
            _context.SaveChanges();

            return RedirectToAction("SubType", new { area = "ChangeManagement" });
        }

    }
}