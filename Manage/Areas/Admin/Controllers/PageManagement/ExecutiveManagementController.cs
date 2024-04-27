using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.ExecutiveManagement;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class ExecutiveManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public ExecutiveManagementController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.ExecutiveManagement = true;

            var model = new ExecutiveManagementIndexViewModel
            {
                ExecutiveManagementComponent = await _unitOfWork.ExecutiveManagementComponent.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.ExecutiveManagement = true;

            var executiveManagementComponent = await _unitOfWork.ExecutiveManagementComponent.GetAsync();
            if (executiveManagementComponent != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(ExecutiveManagementDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.ExecutiveManagement = true;

            if (ModelState.IsValid)
            {
                var executiveManagementComponent = new ExecutiveManagementComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.ExecutiveManagement)
                };

                await _unitOfWork.ExecutiveManagementComponent.CreateAsync(executiveManagementComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Executive Management component <{executiveManagementComponent.Title_EN}> successfully define.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.ExecutiveManagement = true;

            var executiveManagementComponent = await _unitOfWork.ExecutiveManagementComponent.GetAsync();
            if (executiveManagementComponent == null) return NotFound();

            var model = new ExecutiveManagementEditComponentViewModel
            {
                Title_AZ = executiveManagementComponent.Title_AZ,
                Title_RU = executiveManagementComponent.Title_RU,
                Title_EN = executiveManagementComponent.Title_EN,
                Title_TR = executiveManagementComponent.Title_TR,
                Content_AZ = executiveManagementComponent.Content_AZ,
                Content_RU = executiveManagementComponent.Content_RU,
                Content_EN = executiveManagementComponent.Content_EN,
                Content_TR = executiveManagementComponent.Content_TR,
                PhotoPath = _fileService.GetFileUrl(executiveManagementComponent.PhotoName, FilePath.ExecutiveManagement)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(ExecutiveManagementEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.ExecutiveManagement = true;

            var executiveManagementComponent = await _unitOfWork.ExecutiveManagementComponent.GetAsync();
            if (executiveManagementComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                executiveManagementComponent.Title_AZ = model.Title_AZ;
                executiveManagementComponent.Title_RU = model.Title_RU;
                executiveManagementComponent.Title_EN = model.Title_EN;
                executiveManagementComponent.Title_TR = model.Title_TR;
                executiveManagementComponent.Content_AZ = model.Content_AZ;
                executiveManagementComponent.Content_RU = model.Content_RU;
                executiveManagementComponent.Content_EN = model.Content_EN;
                executiveManagementComponent.Content_TR = model.Content_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(executiveManagementComponent.PhotoName, FilePath.ExecutiveManagement);
                    executiveManagementComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.ExecutiveManagement);
                }

                await _unitOfWork.ExecutiveManagementComponent.EditAsync(executiveManagementComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Executive Management component  <{executiveManagementComponent.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.ExecutiveManagement = true;

            var executiveManagementComponent = await _unitOfWork.ExecutiveManagementComponent.GetAsync();
            if (executiveManagementComponent == null) return NotFound();

            return View(executiveManagementComponent);
        }
    }
}
