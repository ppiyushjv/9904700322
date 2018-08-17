using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    [Table("ChangeManagementType")]
    public partial class ChangeManagementType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}