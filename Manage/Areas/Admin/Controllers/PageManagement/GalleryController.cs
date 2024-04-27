using Core;
using Core.Constants.File;
using Core.Extensions;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.Gallery;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class GalleryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public GalleryController(
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
            ViewBag.Gallery = true;

            var model = new GalleryIndexViewModel
            {
                ImageGalleryComponents = await _unitOfWork.ImageGalleryComponent.GetAllAsync(),
                VideoGalleryComponents = await _unitOfWork.VideoGalleryComponent.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddImageComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Gallery = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddImageComponent(GalleryAddImageComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Gallery = true;

            if (ModelState.IsValid)
            {
                var imageGalleryComponent = new ImageGalleryComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Slug = model.Slug.Slugify(),
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Gallery)
                };

                await _unitOfWork.ImageGalleryComponent.CreateAsync(imageGalleryComponent);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var imageGalleryComponentPhoto = new ImageGalleryComponentPhoto
                    {
                        ImageGalleryComponentId = imageGalleryComponent.Id,
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.Gallery)
                    };

                    await _unitOfWork.ImageGalleryComponentPhoto.CreateAsync(imageGalleryComponentPhoto);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"Image Gallery component <{imageGalleryComponent.Title_EN}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditImageComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Gallery = true;

            var imageGalleryComponent = await _unitOfWork.ImageGalleryComponent.GetAsync(id);
            if (imageGalleryComponent == null) return NotFound();

            var model = new GalleryEditImageComponentViewModel
            {
                Id = imageGalleryComponent.Id,
                Title_AZ = imageGalleryComponent.Title_AZ,
                Title_RU = imageGalleryComponent.Title_RU,
                Title_EN = imageGalleryComponent.Title_EN,
                Title_TR = imageGalleryComponent.Title_TR,
                Slug = imageGalleryComponent.Slug,
                PhotoName = imageGalleryComponent.PhotoName,
                ImageGalleryComponentPhotos = imageGalleryComponent.ImageGalleryComponentPhotos
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditImageComponent(GalleryEditImageComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Gallery = true;

            var imageGalleryComponent = await _unitOfWork.ImageGalleryComponent.GetAsync(model.Id);
            if (imageGalleryComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                imageGalleryComponent.Title_AZ = model.Title_AZ;
                imageGalleryComponent.Title_RU = model.Title_RU;
                imageGalleryComponent.Title_EN = model.Title_EN;
                imageGalleryComponent.Title_TR = model.Title_TR;
                imageGalleryComponent.Slug = model.Slug;

                if (model.Photo != null)
                {
                    _fileService.Delete(imageGalleryComponent.PhotoName, FilePath.Gallery);
                    imageGalleryComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Gallery);
                }

                await _unitOfWork.ImageGalleryComponent.EditAsync(imageGalleryComponent);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var imageGalleryComponentPhoto = new ImageGalleryComponentPhoto
                    {
                        ImageGalleryComponentId = imageGalleryComponent.Id,
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.Gallery)
                    };

                    await _unitOfWork.ImageGalleryComponentPhoto.CreateAsync(imageGalleryComponentPhoto);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"Image Gallery component <{imageGalleryComponent.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsImageComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Gallery = true;

            var imageGalleryComponent = await _unitOfWork.ImageGalleryComponent.GetAsync(id);
            if (imageGalleryComponent == null) return NotFound();

            return View(imageGalleryComponent);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteImageComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Gallery = true;

            var imageGalleryComponent = await _unitOfWork.ImageGalleryComponent.GetAsync(id);
            if (imageGalleryComponent == null) return NotFound();

            _fileService.Delete(imageGalleryComponent.PhotoName, FilePath.Gallery);

            foreach (var imageGalleryComponentPhoto in imageGalleryComponent.ImageGalleryComponentPhotos)
                _fileService.Delete(imageGalleryComponentPhoto.PhotoName, FilePath.Gallery);

            await _unitOfWork.ImageGalleryComponent.DeleteAsync(imageGalleryComponent);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Image Gallery component <{imageGalleryComponent.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteImageComponentPhoto(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Gallery = true;

            var imageGalleryComponentPhoto = await _unitOfWork.ImageGalleryComponentPhoto.GetAsync(id);
            if (imageGalleryComponentPhoto == null) return NotFound();

            _fileService.Delete(imageGalleryComponentPhoto.PhotoName, FilePath.Gallery);

            await _unitOfWork.ImageGalleryComponentPhoto.DeleteAsync(imageGalleryComponentPhoto);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Image Gallery component photo <{imageGalleryComponentPhoto.PhotoName}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("editimagecomponent", "gallery", new { id = imageGalleryComponentPhoto.ImageGalleryComponentId });
        }

        [HttpGet]
        public async Task<IActionResult> AddVideoComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Gallery = true;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddVideoComponent(GalleryAddVideoComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Gallery = true;

            if (ModelState.IsValid)
            {
                var videoGalleryComponent = new VideoGalleryComponent
                {
                    Link = model.Link,
                    Order = model.Order,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Gallery)
                };

                await _unitOfWork.VideoGalleryComponent.CreateAsync(videoGalleryComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Video Gallery component <{videoGalleryComponent.PhotoName}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditVideoComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Gallery = true;

            var videoGalleryComponent = await _unitOfWork.VideoGalleryComponent.GetAsync(id);
            if (videoGalleryComponent == null) return NotFound();

            var model = new GalleryEditVideoComponentViewModel
            {
                Id = videoGalleryComponent.Id,
                Link = videoGalleryComponent.Link,
                Order = videoGalleryComponent.Order,
                PhotoName = videoGalleryComponent.PhotoName
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditVideoComponent(GalleryEditVideoComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Gallery = true;

            var videoGalleryComponent = await _unitOfWork.VideoGalleryComponent.GetAsync(model.Id);
            if (videoGalleryComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                videoGalleryComponent.Link = model.Link;
                videoGalleryComponent.Order = model.Order;

                if (model.Photo != null)
                {
                    _fileService.Delete(videoGalleryComponent.PhotoName, FilePath.Gallery);
                    videoGalleryComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Gallery);
                }

                await _unitOfWork.VideoGalleryComponent.EditAsync(videoGalleryComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Video Gallery component <{videoGalleryComponent.PhotoName}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteVideoComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Gallery = true;

            var videoGalleryComponent = await _unitOfWork.VideoGalleryComponent.GetAsync(id);
            if (videoGalleryComponent == null) return NotFound();

            _fileService.Delete(videoGalleryComponent.PhotoName, FilePath.Gallery);

            await _unitOfWork.VideoGalleryComponent.DeleteAsync(videoGalleryComponent);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Video Gallery component <{videoGalleryComponent.PhotoName}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("index");
        }
    }
}
