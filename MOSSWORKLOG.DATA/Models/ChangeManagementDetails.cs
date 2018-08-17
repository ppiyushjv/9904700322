using MOSSWORKLOG.DATA.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    [Table("ChangeManagementDetail")]
    public partial class ChangeManagementDetail
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual tblClient Client { get; set;}

        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual tblProject Project { get; set; }

        public int ChangeTypeId { get; set; }
        [ForeignKey("ChangeTypeId")]
        public virtual ChangeManagementType ChangeType { get; set; }

        public int ChangeSubTypeId { get; set; }
        [ForeignKey("ChangeSubTypeId")]
        public virtual ChangeManagementSubType ChangeSubType { get; set; }

        public PriorityEnum Priority { get; set; }
        public StatusEnum Status { get; set; }

        public DateTime? DueDate { get; set; }

        public int? AssignTo { get; set; }
        [ForeignKey("AssignTo")]
        public virtual tblUser AssingUserName { get; set; }

        public string Description { get; set; }

        public string StepToReproduce { get; set; }

        public DateTime? CloseDate { get; set;}
        public DateTime? CreateDate { get; set; }
        public DateTime? ResolveDate { get; set; }

        public int? CloseBy { get; set; }
        [ForeignKey("CloseBy")]
        public virtual tblUser CloseByUserName { get; set; }

        public int? CreateBy { get; set; }
        [ForeignKey("CreateBy")]
        public virtual tblUser CreateByUserName { get; set; }

        public int? ResolveBy { get; set; }
        [ForeignKey("ResolveBy")]
        public virtual tblUser ResolveByUserName { get; set; }

        public IList<ChangeManagementAttachment> Attachments { get; set; }
        public IList<ChangeManagementComment> Comments { get; set; }
    }
}