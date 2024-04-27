using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ICommunityComponentRepository : IRepository<CommunityComponent>
    {
        Task<CommunityComponent> GetAsync();

        Task<CommunityComponent> PrepareSplitedContentsAsync(CommunityComponent communityComponent);
    }
}
