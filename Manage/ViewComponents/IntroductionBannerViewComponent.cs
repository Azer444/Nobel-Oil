using Core;
using Core.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.ViewComponents
{
    public class IntroductionBannerViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public IntroductionBannerViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync(Page page)
        {
            var model = await _unitOfWork.PageMainPhoto.GetByPageAsync(page);
            return View("IntroductionBanner", model);
        }
    }
}
