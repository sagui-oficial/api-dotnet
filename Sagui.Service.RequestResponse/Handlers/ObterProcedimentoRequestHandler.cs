using Sagui.Base.Utils;
using Sagui.Service.Contracts;
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
    public class ObterProcedimentoRequestHandler :IBaseRequestHandler<RequestProcedimento, ResponseProcedimento>
    {
        ProcedimentoService ProcedimentoService;
        private Business.Validador.Procedimentos.ValidatorProcedimento ValidatorProcedimento { get; set; }

        ResponseProcedimento responseProcedimento;

        public ObterProcedimentoRequestHandler(ProcedimentoService _ProcedimentoService)
        {
            ProcedimentoService = _ProcedimentoService;
            ValidatorProcedimento = new Business.Validador.Procedimentos.ValidatorProcedimento();
            responseProcedimento = new ResponseProcedimento();
        }

        public async Task<ResponseProcedimento> Handle(RequestProcedimento request)
        {
            var procedimento = ProcedimentoService.Obter(request);

            if (procedimento.Id > 0)
            {
                responseProcedimento.Procedimento = procedimento;
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Success;
                
                responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ObterComSucesso, nameof(responseProcedimento.Procedimento),
                        String.Format(Constantes.MensagemObtidacomSucesso, nameof(responseProcedimento.Procedimento))));


                return responseProcedimento;
            }
            else
            {
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Error;
                


                responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoObter, nameof(responseProcedimento.Procedimento),
                        String.Format(Constantes.MensagemNaoObtidacomSucesso, nameof(responseProcedimento.Procedimento))));

                return responseProcedimento;
            }
        }
    }
}
