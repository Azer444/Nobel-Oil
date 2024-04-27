using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly NobelContext _context;

        public LanguageRepository(NobelContext context)
        {
            _context = context;
        }

        public async Task<Language> GetByName(string name)
        {
            return await _context.Languages.Where(l => l.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        }

        public Core.Constants.Language GetCurrentThreadLang()
        {
            string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpperInvariant();
            Enum.TryParse(lang, out Core.Constants.Language langEnum);

            return langEnum;
        }

        public async Task<Language> GetById(int id)
        {
            return await _context.Languages.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Language>> GetAll()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<List<string>> GetAllEnabledNames()
        {
            var languages = await _context.Languages.Where(l => l.Enabled)
                .Select(l => l.Name.ToLower())
                .ToListAsync();

            return languages;
        }

        async Task ILanguageRepository.Add(Language language)
        {
            await _context.AddAsync(language);
        }

        public async Task Update(List<Language> languages)
        {
            foreach (var language in languages)
                _context.Update(language);
        }

        public string ChooseLanguage(object obj, string property, string lang)
        {
            try
            {
                return obj.GetType().GetProperty(property + "_" + lang.ToUpper()).GetValue(obj, null).ToString();
            }
            catch (NullReferenceException e)
            {
                return string.Empty;
            }
        }

        public List<string> ChooseLanguageList(object obj, string property, string lang)
        {
            try
            {
                return (List<string>)obj.GetType().GetProperty(property + "_" + lang.ToUpperInvariant()).GetValue(obj, null);
            }
            catch (NullReferenceException e)
            {
                return new List<string>();
            }
        }

        public List<T> ChooseLanguageList<T>(object obj, string property, string lang)
        {
            try
            {
                return (List<T>)obj.GetType().GetProperty(property + "_" + lang.ToUpperInvariant()).GetValue(obj, null);
            }
            catch (NullReferenceException e)
            {
                return new List<T>();
            }
        }
    }
}
