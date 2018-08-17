using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class TrakMeSettings
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SettingPara { get; set; }
        public string SettingValue { get; set; }
    }
}