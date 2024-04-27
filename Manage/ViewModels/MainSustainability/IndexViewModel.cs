using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.MainSustainability
{
    public class IndexViewModel
    {
        public MainSustainabilityReport MainSustainabilityReportComponent { get; set; }
        public SustainableDevelopment SustainableDevelopmentComponent { get; set; }
        public SafetyComponent SafetyComponent { get; set; }
        public EnvironmentComponent EnvironmentComponent { get; set; }
        public HumanResourceComponent HumanResourceComponent { get; set; }
        public CommunityComponent CommunityComponent { get; set; }
        public EthicsComplianceComponent EthicsComplianceComponent { get; set; }
        public List<Flatpage> Flatpages { get; set; }
    }
}
