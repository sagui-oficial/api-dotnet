using Sagui.Base.Utils;
using Sagui.Service.Contracts;
using Sagui.Service.GTO;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class AtualizarGTORequestHandler : IBaseRequestHandler<RequestGTO, ResponseGTO>
    {
        private GTOService GTOService;

        private Business.Validador.GTO.ValidadorGTO validadorGTO { get; set; }

        ResponseGTO responseGTO;

        public AtualizarGTORequestHandler(GTOService _GTOService)
        {
            GTOService = _GTOService;
            validadorGTO = new Business.Validador.GTO.ValidadorGTO();
            responseGTO = new ResponseGTO();
        }

        public async Task<ResponseGTO> Handle(RequestGTO GTO)
        {
            var errors = validadorGTO.Validate(GTO);

            if (errors.Count() == 0)
            {
                var _GTO = GTOService.Atualizar(GTO);

                if (_GTO != null)
                {
                    responseGTO.GTO = _GTO;
                    responseGTO.ExecutionDate = DateTime.Now;
                    responseGTO.ResponseType = ResponseType.Success;
                 
                    responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.AtualizadoComSucesso, nameof(responseGTO.GTO),
                                                                            String.Format(Constantes.MensagemListadaComSucesso, nameof(responseGTO.GTO))));

                    return responseGTO;
                }
                else
                {
                    responseGTO.ExecutionDate = DateTime.Now;
                    responseGTO.ResponseType = ResponseType.Error;
                 

                    responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoAtualizar, nameof(responseGTO.GTO),
                                                                            String.Format(Constantes.MensagemNaoAtualizado, nameof(responseGTO.GTO))));

                    return responseGTO;
                }
            }
            else
            {
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Info;
                responseGTO.Message = errors;
                return responseGTO;
            }
        }
    }
}
