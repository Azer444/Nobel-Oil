using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.AccountManagement
{
    public class LoginViewModel
    {
        [Required, Display(Name = "Username")]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
