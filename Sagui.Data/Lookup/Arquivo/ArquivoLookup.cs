using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.Arquivo
{
    public class ArquivoLookup : PersisterBase
    {
        public List<Model.Arquivos> ListArquivos()
        {
            List<Model.Arquivos> ListArquivos = new List<Model.Arquivos>();

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.ListGTO))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.GTO _GTO = new Model.GTO();
                        _GTO.Id = Convert.ToInt32(reader["Id"]);
                        _GTO.Numero = Convert.ToString(reader["Numero"]);
                        _GTO.Status = Convert.ToInt32(reader["Status"]);
                        _GTO.PlanoOperadora = new Model.PlanoOperadora();
                        _GTO.PlanoOperadora.Id = Convert.ToInt32(reader["PlanoOperadoraId"]);
                        _GTO.PlanoOperadora.NomeFantasia = Convert.ToString(reader["NomeFantasia"]);
                        _GTO.PlanoOperadora.RazaoSocial = Convert.ToString(reader["RazaoSocial"]);
                        _GTO.Paciente = new Model.Paciente();
                        _GTO.Paciente.Id = Convert.ToInt32(reader["PacienteId"]);
                        _GTO.Paciente.Nome = Convert.ToString(reader["Nome"]);
                        _GTO.Solicitacao = Convert.ToDateTime(reader["Solicitacao"]);
                        _GTO.Vencimento = Convert.ToDateTime(reader["Vencimento"]);
                        _GTO.PublicID = (Guid)reader["PublicID"];
                        ListGTO.Add(_GTO);
                    }
                }
                catch (Exception e)
                {

                }
                finally
                {
                    dataInfrastructure.Dispose();
                }
            }
            return ListArquivos;
        }

        public Model.Arquivos ObterArquivo(Model.Arquivos Arquivo)
        {
            if (Arquivo == null)
                throw new ArgumentNullException(nameof(Arquivo));
            DbParams.Add(nameof(Arquivo.PublicID), GTO.PublicID.ToString());
           
            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.ObterGTObyPublicID, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.GTO _GTO = new Model.GTO();
                        _GTO.Id = Convert.ToInt32(reader["Id"]);
                        _GTO.Numero = Convert.ToString(reader["Numero"]);
                        _GTO.Status = Convert.ToInt32(reader["Status"]);
                        _GTO.PlanoOperadora = new Model.PlanoOperadora();
                        _GTO.PlanoOperadora.Id = Convert.ToInt32(reader["PlanoOperadoraId"]);
                        _GTO.PlanoOperadora.NomeFantasia = Convert.ToString(reader["NomeFantasia"]);
                        _GTO.PlanoOperadora.RazaoSocial = Convert.ToString(reader["RazaoSocial"]);
                        _GTO.Paciente = new Model.Paciente();
                        _GTO.Paciente.Id = Convert.ToInt32(reader["PacienteId"]);
                        _GTO.Paciente.Nome = Convert.ToString(reader["Nome"]);
                        _GTO.Solicitacao = Convert.ToDateTime(reader["Solicitacao"]);
                        _GTO.Vencimento = Convert.ToDateTime(reader["Vencimento"]);
                        _GTO.PublicID = (Guid)reader["PublicID"];

                      
                       

                        GTO = _GTO;
                    }
                }
                catch (Exception e)
                {

                }
                finally
                {
                    dataInfrastructure.Dispose();
                }
            }

            DbParams.Clear();
            DbParams.Add("idGTO", GTO.Id.ToString());
            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.ListarProcedimentoGTO, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Procedimentos _Procedimento = new Model.Procedimentos();
                        _Procedimento.IdProcedimento = Convert.ToInt32(reader["IdProcedimento"]);
                        _Procedimento.NomeProcedimento = Convert.ToString(reader["NomeProcedimento"]);
                        _Procedimento.Codigo = Convert.ToInt32(reader["Codigo"]);
                        _Procedimento.ValorProcedimento = Convert.ToDouble(reader["ValorProcedimento"]);
                        _Procedimento.Exigencias = Convert.ToString(reader["Exigencias"]);
                        _Procedimento.Anotacoes = Convert.ToString(reader["Anotacoes"]);
                        GTO.Procedimentos.Add(_Procedimento);
                    }
                }
                catch (Exception e)
                {

                }
                finally
                {
                    dataInfrastructure.Dispose();
                }
            }

            DbParams.Clear();
            DbParams.Add("idGTO", GTO.Id.ToString());
            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.ListarArquivoGTO, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Arquivos _Arquivo = new Model.Arquivos();
                        _Arquivo.Id = Convert.ToInt32(reader["Id"]);
                        _Arquivo.Nome = Convert.ToString(reader["Nome"]);
                        _Arquivo.Stream = (byte[])(reader["Stream"]);
                        _Arquivo.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                        _Arquivo.PathArquivo = Convert.ToString(reader["PathArquivo"]);
                        GTO.Arquivos.Add(_Arquivo);
                    }
                }
                catch (Exception e)
                {

                }
                finally
                {
                    dataInfrastructure.Dispose();
                }
            }

            return GTO;
        }
    }
}
