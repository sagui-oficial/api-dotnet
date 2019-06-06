using Sagui.Base.Utils;
using Sagui.Service.Arquivo;
using Sagui.Service.Contracts;
using Sagui.Service.GTO;
using Sagui.Service.Lote;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ObterLoteRequestHandler : IBaseRequestHandler<RequestLote, ResponseLote>
    {
        LoteService LoteService;
        GTOService GTOService;

        private Business.Validador.Lote.ValidadorLote validadorLote { get; set; }

        ResponseLote responseLote;

        public ObterLoteRequestHandler(LoteService _LoteService,
                                       GTOService _GTOService)
        {
            LoteService = _LoteService;
            GTOService = _GTOService;
            validadorLote = new Business.Validador.Lote.ValidadorLote();
            responseLote = new ResponseLote();
        }

        public async Task<ResponseLote> Handle(RequestLote request)
        {
            var Lote = LoteService.Obter(request);

            if (Lote != null)
            {
                Lote.ListaGTO = GTOService.ListarGTOPorLote(Lote);
            }

            if (Lote.Id > 0)
            {
                responseLote.Lote = Lote;
                responseLote.ExecutionDate = DateTime.Now;
                responseLote.ResponseType = ResponseType.Success;
                responseLote.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(Lote), Constantes.MensagemLoteObtidocomSucesso));
                return responseLote;
            }
            else
            {
                responseLote.Lote = Lote;
                responseLote.ExecutionDate = DateTime.Now;
                responseLote.ResponseType = ResponseType.Info;
                responseLote.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(Lote), Constantes.MensagemLoteNaoObtido));
                return responseLote;
            }
        }
    }
}
