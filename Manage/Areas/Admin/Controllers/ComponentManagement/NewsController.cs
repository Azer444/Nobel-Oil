using Core;
using Core.Constants.File;
using Core.Models;
using EcomLab.Core.Constants.File;
using Manage.Areas.Admin.Models.ComponentManagement.News;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.ComponentManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class NewsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public NewsController(IUnitOfWork unitOfWork,
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
            ViewBag.News = true;


            var model = new NewsListViewModel
            {
                News = (await _unitOfWork.News.GetAllAsync()).OrderByDescending(n => n.Id).ToList()
            };

            return View(model);
        }

        #endregion

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.News = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewsCreateViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.News = true;

            if (ModelState.IsValid)
            {
                var news = new News
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    Description_AZ = model.Description_AZ,
                    Description_RU = model.Description_RU,
                    Description_EN = model.Description_EN,
                    Description_TR = model.Description_TR,
                    ShowOnHome = model.ShowOnHome,
                    ActionDate = model.ActionDate,
                    Slug = string.Empty,
                    NewsType = model.NewsType,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.News)
                };

                await _unitOfWork.News.CreateAsync(news);
                await _unitOfWork.CommitAsync();

                news.Slug = _unitOfWork.News.GenerateSlug(news.Title_EN, news);

                await _unitOfWork.News.EditAsync(news);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"News <{news.Title_EN}> successfully created.";
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
            ViewBag.News = true;

            var news = await _unitOfWork.News.GetAsync(id);
            if (news == null) return NotFound();

            var model = new NewsEditViewModel
            {
                Id = news.Id,
                Title_AZ = news.Title_AZ,
                Title_RU = news.Title_RU,
                Title_EN = news.Title_EN,
                Title_TR = news.Title_TR,
                Content_AZ = news.Content_AZ,
                Content_RU = news.Content_RU,
                Content_EN = news.Content_EN,
                Content_TR = news.Content_TR,
                Description_AZ = news.Description_AZ,
                Description_RU = news.Description_RU,
                Description_EN = news.Description_EN,
                Description_TR = news.Description_TR,
                ShowOnHome = news.ShowOnHome,
                PhotoPath = _fileService.GetFileUrl(news.PhotoName, FilePath.News),
                Slug = news.Slug,
                NewsType = news.NewsType,
                ActionDate = news.ActionDate
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewsEditViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.News = true;

            var news = await _unitOfWork.News.GetAsync(model.Id);
            if (news == null) return NotFound();

            if (ModelState.IsValid)
            {
                news.Title_AZ = model.Title_AZ;
                news.Title_RU = model.Title_RU;
                news.Title_EN = model.Title_EN;
                news.Title_TR = model.Title_TR;
                news.Content_AZ = model.Content_AZ;
                news.Content_RU = model.Content_RU;
                news.Content_EN = model.Content_EN;
                news.Content_TR = model.Content_TR;
                news.Description_AZ = model.Description_AZ;
                news.Description_RU = model.Description_RU;
                news.Description_EN = model.Description_EN;
                news.Description_TR = model.Description_TR;
                news.ShowOnHome = model.ShowOnHome;
                news.ActionDate = model.ActionDate;
                news.Title_EN = model.Title_EN;
                news.NewsType = model.NewsType;
                news.Slug = _unitOfWork.News.GenerateSlug(model.Title_EN, news);

                if (model.Photo != null)
                {
                    _fileService.Delete(news.PhotoName, FilePath.News);
                    news.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.News);
                }

                await _unitOfWork.News.EditAsync(news);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"News <{news.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        #endregion

        #region Details

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.News = true;

            var news = await _unitOfWork.News.GetAsync(id);
            if (news == null) return NotFound();

            var model = new NewsDetailsViewModel
            {
                Title_AZ = news.Title_AZ,
                Title_RU = news.Title_RU,
                Title_EN = news.Title_EN,
                Title_TR = news.Title_TR,
                Content_AZ = news.Content_AZ,
                Content_RU = news.Content_RU,
                Content_EN = news.Content_EN,
                Content_TR = news.Content_TR,
                Description_AZ = news.Description_AZ,
                Description_RU = news.Description_RU,
                Description_EN = news.Description_EN,
                Description_TR = news.Description_TR,
                ShowOnHome = news.ShowOnHome,
                PhotoPath = _fileService.GetFileUrl(news.PhotoName, FilePath.News),
                ActionDate = news.ActionDate,
                NewsType = news.NewsType
            };

            return View(model);
        }

        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.News = true;

            var news = await _unitOfWork.News.GetAsync(id);
            if (news == null) return NotFound();

            _fileService.Delete(news.PhotoName, FilePath.News);

            await _unitOfWork.News.DeleteAsync(news);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"News <{news.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list");
        }

        #endregion

        #region Upload

        [HttpPost]
        [IgnoreAntiforgeryToken]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile upload)
        {
            StringBuilder messages = new StringBuilder();

            if (upload != null)
            {
                if (_fileService.CheckContentType(upload, messages, ContentTypeHelper.Images) &&
                    _fileService.CheckSize(upload, messages))
                {
                    var fileName = await _fileService.UploadFileAsync(upload, FilePath.News);
                    var url = _fileService.GetFileUrl(fileName, FilePath.News);
                    var success = new UploadSuccess
                    {
                        Uploaded = 1,
                        FileName = fileName,
                        Url = url
                    };

                    return new JsonResult(success);
                }

                return new JsonResult(messages);
            }

            return null;
        }

        #endregion
    }
}
