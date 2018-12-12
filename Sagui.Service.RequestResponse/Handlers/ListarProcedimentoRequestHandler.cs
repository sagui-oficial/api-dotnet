using Sagui.Base.Utils;
using Sagui.Service.Contracts;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ListarProcedimentoRequestHandler : BaseRequestHandler<RequestProcedimento, ResponseProcedimento>
    {
        private IProcedimentoService IProcedimentoService { get; set; }
        private Business.Validador.Procedimentos.ValidatorProcedimento validatorProcedimento{ get; set; }

        public ListarProcedimentoRequestHandler(IProcedimentoService iProcedimentoService)
        {
            IProcedimentoService = iProcedimentoService;
            validatorProcedimento = new Business.Validador.Procedimentos.ValidatorProcedimento();
        }


        public ResponseProcedimento Listar()
        {
            var ListProcedimento = IProcedimentoService.ListProcedimentos();

            if (ListProcedimento.Count > 0)
            {
                ResponseProcedimento responseProcedimento = new ResponseProcedimento();
                responseProcedimento.Procedimentos = ListProcedimento;
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Success;
                responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(GTO), Constantes.MensagemGTOListadaComSucesso));
                return responseProcedimento;
            }
            else
            {
                ResponseProcedimento responseProcedimento = new ResponseProcedimento();
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Info;
                responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(GTO), Constantes.MensagemProcedimentoNaoListado));
                return responseProcedimento;
            }
        }
    }
}
