using Core.Models;
using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.PageManagement.Environment
{
    public class EnvironmentDetailsSubComponentViewModel
    {
        public string Title_AZ { get; set; }

        public string Title_RU { get; set; }

        public string Title_EN { get; set; }

        public string Title_TR { get; set; }

        public string Slug { get; set; }

        public string Content_AZ { get; set; }

        public string Content_RU { get; set; }

        public string Content_EN { get; set; }

        public string Content_TR { get; set; }

        public string PhotoPath_Environment { get; set; }

        public string ContentEnvironment_AZ { get; set; }

        public string ContentEnvironment_RU { get; set; }

        public string ContentEnvironment_EN { get; set; }

        public string ContentEnvironment_TR { get; set; }

        public bool isBanner { get; set; }

        public ICollection<EnvironmentSubComponentPhoto> EnvironmentSubComponentPhotos { get; set; }
    }
}
