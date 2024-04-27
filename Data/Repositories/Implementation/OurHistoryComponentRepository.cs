using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class OurHistoryComponentRepository : Repository<OurHistoryComponent>, IOurHistoryComponentRepository
    {
        private readonly NobelContext _context;

        public OurHistoryComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<OurHistoryComponent> GetAsync()
        {
            return await _context.OurHistoryComponent.FirstOrDefaultAsync();
        }
    }
}
