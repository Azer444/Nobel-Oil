using Core;
using Core.Constants;
using Manage.MiddlewareFilters;
using Manage.ViewModels.ExecutiveManagement;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class ExecutiveManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExecutiveManagementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var executiveManagers = await _unitOfWork.Managers.GetAllByType(ManagerType.Executive);
            if (executiveManagers == null) return NotFound();

            var executiveManagerComponent = await _unitOfWork.ExecutiveManagementComponent.GetAsync();
            if (executiveManagerComponent == null) return NotFound();

            var model = new IndexViewModel()
            {
                ExecutiveManagers = executiveManagers,
                ExecutiveManagementComponent = executiveManagerComponent
            };

            return View(model);
        }
    }
}
