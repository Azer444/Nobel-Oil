using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class HumanResourceComponentRepository : Repository<HumanResourceComponent>, IHumanResourceComponentRepository
    {
        private readonly NobelContext _context;

        public HumanResourceComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<HumanResourceComponent> GetAsync()
        {
            return await _context.HumanResourceComponent
                                    .Include(hrc => hrc.HumanResourceComponentPhotos)
                                    .FirstOrDefaultAsync();
        }

        public async Task<HumanResourceComponent> PrepareSplitedContentsAsync(HumanResourceComponent humanResourceComponent)
        {
            if (humanResourceComponent.Content_AZ != null)
            {
                List<string> splitedContent_AZ = new List<string>();

                splitedContent_AZ.AddRange(humanResourceComponent.Content_AZ.Split("<p>[break]</p>"));
                humanResourceComponent.SplitedContent_AZ = splitedContent_AZ;
            }

            if (humanResourceComponent.Content_RU != null)
            {
                List<string> splitedContent_RU = new List<string>();

                splitedContent_RU.AddRange(humanResourceComponent.Content_RU.Split("<p>[break]</p>"));
                humanResourceComponent.SplitedContent_RU = splitedContent_RU;
            }

            List<string> splitedContent_EN = new List<string>();

            splitedContent_EN.AddRange(humanResourceComponent.Content_EN.Split("<p>[break]</p>"));
            humanResourceComponent.SplitedContent_EN = splitedContent_EN;

            if (humanResourceComponent.Content_TR != null)
            {
                List<string> splitedContent_TR = new List<string>();

                splitedContent_TR.AddRange(humanResourceComponent.Content_TR.Split("<p>[break]</p>"));
                humanResourceComponent.SplitedContent_TR = splitedContent_TR;
            }

            return humanResourceComponent;
        }
    }
}
