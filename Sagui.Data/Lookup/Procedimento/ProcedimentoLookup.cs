using Sagui.Data.Base;
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

           using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListProcedimento))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();
                                       
                    while (reader.Read())
                    {
                        Model.Procedimentos _Procedimento = new Model.Procedimentos();
                        _Procedimento.Id = Convert.ToInt32(reader["Id"]);
                        _Procedimento.NomeProcedimento = Convert.ToString(reader["NomeProcedimento"]);
                        _Procedimento.Codigo = Convert.ToString(reader["Codigo"]);
                        _Procedimento.ValorProcedimento = Convert.ToDouble(reader["ValorProcedimento"]);
                        _Procedimento.Exigencias = Convert.ToString(reader["Exigencias"]);
                        _Procedimento.Anotacoes = Convert.ToString(reader["Anotacoes"]);
                        _Procedimento.PublicID = (Guid)reader["PublicID"];
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
                        Model.Procedimentos _Procedimento = new Model.Procedimentos();
                        _Procedimento.Id = Convert.ToInt32(reader["Id"]);
                        _Procedimento.NomeProcedimento = Convert.ToString(reader["NomeProcedimento"]);
                        _Procedimento.Codigo = Convert.ToString(reader["Codigo"]);
                        _Procedimento.ValorProcedimento = Convert.ToDouble(reader["ValorProcedimento"]);
                        _Procedimento.Exigencias = Convert.ToString(reader["Exigencias"]);
                        _Procedimento.Anotacoes = Convert.ToString(reader["Anotacoes"]);
                        _Procedimento.PublicID = (Guid)reader["PublicID"];
                        procedimentos =_Procedimento;
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
                        Model.Procedimentos _Procedimento = new Model.Procedimentos();
                        _Procedimento.Id = Convert.ToInt32(reader["Id"]);
                        _Procedimento.NomeProcedimento = Convert.ToString(reader["NomeProcedimento"]);
                        _Procedimento.Codigo = Convert.ToString(reader["Codigo"]);
                        _Procedimento.ValorProcedimento = Convert.ToDouble(reader["ValorProcedimento"]);
                        _Procedimento.Exigencias = Convert.ToString(reader["Exigencias"]);
                        _Procedimento.Anotacoes = Convert.ToString(reader["Anotacoes"]);
                        _Procedimento.PublicID = (Guid)(reader["PublicID"]);
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
                        Model.Procedimentos _Procedimento = new Model.Procedimentos();
                        _Procedimento.Id = Convert.ToInt32(reader["Id"]);
                        _Procedimento.NomeProcedimento = Convert.ToString(reader["NomeProcedimento"]);
                        _Procedimento.Codigo = Convert.ToString(reader["Codigo"]);
                        _Procedimento.ValorProcedimento = Convert.ToDouble(reader["ValorProcedimento"]);
                        _Procedimento.Exigencias = Convert.ToString(reader["Exigencias"]);
                        _Procedimento.Anotacoes = Convert.ToString(reader["Anotacoes"]);
                        _Procedimento.PublicID = (Guid)(reader["PublicID"]);
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
