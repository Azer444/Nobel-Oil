using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class VMVComponentRepository : Repository<VMVComponent>, IVMVComponentRepository
    {
        private readonly NobelContext _context;

        public VMVComponentRepository(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<VMVComponent> GetAsync()
        {
            return await _context.VMVComponent
                                    .Include(vmvc => vmvc.VMVComponentPhotos)
                                    .FirstOrDefaultAsync();
        }

        public async Task<VMVComponent> PrepareSplitedContentsAsync(VMVComponent vmvComponent)
        {
            if (vmvComponent.Content_AZ != null)
            {
                List<string> splitedContent_AZ = new List<string>();

                splitedContent_AZ.AddRange(vmvComponent.Content_AZ.Split("<p>[break]</p>"));
                vmvComponent.SplitedContent_AZ = splitedContent_AZ;
            }

            if (vmvComponent.Content_RU != null)
            {
                List<string> splitedContent_RU = new List<string>();

                splitedContent_RU.AddRange(vmvComponent.Content_RU.Split("<p>[break]</p>"));
                vmvComponent.SplitedContent_RU = splitedContent_RU;
            }

            List<string> splitedContent_EN = new List<string>();

            splitedContent_EN.AddRange(vmvComponent.Content_EN.Split("<p>[break]</p>"));
            vmvComponent.SplitedContent_EN = splitedContent_EN;

            if (vmvComponent.Content_TR != null)
            {
                List<string> splitedContent_TR = new List<string>();

                splitedContent_TR.AddRange(vmvComponent.Content_TR.Split("<p>[break]</p>"));
                vmvComponent.SplitedContent_TR = splitedContent_TR;
            }

            return vmvComponent;
        }
    }
}
