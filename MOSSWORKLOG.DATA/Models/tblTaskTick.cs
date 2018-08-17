using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class tblTaskTick
    {
        public int Id { get; set; }
        public Nullable<int> TaskId { get; set; }
        [ForeignKey("TaskId")]
        public virtual tblTask Task { get; set;}
        public string TaskTick { get; set; }
    }
}
