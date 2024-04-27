using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class EnvironmentComponentRepository : Repository<EnvironmentComponent>, IEnvironmentComponentRepository
    {
        private readonly NobelContext _context;

        public EnvironmentComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<EnvironmentComponent> GetAsync()
        {
            return await _context.EnvironmentComponent.FirstOrDefaultAsync();
        }
    }
}
