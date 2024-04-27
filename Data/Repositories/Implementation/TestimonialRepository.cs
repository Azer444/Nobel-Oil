using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class TestimonialRepository : Repository<Testimonial>, ITestimonialRepository
    {
        private readonly NobelContext _context;

        public TestimonialRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
