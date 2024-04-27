using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class EnvironmentSubComponentPhotoRepository : Repository<EnvironmentSubComponentPhoto>, IEnvironmentSubComponentPhotoRepository
    {
        public EnvironmentSubComponentPhotoRepository(NobelContext context)
            : base(context)
        {

        }
    }
}
