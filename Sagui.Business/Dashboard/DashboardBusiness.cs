using Sagui.Business.Base;
using Sagui.Data.Lookup;

using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Business.Dashboard
{
    public class DashboardBusiness : BusinessBase
    {

        public Model.ViewModel.Dashboard Obter()
        {
            DashboardLookup dashboardLookup = new DashboardLookup();
            var dashboard = dashboardLookup.Obter();

            return dashboard;
        }

    }
}
