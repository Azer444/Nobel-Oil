using System.ComponentModel.DataAnnotations;

namespace Manage.ViewModels.Contact
{
    public class ContactSubmitForm
    {
        [Required]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Your e-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Your phone")]
        public string Phone { get; set; }

        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Display(Name = "Your message")]
        public string Message { get; set; }
    }
}
