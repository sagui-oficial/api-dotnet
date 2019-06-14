using System;
using System.Collections.Generic;
using System.Linq;
using Sagui.Business.Base;
using Sagui.Data.Lookup.Lote;
using Sagui.Data.Lookup.Usuario;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.Lote;
using Sagui.Data.Persister.Procedimento;
using Sagui.Model;
using Sagui.Model.ValueObject;

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

        public Model.Lote ObterLote(Model.Lote Lote)
        {
            LoteLookup loteLookup = new LoteLookup();
            var lote = loteLookup.ObterLote(Lote);

            return lote;
        }

        public Model.Lote Deletar(Model.Lote lote)
        {

            LotePersister lotePersister = new LotePersister();
            Model.Lote responseLote = lotePersister.DeleteLote(lote);

            if (responseLote == null)
            {
                lotePersister.CommitCommand(false);
            }
            else
            {
                lotePersister.CommitCommand(true);
            }

            return responseLote;
        }

        public Model.Lote Atualizar(Model.Lote Lote)
        {
            Lote.TotalGTOLote = Lote.ListaGTO.Count;
            Lote.ValorTotalLote = Lote.ListaGTO.Sum(g => g.ValorTotalProcedimentos);

            LotePersister LotePersister = new LotePersister();

            var _lote = LotePersister.AtualizarLote(Lote);

            if (_lote != null)
            {
                Lote.Id = _lote.Id;


                LoteGTOPersister loteGTOPersister = new LoteGTOPersister();
                var _persisted2 = loteGTOPersister.DeletarLoteGTO(Lote.Id);

                if (!_persisted2)
                {
                    loteGTOPersister.CommitCommand(false);
                    return null;
                }


                foreach (Model.GTO gto in Lote.ListaGTO)
                {
                                    
                    var _persisted = loteGTOPersister.SaveLoteGTO(Lote.Id, gto.Id);

                    if (!_persisted)
                    {
                        LotePersister.CommitCommand(false);
                        return null;
                    }

                    ProcedimentoGTOPersister procedimentoGTOPersister = new ProcedimentoGTOPersister();

                    if (gto.Status == Status.GTO.Paga.GetHashCode())
                    {

                        var _persisted3 = procedimentoGTOPersister.PagarProcedimentoGTO(gto.Id);

                        if (!_persisted3)
                        {
                            LotePersister.CommitCommand(false);
                            return null;
                        }
                    }
                }

                LotePersister.CommitCommand(true);
            }

            return _lote;
        }

    }
}