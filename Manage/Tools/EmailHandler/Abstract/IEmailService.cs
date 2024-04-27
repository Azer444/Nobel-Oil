using System.Threading.Tasks;

namespace Manage.Tools.EmailHandler.Abstract
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Message message);
    }
}
