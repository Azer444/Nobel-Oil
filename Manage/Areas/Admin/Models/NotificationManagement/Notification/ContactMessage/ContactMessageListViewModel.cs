using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.NotificationManagement.Notification.ContactMessage
{
    public class ContactMessageListViewModel
    {
        public ContactMessageListViewModel()
        {
            ContactMessages = new List<Core.Models.ContactMessage>();
        }

        public List<Core.Models.ContactMessage> ContactMessages { get; set; }

    }
}
