using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.NobelHeritage;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class NobelHeritageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public NobelHeritageController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.NobelHeritage = true;

            var model = new NobelHeritageIndexViewModel
            {
                NobelHeritage = await _unitOfWork.NobelHeritage.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.NobelHeritage = true;

            var nobelHeritage = await _unitOfWork.NobelHeritage.GetAsync();
            if (nobelHeritage != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(NobelHeritageDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.NobelHeritage = true;

            if (ModelState.IsValid)
            {
                var nobelHeritage = new NobelHeritage
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
                    PhotoName = await _fileService.UploadFileAsync(model.MainPhoto, FilePath.NobelHeritage)
                };

                await _unitOfWork.NobelHeritage.CreateAsync(nobelHeritage);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var nobelHeritagePhoto = new NobelHeritagePhoto
                    {
                        NobelHeritageId = nobelHeritage.Id,
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.NobelHeritage)
                    };

                    await _unitOfWork.NobelHeritagePhoto.CreateAsync(nobelHeritagePhoto);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"Nobel heritage component successfully defined.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.NobelHeritage = true;

            var nobelHeritage = await _unitOfWork.NobelHeritage.GetAsync();
            if (nobelHeritage == null) return NotFound();

            var model = new NobelHeritageEditComponentViewModel
            {
                Id = nobelHeritage.Id,
                Title_AZ = nobelHeritage.Title_AZ,
                Title_RU = nobelHeritage.Title_RU,
                Title_EN = nobelHeritage.Title_EN,
                Title_TR = nobelHeritage.Title_TR,
                Content_AZ = nobelHeritage.Content_AZ,
                Content_RU = nobelHeritage.Content_RU,
                Content_EN = nobelHeritage.Content_EN,
                Content_TR = nobelHeritage.Content_TR,
                ContentWWA_AZ = nobelHeritage.ContentWWA_AZ,
                ContentWWA_RU = nobelHeritage.ContentWWA_RU,
                ContentWWA_EN = nobelHeritage.ContentWWA_EN,
                ContentWWA_TR = nobelHeritage.ContentWWA_TR,
                NobelHeritagePhotos = nobelHeritage.NobelHeritagePhotos,
                PhotoPath = _fileService.GetFileUrl(nobelHeritage.PhotoName, FilePath.NobelHeritage)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(NobelHeritageEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.NobelHeritage = true;

            var nobelHeritage = await _unitOfWork.NobelHeritage.GetAsync();
            if (nobelHeritage == null) return NotFound();

            if (ModelState.IsValid)
            {
                nobelHeritage.Title_AZ = model.Title_AZ;
                nobelHeritage.Title_RU = model.Title_RU;
                nobelHeritage.Title_EN = model.Title_EN;
                nobelHeritage.Title_TR = model.Title_TR;
                nobelHeritage.Content_AZ = model.Content_AZ;
                nobelHeritage.Content_RU = model.Content_RU;
                nobelHeritage.Content_EN = model.Content_EN;
                nobelHeritage.Content_TR = model.Content_TR;
                nobelHeritage.ContentWWA_AZ = model.ContentWWA_AZ;
                nobelHeritage.ContentWWA_RU = model.ContentWWA_RU;
                nobelHeritage.ContentWWA_EN = model.ContentWWA_EN;
                nobelHeritage.ContentWWA_TR = model.ContentWWA_TR;

                if (model.NewPhoto != null)
                {
                    _fileService.Delete(nobelHeritage.PhotoName, FilePath.NobelHeritage);
                    nobelHeritage.PhotoName = await _fileService.UploadFileAsync(model.NewPhoto, FilePath.NobelHeritage);
                }

                await _unitOfWork.NobelHeritage.EditAsync(nobelHeritage);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var nobelHeritagePhoto = new NobelHeritagePhoto
                    {
                        NobelHeritageId = nobelHeritage.Id,
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.NobelHeritage)
                    };

                    await _unitOfWork.NobelHeritagePhoto.CreateAsync(nobelHeritagePhoto);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"Nobel heritage component successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.NobelHeritage = true;

            var nobelHeritage = await _unitOfWork.NobelHeritage.GetAsync();
            if (nobelHeritage == null) return NotFound();

            return View("DetailsComponent", nobelHeritage);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComponentPhoto(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.NobelHeritage = true;

            var nobelHeritagePhoto = await _unitOfWork.NobelHeritagePhoto.GetAsync(id);
            if (nobelHeritagePhoto == null) return NotFound();

            _fileService.Delete(nobelHeritagePhoto.PhotoName, FilePath.NobelHeritage);

            await _unitOfWork.NobelHeritagePhoto.DeleteAsync(nobelHeritagePhoto);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Nobel heritage component photo <{nobelHeritagePhoto.PhotoName}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("editcomponent");
        }
    }
}
