using Sagui.Base.Utils;
using Sagui.Service.Contracts;
using Sagui.Service.Usuario;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ObterUsuarioDentistaRequestHandler : IBaseRequestHandler<RequestUsuarioDentista, ResponseUsuarioDentista>
    {
        UsuarioDentistaService UsuarioDentistaService;
        private Business.Validador.Procedimentos.ValidatorProcedimento ValidatorProcedimento { get; set; }

        ResponseUsuarioDentista responseUsuarioDentista;

        public ObterUsuarioDentistaRequestHandler(UsuarioDentistaService _ProcedimentoService)
        {
            UsuarioDentistaService = _ProcedimentoService;
            ValidatorProcedimento = new Business.Validador.Procedimentos.ValidatorProcedimento();
            responseUsuarioDentista = new ResponseUsuarioDentista();
        }

        public async Task<ResponseUsuarioDentista> Handle(RequestUsuarioDentista request)
        {
            var usuario = UsuarioDentistaService.Obter(request);

            if (usuario != null)
            {
                responseUsuarioDentista.Dentinsta = usuario;
                responseUsuarioDentista.ExecutionDate = DateTime.Now;
                responseUsuarioDentista.ResponseType = ResponseType.Success;
                responseUsuarioDentista.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(GTO), Constantes.MensagemGTOObtidacomSucesso));
                return responseUsuarioDentista;
            }
            else
            {
                responseUsuarioDentista.ExecutionDate = DateTime.Now;
                responseUsuarioDentista.ResponseType = ResponseType.Error;
                responseUsuarioDentista.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(GTO), Constantes.MensagemGTONaoObtidacomSucesso));
                return responseUsuarioDentista;
            }
        }
    }
}
