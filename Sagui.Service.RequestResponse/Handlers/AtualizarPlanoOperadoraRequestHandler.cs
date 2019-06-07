using Sagui.Base.Utils;
using Sagui.Business.Validador.PlanoOperadora;
using Sagui.Service.Contracts;
using Sagui.Service.PlanoOperadora;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class AtualizarPlanoOperadoraRequestHandler : IBaseRequestHandler<RequestPlanoOperadora, ResponsePlanoOperadora>
    {
        PlanoOperadoraService planoOperadoraService;
        private Business.Validador.PlanoOperadora.ValidadorPlanoOperadora validatorPlanoOperadora { get; set; }

        ResponsePlanoOperadora responsePlanoOperadora;

        public AtualizarPlanoOperadoraRequestHandler(PlanoOperadoraService _planoOperadoraService)
        {
            planoOperadoraService = _planoOperadoraService;
            validatorPlanoOperadora = new Business.Validador.PlanoOperadora.ValidadorPlanoOperadora();
            responsePlanoOperadora = new ResponsePlanoOperadora();
        }

        public async Task<ResponsePlanoOperadora> Handle(RequestPlanoOperadora PlanoOperadoras)
        {
            var errors = validatorPlanoOperadora.Validate(PlanoOperadoras);

            if (errors.Count() == 0)
            {
                var _PlanoOperadora = planoOperadoraService.Atualizar(PlanoOperadoras);

                if (_PlanoOperadora.Id != 0)
                {
                    responsePlanoOperadora.PlanoOperadora = _PlanoOperadora;
                    responsePlanoOperadora.ExecutionDate = DateTime.Now;
                    responsePlanoOperadora.ResponseType = ResponseType.Success;
               

                    responsePlanoOperadora.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.AtualizadoComSucesso, nameof(responsePlanoOperadora.PlanoOperadora),
                                                                        String.Format(Constantes.MensagemListadaComSucesso, nameof(responsePlanoOperadora.PlanoOperadora))));

                    return responsePlanoOperadora;
                }
                else
                {
                    responsePlanoOperadora.ExecutionDate = DateTime.Now;
                    responsePlanoOperadora.ResponseType = ResponseType.Error;
               

                    responsePlanoOperadora.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoAtualizar, nameof(responsePlanoOperadora.PlanoOperadora),
                                                                        String.Format(Constantes.MensagemNaoAtualizado, nameof(responsePlanoOperadora.PlanoOperadora))));

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
