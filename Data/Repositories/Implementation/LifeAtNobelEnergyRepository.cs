using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class LifeAtNobelEnergyRepository : Repository<LifeAtNobelEnergy>, ILifeAtNobelEnergyRepository
    {
        private readonly NobelContext _context;

        public LifeAtNobelEnergyRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<LifeAtNobelEnergy> GetBySlugAsync(string slug)
        {
            return await _context.LifeAtNobelEnergies.FirstOrDefaultAsync(pr => pr.Slug == slug);
        }

        public async Task<List<LifeAtNobelEnergy>> GetAllRecentLifeAtNobelEnergyForComponentAsync(int id)
        {
            return await _context.LifeAtNobelEnergies
                                      .Where(n => n.Id != id)
                                      .OrderByDescending(n => n.ActionDate)
                                      .ToListAsync();
        }
    }
}
