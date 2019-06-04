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

        private Business.Validador.Lote.ValidadorLote validadorLote { get; set; }

        ResponseLote responseLote;

        public ObterLoteRequestHandler(LoteService _LoteService)
        {
            LoteService = _LoteService;
            validadorLote = new Business.Validador.Lote.ValidadorLote();
            responseLote = new ResponseLote();
        }

        public Task<ResponseLote> Handle(RequestLote request)
        {
            var Lote = LoteService.Obter(request);

            if (Lote != null)
            {
                // GTO.Arquivos = arquivoService.ListarArquivoPorGTO(GTO);
                Lote.Procedimentos = procedimentoService.ListarProcedimentoPorGTO(GTO);
            }

            if (Lote.Id > 0)
            {
                responseGTO.GTO = GTO;
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Success;
                responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(GTO), Constantes.MensagemGTOObtidacomSucesso));
                return responseGTO;
            }
            else
            {
                responseGTO.GTO = GTO;
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Info;
                responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(GTO), Constantes.MensagemGTONaoObtidacomSucesso));
                return responseGTO;
            }
        }
    }
}
