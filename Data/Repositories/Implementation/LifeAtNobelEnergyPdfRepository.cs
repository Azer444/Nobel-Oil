using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class LifeAtNobelEnergyPdfRepository : Repository<LifeAtNobelEnergyPdf>, ILifeAtNobelEnergyPdfRepository
    {
        private readonly NobelContext _context;

        public LifeAtNobelEnergyPdfRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<LifeAtNobelEnergyPdf>> GetAllByLifeAtNobelEnergyPdfIdAsync(int id)
        {
            return await _context.LifeAtNobelEnergyPdfs
                            .Where(n => n.LifeAtNobelEnergyId == id)
                            .ToListAsync();
        }

        public async Task<List<LifeAtNobelEnergyPdf>> GetAllByLifeAtNobelEnergyPdfIdAsync(int id, Core.Constants.Language language)
        {
            return await _context.LifeAtNobelEnergyPdfs
                            .Where(prp =>
                                prp.LifeAtNobelEnergyId == id &&
                                prp.Language == language)
                            .ToListAsync();
        }
    }
}
