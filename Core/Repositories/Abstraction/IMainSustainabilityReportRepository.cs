using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IMainSustainabilityReportRepository : IRepository<MainSustainabilityReport>
    {
        Task<MainSustainabilityReport> GetAsync();
    }
}
