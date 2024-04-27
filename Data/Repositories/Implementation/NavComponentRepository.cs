using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class NavComponentRepository : Repository<NavComponent>, INavComponentRepository
    {
        private readonly NobelContext db;

        public NavComponentRepository(NobelContext db)
            : base(db)
        {
            this.db = db;
        }

        public async override Task<NavComponent> GetAsync(int? id)
        {
            var navComponent = await db.NavComponents
                                               .Include(c => c.NavTitleComponent)
                                               .Include(c => c.NavSubComponents)
                                               .FirstOrDefaultAsync(c => c.Id == id);
            return navComponent;
        }
    }
}
