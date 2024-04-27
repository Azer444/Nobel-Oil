using Core;
using Core.Constants;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.LegalNotice;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class LegalNoticeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public LegalNoticeController(
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
            ViewBag.LegalNotice = true;

            var model = new LegalNoticeIndexViewModel
            {
                PageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.LegalNotice),
                LegalNoticeComponent = await _unitOfWork.LegalNoticeComponent.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineMainPhoto()
        {
            ViewBag.PageManagement = true;
            ViewBag.LegalNotice = true;

            var pageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.LegalNotice);
            if (pageMainPhoto != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineMainPhoto(LegalNoticeDefineMainPhotoViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.LegalNotice = true;

            if (ModelState.IsValid)
            {
                var pageMainPhoto = new PageMainPhoto
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Page = Page.LegalNotice,
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
            ViewBag.LegalNotice = true;

            var pageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.LegalNotice);
            if (pageMainPhoto == null) return NotFound();

            var model = new LegalNoticeEditMainPhotoViewModel
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
        public async Task<IActionResult> EditMainPhoto(LegalNoticeEditMainPhotoViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.LegalNotice = true;

            var pageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.LegalNotice);
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
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.LegalNotice = true;

            var legalNoticeComponent = await _unitOfWork.LegalNoticeComponent.GetAsync();
            if (legalNoticeComponent != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(LegalNoticeDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.LegalNotice = true;

            if (ModelState.IsValid)
            {
                var legalNoticeComponent = new LegalNoticeComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR
                };

                await _unitOfWork.LegalNoticeComponent.CreateAsync(legalNoticeComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Legal Notice component successfully defined.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.LegalNotice = true;

            var legalNoticeComponent = await _unitOfWork.LegalNoticeComponent.GetAsync();
            if (legalNoticeComponent == null) return NotFound();

            var model = new LegalNoticeEditComponentViewModel
            {
                Id = legalNoticeComponent.Id,
                Title_AZ = legalNoticeComponent.Title_AZ,
                Title_RU = legalNoticeComponent.Title_RU,
                Title_EN = legalNoticeComponent.Title_EN,
                Title_TR = legalNoticeComponent.Title_TR,
                Content_AZ = legalNoticeComponent.Content_AZ,
                Content_RU = legalNoticeComponent.Content_RU,
                Content_EN = legalNoticeComponent.Content_EN,
                Content_TR = legalNoticeComponent.Content_TR
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(LegalNoticeEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.LegalNotice = true;

            var legalNoticeComponent = await _unitOfWork.LegalNoticeComponent.GetAsync();
            if (legalNoticeComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                legalNoticeComponent.Title_AZ = model.Title_AZ;
                legalNoticeComponent.Title_RU = model.Title_RU;
                legalNoticeComponent.Title_EN = model.Title_EN;
                legalNoticeComponent.Title_TR = model.Title_TR;
                legalNoticeComponent.Content_AZ = model.Content_AZ;
                legalNoticeComponent.Content_RU = model.Content_RU;
                legalNoticeComponent.Content_EN = model.Content_EN;
                legalNoticeComponent.Content_TR = model.Content_TR;

                await _unitOfWork.LegalNoticeComponent.EditAsync(legalNoticeComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Legal Notice component successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.LegalNotice = true;

            var legalNoticeComponent = await _unitOfWork.LegalNoticeComponent.GetAsync();
            if (legalNoticeComponent == null) return NotFound();

            var model = new LegalNoticeDetailsComponentViewModel
            {
                Title_AZ = legalNoticeComponent.Title_AZ,
                Title_RU = legalNoticeComponent.Title_RU,
                Title_EN = legalNoticeComponent.Title_EN,
                Title_TR = legalNoticeComponent.Title_TR,
                Content_AZ = legalNoticeComponent.Content_AZ,
                Content_RU = legalNoticeComponent.Content_RU,
                Content_EN = legalNoticeComponent.Content_EN,
                Content_TR = legalNoticeComponent.Content_TR
            };

            return View(model);
        }
    }
}
