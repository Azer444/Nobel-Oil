using Core;
using Core.Constants;
using Manage.MiddlewareFilters;
using Manage.ViewModels.BoardDirector;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class BoardDirectorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BoardDirectorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var boardDirectors = await _unitOfWork.Managers.GetAllByType(ManagerType.Board);
            if (boardDirectors == null) return NotFound();

            var boardDirectorComponent = await _unitOfWork.BoardDirectorComponent.GetAsync();
            if (boardDirectorComponent == null) return NotFound();

            var model = new IndexViewModel()
            {
                BoardDirectors = boardDirectors,
                BoardDirectorComponent = boardDirectorComponent
            };

            return View(model);
        }
    }
}
