using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Implementation
{
    public class EthicsComplianceSubComponentPdfsRepostiory : Repository<EthicsComplianceSubComponentPdf>, IEthicsComplianceSubComponentPdfsRepostiory
    {
        private readonly NobelContext _context;

        public EthicsComplianceSubComponentPdfsRepostiory(NobelContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<EthicsComplianceSubComponentPdf>> GetRelatedPDFs(int ethicsComplianceSubComponentId, Core.Constants.Language language)
        {
            return await _context.EthicsComplianceSubComponentPdfs
                .Where(scp => scp.EthicsComplianceSubComponentId == ethicsComplianceSubComponentId && scp.Language == language)
                .ToListAsync();
        }
    }
}
