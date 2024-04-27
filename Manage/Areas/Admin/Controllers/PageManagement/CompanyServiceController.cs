using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.CompanyService;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class CompanyServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public CompanyServiceController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.PageManagement = true;
            ViewBag.CompanyService = true;

            var model = new CompanyServiceListViewModel
            {
                CompanyServices = await _unitOfWork.CompanyServices.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.PageManagement = true;
            ViewBag.CompanyService = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyServiceCreateViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.CompanyService = true;

            if (ModelState.IsValid)
            {
                var companyService = new CompanyService
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    ExternalLink_AZ = model.ExternalLink_AZ,
                    ExternalLink_RU = model.ExternalLink_RU,
                    ExternalLink_EN = model.ExternalLink_EN,
                    ExternalLink_TR = model.ExternalLink_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.CompanyService)
                };

                await _unitOfWork.CompanyServices.CreateAsync(companyService);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Company service <{companyService.Title_EN}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.CompanyService = true;

            var companyService = await _unitOfWork.CompanyServices.GetAsync(id);
            if (companyService == null) return NotFound();

            var model = new CompanyServiceEditViewModel
            {
                Id = companyService.Id,
                Title_AZ = companyService.Title_AZ,
                Title_RU = companyService.Title_RU,
                Title_EN = companyService.Title_EN,
                Title_TR = companyService.Title_TR,
                ExternalLink_AZ = companyService.ExternalLink_AZ,
                ExternalLink_RU = companyService.ExternalLink_RU,
                ExternalLink_EN = companyService.ExternalLink_EN,
                ExternalLink_TR = companyService.ExternalLink_TR,
                PhotoPath = _fileService.GetFileUrl(companyService.PhotoName, FilePath.CompanyService)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyServiceEditViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.CompanyService = true;

            var companyService = await _unitOfWork.CompanyServices.GetAsync(model.Id);
            if (companyService == null) return NotFound();

            if (ModelState.IsValid)
            {
                companyService.Title_AZ = model.Title_AZ;
                companyService.Title_RU = model.Title_RU;
                companyService.Title_EN = model.Title_EN;
                companyService.Title_TR = model.Title_TR;
                companyService.ExternalLink_AZ = model.ExternalLink_AZ;
                companyService.ExternalLink_RU = model.ExternalLink_RU;
                companyService.ExternalLink_EN = model.ExternalLink_EN;
                companyService.ExternalLink_TR = model.ExternalLink_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(companyService.PhotoName, FilePath.CompanyService);
                    companyService.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.CompanyService);
                }

                TempData["message"] = $"Company service <{companyService.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                await _unitOfWork.CompanyServices.EditAsync(companyService);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("list");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.CompanyService = true;

            var companyService = await _unitOfWork.CompanyServices.GetAsync(id);
            if (companyService == null) return NotFound();

            await _unitOfWork.CompanyServices.DeleteAsync(companyService);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Company service <{companyService.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list");
        }
    }
}
