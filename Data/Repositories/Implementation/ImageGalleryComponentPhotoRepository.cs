using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class ImageGalleryComponentPhotoRepository : Repository<ImageGalleryComponentPhoto>, IImageGalleryComponentPhotoRepository
    {
        private readonly NobelContext _context;

        public ImageGalleryComponentPhotoRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
