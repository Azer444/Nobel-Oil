using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class MediaComponentRepository : Repository<MediaComponent>, IMediaComponentRepository
    {
        private readonly NobelContext _context;

        public MediaComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<MediaComponent>> GetAllByIsActiveAsync()
        {
            return await _context.MediaComponents.Where(m => m.IsActive).ToListAsync();
        }
    }
}
