using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOSSWORKLOGAPP
{
    public class TaskModel
    {
        public bool IsEdit { get; set; }
        public int TaskId { get; set; }

        public int? ProjectId { get; set; }
        public string ProjectName { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public string Email { get; set; }

        public string TaskFrequency { get; set; }

        public string TaskTick { get; set; }

        public string DisplayName
        {
            get { return TaskName + " - " + ProjectName; }
        }
        public string[] TaskTickselect { get; set; }

        public string TaskStartDate { get; set; }
        public string TaskEndDate { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }

    public class tblUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public Nullable<int> RoleId { get; set; }
    }

    public class WorkLogModel
    {
        public bool IsEdit { get; set; }
        public int WorkLogId { get; set; }
        public int? TaskId { get; set; }
        public string TaskName { get; set; }
        public int? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int CreatedById { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public decimal? Duration { get; set; }
        public int? Unit { get; set; }
        public decimal? AverageTime { get; set; }
        public int SupApproval { get; set; }
        public int SupReviewBy { get; set; }
        public string SupRemark { get; set; }
        public int SupSatisfaction { get; set; }
        public int ManApproval { get; set; }
        public int ManReviewBy { get; set; }
        public string ManRemark { get; set; }
        public int ManSatisfaction { get; set; }
        public int ClientApproval { get; set; }
        public int ClientReviewBy { get; set; }
        public string ClientRemark { get; set; }
        public int ClientSatisfaction { get; set; }
    }
}
