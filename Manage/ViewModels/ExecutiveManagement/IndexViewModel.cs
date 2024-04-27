using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.ExecutiveManagement
{
    public class IndexViewModel
    {
        public List<Manager> ExecutiveManagers { get; set; }
        public ExecutiveManagementComponent ExecutiveManagementComponent { get; set; }
    }
}
