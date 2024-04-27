using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class SiteConfigRepository : Repository<SiteConfig>, ISiteConfigRepository
    {
        private readonly NobelContext _context;

        public SiteConfigRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<SiteConfig> GetAsync()
        {
            return await _context.SiteConfig.FirstOrDefaultAsync();
        }
    }
}
