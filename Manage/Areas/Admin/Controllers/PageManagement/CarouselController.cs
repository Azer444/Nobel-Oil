using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.Carousel;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    public class CarouselController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public CarouselController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        #region List

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.PageManagement = true;
            ViewBag.PageManagementHome = true;
            ViewBag.Carousel = true;

            var model = new CarouselListViewModel
            {
                Carousels = (await _unitOfWork.Carousels.GetAllAsync()).OrderByDescending(n => n.Id).ToList()
            };

            return View(model);
        }

        #endregion

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.PageManagement = true;
            ViewBag.PageManagementHome = true;
            ViewBag.Carousel = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarouselCreateViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.PageManagementHome = true;
            ViewBag.Carousel = true;

            if (ModelState.IsValid)
            {
                var carousel = new Carousel
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Description_AZ = model.Description_AZ,
                    Description_RU = model.Description_RU,
                    Description_EN = model.Description_EN,
                    Description_TR = model.Description_TR,
                    ReadMoreLink = model.ReadMoreLink,
                    IsActive = model.IsActive,
                    Order = model.Order,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Carousel)
                };

                await _unitOfWork.Carousels.CreateAsync(carousel);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Carousel <{carousel.Title_EN}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        #endregion

        #region Edit 

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.PageManagementHome = true;
            ViewBag.Carousel = true;

            var carousel = await _unitOfWork.Carousels.GetAsync(id);
            if (carousel == null) return NotFound();

            var model = new CarouselEditViewModel
            {
                Title_AZ = carousel.Title_AZ,
                Title_RU = carousel.Title_RU,
                Title_EN = carousel.Title_EN,
                Title_TR = carousel.Title_TR,
                Description_AZ = carousel.Description_AZ,
                Description_RU = carousel.Description_RU,
                Description_EN = carousel.Description_EN,
                Description_TR = carousel.Description_TR,
                ReadMoreLink = carousel.ReadMoreLink,
                IsActive = carousel.IsActive,
                Order = carousel.Order,
                PhotoPath = _fileService.GetFileUrl(carousel.PhotoName, FilePath.Carousel),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarouselEditViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.PageManagementHome = true;
            ViewBag.Carousel = true;

            var carousel = await _unitOfWork.Carousels.GetAsync(model.Id);
            if (carousel == null) return NotFound();

            if (ModelState.IsValid)
            {
                carousel.Title_AZ = model.Title_AZ;
                carousel.Title_RU = model.Title_RU;
                carousel.Title_EN = model.Title_EN;
                carousel.Title_TR = model.Title_TR;
                carousel.Description_AZ = model.Description_AZ;
                carousel.Description_RU = model.Description_RU;
                carousel.Description_EN = model.Description_EN;
                carousel.Description_TR = model.Description_TR;
                carousel.ReadMoreLink = model.ReadMoreLink;
                carousel.IsActive = model.IsActive;
                carousel.Order = model.Order;

                if (model.Photo != null)
                {
                    _fileService.Delete(carousel.PhotoName, FilePath.Carousel);
                    carousel.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Carousel);
                }

                await _unitOfWork.Carousels.EditAsync(carousel);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Carousel <{carousel.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.PageManagementHome = true;
            ViewBag.Carousel = true;

            var carousel = await _unitOfWork.Carousels.GetAsync(id);
            if (carousel == null) return NotFound();

            _fileService.Delete(carousel.PhotoName, FilePath.Carousel);

            await _unitOfWork.Carousels.DeleteAsync(carousel);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Carousel <{carousel.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list");
        }

        #endregion
    }
}
