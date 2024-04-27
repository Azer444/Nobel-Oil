using System;

namespace Manage.Areas.Admin.Models.NotificationManagement.Notification
{
    public class EthicsAndCompilanceApplyDetailsViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string ToEmail { get; set; }
        public bool IsRead { get; set; }

        //Timing
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
