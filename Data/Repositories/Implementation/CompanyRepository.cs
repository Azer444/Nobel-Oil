using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly NobelContext _context;

        public CompanyRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Company> GetBySlugAsync(string slug)
        {
            return await _context.Companies.FirstOrDefaultAsync(c => c.Slug == slug);
        }

        public async Task<List<Company>> GetAllForCareer()
        {
            const int COUNT = 4;

            return await _context.Companies.Where(c => c.ShowOnCareer).Take(COUNT).ToListAsync();
        }
    }
}
