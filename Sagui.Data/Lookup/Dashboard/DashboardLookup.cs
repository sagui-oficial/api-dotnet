
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

        public Model.ViewModel.Faturamento Faturamento(DateTime Inicio, DateTime Fim)
        {
            if (Inicio > Fim)
                throw new ArgumentNullException(nameof(Faturamento));
            DbParams.Clear();
            DbParams.Add("Inicio", Inicio);
            DbParams.Add("Fim", Fim);

            Faturamento faturamento = new Faturamento();


            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.DashboardFaturamento, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Faturamento _faturamento = new Faturamento();
                        _faturamento.Previsto = Convert.ToDouble(reader["previsto"]);
                        _faturamento.Realizado = Convert.ToDouble(reader["realizado"]);
                        faturamento = _faturamento;


                    }
                }
                catch (Exception e)
                {
                    faturamento = null;
                }
            }
                       

            return faturamento;
        }

        public Model.ViewModel.GuiasGlosadas GuiasGlosadas(DateTime Inicio, DateTime Fim)
        {
            if (Inicio > Fim)
                throw new ArgumentNullException(nameof(Faturamento));

            DbParams.Clear();
            DbParams.Add("Inicio", Inicio);
            DbParams.Add("Fim", Fim);

            GuiasGlosadas guiasGlosadas = new GuiasGlosadas();
            

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.DashboardGuiasGlosadas, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        GuiasGlosadas _guiasGlosadas = new GuiasGlosadas();
                        _guiasGlosadas.Quantidade = Convert.ToDouble(reader["quantidade"]);
                        _guiasGlosadas.Valor = Convert.ToDouble(reader["valor"]);
                        guiasGlosadas = _guiasGlosadas;


                    }
                }
                catch (Exception e)
                {
                    guiasGlosadas = null;
                }
            }

           


            return guiasGlosadas;
        }

        public int PacientesAtendidos(DateTime Inicio, DateTime Fim)
        {
            if (Inicio > Fim)
                throw new ArgumentNullException(nameof(Faturamento));

            DbParams.Clear();
            DbParams.Add("Inicio", Inicio);
            DbParams.Add("Fim", Fim);

            int PacientesAtendidos = new int();


            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.DashboardPacienteAtendidos, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        int _pacientesAtendidos = new int();

                        _pacientesAtendidos = Convert.ToInt32(reader["PacientesAtendidos"]);
                        PacientesAtendidos = _pacientesAtendidos;


                    }
                }
                catch (Exception e)
                {
                    PacientesAtendidos = 0;
                }
            }




            return 1;
        }


        public List<Model.ViewModel.Grafico> ListGrafico(DateTime Inicio, DateTime Fim)
        {
            if (Inicio > Fim)
                throw new ArgumentNullException(nameof(Faturamento));
            DbParams.Clear();
            DbParams.Add("Inicio", Inicio);
            DbParams.Add("Fim", Fim);

            List<Model.ViewModel.Grafico> ListGrafico = new List<Model.ViewModel.Grafico>();

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.DashboardGrafico, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        
                        Grafico _grafico = new Grafico();
                        _grafico.Operadora = Convert.ToString(reader["operadora"]);
                        _grafico.Total = Convert.ToDouble(reader["total"]);
                        _grafico.Glosadas = Convert.ToDouble(reader["glosadas"]);
                        ListGrafico.Add(_grafico);
                    }
                }
                catch (Exception e)
                {
                    ListGrafico = null;
                }
            }

            return ListGrafico;
        }

    }
}