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
    public class CriarProcedimentoRequestHandler : BaseRequestHandler<RequestProcedimento, ResponseProcedimento>
    {
        private IProcedimentoService IProcedimentoService { get; set; }
        private Business.Validador.Procedimentos.ValidatorProcedimento ValidatorProcedimento { get; set; }

        public CriarProcedimentoRequestHandler(IProcedimentoService _IProcedimentoService)
        {
            IProcedimentoService = _IProcedimentoService;
            ValidatorProcedimento = new Business.Validador.Procedimentos.ValidatorProcedimento();
        }

        public ResponseProcedimento Cadastrar(Model.Procedimentos Procedimentos)
        {
            var errors = ValidatorProcedimento.Validate(Procedimentos);

            if (errors.Count() == 0)
            {
                var _Procedimento = IProcedimentoService.Cadastrar(Procedimentos);

                if (_Procedimento.IdProcedimento > 0)
                {
                    ResponseProcedimento responseProcedimento = new ResponseProcedimento();
                    responseProcedimento.ExecutionDate = DateTime.Now;
                    responseProcedimento.ResponseType = ResponseType.Success;
                    responseProcedimento.Message = new List<Tuple<dynamic, dynamic, dynamic>>();
                    responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.InseridoComSucesso, 
                                                                                          nameof(Procedimentos), 
                                                                                          Constantes.MensagemProcedimentosInseridosComSucesso));
                    return responseProcedimento;
                }
                else
                {
                    ResponseProcedimento responseProcedimento = new ResponseProcedimento();
                    responseProcedimento.ExecutionDate = DateTime.Now;
                    responseProcedimento.ResponseType = ResponseType.Error;
                    responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoInserir, 
                                                                                nameof(Procedimentos), 
                                                                                Constantes.MensagemProcedimentoNaoInserida));
                    return responseProcedimento;
                }
            }
            else
            {
                ResponseProcedimento responseProcedimento = new ResponseProcedimento();
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Error;
                responseProcedimento.Message = errors;
                return responseProcedimento;
            }
        }
    }
}
