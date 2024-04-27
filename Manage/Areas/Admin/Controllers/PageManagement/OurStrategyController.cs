using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.OurStrategy;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class OurStrategyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public OurStrategyController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            var model = new OurStrategyIndexViewModel
            {
                OurStrategyComponents = await _unitOfWork.OurStrategyComponents.GetAllAsync(),
                KeyAreaComponents = await _unitOfWork.KeyAreaComponents.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComponent(OurStrategyAddComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            if (!ModelState.IsValid) return View(model);

            var ourStrategyComponent = new OurStrategyComponent
            {
                Title_AZ = model.Title_AZ,
                Title_RU = model.Title_RU,
                Title_EN = model.Title_EN,
                Title_TR = model.Title_TR,
                Content_AZ = model.Content_AZ,
                Content_RU = model.Content_RU,
                Content_EN = model.Content_EN,
                Content_TR = model.Content_TR,
                IsBanner = model.IsBanner,
                VideoLink = model.VideoLink,
                PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.OurStrategy),
            };

            await _unitOfWork.OurStrategyComponents.CreateAsync(ourStrategyComponent);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            var ourStrategyComponent = await _unitOfWork.OurStrategyComponents.GetAsync(id);
            if (ourStrategyComponent == null) return NotFound();

            var model = new OurStrategyEditComponentViewModel
            {
                Id = ourStrategyComponent.Id,
                Title_AZ = ourStrategyComponent.Title_AZ,
                Title_RU = ourStrategyComponent.Title_RU,
                Title_EN = ourStrategyComponent.Title_EN,
                Title_TR = ourStrategyComponent.Title_TR,
                Content_AZ = ourStrategyComponent.Content_AZ,
                Content_RU = ourStrategyComponent.Content_RU,
                Content_EN = ourStrategyComponent.Content_EN,
                Content_TR = ourStrategyComponent.Content_TR,
                IsBanner = ourStrategyComponent.IsBanner,
                VideoLink = ourStrategyComponent.VideoLink,
                PhotoPath = _fileService.GetFileUrl(ourStrategyComponent.PhotoName, FilePath.OurStrategy),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(OurStrategyEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            if (!ModelState.IsValid) return View(model);

            var ourStrategyComponent = await _unitOfWork.OurStrategyComponents.GetAsync(model.Id);
            if (ourStrategyComponent == null) return NotFound();

            ourStrategyComponent.Title_AZ = model.Title_AZ;
            ourStrategyComponent.Title_RU = model.Title_RU;
            ourStrategyComponent.Title_EN = model.Title_EN;
            ourStrategyComponent.Title_TR = model.Title_TR;
            ourStrategyComponent.Content_AZ = model.Content_AZ;
            ourStrategyComponent.Content_RU = model.Content_RU;
            ourStrategyComponent.Content_EN = model.Content_EN;
            ourStrategyComponent.Content_TR = model.Content_TR;
            ourStrategyComponent.IsBanner = model.IsBanner;
            ourStrategyComponent.VideoLink = model.VideoLink;

            if (model.Photo != null)
            {
                _fileService.Delete(ourStrategyComponent.PhotoName, FilePath.OurStrategy);
                ourStrategyComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.OurStrategy);
            }

            await _unitOfWork.OurStrategyComponents.EditAsync(ourStrategyComponent);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            var ourStrategyComponent = await _unitOfWork.OurStrategyComponents.GetAsync(id);
            if (ourStrategyComponent == null) return NotFound();

            var model = new OurStrategyDetailsComponentViewModel
            {
                Id = ourStrategyComponent.Id,
                Title_AZ = ourStrategyComponent.Title_AZ,
                Title_RU = ourStrategyComponent.Title_RU,
                Title_EN = ourStrategyComponent.Title_EN,
                Title_TR = ourStrategyComponent.Title_TR,
                Content_AZ = ourStrategyComponent.Content_AZ,
                Content_RU = ourStrategyComponent.Content_RU,
                Content_EN = ourStrategyComponent.Content_EN,
                Content_TR = ourStrategyComponent.Content_TR,
                IsBanner = ourStrategyComponent.IsBanner,
                VideoLink = ourStrategyComponent.VideoLink,
                PhotoPath = _fileService.GetFileUrl(ourStrategyComponent.PhotoName, FilePath.OurStrategy),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            var ourStrategyComponent = await _unitOfWork.OurStrategyComponents.GetAsync(id);
            if (ourStrategyComponent == null) return NotFound();

            _fileService.Delete(ourStrategyComponent.PhotoName, FilePath.OurStrategy);

            await _unitOfWork.OurStrategyComponents.DeleteAsync(ourStrategyComponent);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> AddKeyAreaComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddKeyAreaComponent(OurStrategyAddKeyAreaComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            if (!ModelState.IsValid) return View(model);

            var keyAreaComponent = new KeyAreaComponent
            {
                Title_AZ = model.Title_AZ,
                Title_RU = model.Title_RU,
                Title_EN = model.Title_EN,
                Title_TR = model.Title_TR,
                Content_AZ = model.Content_AZ,
                Content_RU = model.Content_RU,
                Content_EN = model.Content_EN,
                Content_TR = model.Content_TR,
                PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.OurStrategy)
            };

            await _unitOfWork.KeyAreaComponents.CreateAsync(keyAreaComponent);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> EditKeyAreaComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            var keyAreaComponent = await _unitOfWork.KeyAreaComponents.GetAsync(id);
            if (keyAreaComponent == null) return NotFound();

            var model = new OurStrategyEditKeyAreaComponentViewModel
            {
                Id = keyAreaComponent.Id,
                Title_AZ = keyAreaComponent.Title_AZ,
                Title_RU = keyAreaComponent.Title_RU,
                Title_EN = keyAreaComponent.Title_EN,
                Title_TR = keyAreaComponent.Title_TR,
                Content_AZ = keyAreaComponent.Content_AZ,
                Content_RU = keyAreaComponent.Content_RU,
                Content_EN = keyAreaComponent.Content_EN,
                Content_TR = keyAreaComponent.Content_TR,
                PhotoPath = _fileService.GetFileUrl(keyAreaComponent.PhotoName, FilePath.OurStrategy)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditKeyAreaComponent(OurStrategyEditKeyAreaComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            if (!ModelState.IsValid) return View(model);

            var keyAreaComponent = await _unitOfWork.KeyAreaComponents.GetAsync(model.Id);
            if (keyAreaComponent == null) return NotFound();

            keyAreaComponent.Title_AZ = model.Title_AZ;
            keyAreaComponent.Title_RU = model.Title_RU;
            keyAreaComponent.Title_EN = model.Title_EN;
            keyAreaComponent.Title_TR = model.Title_TR;
            keyAreaComponent.Content_AZ = model.Content_AZ;
            keyAreaComponent.Content_RU = model.Content_RU;
            keyAreaComponent.Content_EN = model.Content_EN;
            keyAreaComponent.Content_TR = model.Content_TR;

            if (model.Photo != null)
            {
                _fileService.Delete(keyAreaComponent.PhotoName, FilePath.OurStrategy);
                keyAreaComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.OurStrategy);
            }

            await _unitOfWork.KeyAreaComponents.EditAsync(keyAreaComponent);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> DetailsKeyAreaComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            var keyAreaComponent = await _unitOfWork.KeyAreaComponents.GetAsync(id);
            if (keyAreaComponent == null) return NotFound();

            var model = new OurStrategyDetailsKeyAreaComponentViewModel
            {
                Title_AZ = keyAreaComponent.Title_AZ,
                Title_RU = keyAreaComponent.Title_RU,
                Title_EN = keyAreaComponent.Title_EN,
                Title_TR = keyAreaComponent.Title_TR,
                Content_AZ = keyAreaComponent.Content_AZ,
                Content_RU = keyAreaComponent.Content_RU,
                Content_EN = keyAreaComponent.Content_EN,
                Content_TR = keyAreaComponent.Content_TR,
                PhotoPath = _fileService.GetFileUrl(keyAreaComponent.PhotoName, FilePath.OurStrategy)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteKeyAreaComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurStrategy = true;

            var keyAreaComponent = await _unitOfWork.KeyAreaComponents.GetAsync(id);
            if (keyAreaComponent == null) return NotFound();

            await _unitOfWork.KeyAreaComponents.DeleteAsync(keyAreaComponent);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("index");
        }
    }
}
