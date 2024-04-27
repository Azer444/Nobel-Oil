using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class OurProjectComponentRepository : Repository<OurProjectComponent>, IOurProjectComponentRepository
    {
        private readonly NobelContext _context;

        public OurProjectComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<OurProjectComponent> GetAsync()
        {
            return await _context.OurProjectComponent.FirstOrDefaultAsync();
        }
    }
}
