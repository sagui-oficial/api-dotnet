using Sagui.Data.Base;
using Sagui.Model;
using Sagui.Model.ValueObject;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Persister.GTO
{
    public class GTOPersister : DBParams, IDataInfrastructure
    {
        public Model.GTO AtualizarGTO(Model.GTO GTO)
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
            DbParams.Add(nameof(GTO.PublicID), GTO.PublicID);

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.UpdateGTO, DbParams);

            try
            {
                dataInfrastructure.command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                GTO = null;
            }
            
            return GTO;
        }

        public Model.GTO DeleteGTO(Model.GTO GTO)
        {
            if (GTO == null)
                throw new ArgumentNullException(nameof(GTO));
            DbParams.Add(nameof(GTO.PublicID), GTO.PublicID.ToString());
            DbParams.Add(nameof(GTO.Status), StatusGTO.Status.Deletada);

            DataInfrastructure dataInfrastructure =  DataInfrastructure.GetInstanceDb(SQL.DeleteGTO, DbParams);

            try
            {
                dataInfrastructure.command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                GTO = null;
            }

            return GTO;
        }

        public Model.GTO SaveGTO(Model.GTO GTO)
        {
            if (GTO == null)
                throw new ArgumentNullException(nameof(GTO));

            DbParams.Add(nameof(GTO.Numero), GTO.Numero.ToString());
            DbParams.Add(nameof(GTO.Status), GTO.Status);
            DbParams.Add(nameof(GTO.PlanoOperadora), GTO.PlanoOperadora.Id);
            DbParams.Add(nameof(GTO.Paciente), GTO.Paciente.Id);
            DbParams.Add(nameof(GTO.Solicitacao), GTO.Solicitacao);
            DbParams.Add(nameof(GTO.Vencimento), GTO.Vencimento);

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateGTO, DbParams);

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
                GTO = null;
            }

            return GTO;
        }

        public void CommitCommand(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }
    }
}
