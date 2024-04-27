using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class SafetySubComponentPhotoRepository : Repository<SafetySubComponentPhoto>, ISafetySubComponentPhotoRepository
    {
        private readonly NobelContext _context;

        public SafetySubComponentPhotoRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
