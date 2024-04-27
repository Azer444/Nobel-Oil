
using Core.Constants;

namespace Manage.ViewModels.DynamicPage
{
    public class DynamicPageViewModel
    {
        public int Id { get; set; }
        public string BannerTitle { get; set; }
        public string BannerPhotoName { get; set; }
        public Page Page { get; set; }
    }
}
