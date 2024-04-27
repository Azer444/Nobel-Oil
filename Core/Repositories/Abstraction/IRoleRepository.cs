using Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAll();
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByIdAsync(string roleId);
    }
}
