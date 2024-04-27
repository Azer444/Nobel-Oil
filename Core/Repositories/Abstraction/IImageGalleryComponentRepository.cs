using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IImageGalleryComponentRepository : IRepository<ImageGalleryComponent>
    {
        Task<ImageGalleryComponent> GetBySlugAsync(string slug);
    }
}
