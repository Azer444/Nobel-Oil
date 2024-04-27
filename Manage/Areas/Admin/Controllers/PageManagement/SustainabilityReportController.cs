using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.SustainabilityReport;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin"), Authorize(Roles = "Staff")]
    public class SustainabilityReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public SustainabilityReportController(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainabilityReport = true;
            var model = new SustainabilityReportIndexVM
            {
                SustainabilityReports = await _unitOfWork.SustainabilityReport.GetAllAsync()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainabilityReport = true;
            var sustainabilityReport = await _unitOfWork.SustainabilityReport.GetAsync(id);
            if (sustainabilityReport == null) return NotFound();
            var model = new SustainabilityReportEditVM
            {
                Id = sustainabilityReport.Id,
                Title_AZ = sustainabilityReport.Title_AZ,
                Title_RU = sustainabilityReport.Title_RU,
                Title_EN = sustainabilityReport.Title_EN,
                Title_TR = sustainabilityReport.Title_TR,
                Content_AZ = sustainabilityReport.Content_AZ,
                Content_RU = sustainabilityReport.Content_RU,
                Content_EN = sustainabilityReport.Content_EN,
                Content_TR = sustainabilityReport.Content_TR,
                PhotoPath = _fileService.GetFileUrl(sustainabilityReport.PhotoName, FilePath.SustainabilityReport),
                FilePath_AZ = sustainabilityReport.FileName_AZ,
                FilePath_RU = sustainabilityReport.FileName_RU,
                FilePath_EN = sustainabilityReport.FileName_EN,
                FilePath_TR = sustainabilityReport.FileName_TR
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken, DisableRequestSizeLimit]
        public async Task<IActionResult> Edit(SustainabilityReportEditVM model)
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainabilityReport = true;
            var sustainabilityReport = await _unitOfWork.SustainabilityReport.GetAsync(model.Id);
            if (sustainabilityReport == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            sustainabilityReport.Title_AZ = model.Title_AZ;
            sustainabilityReport.Title_RU = model.Title_RU;
            sustainabilityReport.Title_EN = model.Title_EN;
            sustainabilityReport.Title_TR = model.Title_TR;
            sustainabilityReport.Content_AZ = model.Content_AZ;
            sustainabilityReport.Content_RU = model.Content_RU;
            sustainabilityReport.Content_EN = model.Content_EN;
            sustainabilityReport.Content_TR = model.Content_TR;

            if (model.Photo != null)
            {
                _fileService.Delete(sustainabilityReport.PhotoName, FilePath.SustainabilityReport);
                sustainabilityReport.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.SustainabilityReport);
            }
            if (model.File_AZ != null)
            {
                _fileService.Delete(sustainabilityReport.FileName_AZ, FilePath.SustainabilityReport);
                sustainabilityReport.FileName_AZ = await _fileService.UploadFileAsync(model.File_AZ, FilePath.SustainabilityReport);
            }
            if (model.File_RU != null)
            {
                _fileService.Delete(sustainabilityReport.FileName_RU, FilePath.SustainabilityReport);
                sustainabilityReport.FileName_RU = await _fileService.UploadFileAsync(model.File_RU, FilePath.SustainabilityReport);
            }
            if (model.File_EN != null)
            {
                _fileService.Delete(sustainabilityReport.FileName_EN, FilePath.SustainabilityReport);
                sustainabilityReport.FileName_EN = await _fileService.UploadFileAsync(model.File_EN, FilePath.SustainabilityReport);
            }
            if (model.File_TR != null)
            {
                _fileService.Delete(sustainabilityReport.FileName_TR, FilePath.SustainabilityReport);
                sustainabilityReport.FileName_TR = await _fileService.UploadFileAsync(model.File_TR, FilePath.SustainabilityReport);
            }
            await _unitOfWork.SustainabilityReport.EditAsync(sustainabilityReport);
            await _unitOfWork.CommitAsync();
            TempData["message"] = $"Sustainability report <{sustainabilityReport.Title_EN}> successfully updated.";
            TempData["message_type"] = "success";
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => View());
        }

        [HttpPost, DisableRequestSizeLimit, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SustainabilityReportCreateVM model)
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainabilityReport = true;
            if (!ModelState.IsValid) return View(model);
            var sustainabilityReport = new SustainabilityReport();
            sustainabilityReport.Title_AZ = model.Title_AZ;
            sustainabilityReport.Title_RU = model.Title_RU;
            sustainabilityReport.Title_EN = model.Title_EN;
            sustainabilityReport.Title_TR = model.Title_TR;
            sustainabilityReport.Content_AZ = model.Content_AZ;
            sustainabilityReport.Content_RU = model.Content_RU;
            sustainabilityReport.Content_EN = model.Content_EN;
            sustainabilityReport.Content_TR = model.Content_TR;

            if (model.Photo != null)
                sustainabilityReport.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.SustainabilityReport);
            if (model.File_AZ != null)
                sustainabilityReport.FileName_AZ = await _fileService.UploadFileAsync(model.File_AZ, FilePath.SustainabilityReport);
            if (model.File_RU != null)
                sustainabilityReport.FileName_RU = await _fileService.UploadFileAsync(model.File_RU, FilePath.SustainabilityReport);
            if (model.File_EN != null)
                sustainabilityReport.FileName_EN = await _fileService.UploadFileAsync(model.File_EN, FilePath.SustainabilityReport);
            if (model.File_TR != null)
                sustainabilityReport.FileName_TR = await _fileService.UploadFileAsync(model.File_TR, FilePath.SustainabilityReport);

            await _unitOfWork.SustainabilityReport.CreateAsync(sustainabilityReport);
            await _unitOfWork.CommitAsync();
            TempData["message"] = $"Sustainability report <{sustainabilityReport.Title_EN}> successfully created.";
            TempData["message_type"] = "success";
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainabilityReport = true;
            var report = await _unitOfWork.SustainabilityReport.GetAsync(id);
            if (report == null) return NotFound();

            _fileService.Delete(report.PhotoName, FilePath.SustainabilityReport);
            _fileService.Delete(report.FileName_AZ, FilePath.SustainabilityReport);
            _fileService.Delete(report.FileName_RU, FilePath.SustainabilityReport);
            _fileService.Delete(report.FileName_EN, FilePath.SustainabilityReport);
            _fileService.Delete(report.FileName_TR, FilePath.SustainabilityReport);

            await _unitOfWork.SustainabilityReport.DeleteAsync(report);
            await _unitOfWork.CommitAsync();
            TempData["message"] = $"Sustainability report <{report.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";
            return RedirectToAction("index");
        }
    }
}