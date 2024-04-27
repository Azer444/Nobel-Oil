using Core.Constants;
using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class ManagerRepository : Repository<Manager>, IManagerRepository
    {
        private readonly NobelContext _context;

        public ManagerRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Manager>> GetAllByType(ManagerType type)
        {
            return await _context.Managers.Where(m => m.Type == type).ToListAsync();
        }
    }
}
