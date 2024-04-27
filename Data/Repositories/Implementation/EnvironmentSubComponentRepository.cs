using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class EnvironmentSubComponentRepository : Repository<EnvironmentSubComponent>, IEnvironmentSubComponentRepository
    {
        private readonly NobelContext _context;

        public EnvironmentSubComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<EnvironmentSubComponent> GetAsync(int? id)
        {
            return await _context.EnvironmentSubComponents
                                                .Include(sc => sc.EnvironmentSubComponentPhotos)
                                                .FirstOrDefaultAsync(sc => sc.Id == id);
        }

        public async Task<EnvironmentSubComponent> GetBySlugAsync(string slug)
        {
            return await _context.EnvironmentSubComponents
                                                .Include(sc => sc.EnvironmentSubComponentPhotos)
                                                .FirstOrDefaultAsync(sc => sc.Slug == slug);
        }

        public async Task<EnvironmentSubComponent> PrepareSplitedContentsAsync(EnvironmentSubComponent environmentSubComponent)
        {
            if (environmentSubComponent.Content_AZ != null)
            {
                List<string> splitedContent_AZ = new List<string>();

                splitedContent_AZ.AddRange(environmentSubComponent.Content_AZ.Split("<p>[break]</p>"));
                environmentSubComponent.SplitedContent_AZ = splitedContent_AZ;
            }

            if (environmentSubComponent.Content_RU != null)
            {
                List<string> splitedContent_RU = new List<string>();

                splitedContent_RU.AddRange(environmentSubComponent.Content_RU.Split("<p>[break]</p>"));
                environmentSubComponent.SplitedContent_RU = splitedContent_RU;
            }

            List<string> splitedContent_EN = new List<string>();

            splitedContent_EN.AddRange(environmentSubComponent.Content_EN.Split("<p>[break]</p>"));
            environmentSubComponent.SplitedContent_EN = splitedContent_EN;

            if (environmentSubComponent.Content_TR != null)
            {
                List<string> splitedContent_TR = new List<string>();

                splitedContent_TR.AddRange(environmentSubComponent.Content_TR.Split("<p>[break]</p>"));
                environmentSubComponent.SplitedContent_TR = splitedContent_TR;
            }

            return environmentSubComponent;
        }
    }
}
