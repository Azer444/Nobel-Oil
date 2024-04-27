using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.ComponentManagement.Manager;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.ComponentManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    public class ManagerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public ManagerController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        #region List

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Manager = true;

            var model = new ManagerListViewModel
            {
                Managers = (await _unitOfWork.Managers.GetAllAsync()).OrderByDescending(n => n.Id).ToList()
            };

            return View(model);
        }

        #endregion

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Manager = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ManagerCreateViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Manager = true;

            if (ModelState.IsValid)
            {
                var manager = new Manager
                {
                    Name_AZ = model.Name_AZ,
                    Name_RU = model.Name_RU,
                    Name_EN = model.Name_EN,
                    Name_TR = model.Name_TR,
                    Info_AZ = model.Info_AZ,
                    Info_RU = model.Info_RU,
                    Info_EN = model.Info_EN,
                    Info_TR = model.Info_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    Type = model.Type,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Manager),
                };

                await _unitOfWork.Managers.CreateAsync(manager);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Manager <{manager.Name_EN}> successfully created.";
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
            ViewBag.ComponentManagement = true;
            ViewBag.Manager = true;

            var manager = await _unitOfWork.Managers.GetAsync(id);
            if (manager == null) return NotFound();

            var model = new ManagerEditViewModel
            {
                Id = manager.Id,
                Name_AZ = manager.Name_AZ,
                Name_RU = manager.Name_RU,
                Name_EN = manager.Name_EN,
                Name_TR = manager.Name_TR,
                Info_AZ = manager.Info_AZ,
                Info_RU = manager.Info_RU,
                Info_EN = manager.Info_EN,
                Info_TR = manager.Info_TR,
                Content_AZ = manager.Content_AZ,
                Content_RU = manager.Content_RU,
                Content_EN = manager.Content_EN,
                Content_TR = manager.Content_TR,
                PhotoPath = _fileService.GetFileUrl(manager.PhotoName, FilePath.Manager),
                Type = manager.Type,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ManagerEditViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Manager = true;

            var manager = await _unitOfWork.Managers.GetAsync(model.Id);
            if (manager == null) return NotFound();

            if (ModelState.IsValid)
            {
                manager.Name_AZ = model.Name_AZ;
                manager.Name_RU = model.Name_RU;
                manager.Name_EN = model.Name_EN;
                manager.Name_TR = model.Name_TR;
                manager.Info_AZ = model.Info_AZ;
                manager.Info_RU = model.Info_RU;
                manager.Info_EN = model.Info_EN;
                manager.Info_TR = model.Info_TR;
                manager.Content_AZ = model.Content_AZ;
                manager.Content_RU = model.Content_RU;
                manager.Content_EN = model.Content_EN;
                manager.Content_TR = model.Content_TR;
                manager.Type = model.Type;

                if (model.NewPhoto != null)
                {
                    _fileService.Delete(manager.PhotoName, FilePath.Testimonial);
                    manager.PhotoName = await _fileService.UploadFileAsync(model.NewPhoto, FilePath.Manager);
                }

                await _unitOfWork.Managers.EditAsync(manager);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Manager <{manager.Name_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        #endregion

        #region Details
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Manager = true;

            var manager = await _unitOfWork.Managers.GetAsync(id);
            if (manager == null) return NotFound();

            var model = new ManagerDetailsViewModel
            {
                Name_AZ = manager.Name_AZ,
                Name_RU = manager.Name_RU,
                Name_EN = manager.Name_EN,
                Name_TR = manager.Name_TR,
                Info_AZ = manager.Info_AZ,
                Info_RU = manager.Info_RU,
                Info_EN = manager.Info_EN,
                Info_TR = manager.Info_TR,
                Content_AZ = manager.Content_AZ,
                Content_RU = manager.Content_RU,
                Content_EN = manager.Content_EN,
                Content_TR = manager.Content_TR,
                PhotoPath = _fileService.GetFileUrl(manager.PhotoName, FilePath.Manager),
                Type = manager.Type,

            };

            return View("Details", model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Manager = true;

            var manager = await _unitOfWork.Managers.GetAsync(id);
            if (manager == null) return NotFound();

            _fileService.Delete(manager.PhotoName, FilePath.Manager);

            await _unitOfWork.Managers.DeleteAsync(manager);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Manager <{manager.Name_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list");
        }

        #endregion
    }
}
