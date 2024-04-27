using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class VacancyRepository : Repository<Vacancy>, IVacancyRepository
    {
        private readonly NobelContext _context;

        public VacancyRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Vacancy>> GetAllValidVacancies()
        {
            var dateTimeNow = DateTime.UtcNow;

            return await _context.Vacancies.Where(v => v.StartDate < dateTimeNow && v.EndDate > dateTimeNow).ToListAsync();
        }
    }
}
