using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class PublicationReportPdfRepository : Repository<PublicationReportPdf>, IPublicationReportPdfRepository
    {
        private readonly NobelContext _context;

        public PublicationReportPdfRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<PublicationReportPdf>> GetAllByPublicationReportIdAsync(int id)
        {
            return await _context.PublicationReportPdfs
                            .Where(n => n.PublicationReportId == id)
                            .ToListAsync();
        }

        public async Task<List<PublicationReportPdf>> GetAllByPublicationReportIdAsync(int id, Core.Constants.Language language)
        {
            return await _context.PublicationReportPdfs
                            .Where(prp =>
                                prp.PublicationReportId == id &&
                                prp.Language == language)
                            .ToListAsync();
        }
    }
}
