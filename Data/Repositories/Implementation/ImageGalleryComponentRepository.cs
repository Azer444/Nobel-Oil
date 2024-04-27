using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class ImageGalleryComponentRepository : Repository<ImageGalleryComponent>, IImageGalleryComponentRepository
    {
        private readonly NobelContext _context;

        public ImageGalleryComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public override Task<ImageGalleryComponent> GetAsync(int? id)
        {
            return _context.ImageGalleryComponents
                                                  .Include(gc => gc.ImageGalleryComponentPhotos)
                                                  .FirstOrDefaultAsync(gc => gc.Id == id);
        }

        public Task<ImageGalleryComponent> GetBySlugAsync(string slug)
        {
            return _context.ImageGalleryComponents
                                                   .Include(gc => gc.ImageGalleryComponentPhotos)
                                                   .FirstOrDefaultAsync(gc => gc.Slug == slug);
        }
    }
}
