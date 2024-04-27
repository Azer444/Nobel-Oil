using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IVideoGalleryComponentRepository : IRepository<VideoGalleryComponent>
    {
        Task<List<VideoGalleryComponent>> GetAllForMedia();
    }
}
