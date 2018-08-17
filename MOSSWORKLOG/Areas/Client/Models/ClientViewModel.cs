using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.Models;

namespace MOSSWORKLOG.Areas.Client.Models
{
    public class ClientModel
    {
        public bool IsEdit { get; set; }
        public int ClientId { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Short Code")]
        public string ShortName { get; set; }

        [Required]
        [Display(Name = "Client Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        [Display(Name = "Client Contact")]
        public string Contact { get; set; }
    }


    public class ClientViewModel
    {
        
        public IList<ClientModel> Clients { get; set; }

        public ClientViewModel()
        {
            this.Clients = new List<ClientModel>();
        }

    }

    public class ClientUserModel
    {
        public int ClientId { get; set; }
        public SelectList AllUsers { get; set; }
        [Display(Name = "Select User Name")]
        public string[] UserSelected { get; set; }

        
        public ClientUserModel()
        {
            //this.AllUsers = new SelectList();
        }
    }
}