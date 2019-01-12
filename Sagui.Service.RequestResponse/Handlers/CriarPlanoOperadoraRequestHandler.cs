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
    public class CriarPlanoOperadoraRequestHandler : IBaseRequestHandler<RequestPlanoOperadora, ResponsePlanoOperadora>
    {
        PlanoOperadoraService planoOperadoraService;
        private Business.Validador.PlanoOperadora.ValidadorPlanoOperadora ValidadorPlanoOperadora { get; set; }

        ResponsePlanoOperadora responsePlanoOperadora;

        public CriarPlanoOperadoraRequestHandler(PlanoOperadoraService _planoOperadoraService)
        {
            planoOperadoraService = _planoOperadoraService;
            ValidadorPlanoOperadora = new Business.Validador.PlanoOperadora.ValidadorPlanoOperadora();
            responsePlanoOperadora = new ResponsePlanoOperadora();
        }

        public async Task<ResponsePlanoOperadora> Handle(RequestPlanoOperadora PlanoOperadora)
        {
            var errors = ValidadorPlanoOperadora.Validate(PlanoOperadora);

            if (errors.Count() == 0)
            {
                var _PlanoOperadora = planoOperadoraService.Cadastrar(PlanoOperadora);

                if (_PlanoOperadora.Id != 0)
                {
                    responsePlanoOperadora.PlanoOperadora = _PlanoOperadora;
                    responsePlanoOperadora.ExecutionDate = DateTime.Now;
                    responsePlanoOperadora.ResponseType = ResponseType.Success;
                    responsePlanoOperadora.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.InseridoComSucesso,
                                                                                          nameof(PlanoOperadora),
                                                                                          Constantes.MensagemProcedimentosInseridosComSucesso));
                    return responsePlanoOperadora;
                }
                else
                {
                    responsePlanoOperadora.ExecutionDate = DateTime.Now;
                    responsePlanoOperadora.ResponseType = ResponseType.Error;
                    responsePlanoOperadora.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoInserir,
                                                                                nameof(PlanoOperadora),
                                                                                Constantes.MensagemProcedimentoNaoInserida));
                    return responsePlanoOperadora;
                }
            }
            else
            {
                responsePlanoOperadora.ExecutionDate = DateTime.Now;
                responsePlanoOperadora.ResponseType = ResponseType.Error;
                responsePlanoOperadora.Message = errors;
                return responsePlanoOperadora;
            }
        }
    }
}
