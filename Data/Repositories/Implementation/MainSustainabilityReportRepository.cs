using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class MainSustainabilityReportRepository : Repository<MainSustainabilityReport>, IMainSustainabilityReportRepository
    {
        private readonly NobelContext _context;

        public MainSustainabilityReportRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<MainSustainabilityReport> GetAsync()
        {
            return await _context.MainSustainabilityReport.FirstOrDefaultAsync();
        }
    }
}
