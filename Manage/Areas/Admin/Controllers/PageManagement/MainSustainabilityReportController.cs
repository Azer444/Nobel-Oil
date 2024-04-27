using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.MainSustainabilityReport;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin"), Authorize(Roles = "Staff")]
    public class MainSustainabilityReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public MainSustainabilityReportController(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.MainSustainabilityReport = true;
            var model = new SustainabilityReportIndexViewModel()
            {
                MainSustainabilityReport = await _unitOfWork.MainSustainabilityReport.GetAsync()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.MainSustainabilityReport = true;
            return await Task.Run(() => View());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DefineComponent(MainSustainabilityReportDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.MainSustainabilityReport = true;
            if (!ModelState.IsValid) return View(model);
            var mainSustainabilityReport = new MainSustainabilityReport
            {
                Title_AZ = model.Title_AZ,
                Title_RU = model.Title_RU,
                Title_EN = model.Title_EN,
                Title_TR = model.Title_TR,
                Content_AZ = model.Content_AZ,
                Content_RU = model.Content_RU,
                Content_EN = model.Content_EN,
                Content_TR = model.Content_TR,
                PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.SustainabilityReport)
            };
            await _unitOfWork.MainSustainabilityReport.CreateAsync(mainSustainabilityReport);
            await _unitOfWork.CommitAsync();
            TempData["message"] = $"Main Sustainability report <{mainSustainabilityReport.Title_EN}> successfully created."; TempData["message_type"] = "success";
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.MainSustainabilityReport = true;
            var mainSustainabilityReport = await _unitOfWork.MainSustainabilityReport.GetAsync();
            if (mainSustainabilityReport == null) return NotFound();
            var model = new SustainabilityReportEditVM
            {
                Id = mainSustainabilityReport.Id,
                Title_AZ = mainSustainabilityReport.Title_AZ,
                Title_RU = mainSustainabilityReport.Title_RU,
                Title_EN = mainSustainabilityReport.Title_EN,
                Title_TR = mainSustainabilityReport.Title_TR,
                Content_AZ = mainSustainabilityReport.Content_AZ,
                Content_RU = mainSustainabilityReport.Content_RU,
                Content_EN = mainSustainabilityReport.Content_EN,
                Content_TR = mainSustainabilityReport.Content_TR,
                PhotoPath = _fileService.GetFileUrl(mainSustainabilityReport.PhotoName, FilePath.SustainabilityReport)
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditComponent(SustainabilityReportEditVM model)
        {
            ViewBag.PageManagement = true;
            ViewBag.MainSustainabilityReport = true;
            var mainSustainabilityReport = await _unitOfWork.MainSustainabilityReport.GetAsync();
            if (mainSustainabilityReport == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            mainSustainabilityReport.Title_AZ = model.Title_AZ;
            mainSustainabilityReport.Title_RU = model.Title_RU;
            mainSustainabilityReport.Title_EN = model.Title_EN;
            mainSustainabilityReport.Title_TR = model.Title_TR;
            mainSustainabilityReport.Content_AZ = model.Content_AZ;
            mainSustainabilityReport.Content_RU = model.Content_RU;
            mainSustainabilityReport.Content_EN = model.Content_EN;
            mainSustainabilityReport.Content_TR = model.Content_TR;
            if (model.Photo != null)
            {
                _fileService.Delete(mainSustainabilityReport.PhotoName, FilePath.SustainabilityReport);
                mainSustainabilityReport.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.SustainabilityReport);
            }
            await _unitOfWork.MainSustainabilityReport.EditAsync(mainSustainabilityReport);
            await _unitOfWork.CommitAsync();
            TempData["message"] = $"Main Sustainability report <{mainSustainabilityReport.Title_EN}> successfully updated.";
            TempData["message_type"] = "success";
            return RedirectToAction("index");
        }
    }
}
