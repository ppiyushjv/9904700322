using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class TrakMeMessage
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string Message { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}