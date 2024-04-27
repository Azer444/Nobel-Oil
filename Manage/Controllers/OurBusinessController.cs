using Core;
using Manage.MiddlewareFilters;
using Manage.ViewModels.OurBusiness;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class OurBusinessController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OurBusinessController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var companies = await _unitOfWork.Companies.GetAllAsync();
            if (companies == null) return NotFound();

            var companyServices = await _unitOfWork.CompanyServices.GetAllAsync();
            if (companyServices == null) return NotFound();

            var model = new IndexViewModel()
            {
                Companies = companies,
                CompanyServices = companyServices
            };

            return View(model);
        }

        [HttpGet("{culture}/ourbusiness/company/{slug}")]
        public async Task<IActionResult> Company(string slug)
        {
            var company = await _unitOfWork.Companies.GetBySlugAsync(slug);
            if (company == null) return NotFound();

            var model = new CompanyDetailViewModel()
            {
                Company = company
            };

            return View(model);
        }
    }
}
