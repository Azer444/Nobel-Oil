using Core.Constants;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IDynamicPageRepository : IRepository<DynamicPage>
    {
        Task<DynamicPage> GetByUrl(string url);
        bool IsUrlExists(string url);
        Task<bool> IsUniqueURLAsync(string url);
        Task<bool> IsUniqueURLAsync(string url, int dynamicPageId);
        Task<List<DynamicPage>> GetAllByPageAsync(Page page);
    }
}
