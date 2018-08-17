using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOSSWORKLOG.DATA
{
    public partial class tblContract
    {
        [Key]
        public int ContractId { get; set; }
        public int VenderId { get; set; }
        public virtual tblVender Vender { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Asset { get; set; }
        public string Remarks { get; set; }
        public string Description { get; set; }
    }
}
