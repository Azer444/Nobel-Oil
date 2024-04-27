using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IHomeVideoComponentRepository : IRepository<HomeVideoComponent>
    {
        Task<HomeVideoComponent> GetAsync();
    }
}
