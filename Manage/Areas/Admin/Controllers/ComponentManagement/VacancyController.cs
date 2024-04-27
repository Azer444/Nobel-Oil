using Core;
using Core.Models;
using Manage.Areas.Admin.Models.ComponentManagement.Vacancy;
using Manage.Tools.FileHandler.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.ComponentManagement
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class VacancyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public VacancyController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Vacancy = true;

            var model = new VacancyListViewModel
            {
                Vacancies = await _unitOfWork.Vacancy.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Vacancy = true;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VacancyCreateViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Vacancy = true;

            if (ModelState.IsValid)
            {
                var vacancy = new Vacancy
                {
                    Title_AZ = model.Title_AZ,
                    Title_RU = model.Title_RU,
                    Title_EN = model.Title_EN,
                    Title_TR = model.Title_TR,
                    Content_AZ = model.Content_AZ,
                    Content_RU = model.Content_RU,
                    Content_EN = model.Content_EN,
                    Content_TR = model.Content_TR,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                };

                await _unitOfWork.Vacancy.CreateAsync(vacancy);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Vacancy <{vacancy.Title_EN}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Vacancy = true;

            var vacancy = await _unitOfWork.Vacancy.GetAsync(id);
            if (vacancy == null) return NotFound();

            var model = new VacancyEditViewModel
            {
                Id = vacancy.Id,
                Title_AZ = vacancy.Title_AZ,
                Title_RU = vacancy.Title_RU,
                Title_EN = vacancy.Title_EN,
                Title_TR = vacancy.Title_TR,
                Content_AZ = vacancy.Content_AZ,
                Content_RU = vacancy.Content_RU,
                Content_EN = vacancy.Content_EN,
                Content_TR = vacancy.Content_TR,
                StartDate = vacancy.StartDate,
                EndDate = vacancy.EndDate
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VacancyEditViewModel model)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Vacancy = true;

            var vacancy = await _unitOfWork.Vacancy.GetAsync(model.Id);
            if (vacancy == null) return NotFound();

            if (ModelState.IsValid)
            {
                vacancy.Title_AZ = model.Title_AZ;
                vacancy.Title_RU = model.Title_RU;
                vacancy.Title_EN = model.Title_EN;
                vacancy.Title_TR = model.Title_TR;
                vacancy.Content_AZ = model.Content_AZ;
                vacancy.Content_RU = model.Content_RU;
                vacancy.Content_EN = model.Content_EN;
                vacancy.Content_TR = model.Content_TR;
                vacancy.StartDate = model.StartDate;
                vacancy.EndDate = model.EndDate;

                await _unitOfWork.Vacancy.EditAsync(vacancy);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Vacancy <{vacancy.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("list");
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Vacancy = true;

            var vacancy = await _unitOfWork.Vacancy.GetAsync(id);
            if (vacancy == null) return NotFound();

            var model = new VacancyDetailsViewModel
            {
                Title_AZ = vacancy.Title_AZ,
                Title_RU = vacancy.Title_RU,
                Title_EN = vacancy.Title_EN,
                Title_TR = vacancy.Title_TR,
                Content_AZ = vacancy.Content_AZ,
                Content_RU = vacancy.Content_RU,
                Content_EN = vacancy.Content_EN,
                Content_TR = vacancy.Content_TR,
                StartDate = vacancy.StartDate,
                EndDate = vacancy.EndDate
            };

            return View("Details", model);
        }


        public async Task<IActionResult> Applies(int id)
        {
            var vacancy = await _unitOfWork.Vacancy.GetAsync(id);
            if (vacancy == null) return NotFound();

            var model = new VacancyAppliesViewModel
            {
                Vacancy = vacancy,
                VacancyApplies = await _unitOfWork.VacancyApplies.GetAllByVacancyIdAsync(vacancy.Id)
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.ComponentManagement = true;
            ViewBag.Vacancy = true;

            var vacancy = await _unitOfWork.Vacancy.GetAsync(id);
            if (vacancy == null) return NotFound();

            await _unitOfWork.Vacancy.DeleteAsync(vacancy);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Vacancy <{vacancy.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("list");
        }
    }
}
