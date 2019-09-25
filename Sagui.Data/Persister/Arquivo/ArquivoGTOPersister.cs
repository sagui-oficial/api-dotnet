using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Data.Persister.Arquivo
{
    public class ArquivoGTOPersister : DBParams, IDataInfrastructure
    {
        public void CommitCommand(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }

        public bool SaveArquivoGTO(int IdGTO, int IdArquivo)
        {
            DbParams.Add("idGTO", IdGTO);
            DbParams.Add("idArquivo", IdArquivo);

            DataInfrastructure _dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateArquivoGTO, DbParams);

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
                return false;
            }
        }
    }
}
