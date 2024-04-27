using Core;
using Manage.MiddlewareFilters;
using Manage.Models;
using Manage.ViewModels.Home;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RequestLocalizationOptions _requestOptions;

        public HomeController(IUnitOfWork unitOfWork, RequestLocalizationOptions requestOptions)
        {
            _unitOfWork = unitOfWork;
            _requestOptions = requestOptions;
        }

        [HttpGet("~/")]
        public IActionResult IndexRedirect()
        {
            var defaultCulture = _requestOptions.DefaultRequestCulture.UICulture.TwoLetterISOLanguageName;
            return RedirectToAction("Index", "Home", new { culture = defaultCulture });
        }

        public async Task<IActionResult> Index()
        {
            var culture = CultureInfo.CurrentUICulture;

            var model = new IndexViewModel()
            {
                Carousels = await _unitOfWork.Carousels.GetAllForHome(),
                News = await _unitOfWork.News.GetAllForHome(),
                Projects = await _unitOfWork.Projects.GetAllForHome(),
                HomeVideoComponent = await _unitOfWork.HomeVideoComponent.GetAsync(),
                OurBusinesses = await _unitOfWork.OurBusinesses.GetAllForHome(),
                SustainableDevelopmentComponent = await _unitOfWork.SustainableDevelopment.GetAsync(),
            };

            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
