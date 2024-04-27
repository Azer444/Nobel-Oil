using Core;
using Core.Constants.File;
using Core.Extensions;
using Core.Models;
using EcomLab.Core.Constants.File;
using Manage.Areas.Admin.Models.ComponentManagement.LifeAtNobelEnergy;
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
    public class LifeAtNobelEnergyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public LifeAtNobelEnergyController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        #region List

        [HttpGet("admin/lifeatnobelenergy/list")]
        public async Task<IActionResult> List()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.LifeAtNobelEnergy = true;

            var model = new LifeAtNobelEnergyListViewModel
            {
                LifeAtNobelEnergies = (await _unitOfWork.LifeAtNobelEnergy.GetAllAsync()).OrderByDescending(n => n.Id).ToList()
            };

            return View(model);
        }

        #endregion

        #region Delete

        [HttpGet("admin/lifeatnobelenergy/delete/{slug}")]
        public async Task<IActionResult> Delete(string slug)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.LifeAtNobelEnergy = true;

            var energy = await _unitOfWork.LifeAtNobelEnergy.GetBySlugAsync(slug);
            if (energy == null) return NotFound();

            _fileService.Delete(energy.PhotoName, FilePath.LifeAtNobelEnergy);

            var Pdfs = await _unitOfWork.LifeAtNobelEnergyPdf.GetAllByLifeAtNobelEnergyPdfIdAsync(energy.Id);

            foreach (var Pdf in Pdfs)
            {
                _fileService.Delete(Pdf.PdfFileName, FilePath.LifeAtNobelEnergy);
            }

            await _unitOfWork.LifeAtNobelEnergy.DeleteAsync(energy);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Life At Nobel Energy <{energy.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePdf(int id)
        {
            var Pdf = await _unitOfWork.LifeAtNobelEnergyPdf.GetAsync(id);
            if (Pdf == null) return NotFound();

            _fileService.Delete(Pdf.PdfFileName, FilePath.LifeAtNobelEnergy);

            await _unitOfWork.LifeAtNobelEnergyPdf.DeleteAsync(Pdf);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Life At Nobel Energy pdf <{_fileService.GetPureFileName(Pdf.PdfFileName)}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list", "lifeatnobelenergy");
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
                    var fileName = await _fileService.UploadFileAsync(upload, FilePath.LifeAtNobelEnergy);
                    var url = _fileService.GetFileUrl(fileName, FilePath.LifeAtNobelEnergy);
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

        #region Create

        [HttpGet("admin/lifeatnobelenergy/create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.LifeAtNobelEnergy = true;

            return View();
        }

        [HttpPost("admin/lifeatnobelenergy/create")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Create(LifeAtNobelEnergyCreateViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.LifeAtNobelEnergy = true;

            if (ModelState.IsValid)
            {
                var entity = new LifeAtNobelEnergy
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
                    Slug = model.Slug.Slugify(),
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.LifeAtNobelEnergy),
                    ActionDate = model.ActionDate
                };

                await _unitOfWork.LifeAtNobelEnergy.CreateAsync(entity);
                await _unitOfWork.CommitAsync();

                //upload AZ language related pdf files
                foreach (var pdf in model.Pdfs_AZ)
                {
                    var PdfAz = new LifeAtNobelEnergyPdf
                    {
                        Language = Core.Constants.Language.AZ,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.LifeAtNobelEnergy),
                        LifeAtNobelEnergyId = entity.Id
                    };

                    await _unitOfWork.LifeAtNobelEnergyPdf.CreateAsync(PdfAz);
                    await _unitOfWork.CommitAsync();
                }

                //upload RU language related pdf files
                foreach (var pdf in model.Pdfs_RU)
                {
                    var PdfRu = new LifeAtNobelEnergyPdf
                    {
                        Language = Core.Constants.Language.RU,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.LifeAtNobelEnergy),
                        LifeAtNobelEnergyId = entity.Id
                    };

                    await _unitOfWork.LifeAtNobelEnergyPdf.CreateAsync(PdfRu);
                    await _unitOfWork.CommitAsync();
                }

                //upload EN language related pdf files
                foreach (var pdf in model.Pdfs_EN)
                {
                    var PdfEn = new LifeAtNobelEnergyPdf
                    {
                        Language = Core.Constants.Language.EN,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.LifeAtNobelEnergy),
                        LifeAtNobelEnergyId = entity.Id
                    };

                    await _unitOfWork.LifeAtNobelEnergyPdf.CreateAsync(PdfEn);
                    await _unitOfWork.CommitAsync();
                }

                //upload TR language related pdf files
                foreach (var pdf in model.Pdfs_TR)
                {
                    var PdfTr = new LifeAtNobelEnergyPdf
                    {
                        Language = Core.Constants.Language.TR,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.LifeAtNobelEnergy),
                        LifeAtNobelEnergyId = entity.Id
                    };

                    await _unitOfWork.LifeAtNobelEnergyPdf.CreateAsync(PdfTr);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"Life At Nobel Energy <{entity.Title_EN}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        #endregion

        #region Edit 

        [HttpGet("admin/lifeatnobelenergy/edit/{slug}"), DisableRequestSizeLimit]
        public async Task<IActionResult> Edit(string slug)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.LifeAtNobelEnergy = true;

            var entity = await _unitOfWork.LifeAtNobelEnergy.GetBySlugAsync(slug);
            if (entity == null) return NotFound();

            var model = new LifeAtNobelEnergyEditViewModel
            {
                Id = entity.Id,
                Title_AZ = entity.Title_AZ,
                Title_RU = entity.Title_RU,
                Title_EN = entity.Title_EN,
                Title_TR = entity.Title_TR,
                Content_AZ = entity.Content_AZ,
                Content_RU = entity.Content_RU,
                Content_EN = entity.Content_EN,
                Content_TR = entity.Content_TR,
                Description_AZ = entity.Description_AZ,
                Description_RU = entity.Description_RU,
                Description_EN = entity.Description_EN,
                Description_TR = entity.Description_TR,
                PhotoPath = _fileService.GetFileUrl(entity.PhotoName, FilePath.LifeAtNobelEnergy),
                Slug = entity.Slug,
                ActionDate = entity.ActionDate,
                LifeAtNobelEnergyPdf_AZ = await _unitOfWork.LifeAtNobelEnergyPdf.GetAllByLifeAtNobelEnergyPdfIdAsync(entity.Id, Core.Constants.Language.AZ),
                LifeAtNobelEnergyPdf_RU = await _unitOfWork.LifeAtNobelEnergyPdf.GetAllByLifeAtNobelEnergyPdfIdAsync(entity.Id, Core.Constants.Language.RU),
                LifeAtNobelEnergyPdf_EN = await _unitOfWork.LifeAtNobelEnergyPdf.GetAllByLifeAtNobelEnergyPdfIdAsync(entity.Id, Core.Constants.Language.EN),
                LifeAtNobelEnergyPdf_TR = await _unitOfWork.LifeAtNobelEnergyPdf.GetAllByLifeAtNobelEnergyPdfIdAsync(entity.Id, Core.Constants.Language.TR),
            };

            return View(model);
        }


        [HttpPost("admin/lifeatnobelenergy/edit/{slug}")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Edit(LifeAtNobelEnergyEditViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.LifeAtNobelEnergy = true;

            var entity = await _unitOfWork.LifeAtNobelEnergy.GetAsync(model.Id);
            if (entity == null) return NotFound();

            if (ModelState.IsValid)
            {
                entity.Title_AZ = model.Title_AZ;
                entity.Title_RU = model.Title_RU;
                entity.Title_EN = model.Title_EN;
                entity.Title_TR = model.Title_TR;
                entity.Content_AZ = model.Content_AZ;
                entity.Content_RU = model.Content_RU;
                entity.Content_EN = model.Content_EN;
                entity.Content_TR = model.Content_TR;
                entity.Description_AZ = model.Description_AZ;
                entity.Description_RU = model.Description_RU;
                entity.Description_EN = model.Description_EN;
                entity.Description_TR = model.Description_TR;
                entity.Slug = model.Slug.Slugify();
                entity.ActionDate = model.ActionDate;

                if (model.Photo != null)
                {
                    _fileService.Delete(entity.PhotoName, FilePath.LifeAtNobelEnergy);
                    entity.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.LifeAtNobelEnergy);
                }

                await _unitOfWork.LifeAtNobelEnergy.EditAsync(entity);
                await _unitOfWork.CommitAsync();

                //upload AZ language related pdf files
                foreach (var pdf in model.Pdfs_AZ)
                {
                    var Pdfs_AZ = new LifeAtNobelEnergyPdf
                    {
                        Language = Core.Constants.Language.AZ,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.LifeAtNobelEnergy),
                        LifeAtNobelEnergyId = entity.Id
                    };

                    await _unitOfWork.LifeAtNobelEnergyPdf.CreateAsync(Pdfs_AZ);
                    await _unitOfWork.CommitAsync();
                }

                //upload RU language related pdf files
                foreach (var pdf in model.Pdfs_RU)
                {
                    var Pdfs_RU = new LifeAtNobelEnergyPdf
                    {
                        Language = Core.Constants.Language.RU,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.LifeAtNobelEnergy),
                        LifeAtNobelEnergyId = entity.Id
                    };

                    await _unitOfWork.LifeAtNobelEnergyPdf.CreateAsync(Pdfs_RU);
                    await _unitOfWork.CommitAsync();
                }

                //upload EN language related pdf files
                foreach (var pdf in model.Pdfs_EN)
                {
                    var Pdfs_EN = new LifeAtNobelEnergyPdf
                    {
                        Language = Core.Constants.Language.EN,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.LifeAtNobelEnergy),
                        LifeAtNobelEnergyId = entity.Id
                    };

                    await _unitOfWork.LifeAtNobelEnergyPdf.CreateAsync(Pdfs_EN);
                    await _unitOfWork.CommitAsync();
                }

                //upload TR language related pdf files
                foreach (var pdf in model.Pdfs_TR)
                {
                    var Pdfs_TR = new LifeAtNobelEnergyPdf
                    {
                        Language = Core.Constants.Language.TR,
                        PdfFileName = await _fileService.UploadFileAsync(pdf, FilePath.LifeAtNobelEnergy),
                        LifeAtNobelEnergyId = entity.Id
                    };

                    await _unitOfWork.LifeAtNobelEnergyPdf.CreateAsync(Pdfs_TR);
                    await _unitOfWork.CommitAsync();
                }

                TempData["message"] = $"Life At Nobel Energy <{entity.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            model.LifeAtNobelEnergyPdf_AZ = await _unitOfWork.LifeAtNobelEnergyPdf.GetAllByLifeAtNobelEnergyPdfIdAsync(entity.Id, Core.Constants.Language.AZ);
            model.LifeAtNobelEnergyPdf_RU = await _unitOfWork.LifeAtNobelEnergyPdf.GetAllByLifeAtNobelEnergyPdfIdAsync(entity.Id, Core.Constants.Language.RU);
            model.LifeAtNobelEnergyPdf_EN = await _unitOfWork.LifeAtNobelEnergyPdf.GetAllByLifeAtNobelEnergyPdfIdAsync(entity.Id, Core.Constants.Language.EN);
            model.LifeAtNobelEnergyPdf_TR = await _unitOfWork.LifeAtNobelEnergyPdf.GetAllByLifeAtNobelEnergyPdfIdAsync(entity.Id, Core.Constants.Language.TR);

            return View(model);
        }

        #endregion

        #region Details

        [HttpGet("admin/lifeatnobelenergy/details/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.LifeAtNobelEnergy = true;

            var entity = await _unitOfWork.LifeAtNobelEnergy.GetBySlugAsync(slug);
            if (entity == null) return NotFound();

            var model = new LifeAtNobelEnergyDetailsViewModel
            {
                Title_AZ = entity.Title_AZ,
                Title_RU = entity.Title_RU,
                Title_EN = entity.Title_EN,
                Title_TR = entity.Title_TR,
                Content_AZ = entity.Content_AZ,
                Content_RU = entity.Content_RU,
                Content_EN = entity.Content_EN,
                Content_TR = entity.Content_TR,
                Description_AZ = entity.Description_AZ,
                Description_RU = entity.Description_RU,
                Description_EN = entity.Description_EN,
                Description_TR = entity.Description_TR,
                PhotoPath = _fileService.GetFileUrl(entity.PhotoName, FilePath.LifeAtNobelEnergy),
                ActionDate = entity.ActionDate
            };

            return View(model);
        }

        #endregion
    }
}
