using Core;
using Core.Constants;
using Manage.MiddlewareFilters;
using Manage.ViewModels.MainSustainability;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class MainSustainabilityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MainSustainabilityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {

            var sustainabilityDevelopmentComponent = await _unitOfWork.SustainableDevelopment.GetAsync();
            if (sustainabilityDevelopmentComponent == null) return NotFound();

            var safetyComponent = await _unitOfWork.SafetyComponent.GetAsync();
            if (safetyComponent == null) return NotFound();

            var environmentComponent = await _unitOfWork.EnvironmentComponent.GetAsync();
            if (environmentComponent == null) return NotFound();

            var humanResourceComponent = await _unitOfWork.HumanResourceComponent.GetAsync();
            if (humanResourceComponent == null) return NotFound();

            var communityComponent = await _unitOfWork.CommunityComponent.GetAsync();
            if (communityComponent == null) return NotFound();

            var ethicsComplianceComponent = await _unitOfWork.EthicsComplianceComponent.GetAsync();
            if (ethicsComplianceComponent == null) return NotFound();


            var model = new IndexViewModel()
            {
                MainSustainabilityReportComponent = await _unitOfWork.MainSustainabilityReport.GetAsync(),
                SustainableDevelopmentComponent = sustainabilityDevelopmentComponent,
                SafetyComponent = safetyComponent,
                EnvironmentComponent = environmentComponent,
                HumanResourceComponent = humanResourceComponent,
                CommunityComponent = communityComponent,
                EthicsComplianceComponent = ethicsComplianceComponent,
                Flatpages = await _unitOfWork.Flatpages.GetAllByPageAsync(Page.Sustainability)
            };

            return View(model);
        }

        public async Task<IActionResult> DevelopmentGoals()
        {
            var sustainableDevelopmentGoals = await _unitOfWork.SustainableGoals.GetAllAsync();
            return View(sustainableDevelopmentGoals);
        }
    }
}
