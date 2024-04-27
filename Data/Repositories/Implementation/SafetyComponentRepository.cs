﻿using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class SafetyComponentRepository : Repository<SafetyComponent>, ISafetyComponentRepository
    {
        private readonly NobelContext _context;

        public SafetyComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<SafetyComponent> GetAsync()
        {
            return await _context.SafetyComponent.FirstOrDefaultAsync();
        }
    }
}
