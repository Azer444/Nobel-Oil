using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class OurStrategyComponentRepository : Repository<OurStrategyComponent>, IOurStrategyComponentRepository
    {
        public OurStrategyComponentRepository(NobelContext context)
            : base(context)
        {

        }
    }
}
