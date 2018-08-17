using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOSSWORKLOG.Areas.Document.Models
{
    public class KeywordModel
    {
        public bool IsEdit { get; set; }
        public int Id { get; set; }

        [Required]
        [Display(Name = "Keyword")]
        public string KeyWordName { get; set; }
    }
    public class KeywordViewModel
    {
        public IList<KeywordModel> KeyWords { get; set; }
        public KeywordViewModel()
        {
            this.KeyWords = new List<KeywordModel>();
        }
    }
}