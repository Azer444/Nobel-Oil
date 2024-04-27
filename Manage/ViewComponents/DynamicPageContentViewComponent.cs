using Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.ViewComponents
{
    public class DynamicPageContentViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public DynamicPageContentViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var dynamicPageContents = await _unitOfWork.DynamicPageContents.GetAllByIdAsync(id);

            return View("DynamicPageContent", dynamicPageContents);
        }
    }
}
