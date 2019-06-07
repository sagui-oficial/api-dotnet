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
    public class AtualizarUsuarioPacienteRequestHandler : IBaseRequestHandler<RequestUsuarioPaciente, ResponseUsuarioPaciente>
    {
        UsuarioPacienteService usuarioService;
        private Business.Validador.Usuario.ValidatorUsuarioBase validatorUsuario { get; set; }

        ResponseUsuarioPaciente responseUsuario;

        public AtualizarUsuarioPacienteRequestHandler(UsuarioPacienteService _usuarioService)
        {
            usuarioService = _usuarioService;
            validatorUsuario = new Business.Validador.Usuario.ValidatorUsuarioBase();
            responseUsuario = new ResponseUsuarioPaciente();
        }

        public async Task<ResponseUsuarioPaciente> Handle(RequestUsuarioPaciente Usuario)
        {
            var errors = validatorUsuario.Validate(Usuario);

            if (errors.Count() == 0)
            {
                var _Usuario = usuarioService.Atualizar(Usuario);

                if (_Usuario != null)
                {
                    responseUsuario.Paciente = _Usuario;
                    responseUsuario.ExecutionDate = DateTime.Now;
                    responseUsuario.ResponseType = ResponseType.Success;
                    responseUsuario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.AtualizadoComSucesso, nameof(responseUsuario.Paciente),
                                                               String.Format(Constantes.MensagemAtualizada, nameof(responseUsuario.Paciente))));
                    return responseUsuario;
                }
                else
                {
                    responseUsuario.ExecutionDate = DateTime.Now;
                    responseUsuario.ResponseType = ResponseType.Error;
                    responseUsuario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoAtualizar, nameof(responseUsuario.Paciente),
                                                               String.Format(Constantes.MensagemNaoAtualizado, nameof(responseUsuario.Paciente))));

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
