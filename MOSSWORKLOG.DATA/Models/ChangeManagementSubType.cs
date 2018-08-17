using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    [Table("ChangeManagementSubType")]
    public partial class ChangeManagementSubType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual ChangeManagementType Type { get; set; }
    }
}