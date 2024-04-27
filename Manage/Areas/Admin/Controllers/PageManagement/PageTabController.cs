using Core;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.PageTab;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class PageTabController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public PageTabController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.PageTab = true;

            var model = new PageTabIndexViewModel
            {
                PageTabComponents = await _unitOfWork.PageTabComponents.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.PageTab = true;

            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> CreateComponent(PageTabCreateViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.PageTab = true;
            if (!ModelState.IsValid) return await Task.Run(() => View(model));

            if (!await _unitOfWork.PageTabComponents.IsUniqueURLAsync(model.Link))
            {
                ModelState.AddModelError("", "URL must be unique");
                return await Task.Run(() => View(model));
            }

            var pageTabComponent = new PageTabComponent
            {
                Title_AZ = model.Title_AZ,
                Title_RU = model.Title_RU,
                Title_EN = model.Title_EN,
                Title_TR = model.Title_TR,
                Link = model.Link,
                Page = model.Page,
                IsActive = model.IsActive
            };

            await _unitOfWork.PageTabComponents.CreateAsync(pageTabComponent);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Page tab component <{pageTabComponent.Title_EN}> successfully created.";
            TempData["message_type"] = "success";
            return await Task.Run(() => RedirectToAction("index"));
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.PageTab = true;

            var pageTabComponent = await _unitOfWork.PageTabComponents.GetAsync(id);
            if (pageTabComponent == null) return NotFound();

            var model = new PageTabEditViewModel
            {
                Id = pageTabComponent.Id,
                Title_AZ = pageTabComponent.Title_AZ,
                Title_RU = pageTabComponent.Title_RU,
                Title_EN = pageTabComponent.Title_EN,
                Title_TR = pageTabComponent.Title_TR,
                Link = pageTabComponent.Link,
                Page = pageTabComponent.Page,
                IsActive = pageTabComponent.IsActive
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(PageTabEditViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.PageTab = true;

            if (!ModelState.IsValid) return await Task.Run(() => View(model));

            var pageTabComponent = await _unitOfWork.PageTabComponents.GetAsync(model.Id);
            if (pageTabComponent == null) return await Task.Run(() => NotFound());

            if (!await _unitOfWork.PageTabComponents.IsUniqueURLAsync(model.Link))
            {
                ModelState.AddModelError("URL", "URL must be unique");
                return await Task.Run(() => View(model));
            }

            pageTabComponent.Title_AZ = model.Title_AZ;
            pageTabComponent.Title_RU = model.Title_RU;
            pageTabComponent.Title_EN = model.Title_EN;
            pageTabComponent.Title_TR = model.Title_TR;
            pageTabComponent.Link = model.Link;
            pageTabComponent.Page = model.Page;
            pageTabComponent.IsActive = model.IsActive;

            await _unitOfWork.PageTabComponents.EditAsync(pageTabComponent);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Page tab component <{pageTabComponent.Title_EN}> successfully updated.";
            TempData["message_type"] = "success";

            return await Task.Run(() => RedirectToAction("index"));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.PageTab = true;

            var pageTabComponent = await _unitOfWork.PageTabComponents.GetAsync(id);
            if (pageTabComponent == null) return NotFound();

            await _unitOfWork.PageTabComponents.DeleteAsync(pageTabComponent);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Page tab component <{pageTabComponent.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("index");
        }
    }
}
