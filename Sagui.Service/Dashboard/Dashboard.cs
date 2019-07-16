using Sagui.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Service.Dashboard
{
   public class DashboardService: IDashboardService
    {

        public Model.ViewModel.Dashboard Obter(DateTime Inicio, DateTime Fim)
        {
            using (var DashboardBusiness = new Business.Dashboard.DashboardBusiness())
            {
                var _return = DashboardBusiness.Obter(Inicio, Fim);
                DashboardBusiness.Dispose();
                return _return;
            }
        }

    }
}
