using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class CarouselRepository : Repository<Carousel>, ICarouselRepository
    {
        private readonly NobelContext _context;

        public CarouselRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Carousel>> GetAllForHome()
        {
            return await _context.Carousels.Where(c => c.IsActive).OrderBy(c => c.Order).ToListAsync();
        }
    }


}
