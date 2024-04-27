using Core;
using Manage.MiddlewareFilters;
using Manage.ViewModels.Environment;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class EnvironmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnvironmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var environmentSubComponents = await _unitOfWork.EnvironmentSubComponent.GetAllAsync();
            if (environmentSubComponents == null) return NotFound();

            var model = new IndexViewModel
            {
                EnvironmentSubComponents = environmentSubComponents
            };

            return View(model);
        }


        [HttpGet("{culture}/environment/{slug}")]
        public async Task<IActionResult> Component(string slug)
        {
            var environmentSubComponent = await _unitOfWork.EnvironmentSubComponent.GetBySlugAsync(slug);
            if (environmentSubComponent == null) return NotFound();

            var model = new ComponentViewModel
            {
                EnvironmentSubComponent = await _unitOfWork.EnvironmentSubComponent.PrepareSplitedContentsAsync(environmentSubComponent)
            };

            return View(model);
        }
    }
}
