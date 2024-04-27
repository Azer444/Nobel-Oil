using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IEthicsComplianceSubComponentRepository : IRepository<EthicsComplianceSubComponent>
    {
        Task<EthicsComplianceSubComponent> GetBySlugAsync(string slug);

        Task<EthicsComplianceSubComponent> PrepareSplitedContentsAsync(EthicsComplianceSubComponent ethicsComplianceSubComponent);
    }
}
