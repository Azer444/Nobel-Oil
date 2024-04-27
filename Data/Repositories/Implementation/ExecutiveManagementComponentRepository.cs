using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class ExecutiveManagementComponentRepository : Repository<ExecutiveManagementComponent>, IExecutiveManagementComponentRepository
    {
        private readonly NobelContext _context;

        public ExecutiveManagementComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<ExecutiveManagementComponent> GetAsync()
        {
            return await _context.ExecutiveManagementComponent.FirstOrDefaultAsync();
        }
    }
}
