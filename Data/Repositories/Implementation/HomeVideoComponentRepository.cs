using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class HomeVideoComponentRepository : Repository<HomeVideoComponent>, IHomeVideoComponentRepository
    {
        private readonly NobelContext _context;

        public HomeVideoComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<HomeVideoComponent> GetAsync()
        {
            return await _context.HomeVideoComponent.FirstOrDefaultAsync();
        }
    }
}
