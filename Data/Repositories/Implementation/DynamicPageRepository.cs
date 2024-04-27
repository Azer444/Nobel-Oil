using Core.Constants;
using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class DynamicPageRepository : Repository<DynamicPage>, IDynamicPageRepository
    {
        private readonly NobelContext _context;
        public DynamicPageRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<DynamicPage>> GetAllByPageAsync(Page page)
        {
            return await _context.DynamicPages
                        .Where(f => f.Page == page && f.HasPageComponent)
                        .ToListAsync();
        }

        public async Task<DynamicPage> GetByUrl(string url)
        {
            return (await _context.DynamicPages.ToListAsync()).FirstOrDefault(fp => fp.URL == url);
        }

        public async Task<bool> IsUniqueURLAsync(string url)
        {
            return !await _context.DynamicPages.AnyAsync(f => f.URL.ToUpper() == url.ToUpper());
        }

        public async Task<bool> IsUniqueURLAsync(string url, int dynamicPageId)
        {
            return !await _context.DynamicPages.AnyAsync(f => f.URL.ToUpper() == url.ToUpper() && f.Id != dynamicPageId);
        }

        public bool IsUrlExists(string url)
        {
            return _context.DynamicPages.ToList().FirstOrDefault(f => f.URL.ToLowerInvariant() == url.ToLowerInvariant()) != null;
        }
    }
}
