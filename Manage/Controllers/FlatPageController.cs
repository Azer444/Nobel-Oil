using Core;
using Core.Constants.File;
using Manage.MiddlewareFilters;
using Manage.Tools.FileHandler.Abstraction;
using Manage.ViewModels.FlatPage;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class FlatPageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public FlatPageController(
            IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [Route("~/{culture}/{**url:flatpageurl}")]
        public async Task<IActionResult> Index(string url)
        {
            var flatpage = await _unitOfWork.Flatpages.GetByUrl(url);
            if (flatpage == null) return NotFound();

            var currentLang = _unitOfWork.Languages.GetCurrentThreadLang();

            var model = new FlatPageViewModel
            {
                URL = url,
                BannerTitle = _unitOfWork.Languages.ChooseLanguage(flatpage, "BannerTitle", currentLang.ToString()),
                Content = _unitOfWork.Languages.ChooseLanguage(flatpage, "Content", currentLang.ToString()),
                BannerPhotoUrl = _fileService.GetFileUrl(flatpage.BannerPhotoName, FilePath.Flatpage),
            };

            return View(model);
        }
    }
}
