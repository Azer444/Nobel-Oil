using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.VMV;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class VMVController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public VMVController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.VMV = true;

            var model = new VMVIndexViewModel
            {
                VMVComponent = await _unitOfWork.VMVComponent.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.VMV = true;

            var vmvComponent = await _unitOfWork.VMVComponent.GetAsync();
            if (vmvComponent != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(VMVDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.VMV = true;

            if (ModelState.IsValid)
            {
                var vmvComponent = new VMVComponent
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
                    ContentWWA_TR = model.ContentWWA_TR
                };

                await _unitOfWork.VMVComponent.CreateAsync(vmvComponent);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var vmvComponentPhoto = new VMVComponentPhoto
                    {
                        VMVComponentId = vmvComponent.Id,
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.VMV)
                    };

                    await _unitOfWork.VMVComponentPhoto.CreateAsync(vmvComponentPhoto);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"VMV component successfully defined.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.VMV = true;

            var vmvComponent = await _unitOfWork.VMVComponent.GetAsync();
            if (vmvComponent == null) return NotFound();

            var model = new VMVEditComponentViewModel
            {
                Id = vmvComponent.Id,
                Title_AZ = vmvComponent.Title_AZ,
                Title_RU = vmvComponent.Title_RU,
                Title_EN = vmvComponent.Title_EN,
                Title_TR = vmvComponent.Title_TR,
                Content_AZ = vmvComponent.Content_AZ,
                Content_RU = vmvComponent.Content_RU,
                Content_EN = vmvComponent.Content_EN,
                Content_TR = vmvComponent.Content_TR,
                ContentWWA_AZ = vmvComponent.ContentWWA_AZ,
                ContentWWA_RU = vmvComponent.ContentWWA_RU,
                ContentWWA_EN = vmvComponent.ContentWWA_EN,
                ContentWWA_TR = vmvComponent.ContentWWA_TR,
                VMVComponentPhotos = vmvComponent.VMVComponentPhotos
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(VMVEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.VMV = true;

            var vmvComponent = await _unitOfWork.VMVComponent.GetAsync();
            if (vmvComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                vmvComponent.Title_AZ = model.Title_AZ;
                vmvComponent.Title_RU = model.Title_RU;
                vmvComponent.Title_EN = model.Title_EN;
                vmvComponent.Title_TR = model.Title_TR;
                vmvComponent.Content_AZ = model.Content_AZ;
                vmvComponent.Content_RU = model.Content_RU;
                vmvComponent.Content_EN = model.Content_EN;
                vmvComponent.Content_TR = model.Content_TR;
                vmvComponent.ContentWWA_AZ = model.ContentWWA_AZ;
                vmvComponent.ContentWWA_RU = model.ContentWWA_RU;
                vmvComponent.ContentWWA_EN = model.ContentWWA_EN;
                vmvComponent.ContentWWA_TR = model.ContentWWA_TR;

                await _unitOfWork.VMVComponent.EditAsync(vmvComponent);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var vmvComponentPhoto = new VMVComponentPhoto
                    {
                        VMVComponentId = vmvComponent.Id,
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.VMV)
                    };

                    await _unitOfWork.VMVComponentPhoto.CreateAsync(vmvComponentPhoto);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"VMV component successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.VMV = true;

            var vmvComponent = await _unitOfWork.VMVComponent.GetAsync();
            if (vmvComponent == null) return NotFound();

            return View(vmvComponent);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComponentPhoto(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.VMV = true;

            var vmvComponentPhoto = await _unitOfWork.VMVComponentPhoto.GetAsync(id);
            if (vmvComponentPhoto == null) return NotFound();

            _fileService.Delete(vmvComponentPhoto.PhotoName, FilePath.VMV);

            await _unitOfWork.VMVComponentPhoto.DeleteAsync(vmvComponentPhoto);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"VMV component photo <{vmvComponentPhoto.PhotoName}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("editcomponent");
        }
    }
}
