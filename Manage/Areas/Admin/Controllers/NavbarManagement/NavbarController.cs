using Core;
using Core.Models;
using Manage.Areas.Admin.Models.NavbarManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class NavbarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public NavbarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            var model = new NavbarIndexViewModel
            {
                NavTitleComponents = await _unitOfWork.NavTitleComponent.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult AddTitleComponent()
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTitleComponent(NavTitleComponent navTitleComponent)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            if (ModelState.IsValid)
            {
                await _unitOfWork.NavTitleComponent.CreateAsync(navTitleComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Nav title component <{navTitleComponent.Title_EN}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(navTitleComponent);
        }

        [HttpGet]
        public async Task<IActionResult> EditTitleComponent(int id)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            var navTitleComponent = await _unitOfWork.NavTitleComponent.GetAsync(id);
            if (navTitleComponent == null) return NotFound();

            return View(navTitleComponent);
        }

        [HttpPost]
        public async Task<IActionResult> EditTitleComponent(NavTitleComponent navTitleComponent)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            if (ModelState.IsValid)
            {
                await _unitOfWork.NavTitleComponent.EditAsync(navTitleComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Nav title component <{navTitleComponent.Title_EN}> successfully edited.";
                TempData["message_type"] = "success";

                return RedirectToAction("index");
            }

            return View(navTitleComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Components(int? id)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            var navTitleComponent = await _unitOfWork.NavTitleComponent.GetAsync(id);
            if (navTitleComponent == null) return NotFound();

            return View(navTitleComponent);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTitleComponent(int? id)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            var navTitleComponent = await _unitOfWork.NavTitleComponent.GetAsync(id);
            if (navTitleComponent == null) return NotFound();

            await _unitOfWork.NavTitleComponent.DeleteAsync(navTitleComponent);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Nav title component <{navTitleComponent.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("index");
        }


        [HttpGet]
        public async Task<IActionResult> AddComponent(int id)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            var navTitleComponent = await _unitOfWork.NavTitleComponent.GetAsync(id);
            if (navTitleComponent == null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComponent(NavComponent navComponent)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            if (ModelState.IsValid)
            {
                await _unitOfWork.NavComponent.CreateAsync(navComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Nav component <{navComponent.Title_EN}> successfully created.";
                TempData["message_type"] = "success";

                return RedirectToAction("components", "navbar", new { id = navComponent.NavTitleComponentId });
            }

            return View(navComponent);
        }

        [HttpGet]
        public async Task<IActionResult> EditComponent(int id)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            var navComponent = await _unitOfWork.NavComponent.GetAsync(id);
            if (navComponent == null) return NotFound();

            return View(navComponent);
        }

        [HttpPost]
        public async Task<IActionResult> EditComponent(NavComponent navComponent)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            if (ModelState.IsValid)
            {
                await _unitOfWork.NavComponent.EditAsync(navComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Nav component <{navComponent.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";

                return RedirectToAction("components", "navbar", new { id = navComponent.NavTitleComponentId });
            }

            return View(navComponent);
        }

        [HttpGet]
        public async Task<IActionResult> SubComponents(int id)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            var navComponent = await _unitOfWork.NavComponent.GetAsync(id);
            if (navComponent == null) return NotFound();

            return View(navComponent);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            var navComponent = await _unitOfWork.NavComponent.GetAsync(id);
            if (navComponent == null) return NotFound();

            await _unitOfWork.NavComponent.DeleteAsync(navComponent);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Nav component <{navComponent.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";


            return RedirectToAction("components", "navbar", new { id = navComponent.NavTitleComponentId });
        }

        [HttpGet]
        public async Task<IActionResult> AddSubComponent(int id)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            var navComponent = await _unitOfWork.NavComponent.GetAsync(id);
            if (navComponent == null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubComponent(NavSubComponent navSubComponent)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            if (ModelState.IsValid)
            {
                await _unitOfWork.NavSubComponent.CreateAsync(navSubComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Nav sub-component <{navSubComponent.Title_EN}> successfully created.";
                TempData["message_type"] = "success";


                return RedirectToAction("subcomponents", "navbar", new { id = navSubComponent.NavComponentId });
            }

            return View(navSubComponent);
        }

        [HttpGet]
        public async Task<IActionResult> EditSubComponent(int id)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            var navSubComponent = await _unitOfWork.NavSubComponent.GetAsync(id);
            if (navSubComponent == null) return NotFound();

            return View(navSubComponent);

        }

        [HttpPost]
        public async Task<IActionResult> EditSubComponent(NavSubComponent navSubComponent)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            if (ModelState.IsValid)
            {
                await _unitOfWork.NavSubComponent.EditAsync(navSubComponent);
                await _unitOfWork.CommitAsync();

                TempData["message"] = $"Nav sub-component <{navSubComponent.Title_EN}> successfully updated.";
                TempData["message_type"] = "success";


                return RedirectToAction("subcomponents", "navbar", new { id = navSubComponent.NavComponentId });
            }

            return View(navSubComponent);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSubComponent(int id)
        {
            ViewBag.NavbarManagement = true;
            ViewBag.Navbar = true;

            var navSubComponent = await _unitOfWork.NavSubComponent.GetAsync(id);
            if (navSubComponent == null) return NotFound();

            await _unitOfWork.NavSubComponent.DeleteAsync(navSubComponent);
            await _unitOfWork.CommitAsync();

            TempData["message"] = $"Nav sub-component <{navSubComponent.Title_EN}> successfully deleted.";
            TempData["message_type"] = "success";

            return RedirectToAction("subcomponents", "navbar", new { id = navSubComponent.NavComponentId });
        }
    }
}
