﻿using Core;
using Core.Constants;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.PageManagement.Search;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.PageManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public SearchController(
            IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.PageManagement = true;
            ViewBag.Search = true;

            var model = new SearchIndexViewModel
            {
                PageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Search)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineMainPhoto()
        {
            ViewBag.PageManagement = true;
            ViewBag.Search = true;

            var pageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Search);
            if (pageMainPhoto != null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DefineMainPhoto(SearchDefineMainPhotoViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Search = true;

            if (ModelState.IsValid)
            {
                var pageMainPhoto = new PageMainPhoto
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Page = Page.Search,
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.PageMainPhoto)
                };

                await _unitOfWork.PageMainPhoto.CreateAsync(pageMainPhoto);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Page Main Photo <{pageMainPhoto.PhotoName}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditMainPhoto()
        {
            ViewBag.PageManagement = true;
            ViewBag.Search = true;

            var pageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Search);
            if (pageMainPhoto == null) return NotFound();

            var model = new SearchEditMainPhotoViewModel
            {
                Id = pageMainPhoto.Id,
                Title_AZ = pageMainPhoto.Title_AZ,
                Title_RU = pageMainPhoto.Title_RU,
                Title_EN = pageMainPhoto.Title_EN,
                Title_TR = pageMainPhoto.Title_TR,
                PhotoPath = _fileService.GetFileUrl(pageMainPhoto.PhotoName, FilePath.PageMainPhoto),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditMainPhoto(SearchEditMainPhotoViewModel model)
        {
            ViewBag.PageManagement = true;
            ViewBag.Search = true;

            var pageMainPhoto = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Search);
            if (pageMainPhoto == null) return NotFound();

            if (ModelState.IsValid)
            {
                pageMainPhoto.Title_AZ = model.Title_AZ;
                pageMainPhoto.Title_RU = model.Title_RU;
                pageMainPhoto.Title_EN = model.Title_EN;
                pageMainPhoto.Title_TR = model.Title_TR;

                if (model.Photo != null)
                {
                    _fileService.Delete(pageMainPhoto.PhotoName, FilePath.PageMainPhoto);
                    pageMainPhoto.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.PageMainPhoto);
                }

                await _unitOfWork.PageMainPhoto.EditAsync(pageMainPhoto);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Page Main Photo <{pageMainPhoto.PhotoName}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(model);
        }
    }
}
