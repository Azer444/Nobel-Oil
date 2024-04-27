using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class KeyAreaComponentRepository : Repository<KeyAreaComponent>, IKeyAreaComponentRepository
    {
        public KeyAreaComponentRepository(NobelContext context)
            : base(context)
        {

        }
    }
}
