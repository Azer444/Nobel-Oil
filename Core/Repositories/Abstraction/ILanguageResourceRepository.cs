using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ILanguageResourceRepository
    {
        Task<string> GetByKeyAsync(string key, string lang);
        Task<List<LanguageResource>> GetAllAsync();
        Task<LanguageResource> GetAsync(int? id);
        Task EditAsync(LanguageResource languageResource);
    }
}
