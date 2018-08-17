using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class tblProject
    {
        public int ProjectId { get; set; }
        public Nullable<int> ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual tblClient Client { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
