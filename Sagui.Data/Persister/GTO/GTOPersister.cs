using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Persister.GTO
{
    public class GTOPersister
    {
        public Model.GTO UpdateGTO(Model.GTO GTO, out DataInfrastructure _dataInfrastructure)
        {
            Dictionary<string, object> DbParams = new Dictionary<string, object>();

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.CreateGTO, DbParams))
            {
                _dataInfrastructure = dataInfrastructure;
            }

            return GTO;
        }


        public Model.GTO DeleteGTO(Model.GTO GTO, out DataInfrastructure _dataInfrastructure)
        {
            Dictionary<string, object> DbParams = new Dictionary<string, object>();

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.CreateGTO, DbParams))
            {
                _dataInfrastructure = dataInfrastructure;
            }

            return GTO;
        }

        public Model.GTO SaveGTO(Model.GTO GTO, out DataInfrastructure _dataInfrastructure)
        {
            if (GTO == null)
                throw new ArgumentNullException(nameof(GTO));

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(GTO.Numero), GTO.Numero.ToString());
            DbParams.Add(nameof(GTO.Status), GTO.Status);
            DbParams.Add(nameof(GTO.Operadora), GTO.Operadora.IdOperadora);
            DbParams.Add(nameof(GTO.Paciente), GTO.Paciente.IdPaciente);
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
            }


            _dataInfrastructure = dataInfrastructure;


            return GTO;
        }
    }
}
