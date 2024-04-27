using Core;
using Core.Constants;
using Manage.MiddlewareFilters;
using Manage.ViewModels.WhatWeDo;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class WhatWeDoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WhatWeDoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var ourProjectComponent = await _unitOfWork.OurProjectComponent.GetAsync();
            if (ourProjectComponent == null) return NotFound();

            var ourBusinesses = await _unitOfWork.OurBusinesses.GetAllAsync();
            if (ourBusinesses == null) return NotFound();

            var model = new IndexViewModel()
            {
                OurBusinesses = ourBusinesses,
                OurProjectComponent = ourProjectComponent,
                Flatpages = await _unitOfWork.Flatpages.GetAllByPageAsync(Page.WhatWeDo),
                DynamicPages = await _unitOfWork.DynamicPages.GetAllByPageAsync(Page.WhatWeDo)
            };

            return View(model);
        }
    }
}
