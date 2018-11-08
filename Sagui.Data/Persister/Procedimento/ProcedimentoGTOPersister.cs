using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Persister.Procedimento
{
    public class ProcedimentoGTOPersister: PersisterBase
    {
        public bool SaveProcedimentoGTO(int IdGTO, int IdProcedimento, DataInfrastructure dataInfrastructure, out DataInfrastructure _dataInfrastructure)
        {
            DbParams.Add(nameof(IdGTO), IdGTO);
            DbParams.Add(nameof(IdProcedimento), IdProcedimento);

            _dataInfrastructure = new DataInfrastructure(SQL.CreateProcedimentoGTO, DbParams, dataInfrastructure.connection, dataInfrastructure.transaction);

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
