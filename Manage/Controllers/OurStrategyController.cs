using Core;
using Manage.MiddlewareFilters;
using Manage.ViewModels.OurStrategy;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class OurStrategyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OurStrategyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel
            {
                OurStrategyComponents = await _unitOfWork.OurStrategyComponents.GetAllAsync(),
                KeyAreaComponents = await _unitOfWork.KeyAreaComponents.GetAllAsync()
            };

            return View(model);
        }
    }
}
