using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ISafetySubComponentRepository : IRepository<SafetySubComponent>
    {
        Task<SafetySubComponent> GetBySlugAsync(string slug);

        Task<SafetySubComponent> PrepareSplitedContentsAsync(SafetySubComponent safetySubComponent);
    }
}
