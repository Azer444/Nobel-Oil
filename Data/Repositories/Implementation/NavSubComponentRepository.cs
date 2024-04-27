using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class NavSubComponentRepository : Repository<NavSubComponent>, INavSubComponentRepository
    {
        public NavSubComponentRepository(NobelContext db)
            : base(db)
        {

        }
    }
}
