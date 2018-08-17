using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.Models;
using MOSSWORKLOG.DATA;
using MOSSWORKLOG.DATA.Models.Enums;

namespace MOSSWORKLOG.Areas.ChangeManagement.Models
{
    public class ChangeManagementModel
    {
        public string TicketNumber
        {
            get
            {
                return "T" + this.Id.ToString("D5");
            }
        }
        public bool IsEdit { get; set; }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Client")]
        public int ClientId { get; set; }
        public tblClient Client { get; set; }

        [Required]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        public tblProject Project { get; set; }

        [Required]
        [Display(Name = "Type")]
        public int ChangeTypeId { get; set; }
        public ChangeManagementType ChangeType { get; set; }

        [Required]
        [Display(Name = "Sub Type")]
        public int ChangeSubTypeId { get; set; }
        public ChangeManagementSubType ChangeSubType { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public PriorityEnum Priority { get; set; }

        [Required]
        [Display(Name = "Status")]
        public StatusEnum Status { get; set; }

        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Assign To")]
        public int? AssignTo { get; set; }
        public tblUser AssingUserName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Step to reproduce")]
        public string StepToReproduce { get; set; }

        public DateTime? CloseDate { get; set; }
        public int? CloseBy { get; set; }
        public tblUser CloseByUserName { get; set; }

        public int? CreateBy { get; set; }
        public tblUser CreateByUserName { get; set; }
        public DateTime? CreateDate { get; set; }

        public int? ResolveBy { get; set; }
        public tblUser ResolveByUserName { get; set; }
        public DateTime? ResolveDate { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "Attachment")]
        public HttpPostedFile Attachment { get; set; }

        public IList<ChangeManagementAttachmentModel> Attachments { get; set; }
        public IList<ChangeManagementCommentModel> Comments { get; set; }

        public ChangeManagementModel()
        {
            this.Attachments = new List<ChangeManagementAttachmentModel>();
            this.Comments = new List<ChangeManagementCommentModel>();
        }
    }


    public class ChangeManagementViewModel
    {
        
        public IList<ChangeManagementModel> ChangeManagementModels { get; set; }

        public ChangeManagementViewModel()
        {
            this.ChangeManagementModels = new List<ChangeManagementModel>();
        }

    }

    public class ChangeManagementCommentModel
    {
        public int Id { get; set; }
        public int ChangeManagementId { get; set; }
        public ChangeManagementDetail ChangeManagement { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }

    public class ChangeManagementAttachmentModel
    {
        public int Id { get; set; }
        public int ChangeManagementId { get; set; }
        public HttpPostedFileBase UploadFile { get; set; }
        public ChangeManagementDetail ChangeManagement { get; set; }
        public string AttachmentPath { get; set; }
        public string OriginalName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}