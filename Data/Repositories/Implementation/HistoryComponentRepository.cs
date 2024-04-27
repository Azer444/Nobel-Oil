using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class HistoryComponentRepository : Repository<HistoryComponent>, IHistoryComponentRepository
    {
        private NobelContext _context;

        public HistoryComponentRepository(NobelContext context)
           : base(context)
        {
            _context = context;
        }

        public async virtual Task<List<HistoryComponent>> GetAllByOrderAsync()
        {
            return await _context.HistoryComponents.OrderBy(hc => hc.Order).ToListAsync();
        }
    }
}
