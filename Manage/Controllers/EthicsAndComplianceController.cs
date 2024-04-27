using Core;
using Core.Constants;
using Manage.MiddlewareFilters;
using Manage.ViewModels.EthicsAndCompilance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class EthicsAndComplianceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EthicsAndComplianceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ethicsComplianceSubComponents = await _unitOfWork.EthicsComplianceSubComponent.GetAllAsync();
            if (ethicsComplianceSubComponents == null) return NotFound();

            var model = new IndexViewModel
            {
                EthicsComplianceSubComponents = ethicsComplianceSubComponents
            };

            return View(model);
        }


        [HttpGet("{culture}/ethicsandcompliance/{slug}")]
        public async Task<IActionResult> Component(string slug)
        {
            var subComponent = await _unitOfWork.EthicsComplianceSubComponent.GetBySlugAsync(slug);
            if (subComponent == null) return NotFound();

            var currentLang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var currentLangEnum = Enum.Parse<Language>(currentLang.ToUpperInvariant());

            subComponent.EthicsComplianceSubComponentPdfs = await _unitOfWork.EthicsComplianceSubComponentPdfs.GetRelatedPDFs(subComponent.Id, currentLangEnum);

            var model = new ComponentViewModel
            {
                EthicsComplianceSubComponent = await _unitOfWork.EthicsComplianceSubComponent.PrepareSplitedContentsAsync(subComponent)
            };

            return View(model);
        }
    }
}
