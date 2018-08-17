using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class tblUserRoleAssign
    {
        public int Id { get; set; }
        public Nullable<int> AssignUserId { get; set; }
        public Nullable<int> ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual tblClient Client { get; set; }
        public Nullable<int> ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual tblProject Project { get; set; }
        public Nullable<int> TaskId { get; set; }
        [ForeignKey("TaskId")]
        public virtual tblTask Task { get; set; }
    }
}