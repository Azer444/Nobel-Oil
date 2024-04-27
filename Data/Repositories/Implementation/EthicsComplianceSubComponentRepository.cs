using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class EthicsComplianceSubComponentRepository : Repository<EthicsComplianceSubComponent>, IEthicsComplianceSubComponentRepository
    {
        private readonly NobelContext _context;

        public EthicsComplianceSubComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<EthicsComplianceSubComponent> GetAsync(int? id)
        {
            return await _context.EthicsComplianceSubComponents
                                                .Include(sc => sc.EthicsComplianceSubComponentPdfs)
                                                .FirstOrDefaultAsync(sc => sc.Id == id);
        }

        public async Task<EthicsComplianceSubComponent> GetBySlugAsync(string slug)
        {
            return await _context.EthicsComplianceSubComponents.FirstOrDefaultAsync(sc => sc.Slug == slug);
        }

        public async Task<EthicsComplianceSubComponent> PrepareSplitedContentsAsync(EthicsComplianceSubComponent ethicsComplianceSubComponent)
        {
            if (ethicsComplianceSubComponent.Content_AZ != null)
            {
                List<string> splitedContent_AZ = new List<string>();

                splitedContent_AZ.AddRange(ethicsComplianceSubComponent.Content_AZ.Split("<p>[break]</p>"));
                ethicsComplianceSubComponent.SplitedContent_AZ = splitedContent_AZ;
            }

            if (ethicsComplianceSubComponent.Content_RU != null)
            {
                List<string> splitedContent_RU = new List<string>();

                splitedContent_RU.AddRange(ethicsComplianceSubComponent.Content_RU.Split("<p>[break]</p>"));
                ethicsComplianceSubComponent.SplitedContent_RU = splitedContent_RU;
            }

            List<string> splitedContent_EN = new List<string>();

            splitedContent_EN.AddRange(ethicsComplianceSubComponent.Content_EN.Split("<p>[break]</p>"));
            ethicsComplianceSubComponent.SplitedContent_EN = splitedContent_EN;

            if (ethicsComplianceSubComponent.Content_TR != null)
            {
                List<string> splitedContent_TR = new List<string>();

                splitedContent_TR.AddRange(ethicsComplianceSubComponent.Content_TR.Split("<p>[break]</p>"));
                ethicsComplianceSubComponent.SplitedContent_TR = splitedContent_TR;
            }

            return ethicsComplianceSubComponent;
        }
    }
}
