using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class SustainabilityReportRepository : Repository<SustainabilityReport>, ISustainabilityReportRepository
    {
        private readonly NobelContext _context;

        public SustainabilityReportRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<SustainabilityReport> GetAsync()
        {
            return await _context.SustainabilityReport.FirstOrDefaultAsync();
        }
    }
}
