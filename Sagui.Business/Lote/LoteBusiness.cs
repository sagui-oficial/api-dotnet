using System.Collections.Generic;
using Sagui.Business.Base;
using Sagui.Data.Lookup.Lote;
using Sagui.Data.Lookup.Usuario;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.Lote;

namespace Sagui.Business.Lote
{

    public class LoteBusiness : BusinessBase
    {
        public List<Model.Lote> ListLote()
        {
            LoteLookup LoteLookup = new LoteLookup();
            var listLote = LoteLookup.ListLote();

            return listLote;
        }

        public Model.Lote Cadastrar(Model.Lote Lote)
        {
            LotePersister LotePersister = new LotePersister();
            LotePersister.SaveLote(Lote, out Data.DataInfrastructure dataInfrastructure);

            Model.Lote responseLote = new Model.Lote();
            responseLote = Lote;

            dataInfrastructure.transaction.Commit();
            dataInfrastructure.Dispose();

            return responseLote;
        }
    }
}