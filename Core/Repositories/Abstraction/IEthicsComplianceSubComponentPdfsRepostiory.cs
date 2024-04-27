using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories.Abstraction
{
    public interface IEthicsComplianceSubComponentPdfsRepostiory : IRepository<EthicsComplianceSubComponentPdf>
    {
        Task<List<EthicsComplianceSubComponentPdf>> GetRelatedPDFs(int ethicsComplianceSubComponentId, Core.Constants.Language language);
    }
}
