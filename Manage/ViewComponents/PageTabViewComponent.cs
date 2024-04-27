using Core;
using Core.Constants;
using Manage.ViewModels.ViewComponent;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.ViewComponents
{
    public class PageTabViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public PageTabViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync(Page page, string currentPage)
        {
            var model = new PageTabViewModel
            {
                PageTabComponents = await _unitOfWork.PageTabComponents.GetAllByIsActiveAsync(),
                Page = page,
                CurrentPage = currentPage
            };

            return View("PageTab", model);
        }
    }
}
