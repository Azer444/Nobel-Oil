using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface ILanguageRepository
    {
        Task<Language> GetByName(string name);
        Task<Language> GetById(int id);
        Task<List<Language>> GetAll();
        Task<List<string>> GetAllEnabledNames();
        Task Add(Language language);
        Task Update(List<Language> languages);
        Core.Constants.Language GetCurrentThreadLang();
        string ChooseLanguage(object obj, string property, string lang);
        List<string> ChooseLanguageList(object obj, string property, string lang);
        List<T> ChooseLanguageList<T>(object obj, string property, string lang);
    }
}
