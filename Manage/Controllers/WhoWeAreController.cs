using Core;
using Core.Constants;
using Manage.MiddlewareFilters;
using Manage.ViewModels.WhoWeAre;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class WhoWeAreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WhoWeAreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var aboutComponent = await _unitOfWork.AboutComponent.GetAsync();
            if (aboutComponent == null) return NotFound();

            var vmvComponent = await _unitOfWork.VMVComponent.GetAsync();
            if (vmvComponent == null) return NotFound();

            var nobelHeritage = await _unitOfWork.NobelHeritage.GetAsync();
            if (nobelHeritage == null) return NotFound();

            var ourHistoryComponent = await _unitOfWork.OurHistoryComponent.GetAsync();
            if (ourHistoryComponent == null) return NotFound();

            var corporateGovernanceComponent = await _unitOfWork.CorporateGovernanceComponent.GetAsync();
            if (corporateGovernanceComponent == null) return NotFound();

            var model = new IndexViewModel()
            {
                AboutComponent = aboutComponent,
                VMVComponent = vmvComponent,
                NobelHeritage = nobelHeritage,
                OurHistoryComponent = ourHistoryComponent,
                CorporateGovernanceComponent = corporateGovernanceComponent,
                Flatpages = await _unitOfWork.Flatpages.GetAllByPageAsync(Page.WhoWeAre),
                DynamicPages = await _unitOfWork.DynamicPages.GetAllByPageAsync(Page.WhoWeAre)
            };

            return View(model);
        }
    }
}
