using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ILifeAtNobelEnergyPdfRepository : IRepository<LifeAtNobelEnergyPdf>
    {
        Task<List<LifeAtNobelEnergyPdf>> GetAllByLifeAtNobelEnergyPdfIdAsync(int id);
        Task<List<LifeAtNobelEnergyPdf>> GetAllByLifeAtNobelEnergyPdfIdAsync(int id, Constants.Language language);
    }
}
