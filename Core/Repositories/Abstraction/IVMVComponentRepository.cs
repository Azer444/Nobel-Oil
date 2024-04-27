using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IVMVComponentRepository : IRepository<VMVComponent>
    {
        Task<VMVComponent> GetAsync();
        Task<VMVComponent> PrepareSplitedContentsAsync(VMVComponent vmvComponent);
    }
}
