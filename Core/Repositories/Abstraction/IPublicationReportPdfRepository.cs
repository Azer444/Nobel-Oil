using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IPublicationReportPdfRepository : IRepository<PublicationReportPdf>
    {
        Task<List<PublicationReportPdf>> GetAllByPublicationReportIdAsync(int id);
        Task<List<PublicationReportPdf>> GetAllByPublicationReportIdAsync(int id, Core.Constants.Language language);
    }
}
