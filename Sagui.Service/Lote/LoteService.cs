using Sagui.Model;
using Sagui.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sagui.Service.Lote
{
    public class LoteService : ILoteService<Model.Lote, Model.Lote>
    {
        public Model.Lote Atualizar(Model.Lote Lote)
        {
            using (var LoteBusiness = new Business.Lote.LoteBusiness())
            {
                var _return = LoteBusiness.Atualizar(Lote);
                LoteBusiness.Dispose();
                return _return;
            }
        }

        public Model.Lote Cadastrar(Model.Lote Lote)
        {
            using (var LoteBusiness = new Business.Lote.LoteBusiness())
            {
                var _return = LoteBusiness.Cadastrar(Lote);
                LoteBusiness.Dispose();
                return _return;
            }
        }

        public Model.Lote Deletar(Model.Lote lote)
        {
            using (var LoteBusiness = new Business.Lote.LoteBusiness())
            {
                var _return = LoteBusiness.Deletar(lote);
                LoteBusiness.Dispose();
                return _return;
            }
        }

        public List<Model.Lote> Listar(Model.Lote Lote)
        {
            using (var LoteBusiness = new Business.Lote.LoteBusiness())
            {
                var _return = LoteBusiness.ListLote();
                LoteBusiness.Dispose();
                return _return;
            }
        }

        public Model.Lote Obter(Model.Lote Lote)
        {
            using (var LoteBusiness = new Business.Lote.LoteBusiness())
            {
                var _return = LoteBusiness.ObterLote(Lote);
                LoteBusiness.Dispose();
                return _return;
            }
        }
    }
}
