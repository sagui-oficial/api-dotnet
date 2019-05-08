using Sagui.Data.Base;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Persister.PlanoOperadora
{
    public class PlanoOperadoraPacientePersister : DBParams, IDataInfrastructure
    {
        public void CommitCommand(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }

        public bool SavePlanoOperadoraPaciente(int PlanoOperadora_Id, int Paciente_Id, string NumeroPlano)
        {
            DbParams.Add(nameof(NumeroPlano), NumeroPlano);
            DbParams.Add(nameof(PlanoOperadora_Id), PlanoOperadora_Id);
            DbParams.Add(nameof(Paciente_Id), Paciente_Id);

            DataInfrastructure _dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreatePlanoOperadoraPaciente, DbParams);

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
