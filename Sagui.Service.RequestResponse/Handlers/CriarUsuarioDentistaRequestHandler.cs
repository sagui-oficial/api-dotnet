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
    public class CriarUsuarioDentistaRequestHandler : IBaseRequestHandler<RequestUsuarioDentista, ResponseUsuarioDentista>
    {
        private UsuarioDentistaService usuarioService;
        private Business.Validador.Usuario.ValidatorUsuarioDentista ValidatorUsuario;
        private Business.Validador.Usuario.ValidatorUsuarioBase ValidatorUsuarioBase;

        ResponseUsuarioDentista responseUsuario;

        public CriarUsuarioDentistaRequestHandler(UsuarioDentistaService _UsuarioService)
        {
            usuarioService = _UsuarioService;
            ValidatorUsuario = new Business.Validador.Usuario.ValidatorUsuarioDentista();
            ValidatorUsuarioBase = new Business.Validador.Usuario.ValidatorUsuarioBase();
            responseUsuario = new ResponseUsuarioDentista();
        }

        public async Task<ResponseUsuarioDentista> Handle(RequestUsuarioDentista Usuario)
        {
            var errors = ValidatorUsuarioBase.Validate(Usuario);
            errors = ValidatorUsuario.Validate(Usuario);

            if (errors.Count() == 0)
            {
                var _Usuario = usuarioService.Cadastrar(Usuario);

                if (_Usuario.Id != 0)
                {
                    responseUsuario.Dentinsta = _Usuario;
                    responseUsuario.ExecutionDate = DateTime.Now;
                    responseUsuario.ResponseType = ResponseType.Success;

                    responseUsuario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.InseridoComSucesso, nameof(responseUsuario.Dentinsta),
                                                         String.Format(Constantes.MensagemInseridaComSucesso, nameof(responseUsuario.Dentinsta))));

                    
                    return responseUsuario;
                }
                else
                {
                    responseUsuario.ExecutionDate = DateTime.Now;
                    responseUsuario.ResponseType = ResponseType.Info;
                    responseUsuario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoInserir, nameof(responseUsuario.Dentinsta),
                                                          String.Format(Constantes.MensagemNaoInserida, nameof(responseUsuario.Dentinsta))));

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

