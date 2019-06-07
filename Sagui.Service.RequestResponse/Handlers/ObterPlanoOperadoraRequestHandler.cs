using Sagui.Base.Utils;
using Sagui.Service.Contracts;
using Sagui.Service.PlanoOperadora;
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
    public class ObterPlanoOperadoraRequestHandler :IBaseRequestHandler<RequestPlanoOperadora, ResponsePlanoOperadora>
    {
        PlanoOperadoraService planoOperadoraService;
        ProcedimentoService procedimentoService;
        private Business.Validador.Procedimentos.ValidatorProcedimento ValidatorProcedimento { get; set; }

        ResponsePlanoOperadora responseProcedimento;

        public ObterPlanoOperadoraRequestHandler(PlanoOperadoraService _planoOperadoraService, 
            ProcedimentoService _procedimentoService)
        {
            planoOperadoraService = _planoOperadoraService;
            procedimentoService = _procedimentoService;
            ValidatorProcedimento = new Business.Validador.Procedimentos.ValidatorProcedimento();
            responseProcedimento = new ResponsePlanoOperadora();
        }

        public async Task<ResponsePlanoOperadora> Handle(RequestPlanoOperadora request)
        {
            var planoOperadora = planoOperadoraService.Obter(request);

            if (planoOperadora != null)
            {
                // GTO.Arquivos = arquivoService.ListarArquivoPorGTO(GTO);
                planoOperadora.Procedimentos = procedimentoService.ListarProcedimento_PlanoOperadora(planoOperadora);
            }

            if (planoOperadora.Id > 0)
            {
                responseProcedimento.PlanoOperadora = planoOperadora;
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Success;
                responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(GTO), Constantes.MensagemGTOObtidacomSucesso));
                return responseProcedimento;
            }
            else
            {
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Error;
                responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(GTO), Constantes.MensagemGTONaoObtidacomSucesso));
                return responseProcedimento;
            }
        }
    }
}
