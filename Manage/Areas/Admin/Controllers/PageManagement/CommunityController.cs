using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.Community;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    public class CommunityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public CommunityController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet("admin/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.Community = true;

            var model = new CommunityIndexViewModel
            {
                CommunityComponent = await _unitOfWork.CommunityComponent.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Communtity = true;

            var communityComponent = await _unitOfWork.CommunityComponent.GetAsync();
            if (communityComponent != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(CommunityDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Community = true;

            if (ModelState.IsValid)
            {
                var communityComponent = new CommunityComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    ContentSustainability_AZ = model.ContentSustainability_AZ,
                    ContentSustainability_RU = model.ContentSustainability_RU,
                    ContentSustainability_EN = model.ContentSustainability_EN,
                    ContentSustainability_TR = model.ContentSustainability_TR
                };

                if (model.Photo != null)
                    communityComponent.PhotoName_Sustainability = await _fileService.UploadFileAsync(model.Photo, FilePath.Community);

                await _unitOfWork.CommunityComponent.CreateAsync(communityComponent);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var communityComponentPhoto = new CommunityComponentPhoto
                    {
                        CommunityComponentId = communityComponent.Id,
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.Community)
                    };

                    await _unitOfWork.CommunityComponentPhoto.CreateAsync(communityComponentPhoto);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"Community component successfully defined.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Community = true;

            var communityComponent = await _unitOfWork.CommunityComponent.GetAsync();
            if (communityComponent == null) return NotFound();

            var model = new CommunityEditComponentViewModel
            {
                Id = communityComponent.Id,
                Title_AZ = communityComponent.Title_AZ,
                Title_RU = communityComponent.Title_RU,
                Title_EN = communityComponent.Title_EN,
                Title_TR = communityComponent.Title_TR,
                Content_AZ = communityComponent.Content_AZ,
                Content_RU = communityComponent.Content_RU,
                Content_EN = communityComponent.Content_EN,
                Content_TR = communityComponent.Content_TR,
                ContentSustainability_AZ = communityComponent.ContentSustainability_AZ,
                ContentSustainability_RU = communityComponent.ContentSustainability_RU,
                ContentSustainability_EN = communityComponent.ContentSustainability_EN,
                ContentSustainability_TR = communityComponent.ContentSustainability_TR,
                CommunityComponentPhotos = communityComponent.CommunityComponentPhotos,
                PhotoPath_Sustainability = _fileService.GetFileUrl(communityComponent.PhotoName_Sustainability, FilePath.Community)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(CommunityEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Community = true;

            var communityComponent = await _unitOfWork.CommunityComponent.GetAsync();
            if (communityComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                communityComponent.Title_AZ = model.Title_AZ;
                communityComponent.Title_RU = model.Title_RU;
                communityComponent.Title_EN = model.Title_EN;
                communityComponent.Title_TR = model.Title_TR;
                communityComponent.Content_AZ = model.Content_AZ;
                communityComponent.Content_RU = model.Content_RU;
                communityComponent.Content_EN = model.Content_EN;
                communityComponent.Content_TR = model.Content_TR;
                communityComponent.ContentSustainability_AZ = model.ContentSustainability_AZ;
                communityComponent.ContentSustainability_RU = model.ContentSustainability_RU;
                communityComponent.ContentSustainability_EN = model.ContentSustainability_EN;
                communityComponent.ContentSustainability_TR = model.ContentSustainability_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(communityComponent.PhotoName_Sustainability, FilePath.Community);
                    communityComponent.PhotoName_Sustainability = await _fileService.UploadFileAsync(model.Photo, FilePath.Community);
                }

                await _unitOfWork.CommunityComponent.EditAsync(communityComponent);
                await _unitOfWork.CommitAsync();

                foreach (var photo in model.Photos)
                {
                    var communityComponentPhoto = new CommunityComponentPhoto
                    {
                        CommunityComponentId = communityComponent.Id,
                        PhotoName = await _fileService.UploadFileAsync(photo, FilePath.Community)
                    };

                    await _unitOfWork.CommunityComponentPhoto.CreateAsync(communityComponentPhoto);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"Community component successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.Community = true;

            var communityComponent = await _unitOfWork.CommunityComponent.GetAsync();
            if (communityComponent == null) return NotFound();

            return View(communityComponent);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComponentPhoto(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.Community = true;

            var communityComponentPhoto = await _unitOfWork.CommunityComponentPhoto.GetAsync(id);
            if (communityComponentPhoto == null) return NotFound();

            _fileService.Delete(communityComponentPhoto.PhotoName, FilePath.Community);

            await _unitOfWork.CommunityComponentPhoto.DeleteAsync(communityComponentPhoto);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Community component photo <{communityComponentPhoto.PhotoName}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("editcomponent");
        }
    }
}
