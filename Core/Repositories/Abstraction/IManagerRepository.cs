using Core.Constants;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IManagerRepository : IRepository<Manager>
    {
        Task<List<Manager>> GetAllByType(ManagerType type);
    }
}
