using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IEnvironmentComponentRepository : IRepository<EnvironmentComponent>
    {
        Task<EnvironmentComponent> GetAsync();
    }
}
