using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IEthicsComplianceComponentRepository : IRepository<EthicsComplianceComponent>
    {
        Task<EthicsComplianceComponent> GetAsync();
    }
}
