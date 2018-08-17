using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class tblTask
    {
        public int TaskId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual tblProject Project { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual tblClient Client { get; set; }
        public string TaskFrequency { get; set; }
        public string TaskTick { get; set; }
        public Nullable<System.DateTime> TaskStartDate { get; set; }
        public Nullable<System.DateTime> TaskEndDate { get; set; }
        public string Email { get; set; }
    }
}
