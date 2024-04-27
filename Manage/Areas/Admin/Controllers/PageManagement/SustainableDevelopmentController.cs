using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.OurProject;
using Manage.Areas.Admin.Models.PageManagement.SustainableDevelopment;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class SustainableDevelopmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public SustainableDevelopmentController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainableDevelopment = true;

            var model = new SustainableDevelopmentIndexViewModel
            {
                SustainableDevelopment = await _unitOfWork.SustainableDevelopment.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainableDevelopment = true;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DefineComponent(SustainableDevelopmentDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainableDevelopment = true;

            if (ModelState.IsValid)
            {
                var sustainableDevelopment = new SustainableDevelopment
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.SustainableDevelopment)
                };

                await _unitOfWork.SustainableDevelopment.CreateAsync(sustainableDevelopment);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Sustainable development <{sustainableDevelopment.Title_EN}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainableDevelopment = true;

            var sustainableDevelopment = await _unitOfWork.SustainableDevelopment.GetAsync();
            if (sustainableDevelopment == null) return NotFound();

            var model = new SustainableDevelopmentEditComponentViewModel
            {
                Id = sustainableDevelopment.Id,
                Title_AZ = sustainableDevelopment.Title_AZ,
                Title_RU = sustainableDevelopment.Title_RU,
                Title_EN = sustainableDevelopment.Title_EN,
                Title_TR = sustainableDevelopment.Title_TR,
                Content_AZ = sustainableDevelopment.Content_AZ,
                Content_RU = sustainableDevelopment.Content_RU,
                Content_EN = sustainableDevelopment.Content_EN,
                Content_TR = sustainableDevelopment.Content_TR,
                PhotoPath = _fileService.GetFileUrl(sustainableDevelopment.PhotoName, FilePath.SustainableDevelopment),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(SustainableDevelopmentEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainableDevelopment = true;

            var sustainableDevelopment = await _unitOfWork.SustainableDevelopment.GetAsync();
            if (sustainableDevelopment == null) return NotFound();

            if (ModelState.IsValid)
            {
                sustainableDevelopment.Title_AZ = model.Title_AZ;
                sustainableDevelopment.Title_RU = model.Title_RU;
                sustainableDevelopment.Title_EN = model.Title_EN;
                sustainableDevelopment.Title_TR = model.Title_TR;
                sustainableDevelopment.Content_AZ = model.Content_AZ;
                sustainableDevelopment.Content_RU = model.Content_RU;
                sustainableDevelopment.Content_EN = model.Content_EN;
                sustainableDevelopment.Content_TR = model.Content_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(sustainableDevelopment.PhotoName, FilePath.SustainableDevelopment);
                    sustainableDevelopment.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.SustainableDevelopment);
                }

                await _unitOfWork.SustainableDevelopment.EditAsync(sustainableDevelopment);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Sustainable development <{sustainableDevelopment.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainableDevelopment = true;

            var sustainableDevelopment = await _unitOfWork.SustainableDevelopment.GetAsync();
            if (sustainableDevelopment == null) return NotFound();

            var model = new OurProjectDetailsViewModel
            {
                Title_AZ = sustainableDevelopment.Title_AZ,
                Title_RU = sustainableDevelopment.Title_RU,
                Title_EN = sustainableDevelopment.Title_EN,
                Title_TR = sustainableDevelopment.Title_TR,
                Content_AZ = sustainableDevelopment.Content_AZ,
                Content_RU = sustainableDevelopment.Content_RU,
                Content_EN = sustainableDevelopment.Content_EN,
                Content_TR = sustainableDevelopment.Content_TR,
                PhotoPath = _fileService.GetFileUrl(sustainableDevelopment.PhotoName, FilePath.SustainableDevelopment),
            };

            return View(model);
        }

    }
}
