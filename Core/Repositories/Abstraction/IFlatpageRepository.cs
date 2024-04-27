using Core.Constants;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IFlatpageRepository : IRepository<Flatpage>
    {
        Task<Flatpage> GetByUrl(string url);
        bool IsUrlExists(string url);
        Task<bool> IsUniqueURLAsync(string url);
        Task<bool> IsUniqueURLAsync(string url, int flatpageId);
        Task<List<Flatpage>> GetAllByPageAsync(Page page);
    }
}
