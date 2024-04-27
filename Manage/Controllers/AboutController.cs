using Core;
using Manage.MiddlewareFilters;
using Manage.ViewModels.About;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class AboutController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AboutController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel()
            {
                AboutComponent = await _unitOfWork.AboutComponent.GetAsync(),
            };

            return View(model);
        }
    }
}
