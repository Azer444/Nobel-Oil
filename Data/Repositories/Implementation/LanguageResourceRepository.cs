using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class LanguageResourceRepository : ILanguageResourceRepository
    {
        private readonly NobelContext _context;

        public LanguageResourceRepository(NobelContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageResource>> GetAllAsync()
        {
            return await _context.LanguageResources.ToListAsync();
        }

        public async Task<LanguageResource> GetAsync(int? id)
        {
            return await _context.LanguageResources.FindAsync(id);
        }

        public async Task EditAsync(LanguageResource languageResource)
        {
            _context.LanguageResources.Attach(languageResource);
            _context.Entry(languageResource).State = EntityState.Modified;
        }

        public async Task<string> GetByKeyAsync(string key, string lang)
        {
            try
            {
                return (await _context.LanguageResources.FirstOrDefaultAsync(lr => lr.ContentKey == key)).GetType().GetProperty("Content" + "_" + lang.ToUpper()).GetValue(await _context.LanguageResources.FirstOrDefaultAsync(lr => lr.ContentKey == key), null).ToString();
            }
            catch (NullReferenceException e)
            {
                return string.Empty;
            }
        }
    }
}
