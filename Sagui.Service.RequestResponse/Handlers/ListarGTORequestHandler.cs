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
    public class ListarGTORequestHandler : BaseRequestHandler<RequestGTO, ResponseGTO>
    {
        private IGTOService IGTOService { get; set; }
        private Business.Validador.GTO.ValidadorGTO validadorGTO { get; set; }

        public ListarGTORequestHandler(IGTOService iGTOService)
        {
            IGTOService = iGTOService;
            validadorGTO = new Business.Validador.GTO.ValidadorGTO();
        }


        public ResponseGTO Listar()
        {
            var ListGTO = IGTOService.ListGTOs();

            if (ListGTO.Count > 0)
            {
                ResponseGTO responseGTO = new ResponseGTO();
                responseGTO.GTOs = ListGTO;
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Success;
                responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(GTO), Constantes.MensagemGTOListadaComSucesso));
                return responseGTO;
            }
            else
            {
                ResponseGTO responseGTO = new ResponseGTO();
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Error;
                responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(GTO), Constantes.MensagemGTONaoListada));
                return responseGTO;
            }
        }
    }
}
