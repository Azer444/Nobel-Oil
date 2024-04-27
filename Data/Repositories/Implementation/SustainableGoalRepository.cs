using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class SustainableGoalRepository : Repository<SustainableGoal>, ISustainableGoalRepository
    {
        private readonly NobelContext _context;

        public SustainableGoalRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
