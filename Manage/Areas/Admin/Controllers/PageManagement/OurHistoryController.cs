using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.OurHistory;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class OurHistoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public OurHistoryController(
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
            ViewBag.OurHistory = true;

            var model = new OurHistoryIndexViewModel
            {
                OurHistoryComponent = await _unitOfWork.OurHistoryComponent.GetAsync()
            };

            return View(model);
        }

        #endregion

        #region DefineComponent

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.OurHistory = true;

            var ourHistoryComponent = await _unitOfWork.OurHistoryComponent.GetAsync();
            if (ourHistoryComponent != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(OurHistoryDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurHistory = true;

            if (ModelState.IsValid)
            {
                var ourHistoryComponent = new OurHistoryComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    ContentWWA_AZ = model.ContentWWA_AZ,
                    ContentWWA_RU = model.ContentWWA_RU,
                    ContentWWA_EN = model.ContentWWA_EN,
                    ContentWWA_TR = model.ContentWWA_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.OurHistory)
                };

                await _unitOfWork.OurHistoryComponent.CreateAsync(ourHistoryComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Our history component successfully defined.";
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
            ViewBag.OurHistory = true;

            var ourHistoryComponent = await _unitOfWork.OurHistoryComponent.GetAsync();
            if (ourHistoryComponent == null) return NotFound();

            var model = new OurHistoryEditComponentViewModel
            {
                Id = ourHistoryComponent.Id,
                Title_AZ = ourHistoryComponent.Title_AZ,
                Title_RU = ourHistoryComponent.Title_RU,
                Title_EN = ourHistoryComponent.Title_EN,
                Title_TR = ourHistoryComponent.Title_TR,
                ContentWWA_AZ = ourHistoryComponent.ContentWWA_AZ,
                ContentWWA_RU = ourHistoryComponent.ContentWWA_RU,
                ContentWWA_EN = ourHistoryComponent.ContentWWA_EN,
                ContentWWA_TR = ourHistoryComponent.ContentWWA_TR,
                PhotoPath = _fileService.GetFileUrl(ourHistoryComponent.PhotoName, FilePath.OurHistory)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(OurHistoryEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurHistory = true;

            var ourHistoryComponent = await _unitOfWork.OurHistoryComponent.GetAsync();
            if (ourHistoryComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                ourHistoryComponent.Title_AZ = model.Title_AZ;
                ourHistoryComponent.Title_RU = model.Title_RU;
                ourHistoryComponent.Title_EN = model.Title_EN;
                ourHistoryComponent.Title_TR = model.Title_TR;
                ourHistoryComponent.ContentWWA_AZ = model.ContentWWA_AZ;
                ourHistoryComponent.ContentWWA_RU = model.ContentWWA_RU;
                ourHistoryComponent.ContentWWA_EN = model.ContentWWA_EN;
                ourHistoryComponent.ContentWWA_TR = model.ContentWWA_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(ourHistoryComponent.PhotoName, FilePath.OurHistory);
                    ourHistoryComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.OurHistory);
                }

                await _unitOfWork.OurHistoryComponent.EditAsync(ourHistoryComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Our history component successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        #endregion

    }
}
