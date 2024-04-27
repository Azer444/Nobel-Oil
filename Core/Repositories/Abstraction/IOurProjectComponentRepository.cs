using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IOurProjectComponentRepository : IRepository<OurProjectComponent>
    {
        Task<OurProjectComponent> GetAsync();
    }
}
