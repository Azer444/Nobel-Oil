using Core;
using Manage.MiddlewareFilters;
using Manage.ViewModels.CorporateGovernance;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class CorporateGovernanceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CorporateGovernanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var corporateGovernanceComponent = await _unitOfWork.CorporateGovernanceComponent.GetAsync();
            if (corporateGovernanceComponent == null) return NotFound();

            var boardDirectorComponent = await _unitOfWork.BoardDirectorComponent.GetAsync();
            if (boardDirectorComponent == null) return NotFound();

            var executiveManagementComponent = await _unitOfWork.ExecutiveManagementComponent.GetAsync();
            if (executiveManagementComponent == null) return NotFound();

            var model = new IndexViewModel()
            {
                CorporateGovernanceComponent = corporateGovernanceComponent,
                BoardDirectorComponent = boardDirectorComponent,
                ExecutiveManagementComponent = executiveManagementComponent
            };

            return View(model);
        }
    }
}
