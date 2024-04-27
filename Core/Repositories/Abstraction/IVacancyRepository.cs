using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IVacancyRepository : IRepository<Vacancy>
    {
        Task<List<Vacancy>> GetAllValidVacancies();
    }
}
