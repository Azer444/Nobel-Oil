using Core;
using Manage.ViewModels.EthicsAndCompilance;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.ViewComponents
{
    public class ECSubmitFormViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public ECSubmitFormViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new ECSubmitFormViewComponentViewModel();
            return View("ECSubmitForm", model);
        }
    }
}
