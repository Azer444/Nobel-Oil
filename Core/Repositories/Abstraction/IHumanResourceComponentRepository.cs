using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IHumanResourceComponentRepository : IRepository<HumanResourceComponent>
    {
        Task<HumanResourceComponent> GetAsync();

        Task<HumanResourceComponent> PrepareSplitedContentsAsync(HumanResourceComponent humanResourceComponent);
    }
}
