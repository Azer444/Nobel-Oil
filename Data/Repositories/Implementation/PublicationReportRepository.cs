using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class PublicationReportRepository : Repository<PublicationReport>, IPublicationReportRepository
    {
        private readonly NobelContext _context;

        public PublicationReportRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<PublicationReport> GetBySlugAsync(string slug)
        {
            return await _context.PublicationReports.FirstOrDefaultAsync(pr => pr.Slug == slug);
        }

        public async Task<List<PublicationReport>> GetAllRecentPublicationReportsForComponentAsync(int id)
        {
            return await _context.PublicationReports
                                      .Where(n => n.Id != id)
                                      .OrderByDescending(n => n.ActionDate)
                                      .ToListAsync();
        }
    }
}
