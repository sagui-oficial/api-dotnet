using Sagui.Base.Utils;
using Sagui.Service.Contracts;
using Sagui.Service.GTO;
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
    public class CriarUsuarioPacienteRequestHandler : IBaseRequestHandler<RequestUsuarioPaciente, ResponseUsuarioPaciente>
    {
        private UsuarioPacienteService usuarioService;
        private Business.Validador.Usuario.ValidatorUsuarioBase ValidatorUsuarioBase;
        private Business.Validador.Usuario.ValidatorUsuarioPaciente ValidatorUsuarioPaciente;

        ResponseUsuarioPaciente responseUsuario;

        public CriarUsuarioPacienteRequestHandler(UsuarioPacienteService _UsuarioService)
        {
            usuarioService = _UsuarioService;
            ValidatorUsuarioBase = new Business.Validador.Usuario.ValidatorUsuarioBase();
            ValidatorUsuarioPaciente = new Business.Validador.Usuario.ValidatorUsuarioPaciente();
            responseUsuario = new ResponseUsuarioPaciente();
        }

        public async Task<ResponseUsuarioPaciente> Handle(RequestUsuarioPaciente Usuario)
        {
            var errors = ValidatorUsuarioBase.Validate(Usuario);
             errors = ValidatorUsuarioPaciente.Validate(Usuario);

            if (errors.Count() == 0)
            {
                var _Usuario = usuarioService.Cadastrar(Usuario);

                if (_Usuario.Id != 0)
                {
                    responseUsuario.Paciente = Usuario;
                    responseUsuario.ExecutionDate = DateTime.Now;
                    responseUsuario.ResponseType = ResponseType.Success;
                   

                    responseUsuario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.InseridoComSucesso, nameof(responseUsuario.Paciente),
                                                         String.Format(Constantes.MensagemInseridaComSucesso, nameof(responseUsuario.Paciente))));
                    return responseUsuario;
                }
                else
                {
                    responseUsuario.ExecutionDate = DateTime.Now;
                    responseUsuario.ResponseType = ResponseType.Info;
                

                    responseUsuario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoInserir, nameof(responseUsuario.Paciente),
                                                         String.Format(Constantes.MensagemNaoInserida, nameof(responseUsuario.Paciente))));
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
