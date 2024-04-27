using Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.UserManagement.User
{
    public class UserCreateViewModel
    {
        public UserCreateViewModel()
        {
            ApplicationRolesIDs = new List<string>();
        }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required]
        //[Remote("admin-user-isemailunique")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required, Display(Name = "Email confirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Role")]

        public List<string> ApplicationRolesIDs { get; set; }
        public List<Role> ApplicationRoles { get; set; }
    }
}
