using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ICareerComponentRepository : IRepository<CareerComponent>
    {
        Task<CareerComponent> GetBySlugAsync(string slug);
    }
}
