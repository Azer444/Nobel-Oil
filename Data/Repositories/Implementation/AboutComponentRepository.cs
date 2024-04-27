using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class AboutComponentRepository : Repository<AboutComponent>, IAboutComponentRepository
    {
        private readonly NobelContext _context;

        public AboutComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<AboutComponent> GetAsync()
        {
            return await _context.AboutComponent.FirstOrDefaultAsync();
        }
    }
}
