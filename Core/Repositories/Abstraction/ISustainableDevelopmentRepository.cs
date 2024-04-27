using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ISustainableDevelopmentRepository : IRepository<SustainableDevelopment>
    {
        Task<SustainableDevelopment> GetAsync();
    }
}
