using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class CareerTipComponentRepository : Repository<CareerTipComponent>, ICareerTipComponentRepository
    {
        private readonly NobelContext _context;

        public CareerTipComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        //public async Task<Company> GetBySlugAsync(string slug)
        //{
        //    return await _context.CareerTipComponents.Where(ct => ct.)
        //}

        public async Task<List<CareerTipComponent>> GetForCareerMainPage()
        {
            const int COUNT = 3;

            return await _context.CareerTipComponents.Take(COUNT).ToListAsync();
        }


    }
}
