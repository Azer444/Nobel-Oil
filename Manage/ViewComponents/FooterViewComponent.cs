using Core;
using Manage.ViewModels.FooterViewComponent;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public FooterViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new FooterViewComponentViewModel
            {
                NavTitleComponents = await _unitOfWork.NavTitleComponent.GetAllForHeaderByIsActiveAsync(),
                SiteConfig = await _unitOfWork.SiteConfig.GetAsync()
            };

            return View("Footer", model);
        }
    }
}
