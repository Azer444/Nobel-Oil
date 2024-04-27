using Core;
using Core.Constants.File;
using Core.Extensions;
using Core.Models;
using EcomLab.Core.Constants.File;
using Manage.Areas.Admin.Models.ComponentManagement.News;
using Manage.Areas.Admin.Models.ComponentManagement.PublicationReport;
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
    public class PublicationReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public PublicationReportController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        #region List

        [HttpGet("admin/insights/list")]
        public async Task<IActionResult> List()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.PublicationReport = true;


            var model = new PublicationReportListViewModel
            {
                PublicationReports = (await _unitOfWork.PublicationReport.GetAllAsync()).OrderByDescending(n => n.Id).ToList()
            };

            return View(model);
        }

        #endregion

        #region Create

        [HttpGet("admin/insights/create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.PublicationReport = true;

            return View();
        }

        [HttpPost("admin/insights/create")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Create(PublicationReportCreateViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.PublicationReport = true;

            if (ModelState.IsValid)
            {
                var publicationReport = new PublicationReport
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
                    Slug = model.Slug.Slugify().Substring(0, 100),
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.PublicationReport),
                    ActionDate = model.ActionDate
                };

                await _unitOfWork.PublicationReport.CreateAsync(publicationReport);
                await _unitOfWork.CommitAsync();

                //upload AZ language related pdf files
                foreach (var pdf in model.Pdfs_AZ)
                {
                    var publicationReportPdfAz = new PublicationReportPdf
                    {
                        Language = Core.Constants.Language.AZ,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.PublicationReport),
                        PublicationReportId = publicationReport.Id
                    };

                    await _unitOfWork.PublicationReportPdf.CreateAsync(publicationReportPdfAz);
                    await _unitOfWork.CommitAsync();
                }

                //upload RU language related pdf files
                foreach (var pdf in model.Pdfs_RU)
                {
                    var publicationReportPdfAz = new PublicationReportPdf
                    {
                        Language = Core.Constants.Language.RU,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.PublicationReport),
                        PublicationReportId = publicationReport.Id
                    };

                    await _unitOfWork.PublicationReportPdf.CreateAsync(publicationReportPdfAz);
                    await _unitOfWork.CommitAsync();
                }

                //upload EN language related pdf files
                foreach (var pdf in model.Pdfs_EN)
                {
                    var publicationReportPdfAz = new PublicationReportPdf
                    {
                        Language = Core.Constants.Language.EN,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.PublicationReport),
                        PublicationReportId = publicationReport.Id
                    };

                    await _unitOfWork.PublicationReportPdf.CreateAsync(publicationReportPdfAz);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"Insights <{publicationReport.Title_EN.Substring(0,100)}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        #endregion

        #region Edit 

        [HttpGet("admin/insights/edit/{slug}"), DisableRequestSizeLimit]
        public async Task<IActionResult> Edit(string slug)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.PublicationReport = true;

            var publicationReport = await _unitOfWork.PublicationReport.GetBySlugAsync(slug);
            if (publicationReport == null) return NotFound();

            var model = new PublicationReportEditViewModel
            {
                Id = publicationReport.Id,
                Title_AZ = publicationReport.Title_AZ,
                Title_RU = publicationReport.Title_RU,
                Title_EN = publicationReport.Title_EN,
                Title_TR = publicationReport.Title_TR,
                Content_AZ = publicationReport.Content_AZ,
                Content_RU = publicationReport.Content_RU,
                Content_EN = publicationReport.Content_EN,
                Content_TR = publicationReport.Content_TR,
                Description_AZ = publicationReport.Description_AZ,
                Description_RU = publicationReport.Description_RU,
                Description_EN = publicationReport.Description_EN,
                Description_TR = publicationReport.Description_TR,
                PhotoPath = _fileService.GetFileUrl(publicationReport.PhotoName, FilePath.PublicationReport),
                Slug = publicationReport.Slug,
                ActionDate = publicationReport.ActionDate,
                PublicationReportPdf_AZ = await _unitOfWork.PublicationReportPdf.GetAllByPublicationReportIdAsync(publicationReport.Id, Core.Constants.Language.AZ),
                PublicationReportPdf_RU = await _unitOfWork.PublicationReportPdf.GetAllByPublicationReportIdAsync(publicationReport.Id, Core.Constants.Language.RU),
                PublicationReportPdf_EN = await _unitOfWork.PublicationReportPdf.GetAllByPublicationReportIdAsync(publicationReport.Id, Core.Constants.Language.EN),
            };

            return View(model);
        }

        [HttpPost("admin/insights/edit/{slug}")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Edit(PublicationReportEditViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.PublicationReport = true;

            var publicationReport = await _unitOfWork.PublicationReport.GetAsync(model.Id);
            if (publicationReport == null) return NotFound();

            if (ModelState.IsValid)
            {
                publicationReport.Title_AZ = model.Title_AZ;
                publicationReport.Title_RU = model.Title_RU;
                publicationReport.Title_EN = model.Title_EN;
                publicationReport.Title_TR = model.Title_TR;
                publicationReport.Content_AZ = model.Content_AZ;
                publicationReport.Content_RU = model.Content_RU;
                publicationReport.Content_EN = model.Content_EN;
                publicationReport.Content_TR = model.Content_TR;
                publicationReport.Description_AZ = model.Description_AZ;
                publicationReport.Description_RU = model.Description_RU;
                publicationReport.Description_EN = model.Description_EN;
                publicationReport.Description_TR = model.Description_TR;
                publicationReport.Slug = model.Slug.Slugify();
                publicationReport.ActionDate = model.ActionDate;

                if (model.Photo != null)
                {
                    _fileService.Delete(publicationReport.PhotoName, FilePath.PublicationReport);
                    publicationReport.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.PublicationReport);
                }

                await _unitOfWork.PublicationReport.EditAsync(publicationReport);
                await _unitOfWork.CommitAsync();

                //upload AZ language related pdf files
                foreach (var pdf in model.Pdfs_AZ)
                {
                    var publicationReportPdfAz = new PublicationReportPdf
                    {
                        Language = Core.Constants.Language.AZ,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.PublicationReport),
                        PublicationReportId = publicationReport.Id
                    };

                    await _unitOfWork.PublicationReportPdf.CreateAsync(publicationReportPdfAz);
                    await _unitOfWork.CommitAsync();
                }

                //upload RU language related pdf files
                foreach (var pdf in model.Pdfs_RU)
                {
                    var publicationReportPdfAz = new PublicationReportPdf
                    {
                        Language = Core.Constants.Language.RU,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.PublicationReport),
                        PublicationReportId = publicationReport.Id
                    };

                    await _unitOfWork.PublicationReportPdf.CreateAsync(publicationReportPdfAz);
                    await _unitOfWork.CommitAsync();
                }

                //upload EN language related pdf files
                foreach (var pdf in model.Pdfs_EN)
                {
                    var publicationReportPdfAz = new PublicationReportPdf
                    {
                        Language = Core.Constants.Language.EN,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.PublicationReport),
                        PublicationReportId = publicationReport.Id
                    };

                    await _unitOfWork.PublicationReportPdf.CreateAsync(publicationReportPdfAz);
                    await _unitOfWork.CommitAsync();
                }


                TempData["message"] = $"Insights <{publicationReport.Title_EN.Substring(0, 100)}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            model.PublicationReportPdf_AZ = await _unitOfWork.PublicationReportPdf.GetAllByPublicationReportIdAsync(publicationReport.Id, Core.Constants.Language.AZ);
            model.PublicationReportPdf_RU = await _unitOfWork.PublicationReportPdf.GetAllByPublicationReportIdAsync(publicationReport.Id, Core.Constants.Language.RU);
            model.PublicationReportPdf_EN = await _unitOfWork.PublicationReportPdf.GetAllByPublicationReportIdAsync(publicationReport.Id, Core.Constants.Language.EN);

            return View(model);
        }

        #endregion

        #region Details

        [HttpGet("admin/insights/details/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.PublicationReport = true;

            var publicationReport = await _unitOfWork.PublicationReport.GetBySlugAsync(slug);
            if (publicationReport == null) return NotFound();

            var model = new PublicationReportDetailsViewModel
            {
                Title_AZ = publicationReport.Title_AZ,
                Title_RU = publicationReport.Title_RU,
                Title_EN = publicationReport.Title_EN,
                Title_TR = publicationReport.Title_TR,
                Content_AZ = publicationReport.Content_AZ,
                Content_RU = publicationReport.Content_RU,
                Content_EN = publicationReport.Content_EN,
                Content_TR = publicationReport.Content_TR,
                Description_AZ = publicationReport.Description_AZ,
                Description_RU = publicationReport.Description_RU,
                Description_EN = publicationReport.Description_EN,
                Description_TR = publicationReport.Description_TR,
                PhotoPath = _fileService.GetFileUrl(publicationReport.PhotoName, FilePath.PublicationReport),
                ActionDate = publicationReport.ActionDate
            };

            return View(model);
        }

        #endregion

        #region Delete

        [HttpGet("admin/insights/delete/{slug}")]
        public async Task<IActionResult> Delete(string slug)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.PublicationReport = true;

            var publicationReport = await _unitOfWork.PublicationReport.GetBySlugAsync(slug);
            if (publicationReport == null) return NotFound();

            //Delete publication report photo
            _fileService.Delete(publicationReport.PhotoName, FilePath.PublicationReport);

            //Delete related pdfs
            var publicationReportPdfs = await _unitOfWork.PublicationReportPdf.GetAllByPublicationReportIdAsync(publicationReport.Id);

            foreach (var publicationReportPdf in publicationReportPdfs)
            {
                _fileService.Delete(publicationReportPdf.PdfFileName, FilePath.PublicationReport);
            }

            await _unitOfWork.PublicationReport.DeleteAsync(publicationReport);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Insights <{publicationReport.Title_EN.Substring(0, 100)}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list");
        }

        #endregion


        [HttpGet]
        public async Task<IActionResult> DeletePdf(int id)
        {
            var publicationReportPdf = await _unitOfWork.PublicationReportPdf.GetAsync(id);
            if (publicationReportPdf == null) return NotFound();

            _fileService.Delete(publicationReportPdf.PdfFileName, FilePath.PublicationReport);

            await _unitOfWork.PublicationReportPdf.DeleteAsync(publicationReportPdf);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Insights pdf <{_fileService.GetPureFileName(publicationReportPdf.PdfFileName)}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list", "publicationreport");
        }

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
                    var fileName = await _fileService.UploadFileAsync(upload, FilePath.PublicationReport);
                    var url = _fileService.GetFileUrl(fileName, FilePath.PublicationReport);
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
