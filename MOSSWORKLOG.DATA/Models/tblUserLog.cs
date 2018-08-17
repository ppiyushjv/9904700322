using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class tblUserLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Nullable<System.DateTime> TimeLog { get; set; }
        public string Type { get; set; }
    }
}
