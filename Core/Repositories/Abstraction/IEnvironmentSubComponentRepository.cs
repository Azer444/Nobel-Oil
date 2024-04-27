using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IEnvironmentSubComponentRepository : IRepository<EnvironmentSubComponent>
    {
        Task<EnvironmentSubComponent> GetBySlugAsync(string slug);

        Task<EnvironmentSubComponent> PrepareSplitedContentsAsync(EnvironmentSubComponent environmentSubComponent);
    }
}
