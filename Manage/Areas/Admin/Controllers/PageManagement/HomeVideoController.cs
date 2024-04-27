using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.HomeVideo;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class HomeVideoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public HomeVideoController(
            IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        #region Index

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.PageManagementHome = true;
            ViewBag.HomeVideo = true;

            var model = new HomeVideoIndexViewModel
            {
                HomeVideoComponent = await _unitOfWork.HomeVideoComponent.GetAsync()
            };

            return View(model);
        }

        #endregion

        #region DefineComponent

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.PageManagementHome = true;
            ViewBag.HomeVideo = true;

            var homeVideoComponent = await _unitOfWork.HomeVideoComponent.GetAsync();
            if (homeVideoComponent != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(HomeVideoDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.PageManagementHome = true;
            ViewBag.HomeVideo = true;

            if (ModelState.IsValid)
            {
                var homeVideoComponent = new HomeVideoComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.HomeVideo),
                    VideoUrl = model.VideoUrl,
                };

                await _unitOfWork.HomeVideoComponent.CreateAsync(homeVideoComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Home video component successfully defined.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        #endregion

        #region EditComponent

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.PageManagementHome = true;
            ViewBag.HomeVideo = true;

            var homeVideoComponent = await _unitOfWork.HomeVideoComponent.GetAsync();
            if (homeVideoComponent == null) return NotFound();

            var model = new HomeVideoEditComponentViewModel
            {
                Id = homeVideoComponent.Id,
                Title_AZ = homeVideoComponent.Title_AZ,
                Title_RU = homeVideoComponent.Title_RU,
                Title_EN = homeVideoComponent.Title_EN,
                Title_TR = homeVideoComponent.Title_TR,
                PhotoPath = _fileService.GetFileUrl(homeVideoComponent.PhotoName, FilePath.HomeVideo),
                VideoUrl = homeVideoComponent.VideoUrl,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(HomeVideoEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.PageManagementHome = true;
            ViewBag.HomeVideo = true;

            var homeVideoComponent = await _unitOfWork.HomeVideoComponent.GetAsync();
            if (homeVideoComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                homeVideoComponent.Title_AZ = model.Title_AZ;
                homeVideoComponent.Title_RU = model.Title_RU;
                homeVideoComponent.Title_EN = model.Title_EN;
                homeVideoComponent.Title_TR = model.Title_TR;
                homeVideoComponent.VideoUrl = model.VideoUrl;

                if (model.Photo != null)
                {
                    _fileService.Delete(homeVideoComponent.PhotoName, FilePath.HomeVideo);
                    homeVideoComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.HomeVideo);
                }

                await _unitOfWork.HomeVideoComponent.EditAsync(homeVideoComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Home video component successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        #endregion

    }
}
