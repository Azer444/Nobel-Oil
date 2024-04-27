using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface INobelHeritageRepository : IRepository<NobelHeritage>
    {
        Task<NobelHeritage> GetAsync();

        Task<NobelHeritage> PrepareSplitedContentsAsync(NobelHeritage nobelHeritage);
    }
}
