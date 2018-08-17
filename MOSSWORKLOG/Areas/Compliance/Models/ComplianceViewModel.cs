using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.DATA.Models.Enums;

namespace MOSSWORKLOG.Areas.Compliance.Models
{
    public class ComplianceModel
    {
        public bool IsEdit { get; set; }
        public int Id { get; set; }

        [Required]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Required]
        [Display(Name = "Contact  Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string ContactEmail { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }

        [Required]
        [Display(Name = "Compliance Date")]
        public DateTime ComplianceDate { get; set; }


        [Required]
        [Display(Name = "Descriptions")]
        public string Descriptions { get; set; }

        [Required]
        [Display(Name = "Sub Category Name")]
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public StatusEnum Status { get; set; }

        public SelectList AllCategory { get; set; }
        public SelectList AllSubCategory { get; set; }
    }
    public class ComplianceViewModel
    {
        public IList<ComplianceModel> Compliances { get; set; }
        public ComplianceViewModel()
        {
            this.Compliances = new List<ComplianceModel>();
        }
    }
}