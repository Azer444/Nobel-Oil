using Core;
using Manage.MiddlewareFilters;
using Manage.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _unitOfWork.Projects.GetAllAsync();
            if (projects == null) return NotFound();

            var model = new IndexViewModel()
            {
                Projects = projects,
            };

            return View(model);
        }

        [HttpGet("{culture}/project/{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            var project = await _unitOfWork.Projects.GetBySlugAsync(slug);
            if (project == null) return NotFound();

            var model = new DetailViewModel()
            {
                Project = project,
            };

            return View("Detail", model);
        }
    }
}
