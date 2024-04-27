using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IExecutiveManagementComponentRepository : IRepository<ExecutiveManagementComponent>
    {
        Task<ExecutiveManagementComponent> GetAsync();
    }
}
