using Sagui.Data.Base;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Persister.GTO
{
    public class GTOPersister: PersisterBase
    {
        public Model.GTO AtualizarGTO(Model.GTO GTO, out DataInfrastructure _dataInfrastructure)
        {
            if (GTO == null)
                throw new ArgumentNullException(nameof(GTO));
            DbParams.Add(nameof(GTO.Id), GTO.Id.ToString());
            DbParams.Add(nameof(GTO.Numero), GTO.Numero.ToString());
            DbParams.Add(nameof(GTO.Status), GTO.Status);
            DbParams.Add(nameof(GTO.PlanoOperadora), GTO.PlanoOperadora.Id);
            DbParams.Add(nameof(GTO.Paciente), GTO.Paciente.Id);
            DbParams.Add(nameof(GTO.Solicitacao), GTO.Solicitacao);
            DbParams.Add(nameof(GTO.Vencimento), GTO.Vencimento);

            DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.UpdateGTO, DbParams);

            try
            {
                dataInfrastructure.command.ExecuteNonQuery();
                dataInfrastructure.transaction.Commit();
                                
            }
            catch (Exception e)
            {
                dataInfrastructure.transaction.Rollback();
            }


            _dataInfrastructure = dataInfrastructure;


            return GTO;
        }


        public Model.GTO DeleteGTO(Model.GTO GTO, out DataInfrastructure _dataInfrastructure)
        {
            if (GTO == null)
                throw new ArgumentNullException(nameof(GTO));
            DbParams.Add(nameof(GTO.Id), GTO.Id.ToString());
            DbParams.Add(nameof(GTO.Status), GTO.Status);
           
            DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.DeleteGTO, DbParams);

            try
            {
                dataInfrastructure.command.ExecuteNonQuery();
                dataInfrastructure.transaction.Commit();

            }
            catch (Exception e)
            {
                dataInfrastructure.transaction.Rollback();
            }


            _dataInfrastructure = dataInfrastructure;


            return GTO;
        }

        public Model.GTO SaveGTO(Model.GTO GTO, out DataInfrastructure _dataInfrastructure)
        {
            if (GTO == null)
                throw new ArgumentNullException(nameof(GTO));

            DbParams.Add(nameof(GTO.Numero), GTO.Numero.ToString());
            DbParams.Add(nameof(GTO.Status), GTO.Status);
            DbParams.Add(nameof(GTO.PlanoOperadora), GTO.PlanoOperadora.Id);
            DbParams.Add(nameof(GTO.Paciente), GTO.Paciente.Id);
            DbParams.Add(nameof(GTO.Solicitacao), GTO.Solicitacao);
            DbParams.Add(nameof(GTO.Vencimento), GTO.Vencimento);

            DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.CreateGTO, DbParams);

            try
            {
                var newId = dataInfrastructure.command.ExecuteScalar();

                if (Convert.ToInt32(newId) > 0)
                {
                    GTO.Id = Convert.ToInt32(newId);
                }
            }
            catch (Exception e)
            {
                dataInfrastructure.transaction.Rollback();
                GTO = null;
            }
            
            _dataInfrastructure = dataInfrastructure;

            return GTO;
        }
    }
}
