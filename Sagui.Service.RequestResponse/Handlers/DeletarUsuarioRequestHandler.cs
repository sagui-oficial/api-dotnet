using Sagui.Base.Utils;
using Sagui.Business.Validador.Procedimentos;
using Sagui.Service.Contracts;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Sagui.Service.RequestResponse.Handlers
//{
//    public class DeletarUsuarioRequestHandler : IBaseRequestHandler<RequestUsuarioDentista, ResponseUsuarioDentista>
//    {
//        ProcedimentoService procedimentoService;
//        private Business.Validador.Procedimentos.ValidatorProcedimento validatorProcedimento{ get; set; }

//        ResponseProcedimento responseProcedimento;

//        public DeletarUsuarioRequestHandler(ProcedimentoService _procedimentoService)
//        {
//            procedimentoService = _procedimentoService;
//            validatorProcedimento = new Business.Validador.Procedimentos.ValidatorProcedimento();
//            responseProcedimento = new ResponseProcedimento();
//        }

//        public async Task<ResponseProcedimento> Handle(RequestProcedimento Procedimentos)
//        {
//            //var errors = ValidatorProcedimento.Validate(Procedimentos);

//            //if (errors.Count() == 0)
//            //{
//                var _Procedimento = procedimentoService.Deletar(Procedimentos);

//                if (_Procedimento.IdProcedimento != 0)
//                {
//                    responseProcedimento.Procedimento = _Procedimento;
//                    responseProcedimento.ExecutionDate = DateTime.Now;
//                    responseProcedimento.ResponseType = ResponseType.Success;
//                    responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.InseridoComSucesso,
//                                                                                          nameof(Procedimentos),
//                                                                                          Constantes.MensagemProcedimentosInseridosComSucesso));
//                    return responseProcedimento;
//                }
//                else
//                {
//                    responseProcedimento.ExecutionDate = DateTime.Now;
//                    responseProcedimento.ResponseType = ResponseType.Error;
//                    responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoInserir,
//                                                                                nameof(Procedimentos),
//                                                                                Constantes.MensagemProcedimentoNaoInserida));
//                    return responseProcedimento;
//                }
//            //}
//            //else
//            //{
//            //    responseProcedimento.ExecutionDate = DateTime.Now;
//            //    responseProcedimento.ResponseType = ResponseType.Error;
//            //    responseProcedimento.Message = errors;
//            //    return responseProcedimento;
//            //}
//        }
//    }
//}
