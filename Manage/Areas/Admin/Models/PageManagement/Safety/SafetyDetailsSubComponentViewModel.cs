using Core.Models;
using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.PageManagement.Safety
{
    public class SafetyDetailsSubComponentViewModel
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

        public string PhotoPath_Safety { get; set; }

        public string ContentSafety_AZ { get; set; }

        public string ContentSafety_RU { get; set; }

        public string ContentSafety_EN { get; set; }

        public string ContentSafety_TR { get; set; }

        public bool isBanner { get; set; }

        public ICollection<SafetySubComponentPhoto> SafetySubComponentPhotos { get; set; }
    }
}
