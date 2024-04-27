using Core.Models;
using System.Collections.Generic;

namespace Manage.Areas.Admin.Models.NotificationManagement.Notification
{
    public class EthicsAndCompilanceApplyListViewModel
    {
        public EthicsAndCompilanceApplyListViewModel()
        {
            EthicsAndCompilanceApplies = new List<EthicsAndCompilanceApply>();
        }

        public List<EthicsAndCompilanceApply> EthicsAndCompilanceApplies { get; set; }

    }
}
