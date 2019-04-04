using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Persister.Arquivo
{
    public class ArquivoPersister : DBParams, IDataInfrastructure
    {
        public void DataInfrastructureControl(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }

        public Model.Arquivos SaveArquivo(int IdGTO, Model.Arquivos arquivo)
        {
            DbParams.Add(nameof(IdGTO), IdGTO);
            DbParams.Add(nameof(arquivo.Nome), arquivo.Nome);
            DbParams.Add(nameof(arquivo.DataCriacao), arquivo.DataCriacao);
            DbParams.Add(nameof(arquivo.PathArquivo), arquivo.PathArquivo);
            DbParams.Add(nameof(arquivo.Stream), arquivo.Stream);

            DataInfrastructure _dataInfrastructure =  DataInfrastructure.GetInstanceDb(SQL.CreateArquivo, DbParams);

            dynamic newId = 0;
            try
            {
                newId = _dataInfrastructure.command.ExecuteScalar();
                if (Convert.ToInt32(newId) > 0)
                {
                    arquivo.Id = Convert.ToInt32(newId);

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return arquivo;
        }
    }
}
