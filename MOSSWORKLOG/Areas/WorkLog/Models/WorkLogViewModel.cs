using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.WorkLog.Models
{
    public class WorkLogModel
    {
        public bool IsEdit { get; set; }
        public int WorkLogId { get; set; }

        [Required]
        [Display(Name = "Task Name")]
        public int? TaskId { get; set; }
        public string TaskName { get; set; }
        public int? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int CreatedById { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
        [Required]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }
        public decimal? Duration { get; set; }
        [Required]
        [Display(Name = "Unit")]
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
        public SelectList AllTask { get; set; }
    }
    public class WorkLogViewModel
    {
        public IList<WorkLogModel> WorkLogs { get; set; }
        public WorkLogViewModel()
        {
            this.WorkLogs = new List<WorkLogModel>();
        }
    }
}