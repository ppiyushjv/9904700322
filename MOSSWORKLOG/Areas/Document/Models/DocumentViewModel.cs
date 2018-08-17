using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.Document.Models
{
    public class DocumentModel
    {
        public bool IsEdit { get; set; }
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descriptions")]
        public string Descriptions { get; set; }
        [Required]
        [Display(Name = "Path")]
        public string DocumentPath { get; set; }

        [Required]
        [Display(Name = "Sub Category Name")]
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int[] Keywords { get; set; }
        public string KeywordList { get; set; }

        public HttpPostedFileBase UploadFile { get; set; }
        public SelectList AllCategory { get; set; }
        public SelectList AllSubCategory { get; set; }
        public SelectList AllKeyword { get; set; }
    }
    public class DocumentViewModel
    {
        public IList<DocumentModel> Documents { get; set; }
        public DocumentViewModel()
        {
            this.Documents = new List<DocumentModel>();
        }
    }
}