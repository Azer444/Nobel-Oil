using Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.UserManagement.User
{
    public class UserEditViewModel
    {
        [Required]
        public string ID { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required, Display(Name = "Email confirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Role")]
        public string[] ApplicationRolesIDs { get; set; }

        //Lists
        public List<Role> ApplicationRoles { get; set; }
    }
}
