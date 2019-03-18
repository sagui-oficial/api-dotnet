using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Data.Persister.Arquivo
{
    public class ArquivoGTOPersister : PersisterBase
    {
        public bool SaveArquivoGTO(int IdGTO, int IdArquivo, DataInfrastructure dataInfrastructure, out DataInfrastructure _dataInfrastructure)
        {
            DbParams.Add(nameof(IdGTO), IdGTO);
            DbParams.Add(nameof(IdArquivo), IdArquivo);

            _dataInfrastructure = new DataInfrastructure(SQL.CreateArquivo, DbParams, dataInfrastructure.connection, dataInfrastructure.transaction);

            dynamic newId = 0;
            try
            {
                newId = _dataInfrastructure.command.ExecuteScalar();
                if (Convert.ToInt32(newId) > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
