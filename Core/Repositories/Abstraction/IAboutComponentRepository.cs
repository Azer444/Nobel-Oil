using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IAboutComponentRepository : IRepository<AboutComponent>
    {
        Task<AboutComponent> GetAsync();
    }
}
