using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class EthicsComplianceComponentRepository : Repository<EthicsComplianceComponent>, IEthicsComplianceComponentRepository
    {
        private readonly NobelContext _context;

        public EthicsComplianceComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<EthicsComplianceComponent> GetAsync()
        {
            return await _context.EthicsComplianceComponent.FirstOrDefaultAsync();
        }
    }
}
