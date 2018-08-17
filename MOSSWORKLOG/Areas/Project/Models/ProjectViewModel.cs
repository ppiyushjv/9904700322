using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.Project.Models
{
    public class ProjectModel
    {
        public bool IsEdit { get; set; }
        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Client")]
        public int? ClientId { get; set; }
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email(Notification)")]
        public string Email { get; set; }

        public SelectList AllClient { get; set; }

    }
    public class ProjectViewModel
    {
        public IList<ProjectModel> Projects { get; set; }
        public ProjectViewModel()
        {
            this.Projects = new List<ProjectModel>();
        }
    }
    public class ProjectUserModel
    {
        public int ProjectId { get; set; }
        public SelectList AllUsers { get; set; }
        [Display(Name = "Select User Name")]
        public string[] UserSelected { get; set; }
    }
}