using Sagui.Base.Utils;
using Sagui.Service.Arquivo;
using Sagui.Service.Contracts;
using Sagui.Service.GTO;
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
    public class ObterGTORequestHandler : IBaseRequestHandler<RequestGTO, ResponseGTO>
    {
        GTOService GTOService;
        ArquivoService arquivoService;
        ProcedimentoService procedimentoService;

        private Business.Validador.GTO.ValidadorGTO validadorGTO { get; set; }

        ResponseGTO responseGTO;

        public ObterGTORequestHandler(GTOService _GTOService, 
                                      ArquivoService _arquivoService,
                                      ProcedimentoService _procedimentoService)
        {
            GTOService = _GTOService;
            arquivoService = _arquivoService;
            procedimentoService = _procedimentoService;
            validadorGTO = new Business.Validador.GTO.ValidadorGTO();
            responseGTO = new ResponseGTO();
        }

        public async Task<ResponseGTO> Handle(RequestGTO request)
        {
            var GTO = GTOService.Obter(request);

            
            if(GTO != null)
            {
                GTO.Arquivos = arquivoService.ListarArquivoPorGTO(GTO);
                GTO.Procedimentos = procedimentoService.ListarProcedimentoPorGTO(GTO);
            }

            if (GTO.Id > 0)
            {
                responseGTO.GTO = GTO;
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Success;
                
                responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ObterComSucesso, nameof(responseGTO.GTO),
                 String.Format(Constantes.MensagemObtidacomSucesso, nameof(responseGTO.GTO))));

                return responseGTO;
            }
            else
            {
                responseGTO.GTO = GTO;
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Info;
              

                responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoObter, nameof(responseGTO.GTO),
                    String.Format(Constantes.MensagemNaoObtidacomSucesso, nameof(responseGTO.GTO))));

                return responseGTO;
            }
        }
    }
}
