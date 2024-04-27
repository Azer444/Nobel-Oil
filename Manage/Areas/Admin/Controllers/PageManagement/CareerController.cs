using Core;
using Core.Constants;
using Core.Constants.File;
using Core.Extensions;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.Career;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class CareerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public CareerController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            var model = new CareerIndexViewModel
            {
                PageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Career),
                CareerComponents = await _unitOfWork.CareerComponent.GetAllAsync(),
                CareerTipComponents = await _unitOfWork.CareerTipComponent.GetAllAsync()
            };

            return View(model);
        }

        #region MainPhoto

        [HttpGet]
        public async Task<IActionResult> DefineMainPhoto()
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            var pageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Career);
            if (pageMainPhoto != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineMainPhoto(CareerDefineMainPhotoViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            if (ModelState.IsValid)
            {
                var pageMainPhoto = new PageMainPhoto
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Page = Page.Career,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.PageMainPhoto)
                };

                await _unitOfWork.PageMainPhoto.CreateAsync(pageMainPhoto);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Page Main Photo <{pageMainPhoto.PhotoName}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet("/admin/career/editmainphoto")]
        public async Task<IActionResult> EditMainPhoto()
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            var pageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Career);
            if (pageMainPhoto == null) return NotFound();

            var model = new CareerEditMainPhotoViewModel
            {
                Id = pageMainPhoto.Id,
                Title_AZ = pageMainPhoto.Title_AZ,
                Title_RU = pageMainPhoto.Title_RU,
                Title_EN = pageMainPhoto.Title_EN,
                Title_TR = pageMainPhoto.Title_TR,
                PhotoPath = _fileService.GetFileUrl(pageMainPhoto.PhotoName, FilePath.PageMainPhoto),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditMainPhoto(CareerEditMainPhotoViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            var pageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Career);
            if (pageMainPhoto == null) return NotFound();

            if (ModelState.IsValid)
            {
                pageMainPhoto.Title_AZ = model.Title_AZ;
                pageMainPhoto.Title_RU = model.Title_RU;
                pageMainPhoto.Title_EN = model.Title_EN;
                pageMainPhoto.Title_TR = model.Title_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(pageMainPhoto.PhotoName, FilePath.PageMainPhoto);
                    pageMainPhoto.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.PageMainPhoto);
                }

                await _unitOfWork.PageMainPhoto.EditAsync(pageMainPhoto);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Page Main Photo <{pageMainPhoto.PhotoName}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        #endregion

        #region Component

        [HttpGet("/admin/career/addcomponent")]
        public IActionResult AddComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComponent(CareerAddComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            if (ModelState.IsValid)
            {
                var careerComponent = new CareerComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    ContentCareer_AZ = model.ContentCareer_AZ,
                    ContentCareer_RU = model.ContentCareer_RU,
                    ContentCareer_EN = model.ContentCareer_EN,
                    ContentCareer_TR = model.ContentCareer_TR,
                    ShowVacancies = model.ShowVacancies,
                    IsBanner = model.IsBanner,
                    ImageOnRight = model.ImageOnRight,
                    Slug = model.Slug.Slugify(),
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Career),
                    PhotoName_Career = await _fileService.UploadFileAsync(model.Photo_Career, FilePath.Career)
                };

                await _unitOfWork.CareerComponent.CreateAsync(careerComponent);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            var careerComponent = await _unitOfWork.CareerComponent.GetAsync(id);
            if (careerComponent == null) return NotFound();

            var model = new CareerEditComponentViewModel
            {
                Id = careerComponent.Id,
                Title_AZ = careerComponent.Title_AZ,
                Title_RU = careerComponent.Title_RU,
                Title_EN = careerComponent.Title_EN,
                Title_TR = careerComponent.Title_TR,
                Content_AZ = careerComponent.Content_AZ,
                Content_RU = careerComponent.Content_RU,
                Content_EN = careerComponent.Content_EN,
                Content_TR = careerComponent.Content_TR,
                ContentCareer_AZ = careerComponent.ContentCareer_AZ,
                ContentCareer_RU = careerComponent.ContentCareer_RU,
                ContentCareer_EN = careerComponent.ContentCareer_EN,
                ContentCareer_TR = careerComponent.ContentCareer_TR,
                ShowVacancies = careerComponent.ShowVacancies,
                IsBanner = careerComponent.IsBanner,
                ImageOnRight = careerComponent.ImageOnRight,
                Slug = careerComponent.Slug,
                PhotoName = careerComponent.PhotoName,
                PhotoName_Career = careerComponent.PhotoName_Career,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(CareerEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            var careerComponent = await _unitOfWork.CareerComponent.GetAsync(model.Id);
            if (careerComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                careerComponent.Title_AZ = model.Title_AZ;
                careerComponent.Title_RU = model.Title_RU;
                careerComponent.Title_EN = model.Title_EN;
                careerComponent.Title_TR = model.Title_TR;
                careerComponent.Content_AZ = model.Content_AZ;
                careerComponent.Content_RU = model.Content_RU;
                careerComponent.Content_EN = model.Content_EN;
                careerComponent.Content_TR = model.Content_TR;
                careerComponent.ContentCareer_AZ = model.ContentCareer_AZ;
                careerComponent.ContentCareer_RU = model.ContentCareer_RU;
                careerComponent.ContentCareer_EN = model.ContentCareer_EN;
                careerComponent.ContentCareer_TR = model.ContentCareer_TR;
                careerComponent.ShowVacancies = model.ShowVacancies;
                careerComponent.IsBanner = model.IsBanner;
                careerComponent.ImageOnRight = model.ImageOnRight;
                careerComponent.Slug = model.Slug.Slugify();

                if (model.Photo != null)
                {
                    _fileService.Delete(careerComponent.PhotoName, FilePath.Career);
                    careerComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Career);
                }
                if (model.Photo_Career != null)
                {
                    _fileService.Delete(careerComponent.PhotoName_Career, FilePath.Career);
                    careerComponent.PhotoName_Career = await _fileService.UploadFileAsync(model.Photo_Career, FilePath.Career);
                }

                await _unitOfWork.CareerComponent.EditAsync(careerComponent);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            var careerComponent = await _unitOfWork.CareerComponent.GetAsync(id);
            if (careerComponent == null) return NotFound();

            var model = new CareerDetailsComponentViewModel
            {
                Title_AZ = careerComponent.Title_AZ,
                Title_RU = careerComponent.Title_RU,
                Title_EN = careerComponent.Title_EN,
                Title_TR = careerComponent.Title_TR,
                Slug = careerComponent.Slug,
                Content_AZ = careerComponent.Content_AZ,
                Content_RU = careerComponent.Content_RU,
                Content_EN = careerComponent.Content_EN,
                Content_TR = careerComponent.Content_TR,
                ContentCareer_AZ = careerComponent.ContentCareer_AZ,
                ContentCareer_RU = careerComponent.ContentCareer_RU,
                ContentCareer_EN = careerComponent.ContentCareer_EN,
                ContentCareer_TR = careerComponent.ContentCareer_TR,
                ShowVacancies = careerComponent.ShowVacancies,
                IsBanner = careerComponent.IsBanner,
                ImageOnRight = careerComponent.ImageOnRight,
                PhotoPath = _fileService.GetFileUrl(careerComponent.PhotoName, FilePath.Career),
                PhotoPath_Career = _fileService.GetFileUrl(careerComponent.PhotoName_Career, FilePath.Career)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            var careerComponent = await _unitOfWork.CareerComponent.GetAsync(id);
            if (careerComponent == null) return NotFound();

            _fileService.Delete(careerComponent.PhotoName, FilePath.Career);
            _fileService.Delete(careerComponent.PhotoName_Career, FilePath.Career);

            await _unitOfWork.CareerComponent.DeleteAsync(careerComponent);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("index");
        }

        #endregion

        #region TipComponent

        [HttpGet("/admin/career/addtipcomponent")]
        public async Task<IActionResult> AddTipComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTipComponent(CareerAddTipComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            if (ModelState.IsValid)
            {
                var careerTipComponent = new CareerTipComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    Date = model.Date,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Career),
                    PhotoName_Career = await _fileService.UploadFileAsync(model.Photo_Career, FilePath.Career)
                };

                await _unitOfWork.CareerTipComponent.CreateAsync(careerTipComponent);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditTipComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            var careerTipComponent = await _unitOfWork.CareerTipComponent.GetAsync(id);
            if (careerTipComponent == null) return NotFound();

            var model = new CareerEditTipComponentViewModel
            {
                Id = careerTipComponent.Id,
                Title_AZ = careerTipComponent.Title_AZ,
                Title_RU = careerTipComponent.Title_RU,
                Title_EN = careerTipComponent.Title_EN,
                Title_TR = careerTipComponent.Title_TR,
                Content_AZ = careerTipComponent.Content_AZ,
                Content_RU = careerTipComponent.Content_RU,
                Content_EN = careerTipComponent.Content_EN,
                Content_TR = careerTipComponent.Content_TR,
                Date = careerTipComponent.Date,
                PhotoName = careerTipComponent.PhotoName,
                PhotoName_Career = careerTipComponent.PhotoName_Career,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditTipComponent(CareerEditTipComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            var careerTipComponent = await _unitOfWork.CareerTipComponent.GetAsync(model.Id);
            if (careerTipComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                careerTipComponent.Title_AZ = model.Title_AZ;
                careerTipComponent.Title_RU = model.Title_RU;
                careerTipComponent.Title_EN = model.Title_EN;
                careerTipComponent.Title_TR = model.Title_TR;
                careerTipComponent.Content_AZ = model.Content_AZ;
                careerTipComponent.Content_RU = model.Content_RU;
                careerTipComponent.Content_EN = model.Content_EN;
                careerTipComponent.Content_TR = model.Content_TR;
                careerTipComponent.Date = careerTipComponent.Date;

                if (model.Photo != null)
                {
                    _fileService.Delete(careerTipComponent.PhotoName, FilePath.Career);
                    careerTipComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Career);
                }
                if (model.Photo_Career != null)
                {
                    _fileService.Delete(careerTipComponent.PhotoName_Career, FilePath.Career);
                    careerTipComponent.PhotoName_Career = await _fileService.UploadFileAsync(model.Photo_Career, FilePath.Career);
                }

                await _unitOfWork.CareerTipComponent.EditAsync(careerTipComponent);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsTipComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Career = true;

            var careerTipComponent = await _unitOfWork.CareerTipComponent.GetAsync(id);
            if (careerTipComponent == null) return NotFound();

            var model = new CareerDetailsTipComponentViewModel
            {
                Title_AZ = careerTipComponent.Title_AZ,
                Title_RU = careerTipComponent.Title_RU,
                Title_EN = careerTipComponent.Title_EN,
                Title_TR = careerTipComponent.Title_TR,
                Content_AZ = careerTipComponent.Content_AZ,
                Content_RU = careerTipComponent.Content_RU,
                Content_EN = careerTipComponent.Content_EN,
                Content_TR = careerTipComponent.Content_TR,
                Date = careerTipComponent.Date,
                PhotoPath = _fileService.GetFileUrl(careerTipComponent.PhotoName, FilePath.Career),
                PhotoPath_Career = _fileService.GetFileUrl(careerTipComponent.PhotoName_Career, FilePath.Career)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTipComponent(int id)
        {
            var careerTipComponent = await _unitOfWork.CareerTipComponent.GetAsync(id);
            if (careerTipComponent == null) return NotFound();

            _fileService.Delete(careerTipComponent.PhotoName, FilePath.Career);
            _fileService.Delete(careerTipComponent.PhotoName_Career, FilePath.Career);

            await _unitOfWork.CareerTipComponent.DeleteAsync(careerTipComponent);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("index");
        }

        #endregion
    }
}
