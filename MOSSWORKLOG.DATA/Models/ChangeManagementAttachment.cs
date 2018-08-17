using MOSSWORKLOG.DATA.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    [Table("ChangeManagementAttachment")]
    public partial class ChangeManagementAttachment
    {
        [Key]
        public int Id { get; set; }
        public int ChangeManagementId { get; set; }

        [ForeignKey("ChangeManagementId")]
        public virtual ChangeManagementDetail ChangeManagement { get; set; }
        public string AttachmentPath { get; set; }
        public string OriginalName { get; set; }

        public int CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual tblUser Created { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}