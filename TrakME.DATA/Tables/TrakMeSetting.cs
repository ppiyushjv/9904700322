namespace TrakME.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrakMeSetting
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string SettingPara { get; set; }

        public string SettingValue { get; set; }
    }
}
