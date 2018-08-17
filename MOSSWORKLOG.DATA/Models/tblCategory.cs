using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class tblCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<int> CatId { get; set; }
        [ForeignKey("CatId")]
        public virtual tblCategory Category { get; set; }
    }
}
