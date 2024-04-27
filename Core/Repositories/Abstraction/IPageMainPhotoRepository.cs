using Core.Constants;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IPageMainPhotoRepository : IRepository<PageMainPhoto>
    {
        Task<PageMainPhoto> GetByPageAsync(Page page);
    }
}
