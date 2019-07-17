using Sagui.Business.Base;
using Sagui.Data.Lookup;

using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Business.Dashboard
{
    public class DashboardBusiness : BusinessBase
    {

        public Model.ViewModel.Dashboard Obter(DateTime Inicio, DateTime Fim)
        {
            DashboardLookup dashboardLookup = new DashboardLookup();
           
            Model.ViewModel.Dashboard db = new Model.ViewModel.Dashboard();

            db.Faturamento = dashboardLookup.Faturamento(Inicio, Fim);
            db.GuiasGlosadas = dashboardLookup.GuiasGlosadas(Inicio, Fim);
            db.PacienteAtendidos = dashboardLookup.PacientesAtendidos(Inicio, Fim);
            db.Grafico = dashboardLookup.ListGrafico(Inicio, Fim);

            return db;
        }

    }
}
