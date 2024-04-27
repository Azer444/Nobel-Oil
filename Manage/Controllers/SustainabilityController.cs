using Core;
using Core.Models;
using Manage.MiddlewareFilters;
using Manage.ViewModels.Sustainability;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class SustainabilityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SustainabilityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 3;
            var sustainabilityReportComponent = await _unitOfWork.SustainabilityReport.GetAllAsync();
            if (sustainabilityReportComponent == null) return NotFound();

            var pager = new Pager(sustainabilityReportComponent.Count, page, pageSize);
            sustainabilityReportComponent = sustainabilityReportComponent.Skip(pager.RecSkip).Take(pager.PageSize).ToList();

            var model = new IndexViewModel()
            {
                SustainabilityReports = sustainabilityReportComponent,
                Pager = pager
            };
            return View(model);
        }
    }
}
