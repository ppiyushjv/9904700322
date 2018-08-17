using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.Models;

namespace MOSSWORKLOG.Areas.Asset.Models
{
    public class VenderModel
    {
        public bool IsEdit { get; set; }
        public int VenderId { get; set; }

        [Required]
        [Display(Name = "Vendor Name")]
        public string VenderName { get; set; }

        [Required]
        [Display(Name = "Short Code")]
        public string VenderShortName { get; set; }

        [Required]
        [Display(Name = "Vendor Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        [Display(Name = "Vendor Contact")]
        public string Contact { get; set; }
    }


    public class VenderViewModel
    {
        
        public IList<VenderModel> Venders { get; set; }

        public VenderViewModel()
        {
            this.Venders = new List<VenderModel>();
        }

    }
}