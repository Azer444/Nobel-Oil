using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.CorporateGovernance;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class CorporateGovernanceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public CorporateGovernanceController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.CorporateGovernance = true;

            var model = new CorporateGovernanceIndexViewModel
            {
                CorporateGovernanceComponent = await _unitOfWork.CorporateGovernanceComponent.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.CorporateGovernance = true;

            var corporateGovernanceComponent = await _unitOfWork.CorporateGovernanceComponent.GetAsync();
            if (corporateGovernanceComponent != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(CorporateGovernanceDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.CorporateGovernance = true;

            if (ModelState.IsValid)
            {
                var corporateGovernanceComponent = new CorporateGovernanceComponent
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
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.CorporateGovernance),
                    PhotoName_WWA = await _fileService.UploadFileAsync(model.Photo_WWA, FilePath.CorporateGovernance)
                };

                await _unitOfWork.CorporateGovernanceComponent.CreateAsync(corporateGovernanceComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Corporate Governance component  <{corporateGovernanceComponent.Title_EN}> successfully defined.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.CorporateGovernance = true;

            var corporateGovernanceComponent = await _unitOfWork.CorporateGovernanceComponent.GetAsync();
            if (corporateGovernanceComponent == null) return NotFound();

            var model = new CorporateGovernanceEditComponentViewModel
            {
                Title_AZ = corporateGovernanceComponent.Title_AZ,
                Title_RU = corporateGovernanceComponent.Title_RU,
                Title_EN = corporateGovernanceComponent.Title_EN,
                Title_TR = corporateGovernanceComponent.Title_TR,
                Content_AZ = corporateGovernanceComponent.Content_AZ,
                Content_RU = corporateGovernanceComponent.Content_RU,
                Content_EN = corporateGovernanceComponent.Content_EN,
                Content_TR = corporateGovernanceComponent.Content_TR,
                ContentWWA_AZ = corporateGovernanceComponent.ContentWWA_AZ,
                ContentWWA_RU = corporateGovernanceComponent.ContentWWA_RU,
                ContentWWA_EN = corporateGovernanceComponent.ContentWWA_EN,
                ContentWWA_TR = corporateGovernanceComponent.ContentWWA_TR,
                PhotoPath = _fileService.GetFileUrl(corporateGovernanceComponent.PhotoName, FilePath.CorporateGovernance),
                PhotoPath_WWA = _fileService.GetFileUrl(corporateGovernanceComponent.PhotoName_WWA, FilePath.CorporateGovernance)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(CorporateGovernanceEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.CorporateGovernance = true;

            var corporateGovernanceComponent = await _unitOfWork.CorporateGovernanceComponent.GetAsync();
            if (corporateGovernanceComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                corporateGovernanceComponent.Title_AZ = model.Title_AZ;
                corporateGovernanceComponent.Title_RU = model.Title_RU;
                corporateGovernanceComponent.Title_EN = model.Title_EN;
                corporateGovernanceComponent.Title_TR = model.Title_TR;
                corporateGovernanceComponent.Content_AZ = model.Content_AZ;
                corporateGovernanceComponent.Content_RU = model.Content_RU;
                corporateGovernanceComponent.Content_EN = model.Content_EN;
                corporateGovernanceComponent.Content_TR = model.Content_TR;
                corporateGovernanceComponent.ContentWWA_AZ = model.ContentWWA_AZ;
                corporateGovernanceComponent.ContentWWA_RU = model.ContentWWA_RU;
                corporateGovernanceComponent.ContentWWA_EN = model.ContentWWA_EN;
                corporateGovernanceComponent.ContentWWA_TR = model.ContentWWA_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(corporateGovernanceComponent.PhotoName, FilePath.CorporateGovernance);
                    corporateGovernanceComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.CorporateGovernance);
                }

                if (model.Photo_WWA != null)
                {
                    _fileService.Delete(corporateGovernanceComponent.PhotoName_WWA, FilePath.CorporateGovernance);
                    corporateGovernanceComponent.PhotoName_WWA = await _fileService.UploadFileAsync(model.Photo_WWA, FilePath.CorporateGovernance);
                }

                await _unitOfWork.CorporateGovernanceComponent.EditAsync(corporateGovernanceComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Corporate Governance component  <{corporateGovernanceComponent.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.CorporateGovernance = true;

            var corporateGovernanceComponent = await _unitOfWork.CorporateGovernanceComponent.GetAsync();
            if (corporateGovernanceComponent == null) return NotFound();

            return View(corporateGovernanceComponent);
        }
    }
}
