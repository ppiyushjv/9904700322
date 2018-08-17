using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class tblUser
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public int? SupervisorId { get; set; }
        public int? ManagerId { get; set; }
        public Nullable<int> RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual tblRole Role { get; set; }
    }
}