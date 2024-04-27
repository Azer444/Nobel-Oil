using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class CommunityComponentPhotoRepository : Repository<CommunityComponentPhoto>, ICommunityComponentPhotoRepository
    {
        public CommunityComponentPhotoRepository(NobelContext context)
            : base(context)
        {

        }
    }
}
