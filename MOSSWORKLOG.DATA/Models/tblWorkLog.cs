using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class tblWorkLog
    {
        public int WorkLogId { get; set; }
        public Nullable<int> TaskId { get; set; }
        [ForeignKey("TaskId")]
        public virtual tblTask Task{ get; set; }

        public Nullable<int> CreatedById { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<decimal> Duration { get; set; }
        public Nullable<int> Unit { get; set; }
        public Nullable<decimal> AverageTime { get; set; }
        public Nullable<int> SupApproval { get; set; }
        public Nullable<int> SupReviewBy { get; set; }
        public string SupRemark { get; set; }
        public Nullable<int> SupSatisfaction { get; set; }
        public Nullable<int> ManApproval { get; set; }
        public Nullable<int> ManReviewBy { get; set; }
        public string ManRemark { get; set; }
        public Nullable<int> ManSatisfaction { get; set; }
        public Nullable<int> ClientApproval { get; set; }
        public Nullable<int> ClientReviewBy { get; set; }
        public string ClientRemark { get; set; }
        public Nullable<int> ClientSatisfaction { get; set; }
    }
}