using Sagui.Data.Base;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Persister.PlanoOperadora
{
    public class PlanoOperadoraPacientePersister : PersisterBase
    {
        public bool SavePlanoOperadoraPaciente(int IdPlanoOperadora, int IdUsuarioPaciente, string numeroPlano, DataInfrastructure dataInfrastructure, out DataInfrastructure _dataInfrastructure)
        {
            DbParams.Add(nameof(IdPlanoOperadora), IdPlanoOperadora);
            DbParams.Add(nameof(IdUsuarioPaciente), IdUsuarioPaciente);

            _dataInfrastructure = new DataInfrastructure(SQL.CreatePlanoOperadoraPaciente, DbParams, dataInfrastructure.connection, dataInfrastructure.transaction);

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
