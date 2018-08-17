using MOSSWORKLOG.DATA.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class TrakMeEventViewer
    {
        [Key]
        public int Id { get; set; }

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public virtual TrakMeEvent Event { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual TrakMeUser User { get; set; }

        public string Message { get; set; }

        public bool IsTrackable { get; set; }

        public bool IsActive { get; set; }
    }
}