using Core.Models;
using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.PageManagement.Safety
{
    public class SafetyIndexViewModel
    {
        public SafetyComponent SafetyComponent { get; set; }

        public List<SafetySubComponent> SafetySubComponents { get; set; }
    }
}
