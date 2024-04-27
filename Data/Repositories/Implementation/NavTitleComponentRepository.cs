using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class NavTitleComponentRepository : Repository<NavTitleComponent>, INavTitleComponentRepository
    {
        private readonly NobelContext db;

        public NavTitleComponentRepository(NobelContext db)
            : base(db)
        {
            this.db = db;
        }

        public async override Task<List<NavTitleComponent>> GetAllAsync()
        {
            var navTitleComponents = await db.NavTitleComponents
                                                            .OrderBy(n => n.Order)
                                                            .Include(c => c.NavComponents)
                                                            .ThenInclude(c => c.NavSubComponents)
                                                            .ToListAsync();
            return navTitleComponents;
        }

        public async Task<List<NavTitleComponent>> GetAllForHeaderByIsActiveAsync()
        {
            var navTitleComponents = await db.NavTitleComponents
                                                 .Where(ntc => !ntc.ShowOnlyOnFooter)
                                                 .OrderBy(n => n.Order)
                                                .Include(c => c.NavComponents.Where(d => d.IsActive))
                                                .ThenInclude(c => c.NavSubComponents.Where(d => d.IsActive)).ToListAsync();
            return navTitleComponents;
        }

        public async Task<List<NavTitleComponent>> GetAllForHeaderAsync()
        {
            var navTitleComponents = await db.NavTitleComponents
                                                            .Where(ntc => !ntc.ShowOnlyOnFooter)
                                                            .OrderBy(n => n.Order)
                                                            .Include(c => c.NavComponents)
                                                            .ThenInclude(c => c.NavSubComponents)
                                                            .ToListAsync();
            return navTitleComponents;
        }

        public async override Task<NavTitleComponent> GetAsync(int? id)
        {
            var navTitleComponent = await db.NavTitleComponents
                                                        .Include(c => c.NavComponents)
                                                        .ThenInclude(c => c.NavSubComponents)
                                                        .FirstOrDefaultAsync(c => c.Id == id);
            return navTitleComponent;
        }
    }
}
