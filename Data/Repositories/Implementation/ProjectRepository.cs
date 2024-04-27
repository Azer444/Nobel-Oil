using Core.Extensions;
using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly NobelContext _context;

        public ProjectRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllForHome()
        {
            return await _context.Projects.Where(n => n.ShowOnHome).OrderBy(c => c.CreatedAt).ToListAsync();
        }

        public string GenerateSlug(string title, Project project)
        {
            StringBuilder slug = new StringBuilder(title.Slugify());
            return slug.Append("-" + project.Id).ToString();
        }

        public async Task<Project> GetBySlugAsync(string slug)
        {
            return await _context.Projects.FirstOrDefaultAsync(n => n.Slug == slug);
        }
    }
}
