using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.GTO
{
    public class GTOLookup : PersisterBase
    {
        //todo: refazer a query para trazer Operadora e Paciente
        //todo: refazer a query para trazer Procedimento da GTO e Arquivo da GTO

        public List<Model.GTO> ListGTO()
        {
            List<Model.GTO> ListGTO = new List<Model.GTO>();

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
                        //_GTO.Procedimentos = ObterProcedimentoGTO(_GTO.Id);
                        //_GTO.Arquivos = ObterArquivoGTO(_GTO.Id);
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
            return ListGTO;
        }

        public Model.GTO ObterGTO(Model.GTO GTO)
        {


            if (GTO == null)
                throw new ArgumentNullException(nameof(GTO));
            DbParams.Add(nameof(GTO.PublicID), GTO.PublicID.ToString());

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
                        //_GTO.Arquivos = ObterArquivoGTO(_GTO.Id);

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

            
            return GTO;
        }

       
        public List<Model.Arquivos> ObterArquivoGTO(int IdGTO)
        {
            List<Model.Arquivos> ListArquivo = new List<Model.Arquivos>();

            DbParams.Clear();
            DbParams.Add("idGTO", IdGTO);
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
                        _Arquivo.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                        _Arquivo.PathArquivo = Convert.ToString(reader["PathArquivo"]);
                        _Arquivo.PublicID = (Guid)reader["PublicID"];
                        ListArquivo.Add(_Arquivo);
                    }
                }
                catch (Exception e)
                {

                }
                finally
                {
                    dataInfrastructure.Dispose();
                }

                return ListArquivo;
            }

        }
    }
}
