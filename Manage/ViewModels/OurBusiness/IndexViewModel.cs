using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.OurBusiness
{
    public class IndexViewModel
    {
        public List<Company> Companies { get; set; }
        public List<CompanyService> CompanyServices { get; set; }
    }
}
