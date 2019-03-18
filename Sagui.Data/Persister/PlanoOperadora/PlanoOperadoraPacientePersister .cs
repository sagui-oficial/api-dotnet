using Sagui.Data.Base;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Persister.PlanoOperadora
{
    public class PlanoOperadoraPacientePersister : DBParams
    {
        public bool SavePlanoOperadoraPaciente(int PlanoOperadora_Id, int Paciente_Id, string NumeroPlano, DataInfrastructure dataInfrastructure, out DataInfrastructure _dataInfrastructure)
        {
            DbParams.Add(nameof(NumeroPlano), NumeroPlano);
            DbParams.Add(nameof(PlanoOperadora_Id), PlanoOperadora_Id);
            DbParams.Add(nameof(Paciente_Id), Paciente_Id);

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
