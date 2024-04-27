using Core;
using Core.Constants;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.Media;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class MediaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public MediaController(
            IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.Media = true;

            var model = new MediaIndexViewModel
            {
                PageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Media),
                MediaComponents = await _unitOfWork.MediaComponent.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineMainPhoto()
        {
            ViewBag.PageManagement = true;
            ViewBag.Media = true;

            var pageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Media);
            if (pageMainPhoto != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineMainPhoto(MediaDefineMainPhotoViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Media = true;

            if (ModelState.IsValid)
            {
                var pageMainPhoto = new PageMainPhoto
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Page = Page.Media,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.PageMainPhoto)
                };

                await _unitOfWork.PageMainPhoto.CreateAsync(pageMainPhoto);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Page Main Photo <{pageMainPhoto.PhotoName}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditMainPhoto()
        {
            ViewBag.PageManagement = true;
            ViewBag.Media = true;

            var pageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Media);
            if (pageMainPhoto == null) return NotFound();

            var model = new MediaEditMainPhotoViewModel
            {
                Id = pageMainPhoto.Id,
                Title_AZ = pageMainPhoto.Title_AZ,
                Title_RU = pageMainPhoto.Title_RU,
                Title_EN = pageMainPhoto.Title_EN,
                Title_TR = pageMainPhoto.Title_TR,
                PhotoPath = _fileService.GetFileUrl(pageMainPhoto.PhotoName, FilePath.PageMainPhoto),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditMainPhoto(MediaEditMainPhotoViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Media = true;

            var pageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Media);
            if (pageMainPhoto == null) return NotFound();

            if (ModelState.IsValid)
            {
                pageMainPhoto.Title_AZ = model.Title_AZ;
                pageMainPhoto.Title_RU = model.Title_RU;
                pageMainPhoto.Title_EN = model.Title_EN;
                pageMainPhoto.Title_TR = model.Title_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(pageMainPhoto.PhotoName, FilePath.PageMainPhoto);
                    pageMainPhoto.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.PageMainPhoto);
                }

                await _unitOfWork.PageMainPhoto.EditAsync(pageMainPhoto);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Page Main Photo <{pageMainPhoto.PhotoName}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Media = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComponent(MediaAddComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Media = true;

            if (ModelState.IsValid)
            {
                var mediaComponent = new MediaComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    Link = model.Link,
                    isBanner = model.isBanner,
                    IsActive = model.IsActive,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Media)
                };

                await _unitOfWork.MediaComponent.CreateAsync(mediaComponent);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Media = true;

            var mediaComponent = await _unitOfWork.MediaComponent.GetAsync(id);
            if (mediaComponent == null) return NotFound();

            var model = new MediaEditComponentViewModel
            {
                Id = mediaComponent.Id,
                Title_AZ = mediaComponent.Title_AZ,
                Title_RU = mediaComponent.Title_RU,
                Title_EN = mediaComponent.Title_EN,
                Title_TR = mediaComponent.Title_TR,
                Content_AZ = mediaComponent.Content_AZ,
                Content_RU = mediaComponent.Content_RU,
                Content_EN = mediaComponent.Content_EN,
                Content_TR = mediaComponent.Content_TR,
                Link = mediaComponent.Link,
                isBanner = mediaComponent.isBanner,
                PhotoName = mediaComponent.PhotoName,
                IsActive = mediaComponent.IsActive
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(MediaEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Media = true;

            var mediaComponent = await _unitOfWork.MediaComponent.GetAsync(model.Id);
            if (mediaComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                mediaComponent.Title_AZ = model.Title_AZ;
                mediaComponent.Title_RU = model.Title_RU;
                mediaComponent.Title_EN = model.Title_EN;
                mediaComponent.Title_TR = model.Title_TR;
                mediaComponent.Content_AZ = model.Content_AZ;
                mediaComponent.Content_RU = model.Content_RU;
                mediaComponent.Content_EN = model.Content_EN;
                mediaComponent.Content_TR = model.Content_TR;
                mediaComponent.Link = model.Link;
                mediaComponent.isBanner = model.isBanner;
                mediaComponent.IsActive = model.IsActive;

                if (model.Photo != null)
                {
                    _fileService.Delete(mediaComponent.PhotoName, FilePath.Media);
                    mediaComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Media);
                }

                await _unitOfWork.MediaComponent.EditAsync(mediaComponent);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent(int id)
        {
            var mediaComponent = await _unitOfWork.MediaComponent.GetAsync(id);
            if (mediaComponent == null) return NotFound();

            var model = new MediaDetailsComponentViewModel
            {
                Title_AZ = mediaComponent.Title_AZ,
                Title_RU = mediaComponent.Title_RU,
                Title_EN = mediaComponent.Title_EN,
                Title_TR = mediaComponent.Title_TR,
                Content_AZ = mediaComponent.Content_AZ,
                Content_RU = mediaComponent.Content_RU,
                Content_EN = mediaComponent.Content_EN,
                Content_TR = mediaComponent.Content_TR,
                isBanner = mediaComponent.isBanner,
                Link = mediaComponent.Link,
                IsActive = mediaComponent.IsActive,
                PhotoPath = _fileService.GetFileUrl(mediaComponent.PhotoName, FilePath.Media)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            var mediaComponent = await _unitOfWork.MediaComponent.GetAsync(id);
            if (mediaComponent == null) return NotFound();

            _fileService.Delete(mediaComponent.PhotoName, FilePath.Media);

            await _unitOfWork.MediaComponent.DeleteAsync(mediaComponent);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("index");
        }
    }
}
