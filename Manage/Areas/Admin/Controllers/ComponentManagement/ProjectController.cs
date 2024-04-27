using Core;
using Core.Constants.File;
using Core.Models;
using Manage.Areas.Admin.Models.ComponentManagement.Project;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.ComponentManagement
{
    [Authorize(Roles = "Staff")]
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public ProjectController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        #region List

        [HttpGet("admin/project/list")]
        public async Task<IActionResult> List()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Project = true;

            var model = new ProjectListViewModel
            {
                Projects = (await _unitOfWork.Projects.GetAllAsync()).OrderByDescending(n => n.Id).ToList()
            };

            return View(model);
        }

        #endregion

        #region Create

        [HttpGet("admin/project/create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Project = true;

            return View();
        }

        [HttpPost("admin/project/create")]
        public async Task<IActionResult> Create(ProjectCreateViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Project = true;

            if (ModelState.IsValid)
            {
                var project = new Project
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Description_AZ = model.Description_AZ,
                    Description_RU = model.Description_RU,
                    Description_EN = model.Description_EN,
                    Description_TR = model.Description_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    ShowOnHome = model.ShowOnHome,
                    MainPhotoName = await _fileService.UploadFileAsync(model.MainPhoto, FilePath.Project),
                    PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Project)
                };

                await _unitOfWork.Projects.CreateAsync(project);
                await _unitOfWork.CommitAsync();

                project.Slug = _unitOfWork.Projects.GenerateSlug(project.Title_EN, project);

                await _unitOfWork.Projects.EditAsync(project);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Project <{project.Title_EN}> successfully created.";
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
            ViewBag.Project = true;

            var project = await _unitOfWork.Projects.GetAsync(id);
            if (project == null) return NotFound();

            var model = new ProjectEditViewModel
            {
                Id = project.Id,
                Title_AZ = project.Title_AZ,
                Title_RU = project.Title_RU,
                Title_EN = project.Title_EN,
                Title_TR = project.Title_TR,
                Description_AZ = project.Description_AZ,
                Description_RU = project.Description_RU,
                Description_EN = project.Description_EN,
                Description_TR = project.Description_TR,
                Content_AZ = project.Content_AZ,
                Content_RU = project.Content_RU,
                Content_EN = project.Content_EN,
                Content_TR = project.Content_TR,
                ShowOnHome = project.ShowOnHome,
                Slug = project.Slug,
                MainPhotoPath = _fileService.GetFileUrl(project.MainPhotoName, FilePath.Project),
                PhotoPath = _fileService.GetFileUrl(project.PhotoName, FilePath.Project),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectEditViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Project = true;

            var project = await _unitOfWork.Projects.GetAsync(model.Id);
            if (project == null) return NotFound();

            if (ModelState.IsValid)
            {
                project.Title_AZ = model.Title_AZ;
                project.Title_RU = model.Title_RU;
                project.Title_EN = model.Title_EN;
                project.Title_TR = model.Title_TR;
                project.Description_AZ = model.Description_AZ;
                project.Description_RU = model.Description_RU;
                project.Description_EN = model.Description_EN;
                project.Description_TR = model.Description_TR;
                project.Content_AZ = model.Content_AZ;
                project.Content_RU = model.Content_RU;
                project.Content_EN = model.Content_EN;
                project.Content_TR = model.Content_TR;
                project.ShowOnHome = model.ShowOnHome;
                project.Title_EN = model.Title_EN;
                project.Slug = _unitOfWork.Projects.GenerateSlug(model.Title_EN, project);

                if (model.MainPhoto != null)
                {
                    _fileService.Delete(project.MainPhotoName, FilePath.Project);
                    project.MainPhotoName = await _fileService.UploadFileAsync(model.MainPhoto, FilePath.Project);
                }

                if (model.Photo != null)
                {
                    _fileService.Delete(project.PhotoName, FilePath.Project);
                    project.PhotoName = await _fileService.UploadFileAsync(model.Photo, FilePath.Project);
                }

                await _unitOfWork.Projects.EditAsync(project);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Project <{project.Title_EN}> successfully updated.";
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
            ViewBag.Project = true;

            var project = await _unitOfWork.Projects.GetAsync(id);
            if (project == null) return NotFound();

            var model = new ProjectDetailsViewModel
            {
                Title_AZ = project.Title_AZ,
                Title_RU = project.Title_RU,
                Title_EN = project.Title_EN,
                Title_TR = project.Title_TR,
                Description_AZ = project.Description_AZ,
                Description_RU = project.Description_RU,
                Description_EN = project.Description_EN,
                Description_TR = project.Description_TR,
                Content_AZ = project.Content_AZ,
                Content_RU = project.Content_RU,
                Content_EN = project.Content_EN,
                Content_TR = project.Content_TR,
                ShowOnHome = project.ShowOnHome,
                Slug = project.Slug,
                PhotoPath = _fileService.GetFileUrl(project.PhotoName, FilePath.Project),
                MainPhotoPath = _fileService.GetFileUrl(project.MainPhotoName, FilePath.Project),
            };

            return View("Details", model);
        }

        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Project = true;

            var project = await _unitOfWork.Projects.GetAsync(id);
            if (project == null) return NotFound();

            _fileService.Delete(project.PhotoName, FilePath.Project);

            await _unitOfWork.Projects.DeleteAsync(project);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Project <{project.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list");
        }

        #endregion
    }
}
