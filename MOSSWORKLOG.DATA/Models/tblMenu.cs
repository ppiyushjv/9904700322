using System;
using System.Collections.Generic;

namespace MOSSWORKLOG.DATA
{
    public partial class tblMenu
    {
        public int Id { get; set; }
        public string MainId { get; set; }
        public string SubId { get; set; }
        public string Lable { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }
        public string IconClass { get; set; }
        public string UserRole { get; set; }
        public Nullable<int> SerialNo { get; set; }
        public Nullable<bool> IsSub { get; set; }
    }
}
