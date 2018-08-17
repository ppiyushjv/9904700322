using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class TrakMeUserLog
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string AreaName { get; set; }
    }
}