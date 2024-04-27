using Core;
using Core.Constants;
using Core.Constants.File;
using Core.Models;
using Manage.MiddlewareFilters;
using Manage.Tools.FileHandler.Abstraction;
using Manage.ViewModels.Career;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class CareerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public CareerController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            var careerComponents = await _unitOfWork.CareerComponent.GetAllAsync();
            if (careerComponents == null) return NotFound();

            var careerTipComponents = await _unitOfWork.CareerTipComponent.GetForCareerMainPage();
            if (careerTipComponents == null) return NotFound();

            var companies = await _unitOfWork.Companies.GetAllForCareer();
            if (companies == null) return NotFound();


            var model = new IndexViewModel()
            {
                CareerComponents = careerComponents,
                CareerTipComponents = careerTipComponents,
                Companies = companies,
                Flatpages = await _unitOfWork.Flatpages.GetAllByPageAsync(Page.Career),
                DynamicPages = await _unitOfWork.DynamicPages.GetAllByPageAsync(Page.Career)
            };

            return View(model);
        }

        [HttpGet("{culture}/career/{slug}")]
        public async Task<IActionResult> Component(string slug)
        {
            var careerComponent = await _unitOfWork.CareerComponent.GetBySlugAsync(slug);
            if (careerComponent == null) return NotFound();

            var model = new ComponentViewModel
            {
                CareerComponent = careerComponent,
                Vacancies = await _unitOfWork.Vacancy.GetAllValidVacancies(),
                VacancyApply = new VacancyApplyViewComponentViewModel()
            };

            return View(model);
        }

        public async Task<IActionResult> Tip(int id)
        {
            var careerTipComponent = await _unitOfWork.CareerTipComponent.GetAsync(id);
            if (careerTipComponent == null) return NotFound();

            var model = new CareerTipDetailViewModel
            {
                CareerTipComponent = careerTipComponent
            };

            return View(model);
        }
        [HttpPost("{culture}/career/apply")]
        public async Task<IActionResult> Apply(ComponentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var vacancyApply = new VacancyApply
                {
                    FullName = model.VacancyApply.FullName,
                    Email = model.VacancyApply.Email,
                    CVName = await _fileService.UploadFileAsync(model.VacancyApply.CV, FilePath.Apply),
                    VacancyId = model.VacancyApply.VacancyId,
                };

                await _unitOfWork.VacancyApplies.CreateAsync(vacancyApply);
                await _unitOfWork.CommitAsync();

                foreach (var supportingFile in model.VacancyApply.SupportingFiles)
                {
                    var vacancyApplyFile = new VacancyApplyFile
                    {
                        FileName = await _fileService.UploadFileAsync(supportingFile, FilePath.Apply),
                        VacancyApplyId = vacancyApply.Id,
                    };

                    await _unitOfWork.VacancyApplyFiles.CreateAsync(vacancyApplyFile);
                    await _unitOfWork.CommitAsync();
                }

                return Ok();
            }

            return NotFound();
        }

        #region LifeAtNobelEnergy

        [HttpGet("{culture}/career/lifeatnobelenergy")]
        public async Task<IActionResult> LifeAtNobelEnergy(int page = 1)
        {
            const int pageSize = 6;

            var lifeAtNobelEnergies = (await _unitOfWork.LifeAtNobelEnergy.GetAllAsync()).OrderByDescending(pr => pr.ActionDate).ToList();

            var pager = new Pager(lifeAtNobelEnergies.Count, page, pageSize);
            lifeAtNobelEnergies = lifeAtNobelEnergies.Skip(pager.RecSkip).Take(pager.PageSize).ToList();

            var model = new LifeAtNobelEnergyViewModel
            {
                LifeAtNobelEnergies = lifeAtNobelEnergies,
                Pager = pager
            };

            return View(model);
        }

        [HttpGet("{culture}/career/lifeatnobelenergycomponent/{slug}")]
        public async Task<IActionResult> LifeAtNobelEnergyComponent(string slug)
        {
            var lifeAtNobelEnergy = await _unitOfWork.LifeAtNobelEnergy.GetBySlugAsync(slug);
            if (lifeAtNobelEnergy == null) return NotFound();

            Core.Constants.Language langEnum = _unitOfWork.Languages.GetCurrentThreadLang();

            var model = new LifeAtNobelEnergyComponentViewModel
            {
                LifeAtNobelEnergy = lifeAtNobelEnergy,
                LifeAtNobelEnergies = await _unitOfWork.LifeAtNobelEnergy.GetAllRecentLifeAtNobelEnergyForComponentAsync(lifeAtNobelEnergy.Id),
                LifeAtNobelEnergyPdfs = await _unitOfWork.LifeAtNobelEnergyPdf.GetAllByLifeAtNobelEnergyPdfIdAsync(lifeAtNobelEnergy.Id, langEnum)
            };

            return View(model);
        }

        #endregion LifeAtNobelEnergy
    }
}
