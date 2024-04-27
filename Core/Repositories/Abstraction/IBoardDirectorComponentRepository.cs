using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IBoardDirectorComponentRepository : IRepository<BoardDirectorComponent>
    {
        Task<BoardDirectorComponent> GetAsync();
    }
}
