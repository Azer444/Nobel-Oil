using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class ContactMessageRepository : Repository<ContactMessage>, IContactMessageRepository
    {
        private readonly NobelContext _context;

        public ContactMessageRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

    }
}
