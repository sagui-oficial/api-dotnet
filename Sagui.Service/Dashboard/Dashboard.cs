using Sagui.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Service.Dashboard
{
   public class DashboardService: IDashboardService
    {

        public Model.ViewModel.Dashboard Obter()
        {
            using (var DashboardBusiness = new Business.Dashboard.DashboardBusiness())
            {
                var _return = DashboardBusiness.Obter();
                DashboardBusiness.Dispose();
                return _return;
            }
        }

    }
}
