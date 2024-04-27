namespace Manage.Areas.Admin.Models.MessageManagement.Message
{
    public class MessageLookViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public bool IsRead { get; set; }
    }
}
