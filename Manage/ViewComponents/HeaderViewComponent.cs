using Core;
using Manage.ViewModels.HeaderViewComponent;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public HeaderViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new HeaderViewComponentViewModel
            {
                NavTitleComponents = await _unitOfWork.NavTitleComponent.GetAllForHeaderByIsActiveAsync(),
                SiteConfig = await _unitOfWork.SiteConfig.GetAsync()
            };

            return View("Header", model);
        }
    }
}
