using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ICareerTipComponentRepository : IRepository<CareerTipComponent>
    {
        Task<List<CareerTipComponent>> GetForCareerMainPage();
    }
}
