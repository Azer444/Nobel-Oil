using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class VacancyApplyRepository : Repository<VacancyApply>, IVacancyApplyRepository
    {
        private readonly NobelContext _context;

        public VacancyApplyRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<VacancyApply>> GetAllByVacancyIdAsync(int vacancyId)
        {
            return await _context.VacancyApplies
                                                .Where(a => a.VacancyId == vacancyId)
                                                .Include(a => a.VacancyApplyFiles)
                                                .OrderByDescending(a => a.Id)
                                                .ToListAsync();
        }
    }
}
