using Sagui.Data.Base;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Persister.PlanoOperadora
{
    public class PlanoOperadoraPersister : PersisterBase
    {
        public Model.PlanoOperadora SavePlanoOperadora(Model.PlanoOperadora PlanoOperadora, out DataInfrastructure _dataInfrastructure)
        {
            if (PlanoOperadora == null)
                throw new ArgumentNullException(nameof(PlanoOperadora));

            DbParams.Add(nameof(PlanoOperadora.NomeFantasia), PlanoOperadora.NomeFantasia);
            DbParams.Add(nameof(PlanoOperadora.RazaoSocial), PlanoOperadora.RazaoSocial);
            DbParams.Add(nameof(PlanoOperadora.CNPJ), PlanoOperadora.CNPJ);
            DbParams.Add(nameof(PlanoOperadora.DataEnvioLote), PlanoOperadora.DataEnvioLote);
            DbParams.Add(nameof(PlanoOperadora.DataRecebimentoLote), PlanoOperadora.DataRecebimentoLote);
            
            //DbParams.Add(nameof(PlanoOperadora.Id), PlanoOperadora.Id);
            //DbParams.Add(nameof(PlanoOperadora.ListaArquivos), PlanoOperadora.ListaArquivos);
            //DbParams.Add(nameof(PlanoOperadora.ListaProcedimentos), PlanoOperadora.ListaProcedimentos);
            //DbParams.Add(nameof(PlanoOperadora.PublicID), PlanoOperadora.PublicID);
            
            DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.CreatePlanoOperadora, DbParams);

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
