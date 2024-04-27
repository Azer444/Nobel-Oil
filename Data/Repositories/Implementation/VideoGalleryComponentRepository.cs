using Core.Models;
using Core.Repositories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class VideoGalleryComponentRepository : Repository<VideoGalleryComponent>, IVideoGalleryComponentRepository
    {
        private readonly NobelContext _context;

        public VideoGalleryComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<VideoGalleryComponent>> GetAllForMedia()
        {
            return await _context.VideoGalleryComponents.OrderBy(gc => gc.Order).ToListAsync();
        }
    }
}
