using Core;
using Manage.MiddlewareFilters;
using Manage.ViewModels.History;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class HistoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HistoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var historyComponents = await _unitOfWork.HistoryComponent.GetAllByOrderAsync();
            if (historyComponents == null) return NotFound();

            var model = new IndexViewModel()
            {
                HistoryComponents = historyComponents,
            };

            return View(model);
        }
    }
}
