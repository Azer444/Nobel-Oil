using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IPageTabComponentRepository : IRepository<PageTabComponent>
    {
        Task<List<PageTabComponent>> GetAllByIsActiveAsync();
        Task<PageTabComponent> GetByUrlAsync(string url);
        Task<bool> IsUniqueURLAsync(string url);
    }
}
