using Core;
using Manage.ViewModels.Career;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.ViewComponents
{
    public class VacancyViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public VacancyViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new VacancyViewComponentViewModel
            {
                Vacancies = await _unitOfWork.Vacancy.GetAllValidVacancies()
            };

            return View("Vacancy", model);
        }
    }
}
