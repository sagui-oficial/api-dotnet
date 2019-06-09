using Sagui.Data.Base;
using Sagui.Data.Helper;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Lookup.GTO
{
    public class GTOLookup : DBParams
    {
        //todo: refazer a query para trazer Operadora e Paciente
        //todo: refazer a query para trazer Procedimento da GTO e Arquivo da GTO

        public List<Model.GTO> ListGTO()
        {
            List<Model.GTO> ListGTO = new List<Model.GTO>();

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListGTO))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.GTO _GTO = Parser.ParseGTO(reader);
                        ListGTO.Add(_GTO);
                    }
                }
                catch (Exception e)
                {
                    ListGTO = null;
                }
             
            }
            return ListGTO;
        }

        public Model.GTO ObterGTO(Model.GTO GTO)
        {
            if (GTO == null)
                throw new ArgumentNullException(nameof(GTO));
            DbParams.Add(nameof(GTO.PublicID), GTO.PublicID);

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ObterGTObyPublicID, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.GTO _GTO = Parser.ParseGTO(reader);
                        GTO = _GTO;
                    }
                }
                catch (Exception e)
                {
                    GTO = null;
                }
                
            }

            return GTO;
        }

        public List<Model.GTO> ListarGTOLote(int idLote)
        {
            List<Model.GTO> ListGTO = new List<Model.GTO>();

            DbParams.Clear();
            DbParams.Add("idLote", idLote);

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListarGTOLote, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.GTO _GTO = Parser.ParseGTO(reader);
                        ListGTO.Add(_GTO);
                    }
                }
                catch (Exception e)
                {
                    ListGTO = null;
                }
            }

            return ListGTO;
        }
    }
}
