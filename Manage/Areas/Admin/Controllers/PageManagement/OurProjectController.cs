using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.OurProject;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class OurProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public OurProjectController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.OurProject = true;

            var model = new OurProjectIndexViewModel
            {
                OurProjectComponent = await _unitOfWork.OurProjectComponent.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.OurProject = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(OurProjectDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurProject = true;

            if (ModelState.IsValid)
            {
                var ourProjectComponent = new OurProjectComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.OurProject)
                };

                await _unitOfWork.OurProjectComponent.CreateAsync(ourProjectComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Our project component <{ourProjectComponent.Title_EN}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.OurProject = true;

            var ourProjectComponent = await _unitOfWork.OurProjectComponent.GetAsync();
            if (ourProjectComponent == null) return NotFound();

            var model = new OurProjectEditComponentViewModel
            {
                Id = ourProjectComponent.Id,
                Title_AZ = ourProjectComponent.Title_AZ,
                Title_RU = ourProjectComponent.Title_RU,
                Title_EN = ourProjectComponent.Title_EN,
                Title_TR = ourProjectComponent.Title_TR,
                Content_AZ = ourProjectComponent.Content_AZ,
                Content_RU = ourProjectComponent.Content_RU,
                Content_EN = ourProjectComponent.Content_EN,
                Content_TR = ourProjectComponent.Content_TR,
                PhotoPath = _fileService.GetFileUrl(ourProjectComponent.PhotoName, FilePath.OurProject),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(OurProjectEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurProject = true;

            var ourProjectComponent = await _unitOfWork.OurProjectComponent.GetAsync();
            if (ourProjectComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                ourProjectComponent.Title_AZ = model.Title_AZ;
                ourProjectComponent.Title_RU = model.Title_RU;
                ourProjectComponent.Title_EN = model.Title_EN;
                ourProjectComponent.Title_TR = model.Title_TR;
                ourProjectComponent.Content_AZ = model.Content_AZ;
                ourProjectComponent.Content_RU = model.Content_RU;
                ourProjectComponent.Content_EN = model.Content_EN;
                ourProjectComponent.Content_TR = model.Content_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(ourProjectComponent.PhotoName, FilePath.OurProject);
                    ourProjectComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.OurProject);
                }

                await _unitOfWork.OurProjectComponent.EditAsync(ourProjectComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Our project component <{ourProjectComponent.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.OurProject = true;

            var ourProjectComponent = await _unitOfWork.OurProjectComponent.GetAsync();
            if (ourProjectComponent == null) return NotFound();

            var model = new OurProjectDetailsViewModel
            {
                Title_AZ = ourProjectComponent.Title_AZ,
                Title_RU = ourProjectComponent.Title_RU,
                Title_EN = ourProjectComponent.Title_EN,
                Title_TR = ourProjectComponent.Title_TR,
                Content_AZ = ourProjectComponent.Content_AZ,
                Content_RU = ourProjectComponent.Content_RU,
                Content_EN = ourProjectComponent.Content_EN,
                Content_TR = ourProjectComponent.Content_TR,
                PhotoPath = _fileService.GetFileUrl(ourProjectComponent.PhotoName, FilePath.OurProject),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurProject = true;

            var ourProjectComponent = await _unitOfWork.OurProjectComponent.GetAsync(id);
            if (ourProjectComponent == null) return NotFound();

            _fileService.Delete(ourProjectComponent.PhotoName, FilePath.OurProject);

            await _unitOfWork.OurProjectComponent.DeleteAsync(ourProjectComponent);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Our project component <{ourProjectComponent.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("index");
        }
    }
}
