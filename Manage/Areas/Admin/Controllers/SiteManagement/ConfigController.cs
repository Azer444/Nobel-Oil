using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.SiteManagement;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.SiteManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class ConfigController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public ConfigController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.SiteManagement = true;
            ViewBag.SiteConfig = true;

            var siteConfig = await _unitOfWork.SiteConfig.GetAsync();
            return View(siteConfig);
        }

        [HttpGet]
        public async Task<IActionResult> Define()
        {
            ViewBag.SiteManagement = true;
            ViewBag.SiteConfig = true;

            var siteConfig = await _unitOfWork.SiteConfig.GetAsync();
            if (siteConfig != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Define(SiteConfig siteConfig)
        {
            ViewBag.SiteManagement = true;
            ViewBag.SiteConfig = true;

            if (ModelState.IsValid)
            {
                siteConfig.FirstLogoName = await _fileService.UploadFileAsync(siteConfig.FirstLogo, FilePath.SiteConfig);

                await _unitOfWork.SiteConfig.CreateAsync(siteConfig);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("index", "config");
            }

            return View(siteConfig);
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            ViewBag.SiteManagement = true;
            ViewBag.SiteConfig = true;

            var siteConfig = await _unitOfWork.SiteConfig.GetAsync();
            if (siteConfig == null) return NotFound();

            SiteConfigEditViewModel model = new SiteConfigEditViewModel
            {
                Id = siteConfig.Id,
                FirstLogoName = siteConfig.FirstLogoName,
                Contact_AZ = siteConfig.Contact_AZ,
                Contact_RU = siteConfig.Contact_RU,
                Contact_EN = siteConfig.Contact_EN,
                Contact_TR = siteConfig.Contact_TR,
                Copyright_AZ = siteConfig.Copyright_AZ,
                Copyright_RU = siteConfig.Copyright_RU,
                Copyright_EN = siteConfig.Copyright_EN,
                Copyright_TR = siteConfig.Copyright_TR,
                FacebookLink = siteConfig.FacebookLink,
                LinkedinLink = siteConfig.LinkedinLink,
                TwitterLink = siteConfig.TwitterLink,
                YoutubeLink = siteConfig.YoutubeLink
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SiteConfigEditViewModel model)
        {
            ViewBag.SiteManagement = true;
            ViewBag.SiteConfig = true;

            if (ModelState.IsValid)
            {
                var siteConfig = await _unitOfWork.SiteConfig.GetAsync();

                if (model.FirstLogo != null)
                {
                    _fileService.Delete(siteConfig.FirstLogoName, FilePath.SiteConfig);
                    siteConfig.FirstLogoName = await _fileService.UploadFileAsync(model.FirstLogo, FilePath.SiteConfig);
                }

                siteConfig.Contact_AZ = model.Contact_AZ;
                siteConfig.Contact_RU = model.Contact_RU;
                siteConfig.Contact_EN = model.Contact_EN;
                siteConfig.Contact_TR = model.Contact_TR;
                siteConfig.Copyright_AZ = model.Copyright_AZ;
                siteConfig.Copyright_RU = model.Copyright_RU;
                siteConfig.Copyright_EN = model.Copyright_EN;
                siteConfig.Copyright_TR = model.Copyright_TR;
                siteConfig.FacebookLink = model.FacebookLink;
                siteConfig.LinkedinLink = model.LinkedinLink;
                siteConfig.TwitterLink = model.TwitterLink;
                siteConfig.YoutubeLink = model.YoutubeLink;

                await _unitOfWork.SiteConfig.EditAsync(siteConfig);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Details()
        {
            ViewBag.SiteManagement = true;
            ViewBag.SiteConfig = true;

            var siteConfig = await _unitOfWork.SiteConfig.GetAsync();
            if (siteConfig == null) return NotFound();

            return View(siteConfig);
        }
    }
}
