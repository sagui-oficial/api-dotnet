using System.Collections.Generic;
using Sagui.Business.Base;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Lookup.Usuario;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.PlanoOperadora;

namespace Sagui.Business.PlanoOperadora
{

    public class PlanoOperadoraBusiness : BusinessBase
    {
        public List<Model.PlanoOperadora> ListPlanoOperadora()
        {
            PlanoOperadoraLookup planoOperadoraLookup = new PlanoOperadoraLookup();
            var listPlanoOperadora = planoOperadoraLookup.ListPlanoOperadora();

            return listPlanoOperadora;
        }

        public Model.PlanoOperadora Cadastrar(Model.PlanoOperadora planoOperadora)
        {
            PlanoOperadoraPersister planoOperadoraPersister = new PlanoOperadoraPersister();
            planoOperadoraPersister.SavePlanoOperadora(planoOperadora, out Data.DataInfrastructure dataInfrastructure);

            Model.PlanoOperadora responsePlanoOperadora = new Model.PlanoOperadora();
            responsePlanoOperadora = planoOperadora;

            dataInfrastructure.Dispose();
            dataInfrastructure.transaction.Commit();

            return responsePlanoOperadora;
        }
    }
}