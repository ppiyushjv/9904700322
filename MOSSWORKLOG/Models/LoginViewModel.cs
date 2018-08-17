using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOSSWORKLOG.Models
{
    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "User Name")]
        public string ForgetUserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
    public class ResetPaswordViewModel
    {
        public string RequestId { get; set; }
        public string Password { get; set; }
    }

}
