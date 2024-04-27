using System.ComponentModel.DataAnnotations;

namespace Manage.ViewModels.EthicsAndCompilance
{
    public class ECSubmitFormViewComponentViewModel
    {
        [Display(Name = "Full name")]
        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name = "Your e-mail")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Your phone")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Your message")]
        public string Message { get; set; }
    }
}
