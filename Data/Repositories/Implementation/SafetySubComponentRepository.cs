using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class SafetySubComponentRepository : Repository<SafetySubComponent>, ISafetySubComponentRepository
    {
        private readonly NobelContext _context;

        public SafetySubComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<SafetySubComponent> GetAsync(int? id)
        {
            return await _context.SafetySubComponents
                                                .Include(sc => sc.SafetySubComponentPhotos)
                                                .FirstOrDefaultAsync(sc => sc.Id == id);
        }

        public async Task<SafetySubComponent> GetBySlugAsync(string slug)
        {
            return await _context.SafetySubComponents
                                                .Include(sc => sc.SafetySubComponentPhotos)
                                                .FirstOrDefaultAsync(sc => sc.Slug == slug);
        }

        public async Task<SafetySubComponent> PrepareSplitedContentsAsync(SafetySubComponent safetySubComponent)
        {
            if (safetySubComponent.Content_AZ != null)
            {
                List<string> splitedContent_AZ = new List<string>();

                splitedContent_AZ.AddRange(safetySubComponent.Content_AZ.Split("<p>[break]</p>"));
                safetySubComponent.SplitedContent_AZ = splitedContent_AZ;
            }

            if (safetySubComponent.Content_RU != null)
            {
                List<string> splitedContent_RU = new List<string>();

                splitedContent_RU.AddRange(safetySubComponent.Content_RU.Split("<p>[break]</p>"));
                safetySubComponent.SplitedContent_RU = splitedContent_RU;
            }

            List<string> splitedContent_EN = new List<string>();

            splitedContent_EN.AddRange(safetySubComponent.Content_EN.Split("<p>[break]</p>"));
            safetySubComponent.SplitedContent_EN = splitedContent_EN;

            if (safetySubComponent.Content_TR != null)
            {
                List<string> splitedContent_TR = new List<string>();

                splitedContent_TR.AddRange(safetySubComponent.Content_TR.Split("<p>[break]</p>"));
                safetySubComponent.SplitedContent_TR = splitedContent_TR;
            }

            return safetySubComponent;
        }
    }
}
