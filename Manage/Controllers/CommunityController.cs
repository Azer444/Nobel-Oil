using Core;
using Core.Models;
using Manage.MiddlewareFilters;
using Manage.ViewModels.Community;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class CommunityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommunityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{culture}/[controller]")]
        public async Task<IActionResult> Component(int page = 1)
        {
            var communityComponent = await _unitOfWork.CommunityComponent.GetAsync();
            if (communityComponent == null) return NotFound();

            const int pageSize = 6;

            var news = (await _unitOfWork.News.GetAllForCommunityAsync()).OrderByDescending(n => n.ActionDate).ToList();

            var pager = new Pager(news.Count, page, pageSize);
            news = news.Skip(pager.RecSkip).Take(pager.PageSize).ToList();

            var model = new ComponentViewModel
            {
                CommunityComponent = await _unitOfWork.CommunityComponent.PrepareSplitedContentsAsync(communityComponent),
                CommunityNews = news,
                Pager = pager
            };

            return View(model);
        }
    }
}
