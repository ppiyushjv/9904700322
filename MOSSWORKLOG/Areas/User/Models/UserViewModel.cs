using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MOSSWORKLOG.Areas.User.Models
{
    public class UserModel
    {
        public bool IsEdit { get; set; }
        public int UserId { get; set; }

        [Required]
        [Display(Name = "User Role")]
        public int? RoleId { get; set; }
        public string RoleName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [Remote("CheckExistingUser","User", AdditionalFields = "EditName", ErrorMessage = "User already exists!")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8)]
        [MembershipPassword()]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8)]
        [MembershipPassword()]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Manager")]
        public int? ManagerId { get; set; }

        [Display(Name = "Manager")]
        public string Manager { get; set; }

        [Display(Name = "Supervisor")]
        public int? SupervisorId { get; set; }
        [Display(Name = "Supervisor")]
        public string Supervisor { get; set; }

        public SelectList AllRole { get; set; }
        public SelectList AllManager { get; set; }
        public SelectList AllSupervisor { get; set; }
    }
    public class UserViewModel
    {
        public IList<UserModel> Users { get; set; }
        public UserViewModel()
        {
            this.Users = new List<UserModel>();
        }
    }
}