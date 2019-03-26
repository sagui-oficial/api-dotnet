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
        public List<Model.Arquivos> ListArquivos()
        {
            List<Model.Arquivos> ListArquivos = new List<Model.Arquivos>();

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.ListarArquivos))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Arquivos arquivos = new Model.Arquivos();
                        arquivos.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                        arquivos.Id = Convert.ToInt32(reader["Id"]);
                        arquivos.Nome = Convert.ToString(reader["Nome"]);
                        arquivos.PathArquivo = Convert.ToString(reader["PathArquivo"]);
                        //arquivos.PublicID = (Guid)reader["PublicID"];
                        arquivos.Stream = (byte[])reader["Stream"];
                        ListArquivos.Add(arquivos);
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
            return new Model.Arquivos();
        }


        public List<Model.Arquivos> ListarArquivoPorGTO(Model.GTO gto)
        {
            return new List<Model.Arquivos>();
        }
    }
}
