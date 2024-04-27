using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class DynamicPageContentRepository : Repository<DynamicPageContent>, IDynamicPageContentRepository
    {
        private readonly NobelContext _context;
        public DynamicPageContentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public Task<List<DynamicPageContent>> GetAllByIdAsync(int id)
        {
            return _context.DynamicPageContents.Where(p => p.DynamicPageId == id).ToListAsync();
        }
    }
}
