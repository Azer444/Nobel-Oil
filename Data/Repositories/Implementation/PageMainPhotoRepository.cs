using Core.Constants;
using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class PageMainPhotoRepository : Repository<PageMainPhoto>, IPageMainPhotoRepository
    {
        private readonly NobelContext _context;

        public PageMainPhotoRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<PageMainPhoto> GetByPageAsync(Page page)
        {
            return await _context.PageMainPhotos.FirstOrDefaultAsync(p => p.Page == page);
        }
    }
}
