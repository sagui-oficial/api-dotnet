using Sagui.Data.Base;
using Sagui.Data.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.Procedimento
{
    public class ProcedimentoLookup: DBParams
    {
        public List<Model.Procedimentos> ListProcedimento()
        {
            List<Model.Procedimentos> ListProcedimento = new List<Model.Procedimentos>();

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListProcedimento, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();
                                       
                    while (reader.Read())
                    {
                        Model.Procedimentos _Procedimento = Parser.ParseProcedimento(reader);
                        ListProcedimento.Add(_Procedimento);
                    }
                }
                catch (Exception e)
                {
                    ListProcedimento = null;
                }
            }

            return ListProcedimento;
        }

        public Model.Procedimentos ObterProcedimento(Model.Procedimentos procedimentos)
        {
            if (procedimentos == null)
                throw new ArgumentNullException(nameof(procedimentos));

            DbParams.Add(nameof(procedimentos.PublicID), procedimentos.PublicID);
            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ObterProcedimento, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        procedimentos = Parser.ParseProcedimento(reader);
                    }
                }
                catch (Exception e)
                {
                    procedimentos = null;
                }
            }

            return procedimentos;
        }

        public List<Model.Procedimentos> ListarProcedimentoGTO(int idGTO)
        {
            List<Model.Procedimentos> ListProcedimento = new List<Model.Procedimentos>();

            DbParams.Clear();
            DbParams.Add("idGTO", idGTO);

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListarProcedimentoGTO, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Procedimentos _Procedimento = Parser.ParseProcedimento(reader, true);
                        ListProcedimento.Add(_Procedimento);
                    }
                }
                catch (Exception e)
                {
                    ListProcedimento = null;
                }
            }

            return ListProcedimento;
        }
        
        public List<Model.Procedimentos> ListarProcedimento_PlanoOperadora(Model.PlanoOperadora planoOperadora)
        {
            List<Model.Procedimentos> ListProcedimento = new List<Model.Procedimentos>();

            DbParams.Clear();
            DbParams.Add(nameof(planoOperadora.PublicID), planoOperadora.PublicID);

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListarProcedimentoPlanoOperadora, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                       
                        Model.Procedimentos _Procedimento = Parser.ParseProcedimento(reader, true);
                        ListProcedimento.Add(_Procedimento);
                    }
                }
                catch (Exception e)
                {
                    ListProcedimento = null;
                }
            }

            return ListProcedimento;
        }
    }
}
