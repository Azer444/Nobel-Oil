using Core;
using Manage.MiddlewareFilters;
using Manage.ViewModels.HumanResource;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class HumanResourceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HumanResourceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{culture}/[controller]")]
        public async Task<IActionResult> Component()
        {
            var humanResourceComponent = await _unitOfWork.HumanResourceComponent.GetAsync();
            if (humanResourceComponent == null) return NotFound();

            var model = new ComponentViewModel
            {
                HumanResourceComponent = await _unitOfWork.HumanResourceComponent.PrepareSplitedContentsAsync(humanResourceComponent)
            };

            return View(model);
        }
    }
}
