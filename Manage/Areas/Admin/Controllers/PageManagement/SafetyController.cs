using Core;
using Core.Constants.File;
using Core.Extensions;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.Safety;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class SafetyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public SafetyController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.Safety = true;

            var model = new SafetyIndexViewModel
            {
                SafetyComponent = await _unitOfWork.SafetyComponent.GetAsync(),
                SafetySubComponents = await _unitOfWork.SafetySubComponent.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Safety = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(SafetyDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Safety = true;

            if (ModelState.IsValid)
            {
                var safetyComponent = new SafetyComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Safety)
                };

                await _unitOfWork.SafetyComponent.CreateAsync(safetyComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Safety component <{safetyComponent.Title_EN}> successfully defined.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Safety = true;

            var safetyComponent = await _unitOfWork.SafetyComponent.GetAsync();
            if (safetyComponent == null) return NotFound();

            var model = new SafetyEditComponentViewModel
            {
                Id = safetyComponent.Id,
                Title_AZ = safetyComponent.Title_AZ,
                Title_RU = safetyComponent.Title_RU,
                Title_EN = safetyComponent.Title_EN,
                Title_TR = safetyComponent.Title_TR,
                Content_AZ = safetyComponent.Content_AZ,
                Content_RU = safetyComponent.Content_RU,
                Content_EN = safetyComponent.Content_EN,
                Content_TR = safetyComponent.Content_TR,
                PhotoPath = _fileService.GetFileUrl(safetyComponent.PhotoName, FilePath.Safety)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(SafetyEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Safety = true;

            var safetyComponent = await _unitOfWork.SafetyComponent.GetAsync();
            if (safetyComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                safetyComponent.Title_AZ = model.Title_AZ;
                safetyComponent.Title_RU = model.Title_RU;
                safetyComponent.Title_EN = model.Title_EN;
                safetyComponent.Title_TR = model.Title_TR;
                safetyComponent.Content_AZ = model.Content_AZ;
                safetyComponent.Content_RU = model.Content_RU;
                safetyComponent.Content_EN = model.Content_EN;
                safetyComponent.Content_TR = model.Content_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(safetyComponent.PhotoName, FilePath.Safety);
                    safetyComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Safety);
                }

                await _unitOfWork.SafetyComponent.EditAsync(safetyComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Safety component <{safetyComponent.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Safety = true;

            var safetyComponent = await _unitOfWork.SafetyComponent.GetAsync();
            if (safetyComponent == null) return NotFound();

            var model = new SafetyDetailsComponentViewModel
            {
                Title_AZ = safetyComponent.Title_AZ,
                Title_RU = safetyComponent.Title_RU,
                Title_EN = safetyComponent.Title_EN,
                Title_TR = safetyComponent.Title_TR,
                Content_AZ = safetyComponent.Content_AZ,
                Content_RU = safetyComponent.Content_RU,
                Content_EN = safetyComponent.Content_EN,
                Content_TR = safetyComponent.Content_TR,
                PhotoPath = _fileService.GetFileUrl(safetyComponent.PhotoName, FilePath.Safety),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddSubComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Safety = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubComponent(SafetyAddSubComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Safety = true;

            if (ModelState.IsValid)
            {
                var safetySubComponent = new SafetySubComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    ContentSafety_AZ = model.ContentSafety_AZ,
                    ContentSafety_RU = model.ContentSafety_RU,
                    ContentSafety_EN = model.ContentSafety_EN,
                    ContentSafety_TR = model.ContentSafety_TR,
                    Slug = model.Slug.Slugify(),
                    isBanner = model.isBanner,
                    PhotoName_Safety = await _fileService.UploadFileAsync(model.Photo_Safety, FilePath.Safety)
                };

                await _unitOfWork.SafetySubComponent.CreateAsync(safetySubComponent);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var safetySubComponentPhoto = new SafetySubComponentPhoto
                    {
                        SafetySubComponentId = safetySubComponent.Id,
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.Safety)
                    };

                    await _unitOfWork.SafetySubComponentPhoto.CreateAsync(safetySubComponentPhoto);
                    await _unitOfWork.CommitAsync();
                }

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditSubComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Safety = true;

            var safetySubComponent = await _unitOfWork.SafetySubComponent.GetAsync(id);
            if (safetySubComponent == null) return NotFound();

            var model = new SafetyEditSubComponentViewModel
            {
                Id = safetySubComponent.Id,
                Title_AZ = safetySubComponent.Title_AZ,
                Title_RU = safetySubComponent.Title_RU,
                Title_EN = safetySubComponent.Title_EN,
                Title_TR = safetySubComponent.Title_TR,
                Content_AZ = safetySubComponent.Content_AZ,
                Content_RU = safetySubComponent.Content_RU,
                Content_EN = safetySubComponent.Content_EN,
                Content_TR = safetySubComponent.Content_TR,
                ContentSafety_AZ = safetySubComponent.ContentSafety_AZ,
                ContentSafety_RU = safetySubComponent.ContentSafety_RU,
                ContentSafety_EN = safetySubComponent.ContentSafety_EN,
                ContentSafety_TR = safetySubComponent.ContentSafety_TR,
                isBanner = safetySubComponent.isBanner,
                Slug = safetySubComponent.Slug,
                PhotoName_Safety = safetySubComponent.PhotoName_Safety,
                SafetySubComponentPhotos = safetySubComponent.SafetySubComponentPhotos
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSubComponent(SafetyEditSubComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Safety = true;

            var safetySubComponent = await _unitOfWork.SafetySubComponent.GetAsync(model.Id);
            if (safetySubComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                safetySubComponent.Title_AZ = model.Title_AZ;
                safetySubComponent.Title_RU = model.Title_RU;
                safetySubComponent.Title_EN = model.Title_EN;
                safetySubComponent.Title_TR = model.Title_TR;
                safetySubComponent.Content_AZ = model.Content_AZ;
                safetySubComponent.Content_RU = model.Content_RU;
                safetySubComponent.Content_EN = model.Content_EN;
                safetySubComponent.Content_TR = model.Content_TR;
                safetySubComponent.ContentSafety_AZ = model.ContentSafety_AZ;
                safetySubComponent.ContentSafety_RU = model.ContentSafety_RU;
                safetySubComponent.ContentSafety_EN = model.ContentSafety_EN;
                safetySubComponent.ContentSafety_TR = model.ContentSafety_TR;
                safetySubComponent.isBanner = model.isBanner;
                safetySubComponent.Slug = model.Slug.Slugify();

                if (model.Photo_Safety != null)
                {
                    _fileService.Delete(safetySubComponent.PhotoName_Safety, FilePath.Safety);
                    safetySubComponent.PhotoName_Safety = await _fileService.UploadFileAsync(model.Photo_Safety, FilePath.Safety);
                }

                await _unitOfWork.SafetySubComponent.EditAsync(safetySubComponent);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var safetySubComponentPhoto = new SafetySubComponentPhoto
                    {
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.Safety),
                        SafetySubComponentId = safetySubComponent.Id
                    };

                    await _unitOfWork.SafetySubComponentPhoto.CreateAsync(safetySubComponentPhoto);
                    await _unitOfWork.CommitAsync();
                }

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsSubComponent(int id)
        {
            var safetySubComponent = await _unitOfWork.SafetySubComponent.GetAsync(id);
            if (safetySubComponent == null) return NotFound();

            var model = new SafetyDetailsSubComponentViewModel
            {
                Title_AZ = safetySubComponent.Title_AZ,
                Title_RU = safetySubComponent.Title_RU,
                Title_EN = safetySubComponent.Title_EN,
                Title_TR = safetySubComponent.Title_TR,
                Slug = safetySubComponent.Slug,
                Content_AZ = safetySubComponent.Content_AZ,
                Content_RU = safetySubComponent.Content_RU,
                Content_EN = safetySubComponent.Content_EN,
                Content_TR = safetySubComponent.Content_TR,
                ContentSafety_AZ = safetySubComponent.ContentSafety_AZ,
                ContentSafety_RU = safetySubComponent.ContentSafety_RU,
                ContentSafety_EN = safetySubComponent.ContentSafety_EN,
                ContentSafety_TR = safetySubComponent.ContentSafety_TR,
                isBanner = safetySubComponent.isBanner,
                PhotoPath_Safety = _fileService.GetFileUrl(safetySubComponent.PhotoName_Safety, FilePath.Safety),
                SafetySubComponentPhotos = safetySubComponent.SafetySubComponentPhotos
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSubComponent(int id)
        {
            var safetySubComponent = await _unitOfWork.SafetySubComponent.GetAsync(id);
            if (safetySubComponent == null) return NotFound();

            _fileService.Delete(safetySubComponent.PhotoName_Safety, FilePath.Safety);

            foreach (var safetySubComponentPhoto in safetySubComponent.SafetySubComponentPhotos)
                _fileService.Delete(safetySubComponentPhoto.PhotoName, FilePath.Safety);

            await _unitOfWork.SafetySubComponent.DeleteAsync(safetySubComponent);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSubComponentPhoto(int id)
        {
            var safetySubComponentPhoto = await _unitOfWork.SafetySubComponentPhoto.GetAsync(id);
            if (safetySubComponentPhoto == null) return NotFound();

            _fileService.Delete(safetySubComponentPhoto.PhotoName, FilePath.Safety);

            await _unitOfWork.SafetySubComponentPhoto.DeleteAsync(safetySubComponentPhoto);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("editsubcomponent", "safety", new { id = safetySubComponentPhoto.SafetySubComponentId });
        }
    }
}
