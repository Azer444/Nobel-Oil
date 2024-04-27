using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class BoardDirectorComponentRepository : Repository<BoardDirectorComponent>, IBoardDirectorComponentRepository
    {
        private readonly NobelContext _context;

        public BoardDirectorComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<BoardDirectorComponent> GetAsync()
        {
            return await _context.BoardDirectorComponent.FirstOrDefaultAsync();
        }
    }
}
