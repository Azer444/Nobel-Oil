using Core.Models;
using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.PageManagement.Career
{
    public class CareerIndexViewModel
    {
        public PageMainPhoto PageMainPhoto { get; set; }

        public List<CareerComponent> CareerComponents { get; set; }

        public List<CareerTipComponent> CareerTipComponents { get; set; }
    }
}
