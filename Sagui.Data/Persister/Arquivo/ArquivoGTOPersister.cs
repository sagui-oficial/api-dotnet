using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Data.Persister.Arquivo
{
    public class ArquivoGTOPersister : DBParams
    {
        public bool SaveArquivoGTO(int IdGTO, int IdArquivo)
        {
            DbParams.Add(nameof(IdGTO), IdGTO);
            DbParams.Add(nameof(IdArquivo), IdArquivo);

            DataInfrastructure _dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateArquivo, DbParams);

            dynamic newId = 0;
            try
            {
                newId = _dataInfrastructure.command.ExecuteScalar();
                if (Convert.ToInt32(newId) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
