using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class VacancyApplyFileRepository : Repository<VacancyApplyFile>, IVacancyApplyFileRepository
    {
        private readonly NobelContext _context;

        public VacancyApplyFileRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
