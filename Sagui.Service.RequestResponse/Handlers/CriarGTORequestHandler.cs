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
    public class CriarGTORequestHandler : BaseRequestHandler<RequestGTO, ResponseGTO>
    {
        private IGTOService IGTOService { get; set; }
        private Business.Validador.GTO.ValidadorGTO validadorGTO { get; set; }

        public CriarGTORequestHandler(IGTOService iGTOService)
        {
            IGTOService = iGTOService;
            validadorGTO = new Business.Validador.GTO.ValidadorGTO();
        }

        public ResponseGTO Cadastrar(Model.GTO GTO)
        {
            var errors = validadorGTO.Validate(GTO);

            if (errors.Count() == 0)
            {
                var _GTO = IGTOService.Cadastrar(GTO);

                if (_GTO.Id > 0)
                {
                    ResponseGTO responseGTO = new ResponseGTO();
                    responseGTO.ExecutionDate = DateTime.Now;
                    responseGTO.ResponseType = ResponseType.Success;
                    responseGTO.Message = new List<Tuple<dynamic, dynamic, dynamic>>();
                    responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.InseridoComSucesso, nameof(GTO), Constantes.MensagemGTOInseridaComSucesso));
                    return responseGTO;
                }
                else
                {
                    ResponseGTO responseGTO = new ResponseGTO();
                    responseGTO.ExecutionDate = DateTime.Now;
                    responseGTO.ResponseType = ResponseType.Error;
                    responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoInserir, nameof(GTO), Constantes.MensagemGTONaoInserida));
                    return responseGTO;
                }
            }
            else
            {
                ResponseGTO responseGTO = new ResponseGTO();
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Error;
                responseGTO.Message = errors;
                return responseGTO;
            }
        }
    }
}
