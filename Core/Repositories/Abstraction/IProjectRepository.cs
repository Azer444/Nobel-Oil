using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<Project>> GetAllForHome();
        string GenerateSlug(string title, Project project);
        Task<Project> GetBySlugAsync(string slug);
    }
}
