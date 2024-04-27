using Core.Models;
using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.PageManagement.EthicsCompliance
{
    public class EthicsComplianceIndexViewModel
    {
        public EthicsComplianceComponent EthicsComplianceComponent { get; set; }

        public List<EthicsComplianceSubComponent> EthicsComplianceSubComponents { get; set; }
    }
}
