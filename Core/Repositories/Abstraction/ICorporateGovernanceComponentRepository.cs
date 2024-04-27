using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ICorporateGovernanceComponentRepository : IRepository<CorporateGovernanceComponent>
    {
        Task<CorporateGovernanceComponent> GetAsync();
    }
}
