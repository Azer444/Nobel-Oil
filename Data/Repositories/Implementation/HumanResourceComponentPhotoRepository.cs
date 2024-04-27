using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class HumanResourceComponentPhotoRepository : Repository<HumanResourceComponentPhoto>, IHumanResourceComponentPhotoRepository
    {
        public HumanResourceComponentPhotoRepository(NobelContext context)
            : base(context)
        {

        }
    }
}
