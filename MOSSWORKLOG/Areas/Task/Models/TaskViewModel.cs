using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.Task.Models
{
    public class TaskModel
    {
        public bool IsEdit { get; set; }
        public int TaskId { get; set; }

        [Required]
        [Display(Name = "Project")]
        public int? ProjectId { get; set; }
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string TaskDescription { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email(Notification)")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Task Frequency")]
        public string TaskFrequency { get; set; }

        [Required]
        [Display(Name = "Task Repeat on")]
        public string TaskTick { get; set; }

        public string DisplayName
        {
            get { return TaskName + " - " + ProjectName; }
        }
        public string[] TaskTickselect { get; set; }

        [Display(Name = "Task Start Date")]
        public string TaskStartDate { get; set; }
        [Display(Name = "Task End Date")]
        public string TaskEndDate { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public SelectList AllProject { get; set; }
        public SelectList AllTaskTickWeekly { get; set; }
        public SelectList AllTaskTickMonthly { get; set; }
        public SelectList AllTaskFrequency { get; set; }

    }
    public class TaskViewModel
    {
        public IList<TaskModel> Tasks { get; set; }
        public TaskViewModel()
        {
            this.Tasks = new List<TaskModel>();
        }
    }
    public class TaskUserModel
    {
        public int TaskId { get; set; }
        public SelectList AllUsers { get; set; }
        [Display(Name = "Select User Name")]
        public string[] UserSelected { get; set; }
    }
}