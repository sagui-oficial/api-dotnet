using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Persister.Procedimento
{
    public class ProcedimentoGTOPersister: DBParams, IDataInfrastructure
    {
        public void DataInfrastructureControl(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }

        public bool SaveProcedimentoGTO(int IdGTO, int IdProcedimento)
        {
            DbParams.Add(nameof(IdGTO), IdGTO);
            DbParams.Add(nameof(IdProcedimento), IdProcedimento);

            DataInfrastructure _dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateProcedimentoGTO, DbParams);

            dynamic newId = 0;
            try
            {
                newId = _dataInfrastructure.command.ExecuteScalar();
            }
            catch (Exception e)
            {
                _dataInfrastructure.transaction.Rollback();
            }

            if (Convert.ToInt32(newId) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
