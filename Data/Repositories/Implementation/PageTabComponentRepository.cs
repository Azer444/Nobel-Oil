using Core.Models;
using Core.Repositories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class PageTabComponentRepository : Repository<PageTabComponent>, IPageTabComponentRepository
    {
        private readonly NobelContext _context;

        public PageTabComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }
        public async Task<List<PageTabComponent>> GetAllByIsActiveAsync()
        {
            return await _context.PageTabComponents.Where(p => p.IsActive).ToListAsync();
        }

        public async Task<PageTabComponent> GetByUrlAsync(string url)
        {
            return await _context.PageTabComponents.SingleOrDefaultAsync(p => p.Link == url);
        }

        public async Task<bool> IsUniqueURLAsync(string url)
        {
            return !await _context.PageTabComponents.AnyAsync(f => f.Link.ToUpper() == url.ToUpper());
        }
    }
}
