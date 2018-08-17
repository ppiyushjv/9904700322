using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class PasswordResetRequest
    {
        public int Id { get; set; }
        public string RequestId { get; set; }
        public int RequestedUserId { get; set; }
        public System.DateTime Timestamp { get; set; }
    }
}
