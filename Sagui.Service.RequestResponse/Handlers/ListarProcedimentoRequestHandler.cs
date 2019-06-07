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
    public class ListarProcedimentoRequestHandler : IBaseRequestHandler<RequestProcedimento, ResponseProcedimento>
    {
        ProcedimentoService procedimentoService;
        private Business.Validador.Procedimentos.ValidatorProcedimento validatorProcedimento{ get; set; }

        ResponseProcedimento responseProcedimento;

        public ListarProcedimentoRequestHandler(ProcedimentoService _procedimentoService)
        {
            procedimentoService = _procedimentoService;
            validatorProcedimento = new Business.Validador.Procedimentos.ValidatorProcedimento();
            responseProcedimento = new ResponseProcedimento();
        }

        public async Task<ResponseProcedimento> Handle(RequestProcedimento request)
        {
            var ListProcedimento = procedimentoService.Listar();

            if (ListProcedimento.Count > 0)
            {
                responseProcedimento.Procedimentos = ListProcedimento;
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Success;
                responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(responseProcedimento.Procedimento), 
                                                                             String.Format(Constantes.MensagemListadaComSucesso, nameof(responseProcedimento.Procedimento))  ));
                return responseProcedimento;
            }
            else
            {
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Info;
                responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(responseProcedimento.Procedimento),
                                                            String.Format(Constantes.MensagemNaoListada, nameof(responseProcedimento.Procedimento))));
                return responseProcedimento;
            }
        }
    }
}
