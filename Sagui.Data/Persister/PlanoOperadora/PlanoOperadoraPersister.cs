using Sagui.Data.Base;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Persister.PlanoOperadora
{
    public class PlanoOperadoraPersister : DBParams, IDataInfrastructure
    {
        public void CommitCommand(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }

        public Model.PlanoOperadora SavePlanoOperadora(Model.PlanoOperadora PlanoOperadora)
        {
            if (PlanoOperadora == null)
                throw new ArgumentNullException(nameof(PlanoOperadora));

            DbParams.Add(nameof(PlanoOperadora.CNPJ), PlanoOperadora.CNPJ);
            

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateUsuarioDentista, DbParams);

            try
            {
                var newId = dataInfrastructure.command.ExecuteScalar();

                if (Convert.ToInt32(newId) > 0)
                {
                    PlanoOperadora.Id = Convert.ToInt32(newId);
                }
            }
            catch (Exception e)
            {
                PlanoOperadora = null;
            }

            return PlanoOperadora;
        }
    }
}
