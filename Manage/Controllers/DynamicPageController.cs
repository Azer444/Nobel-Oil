using Core;
using Core.Constants.File;
using Manage.MiddlewareFilters;
using Manage.Tools.FileHandler.Abstraction;
using Manage.ViewModels.DynamicPage;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class DynamicPageController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;
        public DynamicPageController(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [Route("~/{culture}/{**url:dynamicpageurl}")]
        public async Task<IActionResult> Index(string url)
        {
            var dynamicPage = await _unitOfWork.DynamicPages.GetByUrl(url);
            if (dynamicPage == null) return NotFound();
            var currentLang = _unitOfWork.Languages.GetCurrentThreadLang();

            var model = new DynamicPageViewModel
            {
                Id = dynamicPage.Id,
                BannerTitle = _unitOfWork.Languages.ChooseLanguage(dynamicPage, "BannerTitle", currentLang.ToString()),
                BannerPhotoName = _fileService.GetFileUrl(dynamicPage.BannerPhotoName, FilePath.DynamicPage),
                Page = dynamicPage.Page
            };
            return View(model);
        }
    }
}
