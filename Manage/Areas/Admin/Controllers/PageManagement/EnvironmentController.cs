using Core;
using Core.Constants.File;
using Core.Extensions;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.Environment;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class EnvironmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public EnvironmentController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.Environment = true;

            var model = new EnvironmentIndexViewModel
            {
                EnvironmentComponent = await _unitOfWork.EnvironmentComponent.GetAsync(),
                EnvironmentSubComponents = await _unitOfWork.EnvironmentSubComponent.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Environment = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(EnvironmentDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Environment = true;

            if (ModelState.IsValid)
            {
                var environmentComponent = new EnvironmentComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Environment)
                };

                await _unitOfWork.EnvironmentComponent.CreateAsync(environmentComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Environment component <{environmentComponent.Title_EN}> successfully defined.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Environment = true;

            var environmentComponent = await _unitOfWork.EnvironmentComponent.GetAsync();
            if (environmentComponent == null) return NotFound();

            var model = new EnvironmentEditComponentViewModel
            {
                Id = environmentComponent.Id,
                Title_AZ = environmentComponent.Title_AZ,
                Title_RU = environmentComponent.Title_RU,
                Title_EN = environmentComponent.Title_EN,
                Title_TR = environmentComponent.Title_TR,
                Content_AZ = environmentComponent.Content_AZ,
                Content_RU = environmentComponent.Content_RU,
                Content_EN = environmentComponent.Content_EN,
                Content_TR = environmentComponent.Content_TR,
                PhotoPath = _fileService.GetFileUrl(environmentComponent.PhotoName, FilePath.Environment)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(EnvironmentEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Environment = true;

            var environmentComponent = await _unitOfWork.EnvironmentComponent.GetAsync();
            if (environmentComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                environmentComponent.Title_AZ = model.Title_AZ;
                environmentComponent.Title_RU = model.Title_RU;
                environmentComponent.Title_EN = model.Title_EN;
                environmentComponent.Title_TR = model.Title_TR;
                environmentComponent.Content_AZ = model.Content_AZ;
                environmentComponent.Content_RU = model.Content_RU;
                environmentComponent.Content_EN = model.Content_EN;
                environmentComponent.Content_TR = model.Content_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(environmentComponent.PhotoName, FilePath.Environment);
                    environmentComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Environment);
                }

                await _unitOfWork.EnvironmentComponent.EditAsync(environmentComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Environment component <{environmentComponent.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Environment = true;

            var environmentComponent = await _unitOfWork.EnvironmentComponent.GetAsync();
            if (environmentComponent == null) return NotFound();

            var model = new EnvironmentDetailsComponentViewModel
            {
                Title_AZ = environmentComponent.Title_AZ,
                Title_RU = environmentComponent.Title_RU,
                Title_EN = environmentComponent.Title_EN,
                Title_TR = environmentComponent.Title_TR,
                Content_AZ = environmentComponent.Content_AZ,
                Content_RU = environmentComponent.Content_RU,
                Content_EN = environmentComponent.Content_EN,
                Content_TR = environmentComponent.Content_TR,
                PhotoPath = _fileService.GetFileUrl(environmentComponent.PhotoName, FilePath.Environment),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddSubComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Environment = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubComponent(EnvironmentAddSubComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Environment = true;

            if (ModelState.IsValid)
            {
                var environmentSubComponent = new EnvironmentSubComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    ContentEnvironment_AZ = model.ContentEnvironment_AZ,
                    ContentEnvironment_RU = model.ContentEnvironment_RU,
                    ContentEnvironment_EN = model.ContentEnvironment_EN,
                    ContentEnvironment_TR = model.ContentEnvironment_TR,
                    Slug = model.Slug.Slugify(),
                    isBanner = model.isBanner,
                    PhotoName_Environment = await _fileService.UploadFileAsync(model.Photo_Environment, FilePath.Environment)
                };

                await _unitOfWork.EnvironmentSubComponent.CreateAsync(environmentSubComponent);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var environmentSubComponentPhoto = new EnvironmentSubComponentPhoto
                    {
                        EnvironmentSubComponentId = environmentSubComponent.Id,
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.Environment)
                    };

                    await _unitOfWork.EnvironmentSubComponentPhoto.CreateAsync(environmentSubComponentPhoto);
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
            ViewBag.Environment = true;

            var environmentSubComponent = await _unitOfWork.EnvironmentSubComponent.GetAsync(id);
            if (environmentSubComponent == null) return NotFound();

            var model = new EnvironmentEditSubComponentViewModel
            {
                Id = environmentSubComponent.Id,
                Title_AZ = environmentSubComponent.Title_AZ,
                Title_RU = environmentSubComponent.Title_RU,
                Title_EN = environmentSubComponent.Title_EN,
                Title_TR = environmentSubComponent.Title_TR,
                Content_AZ = environmentSubComponent.Content_AZ,
                Content_RU = environmentSubComponent.Content_RU,
                Content_EN = environmentSubComponent.Content_EN,
                Content_TR = environmentSubComponent.Content_TR,
                ContentEnvironment_AZ = environmentSubComponent.ContentEnvironment_AZ,
                ContentEnvironment_RU = environmentSubComponent.ContentEnvironment_RU,
                ContentEnvironment_EN = environmentSubComponent.ContentEnvironment_EN,
                ContentEnvironment_TR = environmentSubComponent.ContentEnvironment_TR,
                isBanner = environmentSubComponent.isBanner,
                Slug = environmentSubComponent.Slug,
                PhotoName_Environment = environmentSubComponent.PhotoName_Environment,
                EnvironmentSubComponentPhotos = environmentSubComponent.EnvironmentSubComponentPhotos
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSubComponent(EnvironmentEditSubComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Environment = true;

            var environmentSubComponent = await _unitOfWork.EnvironmentSubComponent.GetAsync(model.Id);
            if (environmentSubComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                environmentSubComponent.Title_AZ = model.Title_AZ;
                environmentSubComponent.Title_RU = model.Title_RU;
                environmentSubComponent.Title_EN = model.Title_EN;
                environmentSubComponent.Title_TR = model.Title_TR;
                environmentSubComponent.Content_AZ = model.Content_AZ;
                environmentSubComponent.Content_RU = model.Content_RU;
                environmentSubComponent.Content_EN = model.Content_EN;
                environmentSubComponent.Content_TR = model.Content_TR;
                environmentSubComponent.ContentEnvironment_AZ = model.ContentEnvironment_AZ;
                environmentSubComponent.ContentEnvironment_RU = model.ContentEnvironment_RU;
                environmentSubComponent.ContentEnvironment_EN = model.ContentEnvironment_EN;
                environmentSubComponent.ContentEnvironment_TR = model.ContentEnvironment_TR;
                environmentSubComponent.isBanner = model.isBanner;
                environmentSubComponent.Slug = model.Slug.Slugify();

                if (model.Photo_Environment != null)
                {
                    _fileService.Delete(environmentSubComponent.PhotoName_Environment, FilePath.Environment);
                    environmentSubComponent.PhotoName_Environment = await _fileService.UploadFileAsync(model.Photo_Environment, FilePath.Environment);
                }

                await _unitOfWork.EnvironmentSubComponent.EditAsync(environmentSubComponent);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var environmentSubComponentPhoto = new EnvironmentSubComponentPhoto
                    {
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.Environment),
                        EnvironmentSubComponentId = environmentSubComponent.Id
                    };

                    await _unitOfWork.EnvironmentSubComponentPhoto.CreateAsync(environmentSubComponentPhoto);
                    await _unitOfWork.CommitAsync();
                }

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsSubComponent(int id)
        {
            var environmentSubComponent = await _unitOfWork.EnvironmentSubComponent.GetAsync(id);
            if (environmentSubComponent == null) return NotFound();

            var model = new EnvironmentDetailsSubComponentViewModel
            {
                Title_AZ = environmentSubComponent.Title_AZ,
                Title_RU = environmentSubComponent.Title_RU,
                Title_EN = environmentSubComponent.Title_EN,
                Title_TR = environmentSubComponent.Title_TR,
                Slug = environmentSubComponent.Slug,
                Content_AZ = environmentSubComponent.Content_AZ,
                Content_RU = environmentSubComponent.Content_RU,
                Content_EN = environmentSubComponent.Content_EN,
                Content_TR = environmentSubComponent.Content_TR,
                ContentEnvironment_AZ = environmentSubComponent.ContentEnvironment_AZ,
                ContentEnvironment_RU = environmentSubComponent.ContentEnvironment_RU,
                ContentEnvironment_EN = environmentSubComponent.ContentEnvironment_EN,
                ContentEnvironment_TR = environmentSubComponent.ContentEnvironment_TR,
                isBanner = environmentSubComponent.isBanner,
                PhotoPath_Environment = _fileService.GetFileUrl(environmentSubComponent.PhotoName_Environment, FilePath.Environment),
                EnvironmentSubComponentPhotos = environmentSubComponent.EnvironmentSubComponentPhotos
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSubComponent(int id)
        {
            var environmentSubComponent = await _unitOfWork.EnvironmentSubComponent.GetAsync(id);
            if (environmentSubComponent == null) return NotFound();

            _fileService.Delete(environmentSubComponent.PhotoName_Environment, FilePath.Environment);

            foreach (var environmentSubComponentPhoto in environmentSubComponent.EnvironmentSubComponentPhotos)
                _fileService.Delete(environmentSubComponentPhoto.PhotoName, FilePath.Environment);

            await _unitOfWork.EnvironmentSubComponent.DeleteAsync(environmentSubComponent);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSubComponentPhoto(int id)
        {
            var environmentSubComponentPhoto = await _unitOfWork.EnvironmentSubComponentPhoto.GetAsync(id);
            if (environmentSubComponentPhoto == null) return NotFound();

            _fileService.Delete(environmentSubComponentPhoto.PhotoName, FilePath.Environment);

            await _unitOfWork.EnvironmentSubComponentPhoto.DeleteAsync(environmentSubComponentPhoto);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("editsubcomponent", "environment", new { id = environmentSubComponentPhoto.EnvironmentSubComponentId });
        }
    }
}
