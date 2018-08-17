using MOSSWORKLOG.DATA.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOSSWORKLOG.DATA
{
    public partial class Compliance
    {
        public int Id { get; set; }

        public DateTime ComplianceDate { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ComplianceCategory Category { get; set; }

        public int SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual ComplianceCategory SubCategory { get; set; }

        public string Descriptions { get; set; }

        public StatusEnum Status { get; set; }
    }


    public partial class ComplianceTask
    {
        public int Id { get; set; }

        public DateTime ActoinDatetime { get; set; }

        public int ComplianceId { get; set; }

        [ForeignKey("ComplianceId")]
        public virtual Compliance Compliance { get; set; }

        public string Remarks { get; set; }

        public string Status { get; set; }
    }
}