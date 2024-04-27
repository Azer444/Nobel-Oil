using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class NobelHeritagePhotoRepository : Repository<NobelHeritagePhoto>, INobelHeritagePhotoRepository
    {
        public NobelHeritagePhotoRepository(NobelContext context)
            : base(context)
        {

        }
    }
}
