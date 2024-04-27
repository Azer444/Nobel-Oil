using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.BoardDirector;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class BoardDirectorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public BoardDirectorController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.BoardDirector = true;

            var model = new BoardDirectorIndexViewModel
            {
                BoardDirector = await _unitOfWork.BoardDirectorComponent.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.BoardDirector = true;

            var boardDirector = await _unitOfWork.BoardDirectorComponent.GetAsync();
            if (boardDirector != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(BoardDirectorDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.BoardDirector = true;

            if (ModelState.IsValid)
            {
                var boardDirector = new BoardDirectorComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.BoardDirector)
                };

                await _unitOfWork.BoardDirectorComponent.CreateAsync(boardDirector);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Board director component successfully defined.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.BoardDirector = true;

            var boardDirector = await _unitOfWork.BoardDirectorComponent.GetAsync();
            if (boardDirector == null) return NotFound();

            var model = new BoardDirectorEditComponentViewModel
            {
                Id = boardDirector.Id,
                Title_AZ = boardDirector.Title_AZ,
                Title_RU = boardDirector.Title_RU,
                Title_EN = boardDirector.Title_EN,
                Title_TR = boardDirector.Title_TR,
                Content_AZ = boardDirector.Content_AZ,
                Content_RU = boardDirector.Content_RU,
                Content_EN = boardDirector.Content_EN,
                Content_TR = boardDirector.Content_TR,
                PhotoPath = _fileService.GetFileUrl(boardDirector.PhotoName, FilePath.BoardDirector)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(BoardDirectorEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.BoardDirector = true;

            var boardDirector = await _unitOfWork.BoardDirectorComponent.GetAsync();
            if (boardDirector == null) return NotFound();

            if (ModelState.IsValid)
            {
                boardDirector.Title_AZ = model.Title_AZ;
                boardDirector.Title_RU = model.Title_RU;
                boardDirector.Title_EN = model.Title_EN;
                boardDirector.Title_TR = model.Title_TR;
                boardDirector.Content_AZ = model.Content_AZ;
                boardDirector.Content_RU = model.Content_RU;
                boardDirector.Content_EN = model.Content_EN;
                boardDirector.Content_TR = model.Content_TR;

                if (model.NewPhoto != null)
                {
                    _fileService.Delete(boardDirector.PhotoName, FilePath.BoardDirector);
                    boardDirector.PhotoName = await _fileService.UploadFileAsync(model.NewPhoto, FilePath.BoardDirector);
                }

                await _unitOfWork.BoardDirectorComponent.EditAsync(boardDirector);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Board director component successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.BoardDirector = true;

            var boardDirector = await _unitOfWork.BoardDirectorComponent.GetAsync();
            if (boardDirector == null) return NotFound();

            return View("DetailsComponent", boardDirector);
        }
    }
}
