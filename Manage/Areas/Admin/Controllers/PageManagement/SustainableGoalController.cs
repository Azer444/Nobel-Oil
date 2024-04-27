using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.SustainableGoal;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class SustainableGoalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public SustainableGoalController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainableGoal = true;

            var model = new SustainableGoalListViewModel
            {
                SustainableGoals = await _unitOfWork.SustainableGoals.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainableGoal = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SustainableGoalCreateViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainableGoal = true;

            if (ModelState.IsValid)
            {
                var sustainableGoal = new SustainableGoal
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    ExternalLink_AZ = model.ExternalLink_AZ,
                    ExternalLink_RU = model.ExternalLink_RU,
                    ExternalLink_EN = model.ExternalLink_EN,
                    ExternalLink_TR = model.ExternalLink_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.SustainableGoal)
                };

                await _unitOfWork.SustainableGoals.CreateAsync(sustainableGoal);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Sustainable goal <{sustainableGoal.Title_EN}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainableGoal = true;

            var sustainableGoal = await _unitOfWork.SustainableGoals.GetAsync(id);
            if (sustainableGoal == null) return NotFound();

            var model = new SustainableGoalEditViewModel
            {
                Id = sustainableGoal.Id,
                Title_AZ = sustainableGoal.Title_AZ,
                Title_RU = sustainableGoal.Title_RU,
                Title_EN = sustainableGoal.Title_EN,
                Title_TR = sustainableGoal.Title_TR,
                ExternalLink_AZ = sustainableGoal.ExternalLink_AZ,
                ExternalLink_RU = sustainableGoal.ExternalLink_RU,
                ExternalLink_EN = sustainableGoal.ExternalLink_EN,
                ExternalLink_TR = sustainableGoal.ExternalLink_TR,
                PhotoPath = _fileService.GetFileUrl(sustainableGoal.PhotoName, FilePath.SustainableGoal)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SustainableGoalEditViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainableGoal = true;

            var sustainableGoal = await _unitOfWork.SustainableGoals.GetAsync(model.Id);
            if (sustainableGoal == null) return NotFound();

            if (ModelState.IsValid)
            {
                sustainableGoal.Title_AZ = model.Title_AZ;
                sustainableGoal.Title_RU = model.Title_RU;
                sustainableGoal.Title_EN = model.Title_EN;
                sustainableGoal.Title_TR = model.Title_TR;
                sustainableGoal.ExternalLink_AZ = model.ExternalLink_AZ;
                sustainableGoal.ExternalLink_RU = model.ExternalLink_RU;
                sustainableGoal.ExternalLink_EN = model.ExternalLink_EN;
                sustainableGoal.ExternalLink_TR = model.ExternalLink_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(sustainableGoal.PhotoName, FilePath.SustainableGoal);
                    sustainableGoal.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.SustainableGoal);
                }

                TempData["message"] = $"Sustainable goal <{sustainableGoal.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                await _unitOfWork.SustainableGoals.EditAsync(sustainableGoal);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("list");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.SustainableGoal = true;

            var sustainableGoal = await _unitOfWork.SustainableGoals.GetAsync(id);
            if (sustainableGoal == null) return NotFound();

            await _unitOfWork.SustainableGoals.DeleteAsync(sustainableGoal);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Sustainable goal <{sustainableGoal.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list");
        }
    }
}
