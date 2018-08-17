using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class TrakMeCity
    {
        [Key]
        public int Id { get; set; }
        public string CoutryCode { get; set; }
        public string CountryName { get; set; }
        public string StateCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string TimeZone { get; set; }
    }
}