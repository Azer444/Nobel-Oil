using Core.Models;
using Core.Repositories.Abstraction;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleRepository(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public IQueryable<Role> GetAll()
        {
            return _roleManager.Roles;
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public async Task<Role> FindByIdAsync(string roleId)
        {
            return await _roleManager.FindByIdAsync(roleId);
        }
    }
}
