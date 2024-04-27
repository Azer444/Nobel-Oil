using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class CommunityComponentRepository : Repository<CommunityComponent>, ICommunityComponentRepository
    {
        private readonly NobelContext _context;

        public CommunityComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<CommunityComponent> GetAsync()
        {
            return await _context.CommunityComponent
                                    .Include(cc => cc.CommunityComponentPhotos)
                                    .FirstOrDefaultAsync();
        }

        public async Task<CommunityComponent> PrepareSplitedContentsAsync(CommunityComponent communityComponent)
        {
            if (communityComponent.Content_AZ != null)
            {
                List<string> splitedContent_AZ = new List<string>();

                splitedContent_AZ.AddRange(communityComponent.Content_AZ.Split("<p>[break]</p>"));
                communityComponent.SplitedContent_AZ = splitedContent_AZ;
            }

            if (communityComponent.Content_RU != null)
            {
                List<string> splitedContent_RU = new List<string>();

                splitedContent_RU.AddRange(communityComponent.Content_RU.Split("<p>[break]</p>"));
                communityComponent.SplitedContent_RU = splitedContent_RU;
            }

            List<string> splitedContent_EN = new List<string>();

            splitedContent_EN.AddRange(communityComponent.Content_EN.Split("<p>[break]</p>"));
            communityComponent.SplitedContent_EN = splitedContent_EN;

            if (communityComponent.Content_TR != null)
            {
                List<string> splitedContent_TR = new List<string>();

                splitedContent_TR.AddRange(communityComponent.Content_TR.Split("<p>[break]</p>"));
                communityComponent.SplitedContent_TR = splitedContent_TR;
            }

            return communityComponent;
        }
    }
}
