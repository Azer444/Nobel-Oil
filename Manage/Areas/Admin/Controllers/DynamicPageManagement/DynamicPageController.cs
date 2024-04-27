using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.DynamicPageManagement;
using Manage.Areas.Admin.Models.FlatpageManagement;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.DynamicPageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class DynamicPageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public DynamicPageController(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        #region Dynamic Pages

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = new DynamicPageListViewModel
            {
                DynamicPages = await _unitOfWork.DynamicPages.GetAllAsync()
            };

            return await Task.Run(() => View(model));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Add(DynamicPageAddViewModel model)
        {
            if (!ModelState.IsValid) return await Task.Run(() => View(model));
            if (!await _unitOfWork.DynamicPages.IsUniqueURLAsync(model.URL)
                || !await _unitOfWork.Flatpages.IsUniqueURLAsync(model.URL))
            {
                ModelState.AddModelError("", "URL must be unique");
                return await Task.Run(() => View(model));
            }

            var dynamicPage = new DynamicPage
            {
                URL = model.URL,
                BannerTitle_AZ = model.BannerTitle_AZ,
                BannerTitle_RU = model.BannerTitle_RU,
                BannerTitle_EN = model.BannerTitle_EN,
                BannerTitle_TR = model.BannerTitle_TR,
                BannerPhotoName = await _fileService.UploadFileAsync(model.BannerPhoto, FilePath.DynamicPage),
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
                dynamicPage.PagePhotoName = await _fileService.UploadFileAsync(model.PagePhoto, FilePath.DynamicPage);
            }

            await _unitOfWork.DynamicPages.CreateAsync(dynamicPage);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("list");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dynamicPage = await _unitOfWork.DynamicPages.GetAsync(id);
            if (dynamicPage == null) return NotFound();

            var model = new DynamicPageEditViewModel
            {
                Id = dynamicPage.Id,
                URL = dynamicPage.URL,
                BannerTitle_AZ = dynamicPage.BannerTitle_AZ,
                BannerTitle_RU = dynamicPage.BannerTitle_RU,
                BannerTitle_EN = dynamicPage.BannerTitle_EN,
                BannerTitle_TR = dynamicPage.BannerTitle_TR,
                BannerPhotoPath = _fileService.GetFileUrl(dynamicPage.BannerPhotoName, FilePath.DynamicPage),
                HasComponent = dynamicPage.HasPageComponent,
                TitlePage_AZ = dynamicPage.TitlePage_AZ,
                TitlePage_RU = dynamicPage.TitlePage_RU,
                TitlePage_EN = dynamicPage.TitlePage_EN,
                TitlePage_TR = dynamicPage.TitlePage_TR,
                ContentPage_AZ = dynamicPage.ContentPage_AZ,
                ContentPage_RU = dynamicPage.ContentPage_RU,
                ContentPage_EN = dynamicPage.ContentPage_EN,
                ContentPage_TR = dynamicPage.ContentPage_TR,
                IsBanner = dynamicPage.IsBanner,
                Page = dynamicPage.Page,
                PagePhotoPath = _fileService.GetFileUrl(dynamicPage.PagePhotoName, FilePath.DynamicPage),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DynamicPageEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dynamicPage = await _unitOfWork.DynamicPages.GetAsync(model.Id);
            if (dynamicPage == null) return NotFound();

            if (!await _unitOfWork.DynamicPages.IsUniqueURLAsync(model.URL, dynamicPage.Id)
              || !await _unitOfWork.Flatpages.IsUniqueURLAsync(model.URL))
            {
                ModelState.AddModelError("", "URL must be unique");
                return View(model);
            }

            dynamicPage.URL = model.URL;
            dynamicPage.BannerTitle_AZ = model.BannerTitle_AZ;
            dynamicPage.BannerTitle_RU = model.BannerTitle_RU;
            dynamicPage.BannerTitle_EN = model.BannerTitle_EN;
            dynamicPage.BannerTitle_TR = model.BannerTitle_TR;
            dynamicPage.HasPageComponent = model.HasComponent;
            dynamicPage.TitlePage_AZ = model.TitlePage_AZ;
            dynamicPage.TitlePage_RU = model.TitlePage_RU;
            dynamicPage.TitlePage_EN = model.TitlePage_EN;
            dynamicPage.TitlePage_TR = model.TitlePage_TR;
            dynamicPage.ContentPage_AZ = model.ContentPage_AZ;
            dynamicPage.ContentPage_RU = model.ContentPage_RU;
            dynamicPage.ContentPage_EN = model.ContentPage_EN;
            dynamicPage.ContentPage_TR = model.ContentPage_TR;
            dynamicPage.IsBanner = model.IsBanner;
            dynamicPage.Page = model.Page;

            if (model.PagePhoto != null)
            {
                _fileService.Delete(dynamicPage.PagePhotoName, FilePath.DynamicPage);
                dynamicPage.PagePhotoName = await _fileService.UploadFileAsync(model.PagePhoto, FilePath.DynamicPage);
            }

            if (model.BannerPhoto != null)
            {
                _fileService.Delete(dynamicPage.BannerPhotoName, FilePath.DynamicPage);
                dynamicPage.BannerPhotoName = await _fileService.UploadFileAsync(model.BannerPhoto, FilePath.DynamicPage);
            }

            await _unitOfWork.DynamicPages.EditAsync(dynamicPage);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("list");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var dynamicPage = await _unitOfWork.DynamicPages.GetAsync(id);
            if (dynamicPage == null) return NotFound();

            var model = new DynamicPageDetailsViewModel
            {
                Id = dynamicPage.Id,
                URL = dynamicPage.URL,
                BannerTitle_AZ = dynamicPage.BannerTitle_AZ,
                BannerTitle_RU = dynamicPage.BannerTitle_RU,
                BannerTitle_EN = dynamicPage.BannerTitle_EN,
                BannerTitle_TR = dynamicPage.BannerTitle_TR,
                ContentPage_AZ = dynamicPage.ContentPage_AZ,
                ContentPage_RU = dynamicPage.ContentPage_RU,
                ContentPage_EN = dynamicPage.ContentPage_EN,
                ContentPage_TR = dynamicPage.ContentPage_TR,
                BannerPhotoPath = _fileService.GetFileUrl(dynamicPage.BannerPhotoName, FilePath.DynamicPage)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var dynamicPage = await _unitOfWork.DynamicPages.GetAsync(id);
            if (dynamicPage == null) return NotFound();

            _fileService.Delete(dynamicPage.BannerPhotoName, FilePath.Flatpage);

            await _unitOfWork.DynamicPages.DeleteAsync(dynamicPage);
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
                var fileName = await _fileService.UploadFileAsync(upload, FilePath.DynamicPage);
                var url = _fileService.GetFileUrl(fileName, FilePath.DynamicPage);
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

        #endregion

        #region Dynamic Page Contents

        [HttpGet]
        public async Task<IActionResult> ContentList(int id)
        {
            var model = new DynamicPageContentListViewModel
            {
                DynamicPageContents = await _unitOfWork.DynamicPageContents.GetAllByIdAsync(id),
                DynamicPageId = id
            };

            return await Task.Run(() => View(model));
        }

        [HttpPost]
        public async Task<IActionResult> ContentCreate(ContentAddViewModel model)
        {
            if (!ModelState.IsValid) return await Task.Run(() => View(model));

            var content = new DynamicPageContent
            {
                ContentTitle_AZ = model.ContentTitle_AZ,
                ContentTitle_TR = model.ContentTitle_TR,
                ContentTitle_EN = model.ContentTitle_EN,
                ContentTitle_RU = model.ContentTitle_RU,
                ContentPhotoName = await _fileService.UploadFileAsync(model.ContentPhoto, FilePath.DynamicPage),
                IsContentTitle = model.IsContentTitle,
                Content_AZ = model.Content_AZ,
                Content_TR = model.Content_TR,
                Content_EN = model.Content_EN,
                Content_RU = model.Content_RU,
                DynamicPageId = model.DynamicPageId
            };

            await _unitOfWork.DynamicPageContents.CreateAsync(content);
            await _unitOfWork.CommitAsync();

            return Redirect($"/admin/dynamicpage/contentlist/{content.DynamicPageId}");
        }

        [HttpGet]
        public async Task<IActionResult> ContentCreate(int id)
        {
            var model = new ContentAddViewModel
            {
                DynamicPageId = id
            };
            return await Task.Run(() => View(model));
        }

        [HttpGet]
        public async Task<IActionResult> ContentEdit(int id)
        {
            var content = await _unitOfWork.DynamicPageContents.GetAsync(id);
            if (content == null) return NotFound();

            var model = new ContentEditViewModel
            {
                Id = content.Id,
                ContentTitle_AZ = content.ContentTitle_AZ,
                ContentTitle_TR = content.ContentTitle_TR,
                ContentTitle_EN = content.ContentTitle_EN,
                ContentTitle_RU = content.ContentTitle_RU,
                ContentPhotoName = _fileService.GetFileUrl(content.ContentPhotoName, FilePath.DynamicPage),
                IsContentTitle = content.IsContentTitle,
                Content_AZ = content.Content_AZ,
                Content_TR = content.Content_TR,
                Content_EN = content.Content_EN,
                Content_RU = content.Content_RU,
                DynamicPageId = content.DynamicPageId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ContentEdit(ContentEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var content = await _unitOfWork.DynamicPageContents.GetAsync(model.Id);
            if (content == null) return NotFound();

            content.ContentTitle_AZ = model.ContentTitle_AZ;
            content.ContentTitle_TR = model.ContentTitle_TR;
            content.ContentTitle_EN = model.ContentTitle_EN;
            content.ContentTitle_RU = model.ContentTitle_RU;
            content.IsContentTitle = model.IsContentTitle;
            content.Content_AZ = model.Content_AZ;
            content.Content_TR = model.Content_TR;
            content.Content_EN = model.Content_EN;
            content.Content_RU = model.Content_RU;

            if (model.ContentPhoto != null)
            {
                _fileService.Delete(model.ContentPhotoName, FilePath.DynamicPage);
                content.ContentPhotoName = await _fileService.UploadFileAsync(model.ContentPhoto, FilePath.DynamicPage);
            }

            await _unitOfWork.DynamicPageContents.EditAsync(content);
            await _unitOfWork.CommitAsync();

            return Redirect($"/admin/dynamicpage/contentlist/{content.DynamicPageId}");
        }

        [HttpGet]
        public async Task<IActionResult> ContentDetails(int id)
        {
            var content = await _unitOfWork.DynamicPageContents.GetAsync(id);
            if (content == null) return NotFound();

            var model = new ContentDetailsViewModel
            {
                ContentPhotoName = _fileService.GetFileUrl(content.ContentPhotoName, FilePath.DynamicPage),
                ContentTitle_AZ = content.ContentTitle_AZ,
                ContentTitle_TR = content.ContentTitle_TR,
                ContentTitle_EN = content.ContentTitle_EN,
                ContentTitle_RU = content.ContentTitle_RU,
                Content_RU = content.Content_RU,
                Content_EN = content.Content_EN,
                Content_TR = content.Content_TR,
                Content_AZ = content.Content_AZ,
                IsContentTitle = content.IsContentTitle,
                DynamicPageId = content.DynamicPageId
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ContentDelete(int id, int pageid)
        {
            var dynamicPageContent = await _unitOfWork.DynamicPageContents.GetAsync(id);
            if (dynamicPageContent == null) return NotFound();

            _fileService.Delete(dynamicPageContent.ContentPhotoName, FilePath.Flatpage);

            await _unitOfWork.DynamicPageContents.DeleteAsync(dynamicPageContent);
            await _unitOfWork.CommitAsync();
            return Redirect($"/admin/dynamicpage/contentlist/{pageid}");
        }

        #endregion
    }
}
