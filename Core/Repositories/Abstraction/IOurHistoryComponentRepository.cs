using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IOurHistoryComponentRepository : IRepository<OurHistoryComponent>
    {
        Task<OurHistoryComponent> GetAsync();
    }
}
