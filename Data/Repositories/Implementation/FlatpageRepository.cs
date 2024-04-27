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
    public class FlatpageRepository : Repository<Flatpage>, IFlatpageRepository
    {
        private readonly NobelContext _context;

        public FlatpageRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public bool IsUrlExists(string url)
        {
            return _context.Flatpages.ToList().FirstOrDefault(f => f.URL.ToLowerInvariant() == url.ToLowerInvariant()) != null;
        }

        public async Task<Flatpage> GetByUrl(string url)
        {
            return (await _context.Flatpages.ToListAsync()).FirstOrDefault(fp => fp.URL == url);
        }


        public async Task<bool> IsUniqueURLAsync(string url)
        {
            return !await _context.Flatpages.AnyAsync(f => f.URL.ToUpper() == url.ToUpper());
        }

        public async Task<bool> IsUniqueURLAsync(string url, int flatpageId)
        {
            return !await _context.Flatpages.AnyAsync(f => f.URL.ToUpper() == url.ToUpper() && f.Id != flatpageId);
        }

        public async Task<List<Flatpage>> GetAllByPageAsync(Page page)
        {
            return await _context.Flatpages
                                    .Where(f => f.Page == page && f.HasPageComponent)
                                    .ToListAsync();
        }
    }
}
