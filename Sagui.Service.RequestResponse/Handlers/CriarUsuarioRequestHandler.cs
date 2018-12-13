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
    public class CriarUsuarioRequestHandler : BaseRequestHandler<RequestUsuario, ResponseUsuario>
    {
        private IUsuarioService IUsuarioService { get; set; }
        private Business.Validador.Usuario.ValidatorUsuario ValidatorUsuario { get; set; }

        public CriarUsuarioRequestHandler(IUsuarioService _IUsuarioService)
        {
            IUsuarioService = _IUsuarioService;
            ValidatorUsuario = new Business.Validador.Usuario.ValidatorUsuario();
        }

        public ResponseUsuario Cadastrar(Model.Usuario Usuario)
        {
            var errors = ValidatorUsuario.Validate(Usuario);

            if (errors.Count() == 0)
            {
                var _Usuario = IUsuarioService.Cadastrar(Usuario);

                if (_Usuario.Id != 0)
                {
                    ResponseUsuario responseUsuario = new ResponseUsuario();
                    responseUsuario.Usuario = _Usuario;
                    responseUsuario.ExecutionDate = DateTime.Now;
                    responseUsuario.ResponseType = ResponseType.Success;
                    responseUsuario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.InseridoComSucesso, 
                                                                                          nameof(Usuario), 
                                                                                          Constantes.MensagemUsuarioInseridosComSucesso));
                    return responseUsuario;
                }
                else
                {
                    ResponseUsuario responseUsuario = new ResponseUsuario();
                    responseUsuario.ExecutionDate = DateTime.Now;
                    responseUsuario.ResponseType = ResponseType.Info;
                    responseUsuario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoInserir, 
                                                                                nameof(Usuario), 
                                                                                Constantes.MensagemUsuarioNaoInserido));
                    return responseUsuario;
                }
            }
            else
            {
                ResponseUsuario responseUsuario = new ResponseUsuario();
                responseUsuario.ExecutionDate = DateTime.Now;
                responseUsuario.ResponseType = ResponseType.Error;
                responseUsuario.Message = errors;
                return responseUsuario;
            }
        }
    }
}
