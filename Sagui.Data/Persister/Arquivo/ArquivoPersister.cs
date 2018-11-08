using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Persister.Arquivo
{
    public class ArquivoPersister : PersisterBase
    {
        public Model.Arquivos SaveArquivo(int IdGTO, Model.Arquivos arquivo, DataInfrastructure dataInfrastructure, out DataInfrastructure _dataInfrastructure)
        {
            DbParams.Add(nameof(IdGTO), IdGTO);
            DbParams.Add(nameof(arquivo.Nome), arquivo.Nome);
            DbParams.Add(nameof(arquivo.DataCriacao), arquivo.DataCriacao);
            DbParams.Add(nameof(arquivo.Stream), arquivo.Stream);

            _dataInfrastructure = new DataInfrastructure(SQL.CreateArquivo, DbParams, dataInfrastructure.connection, dataInfrastructure.transaction);

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
