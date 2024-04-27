using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ILegalNoticeComponentRepository : IRepository<LegalNoticeComponent>
    {
        Task<LegalNoticeComponent> GetAsync();
    }
}
