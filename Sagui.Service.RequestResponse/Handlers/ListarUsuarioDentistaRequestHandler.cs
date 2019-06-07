using Sagui.Base.Utils;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Service.Usuario;
using System;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ListarUsuarioDentistaRequestHandler : IBaseRequestHandler<RequestUsuarioDentista, ResponseUsuarioDentista>
    {
        UsuarioDentistaService usuarioFuncionarioService;
        private Business.Validador.Usuario.ValidatorUsuarioBase validatorUsuarioFuncionario { get; set; }
        ResponseUsuarioDentista responseUsuarioFuncionario;

        public ListarUsuarioDentistaRequestHandler(UsuarioDentistaService _usuarioService)
        {
            usuarioFuncionarioService = _usuarioService;
            validatorUsuarioFuncionario = new Business.Validador.Usuario.ValidatorUsuarioBase();
            responseUsuarioFuncionario = new ResponseUsuarioDentista();
        }
              

        public async Task<ResponseUsuarioDentista> Handle(RequestUsuarioDentista request)
        {
            var ListUsuarioFuncionario = usuarioFuncionarioService.Listar();

            if (ListUsuarioFuncionario.Count > 0)
            {
                responseUsuarioFuncionario.Dentinstas = ListUsuarioFuncionario;
                responseUsuarioFuncionario.ExecutionDate = DateTime.Now;
                responseUsuarioFuncionario.ResponseType = ResponseType.Success;
                
                responseUsuarioFuncionario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(responseUsuarioFuncionario.Dentinsta),
                       String.Format(Constantes.MensagemListadaComSucesso, nameof(responseUsuarioFuncionario.Dentinsta))));


                return responseUsuarioFuncionario;
            }
            else
            {
                responseUsuarioFuncionario.ExecutionDate = DateTime.Now;
                responseUsuarioFuncionario.ResponseType = ResponseType.Info;
                
                responseUsuarioFuncionario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(responseUsuarioFuncionario.Dentinsta),
                       String.Format(Constantes.MensagemNaoListada, nameof(responseUsuarioFuncionario.Dentinsta))));

                return responseUsuarioFuncionario;
            }
        }
    }
}
