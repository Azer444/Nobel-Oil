using Core;
using Manage.MiddlewareFilters;
using Manage.ViewModels.NobelHeritage;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class NobelHeritageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public NobelHeritageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var nobelHeritage = await _unitOfWork.NobelHeritage.GetAsync();
            if (nobelHeritage == null) return NotFound();

            var model = new IndexViewModel()
            {
                NobelHeritageComponent = await _unitOfWork.NobelHeritage.PrepareSplitedContentsAsync(nobelHeritage),
                Testimonials = await _unitOfWork.Testimonials.GetAllAsync(),
            };

            return View(model);
        }
    }
}
