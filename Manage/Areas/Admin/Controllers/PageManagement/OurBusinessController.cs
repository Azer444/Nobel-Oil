using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.OurBusiness;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    public class OurBusinessController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public OurBusinessController(IUnitOfWork unitOfWork,
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
            ViewBag.OurBusiness = true;

            var model = new OurBusinessListViewModel
            {
                OurBusinesses = (await _unitOfWork.OurBusinesses.GetAllAsync()).OrderByDescending(n => n.Id).ToList()
            };

            return View(model);
        }

        #endregion

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.PageManagement = true;
            ViewBag.OurBusiness = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OurBusinessCreateViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurBusiness = true;

            if (ModelState.IsValid)
            {
                var ourBusiness = new OurBusiness
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    Link = model.Link,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.OurBusiness)
                };

                await _unitOfWork.OurBusinesses.CreateAsync(ourBusiness);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Our business <{ourBusiness.Title_EN}> successfully created.";
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
            ViewBag.OurBusiness = true;

            var ourBusiness = await _unitOfWork.OurBusinesses.GetAsync(id);
            if (ourBusiness == null) return NotFound();

            var model = new OurBusinessEditViewModel
            {
                Id = ourBusiness.Id,
                Title_AZ = ourBusiness.Title_AZ,
                Title_RU = ourBusiness.Title_RU,
                Title_EN = ourBusiness.Title_EN,
                Title_TR = ourBusiness.Title_TR,
                Content_AZ = ourBusiness.Content_AZ,
                Content_RU = ourBusiness.Content_RU,
                Content_EN = ourBusiness.Content_EN,
                Content_TR = ourBusiness.Content_TR,
                Link = ourBusiness.Link,
                PhotoPath = _fileService.GetFileUrl(ourBusiness.PhotoName, FilePath.OurBusiness),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OurBusinessEditViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurBusiness = true;

            var ourBusiness = await _unitOfWork.OurBusinesses.GetAsync(model.Id);
            if (ourBusiness == null) return NotFound();

            if (ModelState.IsValid)
            {
                ourBusiness.Title_AZ = model.Title_AZ;
                ourBusiness.Title_RU = model.Title_RU;
                ourBusiness.Title_EN = model.Title_EN;
                ourBusiness.Title_TR = model.Title_TR;
                ourBusiness.Content_AZ = model.Content_AZ;
                ourBusiness.Content_RU = model.Content_RU;
                ourBusiness.Content_EN = model.Content_EN;
                ourBusiness.Content_TR = model.Content_TR;
                ourBusiness.Link = model.Link;

                if (model.Photo != null)
                {
                    _fileService.Delete(ourBusiness.PhotoName, FilePath.OurBusiness);
                    ourBusiness.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.OurBusiness);
                }

                await _unitOfWork.OurBusinesses.EditAsync(ourBusiness);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Our business <{ourBusiness.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        #endregion

        #region Details
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurBusiness = true;

            var ourBusiness = await _unitOfWork.OurBusinesses.GetAsync(id);
            if (ourBusiness == null) return NotFound();

            var model = new OurBusinessDetailsViewModel
            {
                Title_AZ = ourBusiness.Title_AZ,
                Title_RU = ourBusiness.Title_RU,
                Title_EN = ourBusiness.Title_EN,
                Title_TR = ourBusiness.Title_TR,
                Content_AZ = ourBusiness.Content_AZ,
                Content_RU = ourBusiness.Content_RU,
                Content_EN = ourBusiness.Content_EN,
                Content_TR = ourBusiness.Content_TR,
                Link = ourBusiness.Link,
                PhotoPath = _fileService.GetFileUrl(ourBusiness.PhotoName, FilePath.OurBusiness),
            };

            return View("Details", model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.OurBusiness = true;

            var ourBusiness = await _unitOfWork.OurBusinesses.GetAsync(id);
            if (ourBusiness == null) return NotFound();

            _fileService.Delete(ourBusiness.PhotoName, FilePath.OurBusiness);

            await _unitOfWork.OurBusinesses.DeleteAsync(ourBusiness);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Our business <{ourBusiness.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list");
        }

        #endregion
    }
}
