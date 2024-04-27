using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class CompanyServiceRepository : Repository<CompanyService>, ICompanyServiceRepository
    {
        private readonly NobelContext _context;

        public CompanyServiceRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
