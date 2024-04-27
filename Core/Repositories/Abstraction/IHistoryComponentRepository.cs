using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IHistoryComponentRepository : IRepository<HistoryComponent>
    {
        Task<List<HistoryComponent>> GetAllByOrderAsync();
    }
}
