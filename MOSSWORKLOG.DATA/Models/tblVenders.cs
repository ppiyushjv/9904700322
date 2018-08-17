using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOSSWORKLOG.DATA
{
    public partial class tblVender
    {
        [Key]
        public int VenderId { get; set; }
        public string VenderShortName { get; set; }
        public string VenderName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }
}
