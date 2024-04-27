using Core;
using Manage.MiddlewareFilters;
using Manage.ViewModels.LegalNotice;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class LegalNoticeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LegalNoticeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var legalNoticeComponent = await _unitOfWork.LegalNoticeComponent.GetAsync();
            if (legalNoticeComponent == null) return NotFound();

            var model = new IndexViewModel
            {
                LegalNoticeComponent = legalNoticeComponent
            };

            return View(model);
        }

    }
}
