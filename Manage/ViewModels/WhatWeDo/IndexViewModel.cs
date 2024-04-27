using Core.Models;
using System.Collections.Generic;

namespace Manage.ViewModels.WhatWeDo
{
    public class IndexViewModel
    {

        public List<Core.Models.OurBusiness> OurBusinesses { get; set; }
        public OurProjectComponent OurProjectComponent { get; set; }
        public List<Flatpage> Flatpages { get; set; }
        public List<Core.Models.DynamicPage> DynamicPages { get; set; }
    }
}
