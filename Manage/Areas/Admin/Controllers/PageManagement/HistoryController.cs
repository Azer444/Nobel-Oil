using Core;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.History;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class HistoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public HistoryController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.History = true;

            var model = new HistoryIndexViewModel
            {
                HistoryComponents = await _unitOfWork.HistoryComponent.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.History = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComponent(HistoryAddViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.History = true;

            if (ModelState.IsValid)
            {
                var historyComponent = new HistoryComponent
                {
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    ActionDate = model.ActionDate,
                    Order = model.Order,
                };

                await _unitOfWork.HistoryComponent.CreateAsync(historyComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"History component <{historyComponent.ActionDate.Year}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.History = true;

            var historyComponent = await _unitOfWork.HistoryComponent.GetAsync(id);
            if (historyComponent == null) return NotFound();

            var model = new HistoryEditViewModel
            {
                Id = historyComponent.Id,
                Content_AZ = historyComponent.Content_AZ,
                Content_RU = historyComponent.Content_RU,
                Content_EN = historyComponent.Content_EN,
                Content_TR = historyComponent.Content_TR,
                ActionDate = historyComponent.ActionDate,
                Order = historyComponent.Order,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(HistoryEditViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.History = true;

            var historyComponent = await _unitOfWork.HistoryComponent.GetAsync(model.Id);
            if (historyComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                historyComponent.Content_AZ = model.Content_AZ;
                historyComponent.Content_RU = model.Content_RU;
                historyComponent.Content_EN = model.Content_EN;
                historyComponent.Content_TR = model.Content_TR;
                historyComponent.ActionDate = model.ActionDate;
                historyComponent.Order = model.Order;

                TempData["message"] = $"History component <{historyComponent.ActionDate.Year}> successfully updated.";
                TempData["message_type"] = "success";

                await _unitOfWork.HistoryComponent.EditAsync(historyComponent);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.History = true;

            var historyComponent = await _unitOfWork.HistoryComponent.GetAsync(id);
            if (historyComponent == null) return NotFound();

            return View(historyComponent);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.History = true;

            var historyComponent = await _unitOfWork.HistoryComponent.GetAsync(id);
            if (historyComponent == null) return NotFound();

            await _unitOfWork.HistoryComponent.DeleteAsync(historyComponent);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"History component <{historyComponent.ActionDate.Year}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("index");
        }
    }
}
