using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.HumanResource;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class HumanResourceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public HumanResourceController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet("admin/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.HumanResource = true;

            var model = new HumanResourceIndexViewModel
            {
                HumanResourceComponent = await _unitOfWork.HumanResourceComponent.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.HumanResource = true;

            var humanResourceComponent = await _unitOfWork.HumanResourceComponent.GetAsync();
            if (humanResourceComponent != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(HumanResourceDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.HumanResource = true;

            if (ModelState.IsValid)
            {
                var humanResourceComponent = new HumanResourceComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    ContentSustainability_AZ = model.ContentSustainability_AZ,
                    ContentSustainability_RU = model.ContentSustainability_RU,
                    ContentSustainability_EN = model.ContentSustainability_EN,
                    ContentSustainability_TR = model.ContentSustainability_TR
                };

                if (model.Photo != null)
                    humanResourceComponent.PhotoName_Sustainability = await _fileService.UploadFileAsync(model.Photo, FilePath.HumanResource);

                await _unitOfWork.HumanResourceComponent.CreateAsync(humanResourceComponent);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var humanResourceComponentPhoto = new HumanResourceComponentPhoto
                    {
                        HumanResourceComponentId = humanResourceComponent.Id,
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.HumanResource)
                    };

                    await _unitOfWork.HumanResourceComponentPhoto.CreateAsync(humanResourceComponentPhoto);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"Human resource component successfully defined.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.HumanResource = true;

            var humanResourceComponent = await _unitOfWork.HumanResourceComponent.GetAsync();
            if (humanResourceComponent == null) return NotFound();

            var model = new HumanResourceEditComponentViewModel
            {
                Id = humanResourceComponent.Id,
                Title_AZ = humanResourceComponent.Title_AZ,
                Title_RU = humanResourceComponent.Title_RU,
                Title_EN = humanResourceComponent.Title_EN,
                Title_TR = humanResourceComponent.Title_TR,
                Content_AZ = humanResourceComponent.Content_AZ,
                Content_RU = humanResourceComponent.Content_RU,
                Content_EN = humanResourceComponent.Content_EN,
                Content_TR = humanResourceComponent.Content_TR,
                ContentSustainability_AZ = humanResourceComponent.ContentSustainability_AZ,
                ContentSustainability_RU = humanResourceComponent.ContentSustainability_RU,
                ContentSustainability_EN = humanResourceComponent.ContentSustainability_EN,
                ContentSustainability_TR = humanResourceComponent.ContentSustainability_TR,
                HumanResourceComponentPhotos = humanResourceComponent.HumanResourceComponentPhotos,
                PhotoPath_Sustainability = _fileService.GetFileUrl(humanResourceComponent.PhotoName_Sustainability, FilePath.HumanResource)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(HumanResourceEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.HumanResource = true;

            var humanResourceComponent = await _unitOfWork.HumanResourceComponent.GetAsync();
            if (humanResourceComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                humanResourceComponent.Title_AZ = model.Title_AZ;
                humanResourceComponent.Title_RU = model.Title_RU;
                humanResourceComponent.Title_EN = model.Title_EN;
                humanResourceComponent.Title_TR = model.Title_TR;
                humanResourceComponent.Content_AZ = model.Content_AZ;
                humanResourceComponent.Content_RU = model.Content_RU;
                humanResourceComponent.Content_EN = model.Content_EN;
                humanResourceComponent.Content_TR = model.Content_TR;
                humanResourceComponent.ContentSustainability_AZ = model.ContentSustainability_AZ;
                humanResourceComponent.ContentSustainability_RU = model.ContentSustainability_RU;
                humanResourceComponent.ContentSustainability_EN = model.ContentSustainability_EN;
                humanResourceComponent.ContentSustainability_TR = model.ContentSustainability_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(humanResourceComponent.PhotoName_Sustainability, FilePath.HumanResource);
                    humanResourceComponent.PhotoName_Sustainability = await _fileService.UploadFileAsync(model.Photo, FilePath.HumanResource);
                }

                await _unitOfWork.HumanResourceComponent.EditAsync(humanResourceComponent);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var humanResourceComponentPhoto = new HumanResourceComponentPhoto
                    {
                        HumanResourceComponentId = humanResourceComponent.Id,
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.HumanResource)
                    };

                    await _unitOfWork.HumanResourceComponentPhoto.CreateAsync(humanResourceComponentPhoto);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"Human resource component successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.HumanResource = true;

            var humanResourceComponent = await _unitOfWork.HumanResourceComponent.GetAsync();
            if (humanResourceComponent == null) return NotFound();

            return View(humanResourceComponent);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComponentPhoto(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.HumanResource = true;

            var humanResourceComponentPhoto = await _unitOfWork.HumanResourceComponentPhoto.GetAsync(id);
            if (humanResourceComponentPhoto == null) return NotFound();

            _fileService.Delete(humanResourceComponentPhoto.PhotoName, FilePath.HumanResource);

            await _unitOfWork.HumanResourceComponentPhoto.DeleteAsync(humanResourceComponentPhoto);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Human resource component photo <{humanResourceComponentPhoto.PhotoName}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("editcomponent");
        }
    }
}
