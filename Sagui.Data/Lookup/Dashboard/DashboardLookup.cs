
using Sagui.Data.Base;
using Sagui.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sagui.Data.Lookup
{
    public class DashboardLookup : DBParams
    {

        public Model.ViewModel.Dashboard Obter()
        {
            //if (Lote == null)
            //    throw new ArgumentNullException(nameof(Lote));
            //DbParams.Add(nameof(Lote.PublicID), Lote.PublicID);

            //using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ObterLotebyPublicID, DbParams))
            //{
            //    try
            //    {
            //        var reader = dataInfrastructure.command.ExecuteReader();

            //        while (reader.Read())
            //        {
            //            Lote = Parser.ParseLote(reader, Lote);
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Lote = null;
            //    }
            //}

            Dashboard dashboard = new Dashboard();

            dashboard.Faturamento = new Faturamento();
            dashboard.Faturamento.Previsto = 1000.00;
            dashboard.Faturamento.Realizado = 9500.00;
            dashboard.GuiasGlosadas = new GuiasGlosadas();
            dashboard.GuiasGlosadas.Valor = 500.00;
            dashboard.GuiasGlosadas.Quantidade = 10;
            dashboard.PacienteAtendidos = 6;
            dashboard.Grafico = new List<Grafico>();

            dashboard.Grafico.Add(new Grafico { Operadora = "Dental Par", Total = 8260.9, Glosadas = 490.8 });
            dashboard.Grafico.Add(new Grafico { Operadora = "Prodent", Total = 6900.67, Glosadas = 898.56 });
            dashboard.Grafico.Add(new Grafico { Operadora = "Uniodonto", Total = 9104.55, Glosadas = 90.89 });
            dashboard.Grafico.Add(new Grafico { Operadora = "Unimed", Total = 3409.77, Glosadas = 129.84 });
            dashboard.Grafico.Add(new Grafico { Operadora = "Prevident", Total = 908.51, Glosadas = 10.7 });
            dashboard.Grafico.Add(new Grafico { Operadora = "Interodonto", Total = 4560.09, Glosadas = 200.98 });
            dashboard.Grafico.Add(new Grafico { Operadora = "SulAmérica", Total = 2090.88, Glosadas = 348.21 });
            dashboard.Grafico.Add(new Grafico { Operadora = "Metlife", Total = 1130.9, Glosadas = 330.98 });

            return dashboard;
        }

    }
}