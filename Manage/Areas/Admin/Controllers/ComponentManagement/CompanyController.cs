using Core;
using Core.Constants.File;
using Core.Extensions;
using Core.Models;
using EcomLab.Core.Constants.File;
using Manage.Areas.Admin.Models.ComponentManagement.Company;
using Manage.Areas.Admin.Models.ComponentManagement.News;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.ComponentManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public CompanyController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Company = true;

            var model = new CompanyListViewModel
            {
                Companies = await _unitOfWork.Companies.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Company = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyCreateViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Company = true;

            if (ModelState.IsValid)
            {
                var company = new Company
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    TitleCareer_AZ = model.TitleCareer_AZ,
                    TitleCareer_RU = model.TitleCareer_RU,
                    TitleCareer_EN = model.TitleCareer_EN,
                    TitleCareer_TR = model.TitleCareer_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    ContentWWD_AZ = model.ContentWWD_AZ,
                    ContentWWD_RU = model.ContentWWD_RU,
                    ContentWWD_EN = model.ContentWWD_EN,
                    ContentWWD_TR = model.ContentWWD_TR,
                    Link_Career = model.Link_Career,
                    Slug = model.Slug.Slugify(),
                    ShowOnCareer = model.ShowOnCareer,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Company),
                    PhotoName_WWD = await _fileService.UploadFileAsync(model.Photo_WWD, FilePath.Company),
                    PhotoName_Career = await _fileService.UploadFileAsync(model.Photo_Career, FilePath.Company),
                };

                await _unitOfWork.Companies.CreateAsync(company);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Company <{company.Title_EN}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        [HttpGet("admin/company/edit/{slug}")]
        public async Task<IActionResult> Edit(string slug)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Company = true;

            var company = await _unitOfWork.Companies.GetBySlugAsync(slug);
            if (company == null) return NotFound();

            var model = new CompanyEditViewModel
            {
                Id = company.Id,
                Title_AZ = company.Title_AZ,
                Title_RU = company.Title_RU,
                Title_EN = company.Title_EN,
                Title_TR = company.Title_TR,
                TitleCareer_AZ = company.TitleCareer_AZ,
                TitleCareer_RU = company.TitleCareer_RU,
                TitleCareer_EN = company.TitleCareer_EN,
                TitleCareer_TR = company.TitleCareer_TR,
                Content_AZ = company.Content_AZ,
                Content_RU = company.Content_RU,
                Content_EN = company.Content_EN,
                Content_TR = company.Content_TR,
                ContentWWD_AZ = company.ContentWWD_AZ,
                ContentWWD_RU = company.ContentWWD_RU,
                ContentWWD_EN = company.ContentWWD_EN,
                ContentWWD_TR = company.ContentWWD_TR,
                Link_Career = company.Link_Career,
                ShowOnCareer = company.ShowOnCareer,
                PhotoPath = _fileService.GetFileUrl(company.PhotoName, FilePath.Company),
                PhotoPath_WWD = _fileService.GetFileUrl(company.PhotoName_WWD, FilePath.Company),
                PhotoPath_Career = _fileService.GetFileUrl(company.PhotoName_Career, FilePath.Company),
                Slug = company.Slug
            };

            return View(model);
        }

        [HttpPost("admin/company/edit/{slug}")]
        public async Task<IActionResult> Edit(CompanyEditViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Company = true;

            var company = await _unitOfWork.Companies.GetAsync(model.Id);
            if (company == null) return NotFound();

            if (ModelState.IsValid)
            {
                company.Title_AZ = model.Title_AZ;
                company.Title_RU = model.Title_RU;
                company.Title_EN = model.Title_EN;
                company.Title_TR = model.Title_TR;
                company.TitleCareer_AZ = model.TitleCareer_AZ;
                company.TitleCareer_RU = model.TitleCareer_RU;
                company.TitleCareer_EN = model.TitleCareer_EN;
                company.TitleCareer_TR = model.TitleCareer_TR;
                company.Content_AZ = model.Content_AZ;
                company.Content_RU = model.Content_RU;
                company.Content_EN = model.Content_EN;
                company.Content_TR = model.Content_TR;
                company.ContentWWD_AZ = model.ContentWWD_AZ;
                company.ContentWWD_RU = model.ContentWWD_RU;
                company.ContentWWD_EN = model.ContentWWD_EN;
                company.ContentWWD_TR = model.ContentWWD_TR;
                company.Link_Career = model.Link_Career;
                company.Slug = model.Slug.Slugify();
                company.ShowOnCareer = model.ShowOnCareer;

                if (model.Photo != null)
                {
                    _fileService.Delete(company.PhotoName, FilePath.Company);
                    company.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Company);
                }

                if (model.Photo_WWD != null)
                {
                    _fileService.Delete(company.PhotoName_WWD, FilePath.Company);
                    company.PhotoName_WWD = await _fileService.UploadFileAsync(model.Photo_WWD, FilePath.Company);
                }

                if (model.Photo_Career != null)
                {
                    _fileService.Delete(company.PhotoName_Career, FilePath.Company);
                    company.PhotoName_Career = await _fileService.UploadFileAsync(model.Photo_Career, FilePath.Company);
                }

                await _unitOfWork.Companies.EditAsync(company);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Company <{company.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        [HttpGet("admin/company/details/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Company = true;

            var company = await _unitOfWork.Companies.GetBySlugAsync(slug);
            if (company == null) return NotFound();

            var model = new CompanyDetailsViewModel
            {
                Title_AZ = company.Title_AZ,
                Title_RU = company.Title_RU,
                Title_EN = company.Title_EN,
                Title_TR = company.Title_TR,
                TitleCareer_AZ = company.TitleCareer_AZ,
                TitleCareer_RU = company.TitleCareer_RU,
                TitleCareer_EN = company.TitleCareer_EN,
                TitleCareer_TR = company.TitleCareer_TR,
                Content_AZ = company.Content_AZ,
                Content_RU = company.Content_RU,
                Content_EN = company.Content_EN,
                Content_TR = company.Content_TR,
                ContentWWD_AZ = company.ContentWWD_AZ,
                ContentWWD_RU = company.ContentWWD_RU,
                ContentWWD_EN = company.ContentWWD_EN,
                ContentWWD_TR = company.ContentWWD_TR,
                Link_Career = company.Link_Career,
                ShowOnCareer = company.ShowOnCareer,
                PhotoPath = _fileService.GetFileUrl(company.PhotoName, FilePath.Company),
                PhotoPath_WWD = _fileService.GetFileUrl(company.PhotoName_WWD, FilePath.Company),
                PhotoPath_Career = _fileService.GetFileUrl(company.PhotoName_Career, FilePath.Company),
            };

            return View(model);
        }

        [HttpGet("admin/company/delete/{slug}")]
        public async Task<IActionResult> Delete(string slug)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Company = true;

            var company = await _unitOfWork.Companies.GetBySlugAsync(slug);
            if (company == null) return NotFound();

            _fileService.Delete(company.PhotoName, FilePath.Company);
            _fileService.Delete(company.PhotoName_WWD, FilePath.Company);
            _fileService.Delete(company.PhotoName_Career, FilePath.Company);

            await _unitOfWork.Companies.DeleteAsync(company);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Company <{company.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list");
        }

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
                    var fileName = await _fileService.UploadFileAsync(upload, FilePath.Company);
                    var url = _fileService.GetFileUrl(fileName, FilePath.Company);
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
    }
}
