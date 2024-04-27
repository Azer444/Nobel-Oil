using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class LegalNoticeComponentRepository : Repository<LegalNoticeComponent>, ILegalNoticeComponentRepository
    {
        private readonly NobelContext _context;

        public LegalNoticeComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<LegalNoticeComponent> GetAsync()
        {
            return await _context.LegalNoticeComponent.FirstOrDefaultAsync();
        }
    }
}
