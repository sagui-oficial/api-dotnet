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
    public class DeletarPlanoOperadoraRequestHandler : IBaseRequestHandler<RequestPlanoOperadora, ResponsePlanoOperadora>
    {
        PlanoOperadoraService planoOperadoraService;
        private Business.Validador.PlanoOperadora.ValidadorPlanoOperadora validatorPlanoOperadora{ get; set; }

        ResponsePlanoOperadora responsePlanoOperadora;

        public DeletarPlanoOperadoraRequestHandler(PlanoOperadoraService _planoOperadoraService)
        {
            planoOperadoraService = _planoOperadoraService;
            validatorPlanoOperadora = new Business.Validador.PlanoOperadora.ValidadorPlanoOperadora();
            responsePlanoOperadora = new ResponsePlanoOperadora();
        }

        public async Task<ResponsePlanoOperadora> Handle(RequestPlanoOperadora PlanoOperadoras)
        {
            //var errors = ValidatorPlanoOperadora.Validate(PlanoOperadoras);

            //if (errors.Count() == 0)
            //{
                var _PlanoOperadora = planoOperadoraService.Deletar(PlanoOperadoras);

                if (_PlanoOperadora != null)
                {
                    responsePlanoOperadora.PlanoOperadora = _PlanoOperadora;
                    responsePlanoOperadora.ExecutionDate = DateTime.Now;
                    responsePlanoOperadora.ResponseType = ResponseType.Success;

                responsePlanoOperadora.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.DeletadaComSucesso, nameof(responsePlanoOperadora.PlanoOperadora),
                                  String.Format(Constantes.MensagemDeletada, nameof(responsePlanoOperadora.PlanoOperadora))));

            
                    return responsePlanoOperadora;
                }
                else
                {
                    responsePlanoOperadora.ExecutionDate = DateTime.Now;
                    responsePlanoOperadora.ResponseType = ResponseType.Error;
                responsePlanoOperadora.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoDeletada, nameof(responsePlanoOperadora.PlanoOperadora),
                                 String.Format(Constantes.MensagemNaoDeletada, nameof(responsePlanoOperadora.PlanoOperadora))));

                
                    return responsePlanoOperadora;
                }
            //}
            //else
            //{
            //    responsePlanoOperadora.ExecutionDate = DateTime.Now;
            //    responsePlanoOperadora.ResponseType = ResponseType.Error;
            //    responsePlanoOperadora.Message = errors;
            //    return responsePlanoOperadora;
            //}
        }
    }
}
