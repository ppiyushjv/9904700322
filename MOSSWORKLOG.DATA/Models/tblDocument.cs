using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class tblDocument
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual tblCategory MainCategory { get; set; }

        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual tblCategory SubCategory { get; set; }

        public string DocumentPath { get; set; }
        public string Descriptions { get; set; }

        public virtual IList<tblDocumentKeyWordMap> KeyWord {get; set;}
        public string Name { get; set; }
    }
}
