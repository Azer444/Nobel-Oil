using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class OurBusinessRepository : Repository<OurBusiness>, IOurBusinessRepository
    {
        private readonly NobelContext _context;

        public OurBusinessRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<OurBusiness>> GetAllForHome()
        {
            return await _context.OurBusinesses.OrderBy(ob => ob.CreatedAt).ToListAsync();
        }
    }
}
