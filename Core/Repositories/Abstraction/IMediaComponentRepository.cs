using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IMediaComponentRepository : IRepository<MediaComponent>
    {
        Task<List<MediaComponent>> GetAllByIsActiveAsync();
    }
}
