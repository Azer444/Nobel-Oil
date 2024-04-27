using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IPublicationReportRepository : IRepository<PublicationReport>
    {
        Task<PublicationReport> GetBySlugAsync(string slug);

        Task<List<PublicationReport>> GetAllRecentPublicationReportsForComponentAsync(int id);
    }
}
