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
    public class ListarGTO_PlanoOperadoraRequestHandler : IBaseRequestHandler<RequestPlanoOperadora, ResponseGTO>
    {
        GTOService GTOService;
        ArquivoService arquivoService;
        ProcedimentoService procedimentoService;
        private Business.Validador.GTO.ValidadorGTO validadorGTO { get; set; }

        ResponseGTO responseGTO;

        public ListarGTO_PlanoOperadoraRequestHandler(GTOService _GTOService, 
                                       ArquivoService _arquivoService, 
                                       ProcedimentoService _procedimentoService)
        {
            GTOService = _GTOService;
            arquivoService = _arquivoService;
            procedimentoService = _procedimentoService;
            validadorGTO = new Business.Validador.GTO.ValidadorGTO();
            responseGTO = new ResponseGTO();
            procedimentoService = new ProcedimentoService();
        }

        public async Task<ResponseGTO> Handle(RequestPlanoOperadora request)
        {
            var ListGTO = GTOService.ListarGTOPorPlanoOperadora(request);

            foreach(var gto in ListGTO)
            {
             //   gto.Arquivos = arquivoService.ListarArquivoPorGTO(gto);
                gto.Procedimentos = procedimentoService.ListarProcedimentoPorGTO(gto);
            }

            if (ListGTO.Count > 0)
            {
                responseGTO.GTOs = ListGTO;
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Success;
                responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(responseGTO.GTO),
                          String.Format(Constantes.MensagemListadaComSucesso, nameof(responseGTO.GTO))));
                return responseGTO;
            }
            else
            {
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Error;
                
                responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(responseGTO.GTO),
                          String.Format(Constantes.MensagemNaoListada, nameof(responseGTO.GTO))));
                return responseGTO;
            }
        }
    }
}
