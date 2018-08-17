
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    [Table("tblDocumentKeyWord")]
    public partial class tblDocumentKeyWord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string KeyWordName { get; set; }
    }
}
