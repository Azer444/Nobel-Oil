using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ISustainabilityReportRepository : IRepository<SustainabilityReport>
    {
        Task<SustainabilityReport> GetAsync();
    }
}
