using System.Collections.Generic;
using System.Linq;
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
            Lote.TotalGTOLote = Lote.ListaGTO.Count;
            Lote.ValorTotalLote = Lote.ListaGTO.Sum(g => g.ValorTotalProcedimentos);

            LotePersister LotePersister = new LotePersister();

            var _lote = LotePersister.SaveLote(Lote);

            if (_lote != null)
            {
                Lote.Id = _lote.Id;

                foreach (Model.GTO gto in Lote.ListaGTO)
                {
                    LoteGTOPersister loteGTOPersister = new LoteGTOPersister();
                    var _persisted = loteGTOPersister.SaveLoteGTO(Lote.Id, gto.Id);

                    if (!_persisted)
                    {
                        LotePersister.CommitCommand(false);
                        return null;
                    }
                }

                LotePersister.CommitCommand(true);
            }

            return _lote;
        }
    }
}