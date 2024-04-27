using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface INavTitleComponentRepository : IRepository<NavTitleComponent>
    {
        Task<List<NavTitleComponent>> GetAllForHeaderAsync();
        Task<List<NavTitleComponent>> GetAllForHeaderByIsActiveAsync();
    }
}
