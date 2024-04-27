using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.FlatpageManagement;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.FlatpageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class FlatpageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public FlatpageController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = new FlatpageListViewModel
            {
                Flatpages = await _unitOfWork.Flatpages.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FlatpageAddViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            if (!await _unitOfWork.DynamicPages.IsUniqueURLAsync(model.URL)
                || !await _unitOfWork.Flatpages.IsUniqueURLAsync(model.URL))
            {
                ModelState.AddModelError("URL", "URL must be unique");
                return View(model);
            }

            var flatpage = new Flatpage
            {
                URL = model.URL,
                BannerTitle_AZ = model.BannerTitle_AZ,
                BannerTitle_RU = model.BannerTitle_RU,
                BannerTitle_EN = model.BannerTitle_EN,
                BannerTitle_TR = model.BannerTitle_TR,
                Content_AZ = model.Content_AZ,
                Content_RU = model.Content_RU,
                Content_EN = model.Content_EN,
                Content_TR = model.Content_TR,
                BannerPhotoName = await _fileService.UploadFileAsync(model.BannerPhoto, FilePath.Flatpage),
                HasPageComponent = model.HasComponent,
                TitlePage_AZ = model.TitlePage_AZ,
                TitlePage_RU = model.TitlePage_RU,
                TitlePage_EN = model.TitlePage_EN,
                TitlePage_TR = model.TitlePage_TR,
                ContentPage_AZ = model.ContentPage_AZ,
                ContentPage_RU = model.ContentPage_RU,
                ContentPage_EN = model.ContentPage_EN,
                ContentPage_TR = model.ContentPage_TR,
                IsBanner = model.IsBanner,
                Page = model.Page
            };

            if (model.PagePhoto != null)
            {
                flatpage.PagePhotoName = await _fileService.UploadFileAsync(model.PagePhoto, FilePath.Flatpage);
            }

            //If related component is created then create its related page tab
            if (model.HasComponent)
            {
                var pageTabComponent = new PageTabComponent
                {
                    Title_AZ = model.TitlePage_AZ,
                    Title_RU = model.TitlePage_RU,
                    Title_EN = model.TitlePage_EN,
                    Title_TR = model.TitlePage_TR,
                    Link = model.URL,
                    Page = model.Page
                };

                await _unitOfWork.PageTabComponents.CreateAsync(pageTabComponent);
            }


            await _unitOfWork.Flatpages.CreateAsync(flatpage);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("list");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var flatpage = await _unitOfWork.Flatpages.GetAsync(id);
            if (flatpage == null) return NotFound();

            var model = new FlatpageEditViewModel
            {
                Id = flatpage.Id,
                URL = flatpage.URL,
                BannerTitle_AZ = flatpage.BannerTitle_AZ,
                BannerTitle_RU = flatpage.BannerTitle_RU,
                BannerTitle_EN = flatpage.BannerTitle_EN,
                BannerTitle_TR = flatpage.BannerTitle_TR,
                Content_AZ = flatpage.Content_AZ,
                Content_RU = flatpage.Content_RU,
                Content_EN = flatpage.Content_EN,
                Content_TR = flatpage.Content_TR,
                BannerPhotoPath = _fileService.GetFileUrl(flatpage.BannerPhotoName, FilePath.Flatpage),
                HasComponent = flatpage.HasPageComponent,
                TitlePage_AZ = flatpage.TitlePage_AZ,
                TitlePage_RU = flatpage.TitlePage_RU,
                TitlePage_EN = flatpage.TitlePage_EN,
                TitlePage_TR = flatpage.TitlePage_TR,
                ContentPage_AZ = flatpage.ContentPage_AZ,
                ContentPage_RU = flatpage.ContentPage_RU,
                ContentPage_EN = flatpage.ContentPage_EN,
                ContentPage_TR = flatpage.ContentPage_TR,
                IsBanner = flatpage.IsBanner,
                Page = flatpage.Page,
                PagePhotoPath = _fileService.GetFileUrl(flatpage.PagePhotoName, FilePath.Flatpage),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FlatpageEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var flatpage = await _unitOfWork.Flatpages.GetAsync(model.Id);
            if (flatpage == null) return NotFound();

            if (!await _unitOfWork.Flatpages.IsUniqueURLAsync(model.URL, flatpage.Id)
                || !await _unitOfWork.DynamicPages.IsUniqueURLAsync(model.URL))
            {
                ModelState.AddModelError("URL", "URL must be unique");
                return View(model);
            }

            flatpage.URL = model.URL;
            flatpage.BannerTitle_AZ = model.BannerTitle_AZ;
            flatpage.BannerTitle_RU = model.BannerTitle_RU;
            flatpage.BannerTitle_EN = model.BannerTitle_EN;
            flatpage.BannerTitle_TR = model.BannerTitle_TR;
            flatpage.Content_AZ = model.Content_AZ;
            flatpage.Content_RU = model.Content_RU;
            flatpage.Content_EN = model.Content_EN;
            flatpage.Content_TR = model.Content_TR;
            flatpage.HasPageComponent = model.HasComponent;
            flatpage.TitlePage_AZ = model.TitlePage_AZ;
            flatpage.TitlePage_RU = model.TitlePage_RU;
            flatpage.TitlePage_EN = model.TitlePage_EN;
            flatpage.TitlePage_TR = model.TitlePage_TR;
            flatpage.ContentPage_AZ = model.ContentPage_AZ;
            flatpage.ContentPage_RU = model.ContentPage_RU;
            flatpage.ContentPage_EN = model.ContentPage_EN;
            flatpage.ContentPage_TR = model.ContentPage_TR;
            flatpage.IsBanner = model.IsBanner;
            flatpage.Page = model.Page;

            if (model.PagePhoto != null)
            {
                _fileService.Delete(flatpage.PagePhotoName, FilePath.Flatpage);
                flatpage.PagePhotoName = await _fileService.UploadFileAsync(model.PagePhoto, FilePath.Flatpage);
            }

            if (model.BannerPhoto != null)
            {
                _fileService.Delete(flatpage.BannerPhotoName, FilePath.Flatpage);
                flatpage.BannerPhotoName = await _fileService.UploadFileAsync(model.BannerPhoto, FilePath.Flatpage);
            }

            await _unitOfWork.Flatpages.EditAsync(flatpage);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("list");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var flatpage = await _unitOfWork.Flatpages.GetAsync(id);
            if (flatpage == null) return NotFound();

            var model = new FlatpageDetailsViewModel
            {
                Id = flatpage.Id,
                URL = flatpage.URL,
                BannerTitle_AZ = flatpage.BannerTitle_AZ,
                BannerTitle_RU = flatpage.BannerTitle_RU,
                BannerTitle_EN = flatpage.BannerTitle_EN,
                BannerTitle_TR = flatpage.BannerTitle_TR,
                Content_AZ = flatpage.Content_AZ,
                Content_RU = flatpage.Content_RU,
                Content_EN = flatpage.Content_EN,
                Content_TR = flatpage.Content_TR,
                BannerPhotoPath = _fileService.GetFileUrl(flatpage.BannerPhotoName, FilePath.Flatpage)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var flatpage = await _unitOfWork.Flatpages.GetAsync(id);
            if (flatpage == null) return NotFound();

            _fileService.Delete(flatpage.BannerPhotoName, FilePath.Flatpage);

            await _unitOfWork.Flatpages.DeleteAsync(flatpage);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("list");
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile upload)
        {
            if (upload != null)
            {
                var fileName = await _fileService.UploadFileAsync(upload, FilePath.Flatpage);
                var url = _fileService.GetFileUrl(fileName, FilePath.Flatpage);
                var success = new UploadSuccess
                {
                    Uploaded = 1,
                    FileName = fileName,
                    Url = url
                };

                return new JsonResult(success);
            }

            return null;
        }
    }
}
