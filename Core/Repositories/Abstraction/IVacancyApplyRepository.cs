using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IVacancyApplyRepository : IRepository<VacancyApply>
    {
        Task<List<VacancyApply>> GetAllByVacancyIdAsync(int vacancyId);
    }
}
