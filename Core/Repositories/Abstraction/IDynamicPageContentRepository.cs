using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IDynamicPageContentRepository : IRepository<DynamicPageContent>
    {
        Task<List<DynamicPageContent>> GetAllByIdAsync(int id);
    }
}
