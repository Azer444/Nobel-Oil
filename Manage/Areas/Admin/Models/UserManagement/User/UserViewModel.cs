using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.UserManagement.User
{
    public class UserViewModel
    {
        public string ID { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Email confirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Joined at"), DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime JoinedAt { get; set; }

        public Core.Models.User User { get; set; }
    }
}
