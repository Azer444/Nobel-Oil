using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Areas.Admin.Controllers.Home
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HomeManagement = true;
            ViewBag.Home = true;

            return View("Index");
        }
    }
}
