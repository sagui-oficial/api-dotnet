using Sagui.Data.Base;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Persister.PlanoOperadora
{
    public class PlanoOperadoraPersister : DBParams
    {
        public Model.PlanoOperadora SavePlanoOperadora(Model.PlanoOperadora PlanoOperadora, out DataInfrastructure _dataInfrastructure)
        {
            if (PlanoOperadora == null)
                throw new ArgumentNullException(nameof(PlanoOperadora));

            DbParams.Add(nameof(PlanoOperadora.CNPJ), PlanoOperadora.CNPJ);
            

            DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.CreateUsuarioDentista, DbParams);

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
                dataInfrastructure.transaction.Rollback();
            }


            _dataInfrastructure = dataInfrastructure;


            return PlanoOperadora;
        }
    }
}
