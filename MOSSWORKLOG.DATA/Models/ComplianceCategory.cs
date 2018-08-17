using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class ComplianceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<int> CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ComplianceCategory Category { get; set; }
    }
}