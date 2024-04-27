using Core;
using Manage.Areas.Admin.Models.PageManagement.LangResource;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class LangResourceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public LangResourceController(
            IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.LanguageResource = true;

            var model = new LangResourceIndexViewModel
            {
                LanguageResources = await _unitOfWork.LanguageResources.GetAllAsync()
            };

            return View(model);
        }

        #region Edit 

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.LanguageResource = true;

            var languageResource = await _unitOfWork.LanguageResources.GetAsync(id);
            if (languageResource == null) return NotFound();

            var model = new LangResourceEditViewModel
            {
                Id = languageResource.Id,
                Content_AZ = languageResource.Content_AZ,
                Content_RU = languageResource.Content_RU,
                Content_EN = languageResource.Content_EN,
                Content_TR = languageResource.Content_TR,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LangResourceEditViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.LanguageResource = true;

            var languageResource = await _unitOfWork.LanguageResources.GetAsync(model.Id);
            if (languageResource == null) return NotFound();

            if (ModelState.IsValid)
            {
                languageResource.Content_AZ = model.Content_AZ;
                languageResource.Content_RU = model.Content_RU;
                languageResource.Content_EN = model.Content_EN;
                languageResource.Content_TR = model.Content_TR;

                await _unitOfWork.LanguageResources.EditAsync(languageResource);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Language Resource <{languageResource.Content_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        #endregion
    }
}
