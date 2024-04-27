using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IOurBusinessRepository : IRepository<OurBusiness>
    {
        Task<List<OurBusiness>> GetAllForHome();
    }
}
