﻿using Sagui.Base.Utils;
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
    public class CriarUsuarioRequestHandler : IBaseRequestHandler<RequestUsuario, ResponseUsuario>
    {
        private UsuarioService usuarioService;
        private Business.Validador.Usuario.ValidatorUsuario ValidatorUsuario;

        ResponseUsuario responseUsuario;

        public CriarUsuarioRequestHandler(UsuarioService _UsuarioService)
        {
            usuarioService = _UsuarioService;
            ValidatorUsuario = new Business.Validador.Usuario.ValidatorUsuario();
            responseUsuario = new ResponseUsuario();
        }

        public async Task<ResponseUsuario> Handle(RequestUsuario Usuario)
        {
            var errors = ValidatorUsuario.Validate(Usuario);

            if (errors.Count() == 0)
            {
                var _Usuario = usuarioService.Cadastrar(Usuario);

                if (_Usuario.Id != 0)
                {
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
                responseUsuario.ExecutionDate = DateTime.Now;
                responseUsuario.ResponseType = ResponseType.Error;
                responseUsuario.Message = errors;
                return responseUsuario;
            }
        }
    }
}
