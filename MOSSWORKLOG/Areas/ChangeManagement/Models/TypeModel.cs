using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.ChangeManagement.Models
{
    public class TypeModel
    {
        public bool IsEdit { get; set; }
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string Name { get; set; }
    }
    public class TypeViewModel
    {
        public IList<TypeModel> Types { get; set; }
        public TypeViewModel()
        {
            this.Types = new List<TypeModel>();
        }
    }
}