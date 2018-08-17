
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    [Table("tblDocumentKeyWordMap")]
    public partial class tblDocumentKeyWordMap
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public virtual tblDocument Document { get; set; }
        [Required]
        public int KeyWordId { get; set; }
        [ForeignKey("KeyWordId")]
        public virtual tblDocumentKeyWord KeyWord { get; set; }
    }
}
