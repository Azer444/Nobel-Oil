using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ICarouselRepository : IRepository<Carousel>
    {
        Task<List<Carousel>> GetAllForHome();
    }
}
