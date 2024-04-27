using Core;
using Manage.MiddlewareFilters;
using Manage.ViewModels.Safety;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class SafetyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SafetyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var safetyComponents = await _unitOfWork.SafetySubComponent.GetAllAsync();
            if (safetyComponents == null) return NotFound();

            var model = new IndexViewModel
            {
                SafetySubComponents = safetyComponents
            };

            return View(model);
        }


        [HttpGet("{culture}/safety/{slug}")]
        public async Task<IActionResult> Component(string slug)
        {
            var safetySubComponent = await _unitOfWork.SafetySubComponent.GetBySlugAsync(slug);
            if (safetySubComponent == null) return NotFound();

            var model = new ComponentViewModel
            {
                SafetySubComponent = await _unitOfWork.SafetySubComponent.PrepareSplitedContentsAsync(safetySubComponent)
            };

            return View(model);
        }
    }
}
