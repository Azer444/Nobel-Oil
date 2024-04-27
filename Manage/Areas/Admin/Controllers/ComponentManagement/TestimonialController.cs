using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.ComponentManagement.Testimonial;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.ComponentManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public TestimonialController(IUnitOfWork unitOfWork,
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
            ViewBag.Testimonial = true;

            var model = new TestimonialListViewModel
            {
                Testimonials = (await _unitOfWork.Testimonials.GetAllAsync()).OrderByDescending(n => n.Id).ToList()
            };

            return View(model);
        }

        #endregion

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Testimonial = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TestimonialCreateViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Testimonial = true;

            if (ModelState.IsValid)
            {
                var testimonial = new Testimonial
                {
                    Writer_AZ = model.Writer_AZ,
                    Writer_RU = model.Writer_RU,
                    Writer_EN = model.Writer_EN,
                    Writer_TR = model.Writer_TR,
                    WriterInfo_AZ = model.WriterInfo_AZ,
                    WriterInfo_RU = model.WriterInfo_RU,
                    WriterInfo_EN = model.WriterInfo_EN,
                    WriterInfo_TR = model.WriterInfo_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Testimonial)
                };

                await _unitOfWork.Testimonials.CreateAsync(testimonial);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Testimonial <{testimonial.Writer_EN}> successfully created.";
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
            ViewBag.Testimonial = true;

            var testimonial = await _unitOfWork.Testimonials.GetAsync(id);
            if (testimonial == null) return NotFound();

            var model = new TestimonialEditViewModel
            {
                Id = testimonial.Id,
                Writer_AZ = testimonial.Writer_AZ,
                Writer_RU = testimonial.Writer_RU,
                Writer_EN = testimonial.Writer_EN,
                Writer_TR = testimonial.Writer_TR,
                WriterInfo_AZ = testimonial.WriterInfo_AZ,
                WriterInfo_RU = testimonial.WriterInfo_RU,
                WriterInfo_EN = testimonial.WriterInfo_EN,
                WriterInfo_TR = testimonial.WriterInfo_TR,
                Content_AZ = testimonial.Content_AZ,
                Content_RU = testimonial.Content_RU,
                Content_EN = testimonial.Content_EN,
                Content_TR = testimonial.Content_TR,
                PhotoPath = _fileService.GetFileUrl(testimonial.PhotoName, FilePath.Testimonial),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TestimonialEditViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Testimonial = true;

            var testimonial = await _unitOfWork.Testimonials.GetAsync(model.Id);
            if (testimonial == null) return NotFound();

            if (ModelState.IsValid)
            {
                testimonial.Writer_AZ = model.Writer_AZ;
                testimonial.Writer_RU = model.Writer_RU;
                testimonial.Writer_EN = model.Writer_EN;
                testimonial.Writer_TR = model.Writer_TR;
                testimonial.WriterInfo_AZ = model.WriterInfo_AZ;
                testimonial.WriterInfo_RU = model.WriterInfo_RU;
                testimonial.WriterInfo_EN = model.WriterInfo_EN;
                testimonial.WriterInfo_TR = model.WriterInfo_TR;
                testimonial.Content_AZ = model.Content_AZ;
                testimonial.Content_RU = model.Content_RU;
                testimonial.Content_EN = model.Content_EN;
                testimonial.Content_TR = model.Content_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(testimonial.PhotoName, FilePath.Testimonial);
                    testimonial.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Testimonial);
                }

                await _unitOfWork.Testimonials.EditAsync(testimonial);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Testimonial <{testimonial.Writer_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        #endregion

        #region Details
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Testimonial = true;

            var testimonial = await _unitOfWork.Testimonials.GetAsync(id);
            if (testimonial == null) return NotFound();

            var model = new TestimonialDetailsViewModel
            {
                Writer_AZ = testimonial.Writer_AZ,
                Writer_RU = testimonial.Writer_RU,
                Writer_EN = testimonial.Writer_EN,
                Writer_TR = testimonial.Writer_TR,
                WriterInfo_AZ = testimonial.WriterInfo_AZ,
                WriterInfo_RU = testimonial.WriterInfo_RU,
                WriterInfo_EN = testimonial.WriterInfo_EN,
                WriterInfo_TR = testimonial.WriterInfo_TR,
                Content_AZ = testimonial.Content_AZ,
                Content_RU = testimonial.Content_RU,
                Content_EN = testimonial.Content_EN,
                Content_TR = testimonial.Content_TR,
                PhotoPath = _fileService.GetFileUrl(testimonial.PhotoName, FilePath.Testimonial),
            };

            return View("Details", model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Testimonial = true;

            var testimonial = await _unitOfWork.Testimonials.GetAsync(id);
            if (testimonial == null) return NotFound();

            _fileService.Delete(testimonial.PhotoName, FilePath.Testimonial);

            await _unitOfWork.Testimonials.DeleteAsync(testimonial);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Testimonial <{testimonial.Writer_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list");
        }

        #endregion
    }
}
