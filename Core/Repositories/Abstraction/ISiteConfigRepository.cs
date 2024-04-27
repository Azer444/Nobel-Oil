using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ISiteConfigRepository : IRepository<SiteConfig>
    {
        Task<SiteConfig> GetAsync();
    }
}
