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
        public Model.GTO SaveGTO(Model.GTO GTO)
        {
            if (GTO == null)
                throw new ArgumentNullException(nameof(GTO));

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(GTO.NumeroGTO), GTO.NumeroGTO);

            DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.CreateGTO, DbParams);
            try
            {
                var newId = (int)dataInfrastructure.command.ExecuteScalar();

                if (newId > 0)
                {
                    GTO.IdGTO = newId;
                }
                return GTO;
            }
            catch
            {
                dataInfrastructure.transaction.Rollback();
            }
            finally
            {
                dataInfrastructure.transaction.Commit();
            }
            return null;
        }
    }
}
