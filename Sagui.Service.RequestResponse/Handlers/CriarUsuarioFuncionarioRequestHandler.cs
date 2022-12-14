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
    public class CriarUsuarioFuncionarioRequestHandler : IBaseRequestHandler<RequestUsuarioFuncionario, ResponseUsuarioFuncionario>
    {
        private UsuarioFuncionarioService usuarioService;
        private Business.Validador.Usuario.ValidatorUsuarioBase ValidatorUsuarioBase;

        ResponseUsuarioFuncionario responseUsuario;

        public CriarUsuarioFuncionarioRequestHandler(UsuarioFuncionarioService _UsuarioService)
        {
            usuarioService = _UsuarioService;
            ValidatorUsuarioBase = new Business.Validador.Usuario.ValidatorUsuarioBase();
            responseUsuario = new ResponseUsuarioFuncionario();
        }

        public async Task<ResponseUsuarioFuncionario> Handle(RequestUsuarioFuncionario Usuario)
        {
            var errors = ValidatorUsuarioBase.Validate(Usuario);

            if (errors.Count() == 0)
            {
                var _Usuario = usuarioService.Cadastrar(Usuario);

                if (_Usuario.Id != 0)
                {
                    responseUsuario.Funcionario = _Usuario;
                    responseUsuario.ExecutionDate = DateTime.Now;
                    responseUsuario.ResponseType = ResponseType.Success;
                  

                    responseUsuario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.InseridoComSucesso, nameof(responseUsuario.Funcionario),
                                                         String.Format(Constantes.MensagemInseridaComSucesso, nameof(responseUsuario.Funcionario))));

                    return responseUsuario;
                }
                else
                {
                    responseUsuario.ExecutionDate = DateTime.Now;
                    responseUsuario.ResponseType = ResponseType.Info;
                   

                    responseUsuario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoInserir, nameof(responseUsuario.Funcionario),
                                                         String.Format(Constantes.MensagemNaoInserida, nameof(responseUsuario.Funcionario))));

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