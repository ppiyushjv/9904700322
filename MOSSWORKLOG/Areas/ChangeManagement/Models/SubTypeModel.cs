using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.ChangeManagement.Models
{
    public class SubTypeModel
    {
        public bool IsEdit { get; set; }
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string Name { get; set; }

        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
    public class SubTypeViewModel
    {
        public IList<SubTypeModel> SubTypes { get; set; }
        public SubTypeViewModel()
        {
            this.SubTypes = new List<SubTypeModel>();
        }
    }
}