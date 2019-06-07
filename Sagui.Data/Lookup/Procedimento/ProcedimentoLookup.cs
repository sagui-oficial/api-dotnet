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
        public List<Model.Procedimentos> ListProcedimento(Model.Procedimentos procedimentos)
        {
            List<Model.Procedimentos> ListProcedimento = new List<Model.Procedimentos>();

            DbParams.Add(nameof(procedimentos.PagingParameter.Status), procedimentos.PagingParameter.Status);

            DbParams.Add("limite", procedimentos.PagingParameter.numeroLinhas);
            DbParams.Add("offset", procedimentos.PagingParameter.offset);

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListProcedimento, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();
                                       
                    while (reader.Read())
                    {
                        Model.Procedimentos _Procedimento = Parser.ParseProcedimento(reader);
                        _Procedimento.PagingParameter = procedimentos.PagingParameter;
                        _Procedimento.PagingParameter.TotalPaginas = Convert.ToInt32(reader["TotalPaginas"]);
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

            DbParams.Add(nameof(procedimentos.PublicID), procedimentos.PublicID.ToString());
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

        

        public List<Model.Procedimentos> ListarProcedimento_PlanoOperadora(int IdPlanoOperadora)
        {
            List<Model.Procedimentos> ListProcedimento = new List<Model.Procedimentos>();

            DbParams.Clear();
            DbParams.Add("IdPlanoOperadora", IdPlanoOperadora);

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
