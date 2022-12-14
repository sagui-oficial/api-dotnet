using Sagui.Base.Utils;
using Sagui.Business.Validador.Procedimentos;
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
    public class DeletarUsuarioFuncionarioRequestHandler : IBaseRequestHandler<RequestUsuarioFuncionario, ResponseUsuarioFuncionario>
    {
        UsuarioFuncionarioService usuarioService;
        private Business.Validador.Usuario.ValidatorUsuarioBase validatorUsuario { get; set; }

        ResponseUsuarioFuncionario responseUsuario;

        public DeletarUsuarioFuncionarioRequestHandler(UsuarioFuncionarioService _usuarioService)
        {
            usuarioService = _usuarioService;
            validatorUsuario = new Business.Validador.Usuario.ValidatorUsuarioBase();
            responseUsuario = new ResponseUsuarioFuncionario();
        }

        public async Task<ResponseUsuarioFuncionario> Handle(RequestUsuarioFuncionario Usuario)
        {
            var errors = validatorUsuario.Validate(Usuario);

            if (errors.Count() == 0)
            {
                var _Usuario = usuarioService.Deletar(Usuario);

                if (_Usuario.PublicID != null)
                {
                    responseUsuario.Funcionario = _Usuario;
                    responseUsuario.ExecutionDate = DateTime.Now;
                    responseUsuario.ResponseType = ResponseType.Success;
                    responseUsuario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.DeletadaComSucesso, nameof(responseUsuario.Funcionario),
                                 String.Format(Constantes.MensagemDeletada, nameof(responseUsuario.Funcionario))));
                    return responseUsuario;
                }
                else
                {
                    responseUsuario.ExecutionDate = DateTime.Now;
                    responseUsuario.ResponseType = ResponseType.Error;
                    responseUsuario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoDeletada, nameof(responseUsuario.Funcionario),
                     String.Format(Constantes.MensagemNaoDeletada, nameof(responseUsuario.Funcionario))));
                    return responseUsuario;
                }
            }
            else
            {
                responseUsuario.ExecutionDate = DateTime.Now;
                responseUsuario.ResponseType = ResponseType.Error;
                responseUsuario.Message = errors;
                return responseUsuario;
            }
        }
    }
}
