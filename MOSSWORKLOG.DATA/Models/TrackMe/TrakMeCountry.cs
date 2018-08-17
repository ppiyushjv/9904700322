using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class TrakMeCountry
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string ISDCode { get; set; }
        public string ShortCode { get; set; }
    }
}