using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetBySlugAsync(string slug);
        Task<List<Company>> GetAllForCareer();
    }
}
