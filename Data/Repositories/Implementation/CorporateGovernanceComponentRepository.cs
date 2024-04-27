using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class CorporateGovernanceComponentRepository : Repository<CorporateGovernanceComponent>, ICorporateGovernanceComponentRepository
    {
        private readonly NobelContext _context;

        public CorporateGovernanceComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<CorporateGovernanceComponent> GetAsync()
        {
            return await _context.CorporateGovernanceComponent.FirstOrDefaultAsync();
        }
    }
}
