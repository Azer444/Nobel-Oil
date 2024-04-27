using Core;
using Core.Constants.File;
using Core.Extensions;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.EthicsCompliance;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class EthicsComplianceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public EthicsComplianceController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.EthicsCompliance = true;

            var model = new EthicsComplianceIndexViewModel
            {
                EthicsComplianceComponent = await _unitOfWork.EthicsComplianceComponent.GetAsync(),
                EthicsComplianceSubComponents = await _unitOfWork.EthicsComplianceSubComponent.GetAllAsync()
            };

            return View(model);
        }

        #region Component


        [HttpGet]
        public async Task<IActionResult> DefineComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.EthicsCompliance = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineComponent(EthicsComplianceDefineComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.EthicsCompliance = true;

            if (ModelState.IsValid)
            {
                var ethicsComplianceComponent = new EthicsComplianceComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.EthicsCompliance)
                };

                await _unitOfWork.EthicsComplianceComponent.CreateAsync(ethicsComplianceComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Ethics Compliance component <{ethicsComplianceComponent.Title_EN}> successfully defined.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.EthicsCompliance = true;

            var ethicsComplianceComponent = await _unitOfWork.EthicsComplianceComponent.GetAsync();
            if (ethicsComplianceComponent == null) return NotFound();

            var model = new EthicsComplianceEditComponentViewModel
            {
                Id = ethicsComplianceComponent.Id,
                Title_AZ = ethicsComplianceComponent.Title_AZ,
                Title_RU = ethicsComplianceComponent.Title_RU,
                Title_EN = ethicsComplianceComponent.Title_EN,
                Title_TR = ethicsComplianceComponent.Title_TR,
                Content_AZ = ethicsComplianceComponent.Content_AZ,
                Content_RU = ethicsComplianceComponent.Content_RU,
                Content_EN = ethicsComplianceComponent.Content_EN,
                Content_TR = ethicsComplianceComponent.Content_TR,
                PhotoPath = _fileService.GetFileUrl(ethicsComplianceComponent.PhotoName, FilePath.EthicsCompliance)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(EthicsComplianceEditComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.EthicsCompliance = true;

            var ethicsComplianceComponent = await _unitOfWork.EthicsComplianceComponent.GetAsync();
            if (ethicsComplianceComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                ethicsComplianceComponent.Title_AZ = model.Title_AZ;
                ethicsComplianceComponent.Title_RU = model.Title_RU;
                ethicsComplianceComponent.Title_EN = model.Title_EN;
                ethicsComplianceComponent.Title_TR = model.Title_TR;
                ethicsComplianceComponent.Content_AZ = model.Content_AZ;
                ethicsComplianceComponent.Content_RU = model.Content_RU;
                ethicsComplianceComponent.Content_EN = model.Content_EN;
                ethicsComplianceComponent.Content_TR = model.Content_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(ethicsComplianceComponent.PhotoName, FilePath.EthicsCompliance);
                    ethicsComplianceComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.EthicsCompliance);
                }

                await _unitOfWork.EthicsComplianceComponent.EditAsync(ethicsComplianceComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Ethics Compliance component <{ethicsComplianceComponent.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.EthicsCompliance = true;

            var ethicsComplianceComponent = await _unitOfWork.EthicsComplianceComponent.GetAsync();
            if (ethicsComplianceComponent == null) return NotFound();

            var model = new EthicsComplianceDetailsComponentViewModel
            {
                Title_AZ = ethicsComplianceComponent.Title_AZ,
                Title_RU = ethicsComplianceComponent.Title_RU,
                Title_EN = ethicsComplianceComponent.Title_EN,
                Title_TR = ethicsComplianceComponent.Title_TR,
                Content_AZ = ethicsComplianceComponent.Content_AZ,
                Content_RU = ethicsComplianceComponent.Content_RU,
                Content_EN = ethicsComplianceComponent.Content_EN,
                Content_TR = ethicsComplianceComponent.Content_TR,
                PhotoPath = _fileService.GetFileUrl(ethicsComplianceComponent.PhotoName, FilePath.EthicsCompliance),

            };

            return View(model);
        }

        #endregion

        #region SubComponent

        [HttpGet]
        public async Task<IActionResult> AddSubComponent()
        {
            ViewBag.PageManagement = true;
            ViewBag.EthicsCompliance = true;

            return View();
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> AddSubComponent(EthicsComplianceAddSubComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.EthicsCompliance = true;

            if (ModelState.IsValid)
            {
                var ethicsComplianceSubComponent = new EthicsComplianceSubComponent
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    ContentEC_AZ = model.ContentEC_AZ,
                    ContentEC_RU = model.ContentEC_RU,
                    ContentEC_EN = model.ContentEC_EN,
                    ContentEC_TR = model.ContentEC_TR,
                    Slug = model.Slug.Slugify(),
                    isBanner = model.isBanner,
                    SubmitForm = model.SubmitForm,
                    PhotoName_EC = await _fileService.UploadFileAsync(model.Photo_EC, FilePath.EthicsCompliance),
                    PhotoName = await _fileService.UploadFileAsync(model.Photo_EC, FilePath.EthicsCompliance)
                };

                await _unitOfWork.EthicsComplianceSubComponent.CreateAsync(ethicsComplianceSubComponent);
                await _unitOfWork.CommitAsync();

                foreach (var pdf in model.Pdfs_AZ)
                {
                    var ethicsComplianceSubComponentPdf = new EthicsComplianceSubComponentPdf
                    {
                        EthicsComplianceSubComponentId = ethicsComplianceSubComponent.Id,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.EthicsCompliancePDF),
                        Language = Core.Constants.Language.AZ

                    };

                    await _unitOfWork.EthicsComplianceSubComponentPdfs.CreateAsync(ethicsComplianceSubComponentPdf);
                }

                foreach (var pdf in model.Pdfs_RU)
                {
                    var ethicsComplianceSubComponentPdf = new EthicsComplianceSubComponentPdf
                    {
                        EthicsComplianceSubComponentId = ethicsComplianceSubComponent.Id,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.EthicsCompliancePDF),
                        Language = Core.Constants.Language.RU

                    };

                    await _unitOfWork.EthicsComplianceSubComponentPdfs.CreateAsync(ethicsComplianceSubComponentPdf);
                }

                foreach (var pdf in model.Pdfs_EN)
                {
                    var ethicsComplianceSubComponentPdf = new EthicsComplianceSubComponentPdf
                    {
                        EthicsComplianceSubComponentId = ethicsComplianceSubComponent.Id,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.EthicsCompliancePDF),
                        Language = Core.Constants.Language.EN

                    };

                    await _unitOfWork.EthicsComplianceSubComponentPdfs.CreateAsync(ethicsComplianceSubComponentPdf);
                }

                foreach (var pdf in model.Pdfs_TR)
                {
                    var ethicsComplianceSubComponentPdf = new EthicsComplianceSubComponentPdf
                    {
                        EthicsComplianceSubComponentId = ethicsComplianceSubComponent.Id,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.EthicsCompliancePDF),
                        Language = Core.Constants.Language.TR

                    };

                    await _unitOfWork.EthicsComplianceSubComponentPdfs.CreateAsync(ethicsComplianceSubComponentPdf);
                }

                await _unitOfWork.CommitAsync();


                TempData["message"] = $"Ethics Compliance subcomponent <{ethicsComplianceSubComponent.Title_EN}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditSubComponent(int id)
        {
            ViewBag.PageManagement = true;
            ViewBag.EthicsCompliance = true;

            var ethicsComplianceSubComponent = await _unitOfWork.EthicsComplianceSubComponent.GetAsync(id);
            if (ethicsComplianceSubComponent == null) return NotFound();

            var model = new EthicsComplianceEditSubComponentViewModel
            {
                Id = ethicsComplianceSubComponent.Id,
                Title_AZ = ethicsComplianceSubComponent.Title_AZ,
                Title_RU = ethicsComplianceSubComponent.Title_RU,
                Title_EN = ethicsComplianceSubComponent.Title_EN,
                Title_TR = ethicsComplianceSubComponent.Title_TR,
                Content_AZ = ethicsComplianceSubComponent.Content_AZ,
                Content_RU = ethicsComplianceSubComponent.Content_RU,
                Content_EN = ethicsComplianceSubComponent.Content_EN,
                Content_TR = ethicsComplianceSubComponent.Content_TR,
                ContentEC_AZ = ethicsComplianceSubComponent.ContentEC_AZ,
                ContentEC_RU = ethicsComplianceSubComponent.ContentEC_RU,
                ContentEC_EN = ethicsComplianceSubComponent.ContentEC_EN,
                ContentEC_TR = ethicsComplianceSubComponent.ContentEC_TR,
                isBanner = ethicsComplianceSubComponent.isBanner,
                SubmitForm = ethicsComplianceSubComponent.SubmitForm,
                Slug = ethicsComplianceSubComponent.Slug,
                PhotoName_EC = ethicsComplianceSubComponent.PhotoName_EC,
                PhotoName = ethicsComplianceSubComponent.PhotoName,
                EthicsComplianceSubComponentPdfs_AZ = await _unitOfWork.EthicsComplianceSubComponentPdfs.GetRelatedPDFs(ethicsComplianceSubComponent.Id, Core.Constants.Language.AZ),
                EthicsComplianceSubComponentPdfs_RU = await _unitOfWork.EthicsComplianceSubComponentPdfs.GetRelatedPDFs(ethicsComplianceSubComponent.Id, Core.Constants.Language.RU),
                EthicsComplianceSubComponentPdfs_EN = await _unitOfWork.EthicsComplianceSubComponentPdfs.GetRelatedPDFs(ethicsComplianceSubComponent.Id, Core.Constants.Language.EN),
                EthicsComplianceSubComponentPdfs_TR = await _unitOfWork.EthicsComplianceSubComponentPdfs.GetRelatedPDFs(ethicsComplianceSubComponent.Id, Core.Constants.Language.TR),
            };

            return View(model);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> EditSubComponent(EthicsComplianceEditSubComponentViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.EthicsCompliance = true;

            var ethicsComplianceSubComponent = await _unitOfWork.EthicsComplianceSubComponent.GetAsync(model.Id);
            if (ethicsComplianceSubComponent == null) return NotFound();

            if (ModelState.IsValid)
            {
                ethicsComplianceSubComponent.Title_AZ = model.Title_AZ;
                ethicsComplianceSubComponent.Title_RU = model.Title_RU;
                ethicsComplianceSubComponent.Title_EN = model.Title_EN;
                ethicsComplianceSubComponent.Title_TR = model.Title_TR;
                ethicsComplianceSubComponent.Content_AZ = model.Content_AZ;
                ethicsComplianceSubComponent.Content_RU = model.Content_RU;
                ethicsComplianceSubComponent.Content_EN = model.Content_EN;
                ethicsComplianceSubComponent.Content_TR = model.Content_TR;
                ethicsComplianceSubComponent.ContentEC_AZ = model.ContentEC_AZ;
                ethicsComplianceSubComponent.ContentEC_RU = model.ContentEC_RU;
                ethicsComplianceSubComponent.ContentEC_EN = model.ContentEC_EN;
                ethicsComplianceSubComponent.ContentEC_TR = model.ContentEC_TR;
                ethicsComplianceSubComponent.isBanner = model.isBanner;
                ethicsComplianceSubComponent.SubmitForm = model.SubmitForm;
                ethicsComplianceSubComponent.Slug = model.Slug.Slugify();

                if (model.Photo_EC != null)
                {
                    _fileService.Delete(ethicsComplianceSubComponent.PhotoName_EC, FilePath.EthicsCompliance);
                    ethicsComplianceSubComponent.PhotoName_EC = await _fileService.UploadFileAsync(model.Photo_EC, FilePath.EthicsCompliance);
                }

                if (model.Photo != null)
                {
                    _fileService.Delete(ethicsComplianceSubComponent.PhotoName, FilePath.EthicsCompliance);
                    ethicsComplianceSubComponent.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.EthicsCompliance);
                }

                await _unitOfWork.EthicsComplianceSubComponent.EditAsync(ethicsComplianceSubComponent);
                await _unitOfWork.CommitAsync();

                foreach (var pdf in model.Pdfs_AZ)
                {
                    var ethicsComplianceSubComponentPdf = new EthicsComplianceSubComponentPdf
                    {
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.EthicsCompliancePDF),
                        EthicsComplianceSubComponentId = ethicsComplianceSubComponent.Id,
                        Language = Core.Constants.Language.AZ,
                    };

                    await _unitOfWork.EthicsComplianceSubComponentPdfs.CreateAsync(ethicsComplianceSubComponentPdf);
                }

                foreach (var pdf in model.Pdfs_RU)
                {
                    var ethicsComplianceSubComponentPdf = new EthicsComplianceSubComponentPdf
                    {
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.EthicsCompliancePDF),
                        EthicsComplianceSubComponentId = ethicsComplianceSubComponent.Id,
                        Language = Core.Constants.Language.RU,
                    };

                    await _unitOfWork.EthicsComplianceSubComponentPdfs.CreateAsync(ethicsComplianceSubComponentPdf);
                }

                foreach (var pdf in model.Pdfs_EN)
                {
                    var ethicsComplianceSubComponentPdf = new EthicsComplianceSubComponentPdf
                    {
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.EthicsCompliancePDF),
                        EthicsComplianceSubComponentId = ethicsComplianceSubComponent.Id,
                        Language = Core.Constants.Language.EN,
                    };

                    await _unitOfWork.EthicsComplianceSubComponentPdfs.CreateAsync(ethicsComplianceSubComponentPdf);
                }

                foreach (var pdf in model.Pdfs_TR)
                {
                    var ethicsComplianceSubComponentPdf = new EthicsComplianceSubComponentPdf
                    {
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.EthicsCompliancePDF),
                        EthicsComplianceSubComponentId = ethicsComplianceSubComponent.Id,
                        Language = Core.Constants.Language.TR,
                    };

                    await _unitOfWork.EthicsComplianceSubComponentPdfs.CreateAsync(ethicsComplianceSubComponentPdf);
                }

                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Ethics Compliance subcomponent <{ethicsComplianceSubComponent.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsSubComponent(int id)
        {
            var ethicsComplianceSubComponent = await _unitOfWork.EthicsComplianceSubComponent.GetAsync(id);
            if (ethicsComplianceSubComponent == null) return NotFound();

            var model = new EthicsComplianceDetailsSubComponentViewModel
            {
                Title_AZ = ethicsComplianceSubComponent.Title_AZ,
                Title_RU = ethicsComplianceSubComponent.Title_RU,
                Title_EN = ethicsComplianceSubComponent.Title_EN,
                Title_TR = ethicsComplianceSubComponent.Title_TR,
                Slug = ethicsComplianceSubComponent.Slug,
                Content_AZ = ethicsComplianceSubComponent.Content_AZ,
                Content_RU = ethicsComplianceSubComponent.Content_RU,
                Content_EN = ethicsComplianceSubComponent.Content_EN,
                Content_TR = ethicsComplianceSubComponent.Content_TR,
                ContentEC_AZ = ethicsComplianceSubComponent.ContentEC_AZ,
                ContentEC_RU = ethicsComplianceSubComponent.ContentEC_RU,
                ContentEC_EN = ethicsComplianceSubComponent.ContentEC_EN,
                ContentEC_TR = ethicsComplianceSubComponent.ContentEC_TR,
                isBanner = ethicsComplianceSubComponent.isBanner,
                SubmitForm = ethicsComplianceSubComponent.SubmitForm,
                PhotoPath_EC = _fileService.GetFileUrl(ethicsComplianceSubComponent.PhotoName_EC, FilePath.EthicsCompliance),
                PhotoPath = _fileService.GetFileUrl(ethicsComplianceSubComponent.PhotoName, FilePath.EthicsCompliance),
                EthicsComplianceSubComponentPdfs = ethicsComplianceSubComponent.EthicsComplianceSubComponentPdfs
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSubComponent(int id)
        {
            var ethicsComplianceSubComponent = await _unitOfWork.EthicsComplianceSubComponent.GetAsync(id);
            if (ethicsComplianceSubComponent == null) return NotFound();

            _fileService.Delete(ethicsComplianceSubComponent.PhotoName_EC, FilePath.EthicsCompliance);
            _fileService.Delete(ethicsComplianceSubComponent.PhotoName, FilePath.EthicsCompliance);

            foreach (var EthicsComplianceSubComponentPdf in ethicsComplianceSubComponent.EthicsComplianceSubComponentPdfs)
                _fileService.Delete(EthicsComplianceSubComponentPdf.PdfFileName, FilePath.EthicsCompliancePDF);

            await _unitOfWork.EthicsComplianceSubComponent.DeleteAsync(ethicsComplianceSubComponent);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Ethics Compliance subcomponent <{ethicsComplianceSubComponent.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSubComponentPDF(int id)
        {
            var ethicsComplianceSubComponentPdf = await _unitOfWork.EthicsComplianceSubComponentPdfs.GetAsync(id);
            if (ethicsComplianceSubComponentPdf == null) return NotFound();

            _fileService.Delete(ethicsComplianceSubComponentPdf.PdfFileName, FilePath.EthicsCompliancePDF);

            await _unitOfWork.EthicsComplianceSubComponentPdfs.DeleteAsync(ethicsComplianceSubComponentPdf);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Ethics Compliance subcomponent pdf <{_fileService.GetPureFileName(ethicsComplianceSubComponentPdf.PdfFileName)}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("editsubcomponent", "ethicscompliance", new { id = ethicsComplianceSubComponentPdf.EthicsComplianceSubComponentId });
        }

        #endregion
    }
}
