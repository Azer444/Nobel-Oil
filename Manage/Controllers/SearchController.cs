using Core;
using Core.Models.Search;
using Manage.MiddlewareFilters;
using Manage.ViewModels.Search;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    [Route("{culture}/[controller]")]
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Search search)
        {
            search.Results = await _unitOfWork.Search.GetResultsAsync(search.Query);

            var model = new SearchViewModel
            {
                Search = search,
            };

            return View(model);
        }
    }
}
