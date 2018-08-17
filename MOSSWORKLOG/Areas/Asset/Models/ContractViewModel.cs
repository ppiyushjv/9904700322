using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.Models;

namespace MOSSWORKLOG.Areas.Asset.Models
{
    public class ContractModel
    {
        public bool IsEdit { get; set; }
        public int ContractId { get; set; }

        [Required]
        [Display(Name = "Vendor Name")]
        public int VendorId { get; set; }

        public string VendorName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }


        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Asset")]
        public string Asset { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }


    public class ContractViewModel
    {
        
        public IList<ContractModel> Contracts { get; set; }

        public ContractViewModel()
        {
            this.Contracts = new List<ContractModel>();
        }

    }
}