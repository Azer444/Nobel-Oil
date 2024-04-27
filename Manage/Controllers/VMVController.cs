using Core;
using Manage.MiddlewareFilters;
using Manage.ViewModels.VMV;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class VMVController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VMVController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var vmvComponent = await _unitOfWork.VMVComponent.GetAsync();
            if (vmvComponent == null) return NotFound();

            var model = new IndexViewModel()
            {
                VMVComponent = await _unitOfWork.VMVComponent.PrepareSplitedContentsAsync(vmvComponent)
            };

            return View(model);
        }
    }
}
