using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.Arquivo
{
    public class ArquivoLookup : DBParams
    {
        #region GTO

        public List<Model.Arquivo_GTO> ListArquivosGTO()
        {
            List<Model.Arquivo_GTO> ListArquivos = new List<Model.Arquivo_GTO>();

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListarArquivosGTO))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Arquivo_GTO arquivos = new Model.Arquivo_GTO();
                        arquivos.Id = Convert.ToInt32(reader["Id"]);
                        arquivos.Nome = Convert.ToString(reader["Nome"]);
                        arquivos.Stream = (byte[])reader["Stream"];
                        arquivos.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                        arquivos.PathArquivo = Convert.ToString(reader["PathArquivo"]);
                        arquivos.PathArquivo = Convert.ToString(reader["Extensao"]);
                        arquivos.Id = Convert.ToInt32(reader["idArquivo_GTO"]); 
                        arquivos.PublicID = (Guid)reader["PublicID"];
                        
                        ListArquivos.Add(arquivos);
                    }
                }
                catch (Exception e)
                {
                    ListArquivos = null;
                }
            }

            return ListArquivos;
        }

        public Model.Arquivo_GTO ObterArquivoGTOPorPublicId(Model.Arquivo_GTO Arquivo)
        {
            if (Arquivo == null)
                throw new ArgumentNullException(nameof(Arquivo));

            DbParams.Add(nameof(Arquivo.PublicID), Arquivo.PublicID.ToString());

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ObterArquivoGTOPorPublicId))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Arquivo_GTO arquivo = new Model.Arquivo_GTO();
                        arquivo.Id = Convert.ToInt32(reader["Id"]);
                        arquivo.Nome = Convert.ToString(reader["Nome"]);
                        arquivo.Stream = (byte[])reader["Stream"];
                        arquivo.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                        arquivo.PathArquivo = Convert.ToString(reader["PathArquivo"]);
                        arquivo.PathArquivo = Convert.ToString(reader["Extensao"]);
                        arquivo.Id = Convert.ToInt32(reader["idArquivo_GTO"]);
                        arquivo.PublicID = (Guid)reader["PublicID"];

                        Arquivo = arquivo;
                    }
                }
                catch (Exception e)
                {
                    Arquivo = null;
                }
            }

            return Arquivo;
        }

        public List<Model.Arquivo_GTO> ListarArquivoPorGTO(Model.GTO gto)
        {
            List<Model.Arquivo_GTO> ListArquivo = new List<Model.Arquivo_GTO>();

            DbParams.Clear();
            DbParams.Add("idGTO", gto.Id);
            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListarArquivoGTO, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Arquivo_GTO arquivos = new Model.Arquivo_GTO();
                        arquivos.Id = Convert.ToInt32(reader["Id"]);
                        arquivos.Nome = Convert.ToString(reader["Nome"]);
                        arquivos.Stream = (byte[])reader["Stream"];
                        arquivos.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                        arquivos.PathArquivo = Convert.ToString(reader["PathArquivo"]);
                        arquivos.PathArquivo = Convert.ToString(reader["Extensao"]);
                        arquivos.Id = Convert.ToInt32(reader["idArquivo_GTO"]);
                        arquivos.PublicID = (Guid)reader["PublicID"];
                        ListArquivo.Add(arquivos);
                    }
                }
                catch (Exception e)
                {
                    ListArquivo = null;
                }
                finally
                {
                    dataInfrastructure.Dispose();
                }

                return ListArquivo;
            }
        }

        #endregion


        #region PlanoOperadora

        public Model.Arquivo_PlanoOperadora ObterArquivoPlanoOperadoraPorPublicId(Model.Arquivo_PlanoOperadora Arquivo)
        {
            if (Arquivo == null)
                throw new ArgumentNullException(nameof(Arquivo));

            DbParams.Add(nameof(Arquivo.PublicID), Arquivo.PublicID.ToString());

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ObterArquivoPlanoOperadoraPorPublicId))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Arquivo_PlanoOperadora arquivo = new Model.Arquivo_PlanoOperadora();
                        arquivo.Id = Convert.ToInt32(reader["Id"]);
                        arquivo.Nome = Convert.ToString(reader["Nome"]);
                        arquivo.Stream = (byte[])reader["Stream"];
                        arquivo.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                        arquivo.PathArquivo = Convert.ToString(reader["PathArquivo"]);
                        arquivo.PathArquivo = Convert.ToString(reader["Extensao"]);
                        arquivo.Id = Convert.ToInt32(reader["idArquivo_GTO"]);
                        arquivo.PublicID = (Guid)reader["PublicID"];

                        Arquivo = arquivo;
                    }
                }
                catch (Exception e)
                {
                    Arquivo = null;
                }
            }

            return Arquivo;
        }

        public List<Model.Arquivo_PlanoOperadora> ListarArquivoPorPlanoOperadora(Model.PlanoOperadora planoOperadora)
        {
            List<Model.Arquivo_PlanoOperadora> ListArquivo = new List<Model.Arquivo_PlanoOperadora>();

            DbParams.Clear();
            DbParams.Add("idPlanoOperadora", planoOperadora.Id);

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListarArquivoPlanoOperadora, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Arquivo_PlanoOperadora arquivos = new Model.Arquivo_PlanoOperadora();
                        arquivos.Id = Convert.ToInt32(reader["Id"]);
                        arquivos.Nome = Convert.ToString(reader["Nome"]);
                        arquivos.Stream = (byte[])reader["Stream"];
                        arquivos.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                        arquivos.PathArquivo = Convert.ToString(reader["PathArquivo"]);
                        arquivos.PathArquivo = Convert.ToString(reader["Extensao"]);
                        arquivos.Id = Convert.ToInt32(reader["idArquivo_GTO"]);
                        arquivos.PublicID = (Guid)reader["PublicID"];
                        ListArquivo.Add(arquivos);
                    }
                }
                catch (Exception e)
                {
                    ListArquivo = null;
                }

                return ListArquivo;
            }
        }
        #endregion
    }
}
