using Core.Models;
using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.PageManagement.Gallery
{
    public class GalleryIndexViewModel
    {
        public List<ImageGalleryComponent> ImageGalleryComponents { get; set; }

        public List<VideoGalleryComponent> VideoGalleryComponents { get; set; }
    }
}
