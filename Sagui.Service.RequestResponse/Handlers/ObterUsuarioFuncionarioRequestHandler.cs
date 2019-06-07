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
    public class ObterUsuarioFuncionarioRequestHandler : IBaseRequestHandler<RequestUsuarioFuncionario, ResponseUsuarioFuncionario>
    {
        UsuarioFuncionarioService UsuarioFuncionarioService;
        private Business.Validador.Procedimentos.ValidatorProcedimento ValidatorProcedimento { get; set; }

        ResponseUsuarioFuncionario responseUsuarioFuncionario;

        public ObterUsuarioFuncionarioRequestHandler(UsuarioFuncionarioService _ProcedimentoService)
        {
            UsuarioFuncionarioService = _ProcedimentoService;
            ValidatorProcedimento = new Business.Validador.Procedimentos.ValidatorProcedimento();
            responseUsuarioFuncionario = new ResponseUsuarioFuncionario();
        }

        public async Task<ResponseUsuarioFuncionario> Handle(RequestUsuarioFuncionario request)
        {
            var usuario = UsuarioFuncionarioService.Obter(request);

            if (usuario != null)
            {
                responseUsuarioFuncionario.Funcionario = usuario;
                responseUsuarioFuncionario.ExecutionDate = DateTime.Now;
                responseUsuarioFuncionario.ResponseType = ResponseType.Success;
                
                responseUsuarioFuncionario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ObterComSucesso, nameof(responseUsuarioFuncionario.Funcionario),
                        String.Format(Constantes.MensagemObtidacomSucesso, nameof(responseUsuarioFuncionario.Funcionario))));

                return responseUsuarioFuncionario;
            }
            else
            {
                responseUsuarioFuncionario.ExecutionDate = DateTime.Now;
                responseUsuarioFuncionario.ResponseType = ResponseType.Error;
                

                responseUsuarioFuncionario.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoObter, nameof(responseUsuarioFuncionario.Funcionario),
                        String.Format(Constantes.MensagemNaoObtidacomSucesso, nameof(responseUsuarioFuncionario.Funcionario))));

                return responseUsuarioFuncionario;
            }
        }
    }
}
