using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ISafetyComponentRepository : IRepository<SafetyComponent>
    {
        Task<SafetyComponent> GetAsync();
    }
}
