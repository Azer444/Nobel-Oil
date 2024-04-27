﻿using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class SustainableDevelopmentRepository : Repository<SustainableDevelopment>, ISustainableDevelopmentRepository
    {
        private readonly NobelContext _context;

        public SustainableDevelopmentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<SustainableDevelopment> GetAsync()
        {
            return await _context.SustainableDevelopment.FirstOrDefaultAsync();
        }
    }
}