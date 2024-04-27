using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ILifeAtNobelEnergyRepository : IRepository<LifeAtNobelEnergy>
    {
        Task<LifeAtNobelEnergy> GetBySlugAsync(string slug);

        Task<List<LifeAtNobelEnergy>> GetAllRecentLifeAtNobelEnergyForComponentAsync(int id);
    }
}
