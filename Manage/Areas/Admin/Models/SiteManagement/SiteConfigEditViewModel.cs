using Microsoft.AspNetCore.Http;

namespace Manage.Areas.Admin.Models.SiteManagement
{
    public class SiteConfigEditViewModel
    {
        public int Id { get; set; }

        public IFormFile FirstLogo { get; set; }

        public string FirstLogoName { get; set; }

        public string FacebookLink { get; set; }

        public string LinkedinLink { get; set; }

        public string TwitterLink { get; set; }

        public string YoutubeLink { get; set; }

        public string Contact_AZ { get; set; }

        public string Contact_RU { get; set; }

        public string Contact_EN { get; set; }

        public string Contact_TR { get; set; }

        public string Copyright_AZ { get; set; }

        public string Copyright_RU { get; set; }

        public string Copyright_EN { get; set; }

        public string Copyright_TR { get; set; }
    }
}
