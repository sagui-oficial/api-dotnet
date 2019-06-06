using Sagui.Data.Base;
using Sagui.Model.ValueObject;
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

            DbParams.Add(nameof(PlanoOperadora.NomeFantasia), PlanoOperadora.NomeFantasia);
            DbParams.Add(nameof(PlanoOperadora.RazaoSocial), PlanoOperadora.RazaoSocial);
            DbParams.Add(nameof(PlanoOperadora.CNPJ), PlanoOperadora.CNPJ);
            DbParams.Add(nameof(PlanoOperadora.DataEnvioLote), PlanoOperadora.DataEnvioLote);
            DbParams.Add(nameof(PlanoOperadora.DataRecebimentoLote), PlanoOperadora.DataRecebimentoLote);
            DbParams.Add(nameof(PlanoOperadora.Status), PlanoOperadora.Status);


            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreatePlanoOperadora, DbParams);

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

        public Model.PlanoOperadora AtualizarPlanoOperadora(Model.PlanoOperadora PlanoOperadora)
        {
            if (PlanoOperadora == null)
                throw new ArgumentNullException(nameof(PlanoOperadora));

            DbParams.Add(nameof(PlanoOperadora.NomeFantasia), PlanoOperadora.NomeFantasia);
            DbParams.Add(nameof(PlanoOperadora.RazaoSocial), PlanoOperadora.RazaoSocial);
            DbParams.Add(nameof(PlanoOperadora.CNPJ), PlanoOperadora.CNPJ);
            DbParams.Add(nameof(PlanoOperadora.DataEnvioLote), PlanoOperadora.DataEnvioLote);
            DbParams.Add(nameof(PlanoOperadora.DataRecebimentoLote), PlanoOperadora.DataRecebimentoLote);
            DbParams.Add(nameof(PlanoOperadora.Status), PlanoOperadora.Status);
            DbParams.Add(nameof(PlanoOperadora.PublicID), PlanoOperadora.PublicID);

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.UpdatePlanoOperadora, DbParams);
            
                try
                {
                     dataInfrastructure.command.ExecuteScalar();

                }
                catch (Exception e)
                {
                    PlanoOperadora = null;
                }
                     


           

            return PlanoOperadora;
        }

        public Model.PlanoOperadora DeletarPlanoOperadora(Model.PlanoOperadora PlanoOperadora)
        {
            if (PlanoOperadora == null)
                throw new ArgumentNullException(nameof(PlanoOperadora));

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(PlanoOperadora.PublicID), PlanoOperadora.PublicID);
            DbParams.Add(nameof(PlanoOperadora.Status), Status.PlanoOperadora.Deletada.GetHashCode());

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.DeletePlanoOperadora, DbParams);

            try
            {
                dataInfrastructure.command.ExecuteScalar();

            }
            catch (Exception e)
            {
                PlanoOperadora = null;
            }


            return PlanoOperadora;
        }

    }
}
