using Sagui.Base.Utils;
using Sagui.Service.Contracts;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Service.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ListarUsuarioFuncionarioRequestHandler : IBaseRequestHandler<RequestUsuarioFuncionario, ResponseUsuarioFuncionario>
    {
        UsuarioFuncionarioService usuarioFuncionarioService;
        private Business.Validador.Usuario.ValidatorUsuarioBase validatorUsuarioFuncionario { get; set; }
        ResponseUsuarioFuncionario responseUsuarioFuncionario;

        public ListarUsuarioFuncionarioRequestHandler(UsuarioFuncionarioService _usuarioService)
        {
            usuarioFuncionarioService = _usuarioService;
            validatorUsuarioFuncionario = new Business.Validador.Usuario.ValidatorUsuarioBase();
            responseUsuarioFuncionario = new ResponseUsuarioFuncionario();
        }

       

        public async Task<ResponseUsuarioFuncionario> Handle(RequestUsuarioFuncionario request)
        {
            var ListUsuarioFuncionario = usuarioFuncionarioService.Listar();

            if (ListUsuarioFuncionario.Count > 0)
            {
                responseUsuarioFuncionario.Funcionarios = ListUsuarioFuncionario;
                responseUsuarioFuncionario.ExecutionDate = DateTime.Now;
                responseUsuarioFuncionario.ResponseType = ResponseType.Success;
                responseUsuarioFuncionario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(GTO), Constantes.MensagemGTOListadaComSucesso));
                return responseUsuarioFuncionario;
            }
            else
            {
                responseUsuarioFuncionario.ExecutionDate = DateTime.Now;
                responseUsuarioFuncionario.ResponseType = ResponseType.Info;
                responseUsuarioFuncionario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(GTO), Constantes.MensagemProcedimentoNaoListado));
                return responseUsuarioFuncionario;
            }
        }
    }
}
