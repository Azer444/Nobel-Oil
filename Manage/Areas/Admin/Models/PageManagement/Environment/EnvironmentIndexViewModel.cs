using Core.Models;
using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.PageManagement.Environment
{
    public class EnvironmentIndexViewModel
    {
        public EnvironmentComponent EnvironmentComponent { get; set; }

        public List<EnvironmentSubComponent> EnvironmentSubComponents { get; set; }
    }
}
