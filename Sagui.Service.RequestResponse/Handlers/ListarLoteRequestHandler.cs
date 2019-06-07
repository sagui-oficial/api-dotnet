using Sagui.Base.Utils;
using Sagui.Service.Contracts;
using Sagui.Service.Lote;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ListarLoteRequestHandler : IBaseRequestHandler<RequestLote, ResponseLote>
    {
        LoteService LoteService;
        private Business.Validador.Lote.ValidadorLote validadorLote { get; set; }

        ResponseLote responseLote;

        public ListarLoteRequestHandler(LoteService _LoteService)
        {
            LoteService = _LoteService;
            validadorLote = new Business.Validador.Lote.ValidadorLote();
            responseLote = new ResponseLote();
        }

        public async Task<ResponseLote> Handle(RequestLote request)
        {
            var ListLote = LoteService.Listar();

            if (ListLote.Count > 0)
            {
                responseLote.Lotes = ListLote;
                responseLote.ExecutionDate = DateTime.Now;
                responseLote.ResponseType = ResponseType.Success;
              
                responseLote.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(responseLote.Lote),
                        String.Format(Constantes.MensagemListadaComSucesso, nameof(responseLote.Lote))));
                return responseLote;
            }
            else
            {
                responseLote.ExecutionDate = DateTime.Now;
                responseLote.ResponseType = ResponseType.Info;
              

                responseLote.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(responseLote.Lote),
                        String.Format(Constantes.MensagemNaoListada, nameof(responseLote.Lote))));

                return responseLote;
            }
        }
    }
}
