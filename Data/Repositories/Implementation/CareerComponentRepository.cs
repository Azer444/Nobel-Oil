using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class CareerComponentRepository : Repository<CareerComponent>, ICareerComponentRepository
    {
        private readonly NobelContext _context;

        public CareerComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<CareerComponent> GetBySlugAsync(string slug)
        {
            return await _context.CareerComponents.FirstOrDefaultAsync(sc => sc.Slug == slug);
        }
    }
}
