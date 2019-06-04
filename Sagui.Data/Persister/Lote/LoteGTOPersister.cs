using Sagui.Data.Base;
using Sagui.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Data.Persister.Lote
{
    public class LoteGTOPersister : DBParams, IDataInfrastructure
    {
        public void CommitCommand(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }

        public bool SaveLoteGTO(int IdLote, int IdGTO)
        {
            DbParams.Clear();
            DbParams.Add(nameof(IdLote), IdLote);
            DbParams.Add(nameof(IdGTO), IdGTO);

            DataInfrastructure _dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateLoteGTO, DbParams);

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
