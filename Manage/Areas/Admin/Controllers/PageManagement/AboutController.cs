using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.About;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class AboutController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public AboutController(
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
            ViewBag.About = true;

            var model = new AboutIndexViewModel
            {
                AboutComponent = await _unitOfWork.AboutComponent.GetAsync()
            };

            return View(model);
        }

        #endregion

        #region DefineComponent

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.About = true;

            var about = await _unitOfWork.AboutComponent.GetAsync();
            if (about != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(AboutDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.About = true;

            if (ModelState.IsValid)
            {
                var aboutComponent = new AboutComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    ContentWWA_AZ = model.ContentWWA_AZ,
                    ContentWWA_RU = model.ContentWWA_RU,
                    ContentWWA_EN = model.ContentWWA_EN,
                    ContentWWA_TR = model.ContentWWA_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.About)
                };

                await _unitOfWork.AboutComponent.CreateAsync(aboutComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"About component successfully defined.";
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
            ViewBag.About = true;

            var aboutComponent = await _unitOfWork.AboutComponent.GetAsync();
            if (aboutComponent == null) return NotFound();

            var model = new AboutEditComponentViewModel
            {
                Id = aboutComponent.Id,
                Title_AZ = aboutComponent.Title_AZ,
                Title_RU = aboutComponent.Title_RU,
                Title_EN = aboutComponent.Title_EN,
                Title_TR = aboutComponent.Title_TR,
                Content_AZ = aboutComponent.Content_AZ,
                Content_RU = aboutComponent.Content_RU,
                Content_EN = aboutComponent.Content_EN,
                Content_TR = aboutComponent.Content_TR,
                ContentWWA_AZ = aboutComponent.ContentWWA_AZ,
                ContentWWA_RU = aboutComponent.ContentWWA_RU,
                ContentWWA_EN = aboutComponent.ContentWWA_EN,
                ContentWWA_TR = aboutComponent.ContentWWA_TR,
                PhotoPath = _fileService.GetFileUrl(aboutComponent.PhotoName, FilePath.About)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(AboutEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.About = true;

            var aboutComponent = await _unitOfWork.AboutComponent.GetAsync();
            if (aboutComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                aboutComponent.Title_AZ = model.Title_AZ;
                aboutComponent.Title_RU = model.Title_RU;
                aboutComponent.Title_EN = model.Title_EN;
                aboutComponent.Title_TR = model.Title_TR;
                aboutComponent.Content_AZ = model.Content_AZ;
                aboutComponent.Content_RU = model.Content_RU;
                aboutComponent.Content_EN = model.Content_EN;
                aboutComponent.Content_TR = model.Content_TR;
                aboutComponent.ContentWWA_AZ = model.ContentWWA_AZ;
                aboutComponent.ContentWWA_RU = model.ContentWWA_RU;
                aboutComponent.ContentWWA_EN = model.ContentWWA_EN;
                aboutComponent.ContentWWA_TR = model.ContentWWA_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(aboutComponent.PhotoName, FilePath.About);
                    aboutComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.About);
                }

                await _unitOfWork.AboutComponent.EditAsync(aboutComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"About component successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        #endregion

    }
}
