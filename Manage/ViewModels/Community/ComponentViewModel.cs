using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.Community
{
    public class ComponentViewModel
    {
        public CommunityComponent CommunityComponent { get; set; }

        public List<News> CommunityNews { get; set; }

        public Pager Pager { get; set; }
    }
}
