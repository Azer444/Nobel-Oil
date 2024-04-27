using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Area.Admin.ViewComponents
{
    public class BooleanResultViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(bool result)
        {

            return View("BooleanResult", result);
        }
    }
}
