using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class NobelHeritageRepository : Repository<NobelHeritage>, INobelHeritageRepository
    {
        private readonly NobelContext _context;

        public NobelHeritageRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<NobelHeritage> GetAsync()
        {
            return await _context.NobelHeritages
                                    .Include(nh => nh.NobelHeritagePhotos)
                                    .FirstOrDefaultAsync();
        }

        public async Task<NobelHeritage> PrepareSplitedContentsAsync(NobelHeritage nobelHeritage)
        {
            if (nobelHeritage.Content_AZ != null)
            {
                List<string> splitedContent_AZ = new List<string>();

                splitedContent_AZ.AddRange(nobelHeritage.Content_AZ.Split("<p>[break]</p>"));
                nobelHeritage.SplitedContent_AZ = splitedContent_AZ;
            }

            if (nobelHeritage.Content_RU != null)
            {
                List<string> splitedContent_RU = new List<string>();

                splitedContent_RU.AddRange(nobelHeritage.Content_RU.Split("<p>[break]</p>"));
                nobelHeritage.SplitedContent_RU = splitedContent_RU;
            }

            List<string> splitedContent_EN = new List<string>();

            splitedContent_EN.AddRange(nobelHeritage.Content_EN.Split("<p>[break]</p>"));
            nobelHeritage.SplitedContent_EN = splitedContent_EN;

            if (nobelHeritage.Content_TR != null)
            {
                List<string> splitedContent_TR = new List<string>();

                splitedContent_TR.AddRange(nobelHeritage.Content_TR.Split("<p>[break]</p>"));
                nobelHeritage.SplitedContent_TR = splitedContent_TR;
            }

            return nobelHeritage;
        }
    }
}
