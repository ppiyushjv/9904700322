using MOSSWORKLOG.DATA.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class TrakMeEventSubType
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int RefreshRate { get; set; }
        public EventTypeEnum Type { get; set; }
    }
}