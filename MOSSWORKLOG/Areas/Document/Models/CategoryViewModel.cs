using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.Document.Models
{
    public class CategoryModel
    {
        public bool IsEdit { get; set; }
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        public string Type { get; set; }

        [Required]
        [Display(Name = "Sub Category Name")]
        public int? CatId { get; set; }
        public string CatName { get; set; }

        public int[] KeyWords { get; set; }

        public SelectList AllCat { get; set; }
    }
    public class CategoryViewModel
    {
        public IList<CategoryModel> Categories { get; set; }
        public CategoryViewModel()
        {
            this.Categories = new List<CategoryModel>();
        }
    }
}