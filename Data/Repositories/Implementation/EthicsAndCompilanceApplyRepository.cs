using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class EthicsAndCompilanceApplyRepository : Repository<EthicsAndCompilanceApply>, IEthicsAndCompilanceApplyRepository
    {
        private readonly NobelContext _context;

        public EthicsAndCompilanceApplyRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
