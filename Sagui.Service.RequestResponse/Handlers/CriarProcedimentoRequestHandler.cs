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
    public class CriarProcedimentoRequestHandler : IBaseRequestHandler<RequestProcedimento, ResponseProcedimento>
    {
        ProcedimentoService procedimentoService;
        private Business.Validador.Procedimentos.ValidatorProcedimento ValidatorProcedimento { get; set; }

        ResponseProcedimento responseProcedimento;

        public CriarProcedimentoRequestHandler(ProcedimentoService _procedimentoService)
        {
            procedimentoService = _procedimentoService;
            ValidatorProcedimento = new Business.Validador.Procedimentos.ValidatorProcedimento();
            responseProcedimento = new ResponseProcedimento();
        }

        public async Task<ResponseProcedimento> Handle(RequestProcedimento Procedimentos)
        {
            var errors = ValidatorProcedimento.Validate(Procedimentos);

            if (errors.Count() == 0)
            {
                var _Procedimento = procedimentoService.Cadastrar(Procedimentos);

                if (_Procedimento.Id != 0)
                {
                    responseProcedimento.Procedimento = _Procedimento;
                    responseProcedimento.ExecutionDate = DateTime.Now;
                    responseProcedimento.ResponseType = ResponseType.Success;
                    responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.InseridoComSucesso, nameof(responseProcedimento.Procedimento),
                                                 String.Format(Constantes.MensagemInseridaComSucesso, nameof(responseProcedimento.Procedimento))));
                    return responseProcedimento;
                }
                else
                {
                    responseProcedimento.ExecutionDate = DateTime.Now;
                    responseProcedimento.ResponseType = ResponseType.Error;
                    responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoInserir, nameof(responseProcedimento.Procedimento),
                                     String.Format(Constantes.MensagemNaoInserida, nameof(responseProcedimento.Procedimento))));

                    return responseProcedimento;
                }
            }
            else
            {
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Error;
                responseProcedimento.Message = errors;
                return responseProcedimento;
            }
        }
    }
}
